using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    /// <summary>Writes blam! reference data as binary to a stream linearly.</summary>
    /// <remarks>
    ///     Achieves linear writes by deferring writing reference fields to the stream
    ///     until after the preceeding values have been written. Defer: allocates space
    ///     for the reference field(s) at the end of the currently allocated space,
    ///     then writes the reference field(s) as binary to the stream after previous
    ///     deferred writes have completed. Commit: causes deferred writes to be
    ///     written to the stream at thier allocated spaces. Known Issues: cannot have
    ///     references that point to the same location in the stream.
    /// </remarks>
    /// <seealso cref="Moonfish.Guerilla.BlamBinaryWriter" />
    public class LinearBinaryWriter : BlamBinaryWriter
    {
        private readonly Dictionary<object, QueueItem> lookupDictionary;
        protected readonly Queue<QueueItem> Queue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LinearBinaryWriter" />
        ///     class.
        /// </summary>
        /// <param name="output">The output stream to write to.</param>
        public LinearBinaryWriter(Stream output) : base(output, Encoding.Default, true)
        {
            AllocationLength = 0;
            Queue = new Queue<QueueItem>(100);
            lookupDictionary = new Dictionary<object, QueueItem>(100);
        }

        /// <summary>get or sets the length of allocated data.</summary>
        /// <value>The queue address.</value>
        protected int AllocationLength { get; set; }

        /// <summary>Commits all deferred writes to the stream.</summary>
        /// <exception cref="IOException">Wrote more/less data than expected.</exception>
        /// <exception cref="IOException">Attempted to write over existing data.</exception>
        public virtual void Commit()
        {
            while (Queue.Count > 0)
            {
                var item = Dequeue();

                //  if the pointer has data, and the stream is not already at the data start address
                //  then seek the data start address using a current stream offset to preserve the read/write 
                //  cache.
                if (item.Pointer != BlamPointer.Null && BaseStream.Position != item.Pointer.StartAddress)
                {
#if DEBUG
                    var offset = item.Pointer.StartAddress - BaseStream.Position;
                    if (offset < 0)
                    {
                        throw new IOException("Attempted to write over existing data.");
                    }
#endif
                    BaseStream.Seek(item.Pointer.StartAddress, SeekOrigin.Begin);
                }

                item.Write(this);

                if (item.Pointer != BlamPointer.Null)
                {
                    if (BaseStream.Position < item.Pointer.EndAddress)
                        Write(new byte[item.Pointer.EndAddress - BaseStream.Position]);
#if DEBUG
                    if (BaseStream.Position != item.Pointer.EndAddress)
                        throw new IOException("Wrote more/less data than expected.");
#endif
                }
            }
        }

        /// <summary>
        ///     Reserves space in the stream and then defers writing the specified
        ///     <see cref="GuerillaBlock" />
        ///     array until after <see cref="Commit" /> has been called.
        /// </summary>
        /// <param name="blocks">The <see cref="GuerillaBlock" /> array to defer.</param>
        public virtual void Defer(GuerillaBlock[] blocks)
        {
            //  if the array is empty there's nothing to write, so return
            if (blocks.Length <= 0)
                return;

            Enqueue(blocks);

            //  all guerilla blocks implement IWriteQueueable
            foreach (IWriteDeferrable block in blocks)
                block.DeferReferences(this);
        }

        /// <summary>
        ///     Reserves space in the stream and then defers writing the specified
        ///     <see cref="byte" />
        ///     array until after <see cref="Commit" /> has been called.
        /// </summary>
        /// <param name="data">The data to defer</param>
        /// <param name="alignment">
        ///     The alignment in the destination stream the data should
        ///     begin on.
        /// </param>
        public virtual void Defer(byte[] data, int alignment = Alignment.Default)
        {
            //  if the array is empty there's nothing to write, so return
            if (data.Length <= 0)
                return;

            Enqueue(data, alignment);
        }

        /// <summary>
        ///     Reserves space in the stream and then defers writing the specified
        ///     <see cref="short" />
        ///     array until after <see cref="Commit" /> has been called.
        /// </summary>
        /// <param name="data">The data to defer</param>
        /// <param name="alignment">
        ///     The alignment in the destination stream the data should
        ///     begin on.
        /// </param>
        public virtual void Defer(short[] data, int alignment = Alignment.Default)
        {
            //  if the array is empty there's nothing to write, so return
            if (data.Length <= 0)
                return;

            Enqueue(data, alignment);
        }

        public virtual void Defer(VertexBuffer vertexBuffer)
        {
            throw new NotImplementedException("Cannot defer vertex buffer in this context");
        }

        /// <summary>Writes the specified guerilla block.</summary>
        /// <param name="guerillaBlock">The guerilla block.</param>
        public void Write(GuerillaBlock guerillaBlock)
        {
            Defer(guerillaBlock); //allocate the block fields here...
            guerillaBlock.DeferReferences(this); //allocate the nested tag blocks.
            Commit(); //write everything to the stream.
        }

        /// <summary>Writes the pointer for the given object to the stream.</summary>
        /// <typeparam name="T">The type of the given object</typeparam>
        /// <param name="object">The object to write the pointer of.</param>
        /// <remarks>If the object is not found then writes <see cref="BlamPointer.Null" />
        ///     to the stream.</remarks>
        public virtual void WritePointer<T>(T @object)
        {
            QueueItem queueItem;
            Write(lookupDictionary.TryGetValue(@object, out queueItem) ? queueItem.Pointer : BlamPointer.Null);
        }

        protected virtual void Defer(GuerillaBlock guerillaBlock)
        {
            var elementSize = guerillaBlock.SerializedSize;
            var alignment = guerillaBlock.Alignment;
            var blamPointer = new BlamPointer(1, AllocationLength, elementSize, alignment);

            var guerillaQueueItem = new GuerillaQueueItem(guerillaBlock) {Pointer = blamPointer};
            Queue.Enqueue(guerillaQueueItem);
            AllocationLength = blamPointer.EndAddress;
        }

        protected BlamPointer GetItemPointer(object key)
        {
            QueueItem value;
            var success = lookupDictionary.TryGetValue(key, out value);
            if (!success)
                return BlamPointer.Null;
            return value.Pointer;
        }

        private QueueItem Dequeue()
        {
            var queueItem = Queue.Dequeue();
            lookupDictionary.Remove(queueItem.ReferenceField);
            return queueItem;
        }

        private void Enqueue(byte[] data, int alignment = Alignment.Default)
        {
            var blamPointer = new BlamPointer(data.Length, AllocationLength, 1, alignment);
            var dataQueueItem = new ByteDataQueueItem(data) {Pointer = blamPointer};
            lookupDictionary[data] = dataQueueItem;
            Queue.Enqueue(dataQueueItem);
            AllocationLength = blamPointer.EndAddress;
        }

        private void Enqueue(short[] data, int alignment = Alignment.Default)
        {
            var blamPointer = new BlamPointer(data.Length, AllocationLength, 2, alignment);
            var dataQueueItem = new ShortDataQueueItem(data) {Pointer = blamPointer};
            lookupDictionary[data] = dataQueueItem;
            Queue.Enqueue(dataQueueItem);
            AllocationLength = blamPointer.EndAddress;
        }

        private void Enqueue(GuerillaBlock[] dataBlocks)
        {
            var elementSize = dataBlocks.GetElementSize();
            var alignment = dataBlocks.GetAlignment();
            var blamPointer = new BlamPointer(dataBlocks.Length, AllocationLength, elementSize, alignment);

            var guerillaQueueItem = new GuerillaQueueItem(dataBlocks) {Pointer = blamPointer};
            lookupDictionary[dataBlocks] = guerillaQueueItem;
            Queue.Enqueue(guerillaQueueItem);
            AllocationLength = blamPointer.EndAddress;
        }

        private class ByteDataQueueItem : QueueItem
        {
            public ByteDataQueueItem(byte[] data)
            {
                Data = data;
            }

            private byte[] Data { get; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return Data; }
            }

            public override void Write(LinearBinaryWriter writer)
            {
                writer.Write(Data);
            }
        }

        private class ShortDataQueueItem : QueueItem
        {
            public ShortDataQueueItem(short[] data)
            {
                Data = data;
            }

            private short[] Data { get; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return Data; }
            }

            public override void Write(LinearBinaryWriter writer)
            {
                short[] buffer = Data;
                foreach (var item in buffer)
                {
                    writer.Write(item);
                }
            }
        }

        private class GuerillaQueueItem : QueueItem
        {
            public GuerillaQueueItem(GuerillaBlock guerillaBlock)
            {
                DataBlocks = new[] {guerillaBlock};
            }

            public GuerillaQueueItem(GuerillaBlock[] dataBlocks)
            {
                DataBlocks = dataBlocks;
            }

            private GuerillaBlock[] DataBlocks { get; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return DataBlocks; }
            }

            public override void Write(LinearBinaryWriter writer)
            {
                foreach (var block in DataBlocks)
                {
                    block.Write(writer);
                }
            }
        }

        /// <summary>
        ///     Queue item used for allocating space for read and write operations on
        ///     a stream.
        /// </summary>
        protected abstract class QueueItem
        {
            /// <summary>Gets or sets the pointer to the allocated space in the stream.</summary>
            /// <value>The pointer to allocated space in the stream.</value>
            public abstract BlamPointer Pointer { get; set; }

            /// <summary>Gets the reference to the queued data.</summary>
            /// <remarks>This is used as a key to lookup queue items.</remarks>
            /// <value>The reference field.</value>
            public abstract object ReferenceField { get; }

            public abstract void Write(LinearBinaryWriter writer);
        }
    }
}