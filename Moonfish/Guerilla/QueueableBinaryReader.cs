using System.Collections.Generic;
using System.IO;
using System.Text;
using Fasterflect;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class QueueableBinaryReader : BinaryReader
    {
        private readonly Dictionary<object, QueueItem> _lookupDictionary;
        private readonly Queue<QueueItem> _queue;
        private int _queueAddress;

        public QueueableBinaryReader( Stream input, int serializedSize )
            : base( input, Encoding.Default, true )
        {
            _queueAddress = serializedSize;
            _queue = new Queue<QueueItem>( 100 );
            _lookupDictionary = new Dictionary<object, QueueItem>( 100 );
        }

        public void QueueRead( GuerillaBlock[] dataBlocks, BlamPointer dataPointer )
        {
            //  if the array is empty there's nothing to read, so return
            if ( dataBlocks.Length <= 0 ) return;

            Enqueue( dataBlocks, dataPointer );
        }

        public void QueueRead( byte[] data, BlamPointer dataPointer )
        {
            //  if the array is empty there's nothing to write, so return
            if ( data.Length <= 0 ) return;

            Enqueue( data, dataPointer );
        }

        public void QueueRead( short[] data, BlamPointer dataPointer )
        {
            //  if the array is empty there's nothing to write, so return
            if ( data.Length <= 0 ) return;

            Enqueue( data, dataPointer );
        }

        public void ReadQueue( )
        {
            while ( _queue.Count > 0 )
            {
                var item = Dequeue( );
                //  if the pointer has data, and the stream is not already at the data start address
                //  then seek the data start address using a current stream offset to preserve the read/write 
                //  cache.
                if ( !BlamPointer.IsNull( item.Pointer ) && BaseStream.Position != item.Pointer.StartAddress )
                {
                    var offset = item.Pointer.StartAddress - BaseStream.Position;
                    BaseStream.Seek( offset, SeekOrigin.Current );
                }

                var dataQueueItem = item as ByteDataQueueItem;
                if ( dataQueueItem != null )
                {
                    dataQueueItem.Data = ReadBytes( item.Pointer.ElementCount );
                    continue;
                }

                var shortDataQueueItem = item as ShortDataQueueItem;
                if ( shortDataQueueItem != null )
                {
                    for ( var i = 0; i < item.Pointer.ElementCount; ++i )
                        shortDataQueueItem.Data[ i ] = ReadInt16( );
                    continue;
                }

                var guerillaBlockQueueItem = item as GuerillaQueueItem;
                if ( guerillaBlockQueueItem == null ) continue;

                //  then foreach element in the block array call the write method
                foreach ( GuerillaBlock block in guerillaBlockQueueItem.DataBlocks )
                {
                    block.ReadFields( this );
                }
            }
        }

        private QueueItem Dequeue( )
        {
            var queueItem = _queue.Dequeue( );
            _lookupDictionary.Remove( queueItem.ReferenceField );
            return queueItem;
        }

        private void Enqueue( byte[] data, BlamPointer dataPointer )
        {
            var dataQueueItem = new ByteDataQueueItem( data ) {Pointer = dataPointer};
            _lookupDictionary[ data ] = dataQueueItem;
            _queue.Enqueue( dataQueueItem );
        }

        private void Enqueue( short[] data, BlamPointer dataPointer )
        {
            var dataQueueItem = new ShortDataQueueItem( data ) {Pointer = dataPointer};
            _lookupDictionary[ data ] = dataQueueItem;
            _queue.Enqueue( dataQueueItem );
        }

        private void Enqueue( GuerillaBlock[] dataBlocks, BlamPointer dataPointer )
        {
            var guerillaQueueItem = new GuerillaQueueItem( dataBlocks ) {Pointer = dataPointer};
            _lookupDictionary[ dataBlocks ] = guerillaQueueItem;
            _queue.Enqueue( guerillaQueueItem );
        }

        private abstract class QueueItem
        {
            public abstract BlamPointer Pointer { get; set; }
            public abstract object ReferenceField { get; }
        };

        private class ByteDataQueueItem : QueueItem
        {
            public ByteDataQueueItem( byte[] data )
            {
                Data = data;
            }

            public byte[] Data { get; set; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return Data; }
            }
        }

        private class ShortDataQueueItem : QueueItem
        {
            public ShortDataQueueItem( short[] data )
            {
                Data = data;
            }

            public short[] Data { get; private set; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return Data; }
            }
        }

        private class GuerillaQueueItem : QueueItem
        {
            public GuerillaQueueItem( GuerillaBlock[] dataBlocks )
            {
                DataBlocks = dataBlocks;
            }

            public GuerillaBlock[] DataBlocks { get; private set; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return DataBlocks; }
            }
        };
    };
}