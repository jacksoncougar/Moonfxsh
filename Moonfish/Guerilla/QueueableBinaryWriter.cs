using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    public class QueueableBlamBinaryWriter : BlamBinaryWriter
    {
        protected readonly Dictionary<object, QueueItem> lookupDictionary;
        protected readonly Queue<QueueItem> Queue;
        private int queueAddress;

        public QueueableBlamBinaryWriter( Stream output, int serializedSize ) : base( output, Encoding.Default, true )
        {
            queueAddress = serializedSize;
            Queue = new Queue<QueueItem>( 100 );
            lookupDictionary = new Dictionary<object, QueueItem>( 100 );
        }

        public void QueueWrite( GuerillaBlock[] dataBlocks )
        {
            //  if the array is empty there's nothing to write, so return
            if ( dataBlocks.Length <= 0 ) return;

            Enqueue( dataBlocks );

            //  all guerilla blocks implement IWriteQueueable
            foreach ( IWriteQueueable block in dataBlocks )
                block.QueueWrites( this );
        }

        public void QueueWrite( byte[] data )
        {
            //  if the array is empty there's nothing to write, so return
            if ( data.Length <= 0 ) return;

            Enqueue( data );
        }

        public void QueueWrite( short[] data )
        {
            //  if the array is empty there's nothing to write, so return
            if ( data.Length <= 0 ) return;

            Enqueue( data );
        }

        public virtual void Write(VertexBuffer buffer)
        {
            Write((int) buffer.Type);
            Write(new byte[28]);
        }

        protected BlamPointer GetItemPointer(object key)
        {
            QueueItem value;
            var success = lookupDictionary.TryGetValue(key, out value);
            if (!success)
                return BlamPointer.Null;
            return value.Pointer;
        }

        public virtual void WritePointer<T>( T instanceFIeld )
        {
            QueueItem queueItem;
            this.Write( lookupDictionary.TryGetValue( instanceFIeld, out queueItem )
                ? queueItem.Pointer
                : BlamPointer.Null );
        }

        public void WriteQueue( )
        {
            while ( Queue.Count > 0 )
            {
                var item = Dequeue( );
                //  if the pointer has data, and the stream is not already at the data start address
                //  then seek the data start address using a current stream offset to preserve the read/write 
                //  cache.
                if ( !BlamPointer.IsNull( item.Pointer ) && BaseStream.Position != item.Pointer.StartAddress )
                {
#if DEBUG
                    var offset = item.Pointer.StartAddress - BaseStream.Position;
                    if ( offset < 0 )
                    {
                        throw new Exception( "That breaks the maps" );
                    }
#endif
                    BaseStream.Seek( item.Pointer.StartAddress, SeekOrigin.Begin );
                }

				item.Write(this);
            }
        }

        internal void QueueWrite( byte[] data, int alignment )
        {
            Enqueue( data, alignment );
        }

        private QueueItem Dequeue( )
        {
            var queueItem = Queue.Dequeue( );
            lookupDictionary.Remove( queueItem.ReferenceField );
            return queueItem;
        }

        private void Enqueue( byte[] data, int alignment = 4 )
        {
            var blamPointer = new BlamPointer( data.Length, queueAddress, 1, alignment );
            var dataQueueItem = new ByteDataQueueItem( data ) {Pointer = blamPointer};
            lookupDictionary[ data ] = dataQueueItem;
            Queue.Enqueue( dataQueueItem );
            queueAddress = blamPointer.EndAddress;
        }

        private void Enqueue( short[] data )
        {
            var blamPointer = new BlamPointer( data.Length, queueAddress, 2 );
            var dataQueueItem = new ShortDataQueueItem( data ) {Pointer = blamPointer};
            lookupDictionary[ data ] = dataQueueItem;
            Queue.Enqueue( dataQueueItem );
            queueAddress = blamPointer.EndAddress;
        }

        private void Enqueue( GuerillaBlock[] dataBlocks )
        {
            var elementSize = dataBlocks.GetElementSize( );
            var alignment = dataBlocks.GetAlignment( );
            var blamPointer = new BlamPointer( dataBlocks.Length, queueAddress, elementSize,
                alignment );

            var guerillaQueueItem = new GuerillaQueueItem( dataBlocks ) {Pointer = blamPointer};
            lookupDictionary[ dataBlocks ] = guerillaQueueItem;
            Queue.Enqueue( guerillaQueueItem );
            queueAddress = blamPointer.EndAddress;
        }

        private class ByteDataQueueItem : QueueItem
        {
            public ByteDataQueueItem( byte[] data )
            {
                Data = data;
            }

            public byte[] Data { get; private set; }
            public override BlamPointer Pointer { get; set; }

            public override object ReferenceField
            {
                get { return Data; }
            }

			public override void Write(QueueableBlamBinaryWriter writer)
			{
				writer.Write(Data);
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

			public override void Write(QueueableBlamBinaryWriter writer)
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

			public override void Write(QueueableBlamBinaryWriter writer)
			{
				foreach (var block in DataBlocks)
				{
                    block.Write(writer);
				}
			}
		};
    };

    /// <summary>
    /// Queue item used for allocating space for read and write operations on a stream.
    /// </summary>
    public abstract class QueueItem
    {
        /// <summary>
        /// Gets or sets the pointer to the allocated space in the stream.
        /// </summary>
        /// <value>The pointer to allocated space in the stream.</value>
        public abstract BlamPointer Pointer { get; set; }
        /// <summary>
        /// Gets the reference to the queued data. 
        /// </summary>
        /// <remarks>
        /// This is used as a key to lookup queue items.
        /// </remarks>
        /// <value>The reference field.</value>
        public abstract object ReferenceField { get; }
        public abstract void Write(QueueableBlamBinaryWriter writer); 
    };
}