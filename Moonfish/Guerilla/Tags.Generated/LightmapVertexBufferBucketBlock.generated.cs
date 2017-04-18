//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class LightmapVertexBufferBucketBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags LightmapVertexBufferBucketFlags;
        private byte[] fieldpad = new byte[2];
        public LightmapBucketRawVertexBlock[] RawVertices = new LightmapBucketRawVertexBlock[0];
        public GlobalGeometryBlockInfoStructBlock GeometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
        public LightmapVertexBufferBucketCacheDataBlock[] CacheData = new LightmapVertexBufferBucketCacheDataBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 56;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.LightmapVertexBufferBucketFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GeometryBlockInfo.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.RawVertices = base.ReadBlockArrayData<LightmapBucketRawVertexBlock>(binaryReader, pointerQueue.Dequeue());
            this.GeometryBlockInfo.ReadInstances(binaryReader, pointerQueue);
            this.CacheData = base.ReadBlockArrayData<LightmapVertexBufferBucketCacheDataBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.RawVertices);
            this.GeometryBlockInfo.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.CacheData);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((short)(this.LightmapVertexBufferBucketFlags)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.WritePointer(this.RawVertices);
            this.GeometryBlockInfo.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.WritePointer(this.CacheData);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            IncidentDirection = 1,
            Color = 2,
        }
    }
}
