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

            resourceBlock.SetResourceLength((int) length);
            resourceBlock.SetResourcePointer((int) startAddress);
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

            writer.Write(resourceObject);

            List<GlobalGeometryBlockResourceBlock> resourceBlocks = writer.ResourceDescriptors;

            endAddress = output.Position;
            length = endAddress - startAddress;

            block.SetDescriptors(resourceBlocks.ToArray());
            block.SetResourceLength((int) length);
            block.SetResourcePointer((int) startAddress);
        }

        public static TV ReadResource<T, TV>(T block, Func<IResourceBlock, int, Stream> @delegate,
            GlobalGeometryBlockInfoStructBlock blockInfo)
            where T : IResourceBlock<TV>, IResourceDescriptor<GlobalGeometryBlockResourceBlock>
            where TV : GuerillaBlock, new()
        {
            var resource = new TV();
            GlobalGeometryBlockResourceBlock[] resources = block.GetDescriptors();

            var stream = new ResourceStreamWrapper(@delegate(block, 0), blockInfo);

            if (stream.Length != block.GetResourceLength())
                throw new InvalidDataException();

            using (var binaryReader = new ResourceReader(stream, blockInfo))
            {
                resource.Read(binaryReader);
            }

            return resource;
        }

        private class ResourceReader : QueueableBlamBinaryReader
        {
            private readonly GlobalGeometryBlockInfoStructBlock info;

            public ResourceReader(Stream input, GlobalGeometryBlockInfoStructBlock info)
                : base(input, info.SectionDataSize)
            {
                this.info = info;
            }

            public override VertexBuffer ReadVertexBuffer()
            {
                long offset = BaseStream.Position;

                var block = info.Resources.Single(item => item.PrimaryLocator == 56 && item.SecondaryLocator == 32);
                var index = (int) (offset - block.ResourceDataOffset - info.SectionDataSize)/block.SecondaryLocator;

                var vertexBufferInfo =
                    info.Resources.Single(item => item.PrimaryLocator == 56 && item.SecondaryLocator == index);

                var vertexBuffer = base.ReadVertexBuffer();

                //TODO: make this linear
                using (BaseStream.Pin())
                {
                    BaseStream.Position = vertexBufferInfo.ResourceDataOffset + info.SectionDataSize;
                    vertexBuffer.Data = ReadBytes(vertexBufferInfo.ResourceDataSize);
                    var check = ReadTagClass();
                    if (check != TagClass.Rsrc && check != TagClass.Blkf)
                        throw new InvalidDataException("Not a resource!");
                }

                return vertexBuffer;
            }
        }

        private class ResourceWriter : QueueableBlamBinaryWriter, IEnumerable<QueueableBlamBinaryWriter.QueueItem>
        {
            private bool first = true;
            private bool last = true;

            public List<GlobalGeometryBlockResourceBlock> ResourceDescriptors { get; }

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

            /// <summary>
            /// Defers writing the specified <see cref="GuerillaBlock"/> array until after the current allocation.
            /// </summary>
            /// <param name="blocks">The <see cref="GuerillaBlock"/> array.</param>
            public override void Defer(GuerillaBlock[] blocks)
            {
                base.Defer(blocks);
                Defer(TagClass.Rsrc);
            }

            private void Defer(TagClass tagClass)
            {
                var blamPointer = new BlamPointer(1, QueueAddress, 4);
                var classQueueItem = new GenericQueueItem(tagClass) {Pointer = blamPointer};
                QueueAddress = blamPointer.EndAddress;
                Queue.Enqueue(new GenericQueueItem(tagClass));
            }

            /// <summary>
            /// Commits the deffered writes to the stream.
            /// </summary>
            /// <exception cref="IOException">Wrote more/less data than expected.</exception>
            /// <exception cref="System.IO.IOException">Attempted to write over existing data.</exception>
            public override void Commit()
            {
                var firstItem =
                    Queue.First(item => item is GenericQueueItem && item.ReferenceField is TagClass) as GenericQueueItem;
                if (firstItem != null)
                    firstItem.Data = TagClass.Blkh;


                var lastItem =
                    Queue.Last(item => item is GenericQueueItem && item.ReferenceField is TagClass && item != firstItem) as GenericQueueItem;
                if (lastItem != null)
                    lastItem.Data = TagClass.Blkf;

                base.Commit();
            }

            private class GenericQueueItem : QueueItem
            {
                public dynamic Data { get; set; }

                public GenericQueueItem(dynamic item)
                {
                    Data = item;
                }

                /// <summary>Gets or sets the pointer to the allocated space in the stream.</summary>
                /// <value>The pointer to allocated space in the stream.</value>
                public override BlamPointer Pointer { get; set; }

                /// <summary>Gets the reference to the queued data.</summary>
                /// <remarks>This is used as a key to lookup queue items.</remarks>
                /// <value>The reference field.</value>
                public override object ReferenceField
                {
                    get { return Data; }
                }

                public override void Write(QueueableBlamBinaryWriter writer)
                {
                    writer.Write(Data);
                }
            };


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
                    SecondaryLocator = (short) pointerToResource.ElementSize,
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
                    SecondaryLocator = (short) pointerToResource.ElementSize,
                    ResourceDataOffset = pointerToResource.StartAddress,
                    ResourceDataSize = pointerToResource.PointedSize
                };

                ResourceDescriptors.Add(descriptor);
            }

            // ReSharper disable once UnusedParameter.Local
            private void AddDescriptor(VertexBuffer vertexBuffer, BlamPointer pointerToResource)
            {
                var index =
                    (short)
                        ResourceDescriptors.Count(
                            item => item.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer);

                var descriptor = new GlobalGeometryBlockResourceBlock()
                {
                    Type = GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer,
                    PrimaryLocator = index,
                    SecondaryLocator = (short) pointerToResource.ElementSize,
                    ResourceDataOffset = pointerToResource.StartAddress,
                    ResourceDataSize = pointerToResource.PointedSize
                };

                var lastIndex =
                    ResourceDescriptors.FindLastIndex(
                        item =>
                            item.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer ||
                            item.PrimaryLocator == 56);
                ResourceDescriptors.Insert(lastIndex + 1, descriptor);
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
                }

                base.WritePointer(instanceFIeld);
            }

            public override void Write(VertexBuffer buffer)
            {
                Defer(buffer.Data);
                AddDescriptor(buffer, GetItemPointer(buffer));

                base.Write(buffer);
            }
        }
    }
}