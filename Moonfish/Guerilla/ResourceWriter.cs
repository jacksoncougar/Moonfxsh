using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    /// <summary>
    /// Writes Blam! resource streams from <see cref="GuerillaBlock"/> objects.
    /// </summary>
    /// <remarks>
    /// (1) This performs gross remapping of all address values by applying an internal offset value to them.
    /// (2) This writes a preceeding four character tag ("rsrc") in front of each GuerillaBlock, byte, or short array.
    /// (3) Appends an 8 byte long head consisting of two values: 
    ///     1. a four character tag ("blkh") and 
    ///     2. an int whose value is the length of the resource data.
    /// (4) Generates a description of where each array was written in the <see cref="ResourceDescriptors"/> property.
    /// (5) Removes the address component from every pointer written to the stream.
    /// (6) Appends a four character tag ("blkf") to the end of the stream.
    /// </remarks>
    /// <seealso cref="Moonfish.Guerilla.QueueableBlamBinaryWriter" />
    public class ResourceWriter : QueueableBlamBinaryWriter
    {
        private const int SectionDataOffset = -8;

        public ResourceWriter(Stream output) : base(output)
        {
            ResourceDescriptors = new List<GlobalGeometryBlockResourceBlock>();
        }

        public List<GlobalGeometryBlockResourceBlock> ResourceDescriptors { get; }

        /// <summary>Commits the deffered writes to the stream.</summary>
        /// <exception cref="IOException">Wrote more/less data than expected.</exception>
        /// <exception cref="System.IO.IOException">Attempted to write over existing data.</exception>
        public override void Commit()
        {
            Defer(TagClass.Blkf, 4);
            base.Commit();
        }

        /// <summary>
        /// Defers the specified data to be written after the current write
        /// allocation.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="alignment"></param>
        public override void Defer(byte[] data, int alignment = 4)
        {
            if (data.Length > 0)
                Defer(TagClass.Rsrc, alignment);

            base.Defer(data, alignment);
        }

        /// <summary>
        /// Reserves space in the stream and then defers writing the specified
        /// <see cref="short" /> array until after <see cref="Commit" /> has been called.
        /// </summary>
        /// <param name="data">The data to defer</param>
        /// <param name="alignment">The alignment in the destination stream the data should
        /// begin on.</param>
        public override void Defer(short[] data, int alignment = 4)
        {
            if (data.Length > 0)
                Defer(TagClass.Rsrc, alignment);

            base.Defer(data);
        }

        /// <summary>
        /// Reserves space in the stream and then defers writing the specified
        /// <see cref="GuerillaBlock" />
        /// array until after <see cref="Commit" /> has been called.
        /// </summary>
        /// <param name="blocks">The <see cref="GuerillaBlock" /> array to defer.</param>
        public override void Defer(GuerillaBlock[] blocks)
        {
            if (blocks.Length > 0)
            {
                Defer(TagClass.Rsrc, 4);
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
        
        public override void Write(BlamPointer blamPointer)
        {
            Write(blamPointer.ElementCount);
            Write(0);
        }
        
        public override void WritePointer<T>(T instanceFIeld)
        {
            var pointer = GetItemPointer(instanceFIeld);
            var bytes = instanceFIeld as byte[];

            if (!BlamPointer.IsNull(pointer))
            {
                if (bytes != null)
                {
                    AddDescriptor(bytes, GetItemPointer(bytes), (short) (BaseStream.Position + SectionDataOffset));
                }
                else
                {
                    AddDescriptor(instanceFIeld, GetItemPointer(instanceFIeld), (short) (BaseStream.Position + SectionDataOffset));
                }
            }

            base.WritePointer(instanceFIeld);
        }

        protected override void Defer(GuerillaBlock guerillaBlock)
        {
            Defer(TagClass.Blkh, 4);
            Defer(() =>
            {
                unsafe
                {
                    var datalength = QueueAddress + SectionDataOffset - guerillaBlock.SerializedSize - sizeof (TagClass);
                    return datalength;
                }
            }); //defer the end address (the length of the stream).
                
            base.Defer(guerillaBlock);
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

        private void Defer(Action action)
        {
            Queue.Enqueue(new StreamManipulatorQueueItem(action));
        }

        private void Defer(Func<int> value)
        {
            var blamPointer = new BlamPointer(1, QueueAddress, sizeof (int));
            var classQueueItem = new ClosureQueueItem(value);
            QueueAddress = blamPointer.EndAddress;
            Queue.Enqueue(classQueueItem);
        }

        private void Defer(TagClass tagClass, int alignment)
        {
            var count = (int)Padding.GetCount(QueueAddress, alignment) - 4;
            count = count < 0 ? alignment + count : count;

            if (count > 0)
            {
                Defer(() =>
                { Write(new byte[count]); });
                QueueAddress += count;
            }

            var blamPointer = new BlamPointer(1, QueueAddress, 4);
            var classQueueItem = new GenericQueueItem(tagClass) {Pointer = blamPointer};
            QueueAddress = blamPointer.EndAddress;
            Queue.Enqueue(classQueueItem);
        }

        private class StreamManipulatorQueueItem : QueueItem
        {
            public StreamManipulatorQueueItem(Action action)
            {
                Action = action;
            }

            private Action Action { get; }

            /// <summary>Gets or sets the pointer to the allocated space in the stream.</summary>
            /// <value>The pointer to allocated space in the stream.</value>
            public override BlamPointer Pointer { get; set; } = BlamPointer.Null;

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
            public ClosureQueueItem(Func<int> value)
            {
                Value = value;
            }

            private Func<int> Value { get; }

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

            public dynamic Data { get; }

            /// <summary>Gets or sets the pointer to the allocated space in the stream.</summary>
            /// <value>The pointer to allocated space in the stream.</value>
            public override BlamPointer Pointer { get; set; } = BlamPointer.Null;

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