using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.TextEditor.Document;
using JetBrains.Annotations;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    /// <summary>
    ///     Contains generic methods to Write resources from IResourceBlocks and
    ///     update the internal resource values accordingly.
    /// </summary>
    public static class ResourceLinker
    {
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

        /// <summary>
        ///     Writes the <see cref="GuerillaBlock" /> resource object to the given stream
        ///     and updates the resource length, position, and
        ///     <see cref="IResourceDescriptor{T}" />'s in the given <see cref="T" />
        ///     block.
        /// </summary>
        /// <typeparam name="T">
        ///     A <see cref="GuerillaBlock" /> object that implements
        ///     <see cref="IResourceBlock{T}" />,
        ///     <see cref="IResourceDescriptor{T}" />
        /// </typeparam>
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

        /// <summary>
        ///     Writes the byte[] resource to the given stream and updates the
        ///     resource length and pointer member data.
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
                var offset = BaseStream.Position;

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

        private class ResourceWriter : QueueableBlamBinaryWriter
        {
            public ResourceWriter(Stream output, int serializedSize) : base(output, serializedSize)
            {
                ResourceDescriptors = new List<GlobalGeometryBlockResourceBlock>();
            }

            public List<GlobalGeometryBlockResourceBlock> ResourceDescriptors { get; }

            /// <summary>Commits the deffered writes to the stream.</summary>
            /// <exception cref="IOException">Wrote more/less data than expected.</exception>
            /// <exception cref="System.IO.IOException">Attempted to write over existing data.</exception>
            public override void Commit()
            {
                Defer(TagClass.Blkf);
                base.Commit();
            }

            public override void Defer(byte[] data, int alignment = 4)
            {
                if (data.Length > 0)
                    Defer(TagClass.Rsrc);

                base.Defer(data, alignment);
            }

            /// <summary>
            ///     Defers the specified data to be written after the current write
            ///     allocation.
            /// </summary>
            /// <param name="data">The data.</param>
            /// <param name="alignment"></param>
            public override void Defer(short[] data, int alignment = 4)
            {
                if (data.Length > 0)
                    Defer(TagClass.Rsrc);

                base.Defer(data);
            }

            /// <summary>
            ///     Defers writing the specified <see cref="GuerillaBlock" /> array until
            ///     after the current allocation.
            /// </summary>
            /// <param name="blocks">The <see cref="GuerillaBlock" /> array.</param>
            public override void Defer(GuerillaBlock[] blocks)
            {
                if (blocks.Length > 0)
                {
                    Defer(TagClass.Rsrc);
                    base.Defer(blocks);
                }
                var vertexBufferBlocks = blocks as GlobalGeometrySectionVertexBufferBlock[];

                if (vertexBufferBlocks != null)
                    foreach (var guerillaBlock in vertexBufferBlocks)
                    {
                        Defer(guerillaBlock.VertexBuffer.Data);
                    }

            }

            public override void Write(VertexBuffer buffer)
            {
                AddDescriptor(buffer, GetItemPointer(buffer));
                base.Write(buffer);
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

            public override void Write(BlamPointer blamPointer)
            {
                Write(blamPointer.ElementCount);
                Write(0);
            }

            protected override void Defer(GuerillaBlock guerillaBlock)
            {
                Defer(TagClass.Blkh);
                Defer(() =>
                {
                    unsafe
                    {
                        var datalength = QueueAddress - guerillaBlock.SerializedSize - sizeof (TagClass);
                        return datalength;
                    }
                }); //defer the end address (the length of the stream).
                QueueAddress -= 8;
                    //set the address back because we are going to remove the addressing access to these values.
                Defer(() => RemoveAddresses(0, 8));
                base.Defer(guerillaBlock);
            }

            private void RemoveAddresses(int address, int length)
            {
                var wrapper = BaseStream as IStreamAddressWrapper;

                if (wrapper != null)
                {
                    wrapper.RemoveAddresses(address, length);
                }

                else
                    throw new InvalidOperationException(
                        "Attemped to remove address from stream that does not support that.");
            }

            private void Defer(Action action)
            {
                Queue.Enqueue(new StreamManipulatorQueueItem(action));
            }

            private void Defer(Func<int> value)
            {
                var blamPointer = new BlamPointer(1, QueueAddress, sizeof(int));
                var classQueueItem = new ClosureQueueItem(value) { Pointer = blamPointer };
                QueueAddress = blamPointer.EndAddress;
                Queue.Enqueue(classQueueItem);
            }

            private void AddDescriptor([NotNull] object resource, BlamPointer pointerToResource, short position)
            {
                if (resource == null)
                    throw new ArgumentNullException(nameof(resource));
                if (!(resource is GuerillaBlock[]))
                    throw new InvalidOperationException("resource must be an array of  " + nameof(GuerillaBlock));

                var descriptor = new GlobalGeometryBlockResourceBlock
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

                var descriptor = new GlobalGeometryBlockResourceBlock
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

                var descriptor = new GlobalGeometryBlockResourceBlock
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

            private void Clear()
            {
                ResourceDescriptors.Clear();
                Queue.Clear();
            }

            private void Defer(TagClass tagClass)
            {
                var blamPointer = new BlamPointer(1, QueueAddress, 4);
                var classQueueItem = new GenericQueueItem(tagClass) {Pointer = blamPointer};
                QueueAddress = blamPointer.EndAddress;
                Queue.Enqueue(classQueueItem);
            }

            private class StreamManipulatorQueueItem : QueueItem
            {
                private Action Action { get; set; }

                public StreamManipulatorQueueItem(Action action)
                {
                    Action = action;
                }

                /// <summary>Gets or sets the pointer to the allocated space in the stream.</summary>
                /// <value>The pointer to allocated space in the stream.</value>
                public override BlamPointer Pointer { get; set; }

                /// <summary>Gets the reference to the queued data.</summary>
                /// <remarks>This is used as a key to lookup queue items.</remarks>
                /// <value>The reference field.</value>
                public override object ReferenceField => Action;
                public override void Write(QueueableBlamBinaryWriter writer)
                {
                    Action?.Invoke();
                }
            }

            private class ClosureQueueItem : QueueItem
            {
                private Func<int> Value { get; }

                public ClosureQueueItem(Func<int> value)
                {
                    Value = value;
                }

                /// <summary>Gets or sets the pointer to the allocated space in the stream.</summary>
                /// <value>The pointer to allocated space in the stream.</value>
                public override BlamPointer Pointer { get; set; }

                /// <summary>Gets the reference to the queued data.</summary>
                /// <remarks>This is used as a key to lookup queue items.</remarks>
                /// <value>The reference field.</value>
                public override object ReferenceField => Value;

                public override void Write(QueueableBlamBinaryWriter writer)
                {
                    writer.Write(Value?.Invoke() ?? 0);
                }
            }

            private class GenericQueueItem : QueueItem
            {
                public GenericQueueItem(dynamic item)
                {
                    Data = item;
                }

                public dynamic Data { get; set; }

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
                    //TODO maybe remove the dynamic
                    writer.Write(Data);
                }
            }
        }
    }
}