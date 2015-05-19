using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Fasterflect;
using JetBrains.Annotations;
using Moonfish.Cache;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class QueueableBinaryWriter : BinaryWriter
    {
        private readonly Dictionary<object, QueueItem> _lookupDictionary;
        private readonly Queue<QueueItem> _queue;
        private int _queueAddress;

        public QueueableBinaryWriter(Stream output, int serializedSize) : base(output, Encoding.Default, true)
        {
            _queueAddress = serializedSize;
            _queue = new Queue<QueueItem>(100);
            _lookupDictionary = new Dictionary<object, QueueItem>(100);
        }

        public void WritePointer(object instanceFIeld)
        {
            QueueItem queueItem;
            this.Write(_lookupDictionary.TryGetValue(instanceFIeld, out queueItem)
                ? queueItem.Pointer
                : BlamPointer.Null);
        }

        public void QueueWrite(GuerillaBlock[] dataBlocks)
        {
            //  if the array is empty there's nothing to write, so return
            if (dataBlocks.Length <= 0) return;

            Enqueue(dataBlocks);

            //  all guerilla blocks implement IWriteQueueable
            foreach (IWriteQueueable block in dataBlocks)
                block.QueueWrites(this);
        }

        public void QueueWrite(byte[] data)
        {
            //  if the array is empty there's nothing to write, so return
            if (data.Length <= 0) return;

            Enqueue(data);
        }

        public void QueueWrite(short[] data)
        {
            //  if the array is empty there's nothing to write, so return
            if (data.Length <= 0) return;

            Enqueue(data);
        }

        private void Enqueue(byte[] data)
        {
            var blamPointer = new BlamPointer(data.Length, _queueAddress, 1);
            var dataQueueItem = new ByteDataQueueItem(data) { Pointer = blamPointer };
            _lookupDictionary[data] = dataQueueItem;
            _queue.Enqueue(dataQueueItem);
            _queueAddress = blamPointer.EndAddress;
        }

        private void Enqueue(short[] data)
        {
            var blamPointer = new BlamPointer(data.Length, _queueAddress, 2);
            var dataQueueItem = new ShortDataQueueItem(data) { Pointer = blamPointer };
            _lookupDictionary[data] = dataQueueItem;
            _queue.Enqueue(dataQueueItem);
            _queueAddress = blamPointer.EndAddress;
        }

        private void Enqueue(GuerillaBlock[] dataBlocks)
        {
            var elementSize = dataBlocks.GetElementSize();
            var alignment = dataBlocks.GetAlignment();
            var blamPointer = new BlamPointer(dataBlocks.Length, _queueAddress, elementSize,
                alignment);

            var guerillaQueueItem = new GuerillaQueueItem(dataBlocks) {Pointer = blamPointer};
            _lookupDictionary[dataBlocks] = guerillaQueueItem;
            _queue.Enqueue(guerillaQueueItem);
            _queueAddress = blamPointer.EndAddress;
        }

        public void WriteQueue()
        {
            while (_queue.Count > 0)
            {
                var item = Dequeue();
                //  if the pointer has data, and the stream is not already at the data start address
                //  then seek the data start address using a current stream offset to preserve the read/write 
                //  cache.
                if (!BlamPointer.IsNull(item.Pointer) && BaseStream.Position != item.Pointer.StartAddress)
                {
#if DEBUG
                    var offset = item.Pointer.StartAddress - BaseStream.Position;
                    if (offset < 0)
                    {
                        }
                    var cacheStream = BaseStream as CacheStream;

                    Debug.WriteLine(@"type: {0}, local-offset: {1}, file-address: {2}",
                        item.ReferenceField.GetType().Name(), offset,
                        cacheStream != null ? cacheStream.GetFilePosition() : BaseStream.Position);
#endif
                    BaseStream.Seek(item.Pointer.StartAddress);
                }

                var dataQueueItem = item as ByteDataQueueItem;
                if (dataQueueItem != null)
                {
                    Write(dataQueueItem.Data);
                    continue;
                }

                var shortDataQueueItem = item as ShortDataQueueItem;
                if (shortDataQueueItem != null)
                {
                    var buffer = shortDataQueueItem.Data;
                    for (int i = 0; i < buffer.Length; ++i)
                        Write(shortDataQueueItem.Data[i]);
                    continue;
                }
                
                var guerillaBlockQueueItem = item as GuerillaQueueItem;
                if (guerillaBlockQueueItem != null)
                {
                    //  then foreach element in the block array call the write method
                    for (var i = 0; i < guerillaBlockQueueItem.DataBlocks.Length; ++i)
                    {
                        guerillaBlockQueueItem.DataBlocks[i].Write_(this);
                    }
                    continue;
                }
            }
        }

        private QueueItem Dequeue()
        {
            var queueItem = _queue.Dequeue();
            _lookupDictionary.Remove(queueItem.ReferenceField);
            return queueItem;
        }

        private abstract class QueueItem
        {
            public abstract BlamPointer Pointer { get; set; }
            public abstract object ReferenceField { get; }
        };

        private class ByteDataQueueItem : QueueItem
        {
            public ByteDataQueueItem(byte[] data)
            {
                Data = data;
            }

            public byte[] Data { get; private set; }

            public override object ReferenceField
            {
                get { return Data; }
            }

            public override BlamPointer Pointer { get; set; }
        }

        private class ShortDataQueueItem : QueueItem
        {
            public ShortDataQueueItem(short[] data)
            {
                Data = data;
            }

            public short[] Data { get; private set; }

            public override object ReferenceField
            {
                get { return Data; }
            }

            public override BlamPointer Pointer { get; set; }
        }

        private class GuerillaQueueItem : QueueItem
        {
            public GuerillaQueueItem(GuerillaBlock[] dataBlocks)
            {
                DataBlocks = dataBlocks;
            }

            public GuerillaBlock[] DataBlocks { get; private set; }

            public override object ReferenceField
            {
                get { return DataBlocks; }
            }

            public override BlamPointer Pointer { get; set; }
        };
    };
}