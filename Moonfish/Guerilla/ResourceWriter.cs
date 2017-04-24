using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    /// <summary>
    /// Contains generic methods to Write resources from 
    /// IResourceBlocks and update the internal resource values accordingly.
    /// </summary>
    public static class ResourceLinker
    {
        /// <summary>
        /// Writes the byte[] resource to the given stream and updates the resource length and pointer member data.
        /// </summary>
        /// <typeparam name="T">Resource block containing a byte[] resource.</typeparam>
        /// <param name="resourceBlock">The resource block to operate on.</param>
        /// <param name="output">The stream to write the resource byte to.</param>
        /// <param name="index">The index of the resource to operate on.</param>
        public static void WriteResourceBytes<T>(T resourceBlock, Stream output, int index = 0)
            where T : IResourceBlock<byte[]>
        {
            var startAddress = output.Position;
            long endAddress;
            long length;

            byte[] bytes = resourceBlock.GetResource(index);
            if (bytes == null)
            {
                return;
            }
            output.Write(bytes, 0, bytes.Length);
            output.PackLength();

            endAddress = output.Position;
            length = endAddress - startAddress;

            resourceBlock.SetResourceLength((int)length);
            resourceBlock.SetResourcePointer((int)startAddress);
        }

        /// <summary>
        /// Writes the <see cref="GuerillaBlock"/> resource object to the given stream 
        /// and updates the resource length, position, and <see cref="IResourceDescriptor{T}"/>'s 
        /// in the given <see cref="T"/> block.
        /// </summary>
        /// <typeparam name="T">A <see cref="GuerillaBlock"/> object that implements 
        /// <see cref="IResourceBlock{T}"/>, 
        /// <see cref="IResourceDescriptor{T}"/></typeparam>
        /// <param name="block">The object which conatains the resource to write.</param>
        /// <param name="output">The output stream to write the resource to.</param>
        /// <param name="index">The index of the resource to write.</param>
        public static void WriteResource<T>(T block, Stream output, int index = 0)
            where T : GuerillaBlock, IResourceBlock<GuerillaBlock>,
                IResourceDescriptor<GlobalGeometryBlockResourceBlock>
        {
            var startAddress = output.Position;
            long endAddress;
            long length;

            var resourceObject = block.GetResource(index);

            var writer = new ResourceWriter(output, resourceObject.SerializedSize);

            var argList = new List<ResourceWriter.PointerEventArg>();
            var vertexBuffers = new List<ResourceWriter.VertexBufferArg>();

            writer.OnWritePointerEvent += (sender, arg) => { argList.Add(arg); };
            writer.OnVertexBufferWriteEvent += (sender, arg) => { vertexBuffers.Add(arg); };

            resourceObject.QueueWrites(writer);
            resourceObject.Write(writer);
            writer.WriteQueue();

            List<GlobalGeometryBlockResourceBlock> resourceBlocks = writer.ResourceDescriptors;

            endAddress = output.Position;
            length = endAddress - startAddress;

            block.SetDescriptors(resourceBlocks.ToArray());
            block.SetResourceLength((int) length);
            block.SetResourcePointer((int) startAddress);
        }

        public static void ReadResource<T, TV>(T block, Func<IResourceBlock, int, Stream> @delegate) 
            where T : IResourceBlock, IResourceDescriptor<GlobalGeometryBlockResourceBlock>
            where TV: GuerillaBlock, new()
        {
            var resource = new TV();
            GlobalGeometryBlockResourceBlock[] resources = block.GetDescriptors();

            var stream = new ResourceStreamWrapper(@delegate(block, 0), resources, resource.SerializedSize);

            if (stream.Length != block.GetResourceLength())
                throw new InvalidDataException();

            using (var binaryReader = new BlamBinaryReader(stream))
            {
                resource.Read(binaryReader);

                GlobalGeometryBlockResourceBlock[] vertexBufferResources =
                    resources.Where(x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();

                //    for (var i = 0; i < sectionBlock.Section.VertexBuffers.Length && i < vertexBufferResources.Length; ++i)
                //    {
                //        sectionBlock.Section.VertexBuffers[i].VertexBuffer.Data =
                //            stream.GetResourceData(vertexBufferResources[i]);
                //    }
                //}
                //SectionData = new[] { sectionBlock };

            }
        }
        

        private class ResourceWriter : QueueableBlamBinaryWriter, IEnumerable<QueueItem>
        {
            /// <summary>
            /// Event fired before a pointer is written to the output stream.
            /// </summary>
            public event EventHandler<PointerEventArg> OnWritePointerEvent;

            public List<GlobalGeometryBlockResourceBlock> ResourceDescriptors { get; }

            public struct PointerEventArg
            {
                public readonly long Position;
                public readonly BlamPointer Pointer;

                public PointerEventArg(long position, BlamPointer pointer)
                {
                    Position = position;
                    Pointer = pointer;
                }
            }

            public ResourceWriter(Stream output, int serializedSize) : base(output, serializedSize)
            {
                ResourceDescriptors = new List<GlobalGeometryBlockResourceBlock>();
            }

            IEnumerator<QueueItem> IEnumerable<QueueItem>.GetEnumerator()
            {
                return Queue.Cast<QueueItem>().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Queue.GetEnumerator();
            }

            private void Clear()
            {
                ResourceDescriptors.Clear();
            }

            private void AddDescriptor([NotNull] object resource, BlamPointer pointerToResource, short position)
            {
                if (resource == null)
                    throw new ArgumentNullException(nameof(resource));
                if (!(resource is GuerillaBlock[]))
                    throw new InvalidOperationException("resource must be an array of  " + nameof(GuerillaBlock));

                var descriptor = new GlobalGeometryBlockResourceBlock()
                {
                    Type = GlobalGeometryBlockResourceBlock.TypeEnum.TagBlock,
                    PrimaryLocator = position,
                    SecondaryLocator = (short)pointerToResource.ElementSize,
                    ResourceDataOffset = pointerToResource.StartAddress,
                    ResourceDataSize = pointerToResource.PointedSize
                };

                ResourceDescriptors.Add(descriptor);
            }

            private void AddDescriptor([NotNull] byte[] resource, BlamPointer pointerToResource, short position)
            {
                if (resource == null)
                    throw new ArgumentNullException(nameof(resource));

                var descriptor = new GlobalGeometryBlockResourceBlock()
                {
                    Type = GlobalGeometryBlockResourceBlock.TypeEnum.TagData,
                    PrimaryLocator = position,
                    SecondaryLocator = (short)pointerToResource.ElementSize,
                    ResourceDataOffset = pointerToResource.StartAddress,
                    ResourceDataSize = pointerToResource.PointedSize
                };

                ResourceDescriptors.Add(descriptor);
            }

            // ReSharper disable once UnusedParameter.Local
            private void AddDescriptor(VertexBuffer vertexBuffer, BlamPointer pointerToResource)
            {
                var index =
                    (short)ResourceDescriptors.Count(
                        item => item.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer);

                var descriptor = new GlobalGeometryBlockResourceBlock()
                {
                    Type = GlobalGeometryBlockResourceBlock.TypeEnum.TagBlock,
                    PrimaryLocator = index,
                    SecondaryLocator = (short)pointerToResource.ElementSize,
                    ResourceDataOffset = pointerToResource.StartAddress,
                    ResourceDataSize = pointerToResource.PointedSize
                };

                ResourceDescriptors.Add(descriptor);
            }
            
            public override void WritePointer<T>(T instanceFIeld)
            {
                var pointer = GetItemPointer(instanceFIeld);
                var bytes = instanceFIeld as byte[];

                if (!BlamPointer.IsNull(pointer))
                {
                    if (bytes != null)
                    {
                        AddDescriptor(bytes, GetItemPointer(bytes), (short) BaseStream.Position);
                    }
                    else
                    {
                        AddDescriptor(instanceFIeld, GetItemPointer(instanceFIeld), (short) BaseStream.Position);
                    }
                    OnWritePointer(BaseStream.Position, GetItemPointer(instanceFIeld));
                }

                base.WritePointer(instanceFIeld);
            }

            public struct VertexBufferArg
            {
                public VertexBuffer VertexBuffer;
                public BlamPointer Pointer;

                public VertexBufferArg(BlamPointer pointer, VertexBuffer vertexBuffer)
                {
                    Pointer = pointer;
                    VertexBuffer = vertexBuffer;
                }
            };

            public event EventHandler<VertexBufferArg> OnVertexBufferWriteEvent;

            public override void Write(VertexBuffer buffer)
            {
                QueueWrite(buffer.Data);
                AddDescriptor(buffer, GetItemPointer(buffer));

                OnVertexBufferWriteEvent?.Invoke(buffer,
                    new VertexBufferArg(this.Last()?.Pointer ?? BlamPointer.Null, buffer));

                base.Write(buffer);
            }

            private void OnWritePointer(long position, BlamPointer pointer)
            {
                OnWritePointerEvent?.Invoke(this, new PointerEventArg(position, pointer));
            }
        }
    }
}