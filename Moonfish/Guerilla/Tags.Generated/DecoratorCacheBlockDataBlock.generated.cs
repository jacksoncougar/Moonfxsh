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
    
    public partial class DecoratorCacheBlockDataBlock : GuerillaBlock, IWriteQueueable
    {
        public DecoratorPlacementBlock[] Placements = new DecoratorPlacementBlock[0];
        public DecalVerticesBlock[] DecalVertices = new DecalVerticesBlock[0];
        public IndicesBlock[] DecalIndices = new IndicesBlock[0];
        public Moonfish.Tags.VertexBuffer DecalVertexBuffer;
        private byte[] fieldpad = new byte[16];
        public SpriteVerticesBlock[] SpriteVertices = new SpriteVerticesBlock[0];
        public IndicesBlock[] SpriteIndices = new IndicesBlock[0];
        public Moonfish.Tags.VertexBuffer SpriteVertexBuffer;
        private byte[] fieldpad0 = new byte[16];
        public override int SerializedSize
        {
            get
            {
                return 136;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(22));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(31));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            this.DecalVertexBuffer = binaryReader.ReadVertexBuffer();
            this.fieldpad = binaryReader.ReadBytes(16);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(47));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            this.SpriteVertexBuffer = binaryReader.ReadVertexBuffer();
            this.fieldpad0 = binaryReader.ReadBytes(16);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Placements = base.ReadBlockArrayData<DecoratorPlacementBlock>(binaryReader, pointerQueue.Dequeue());
            this.DecalVertices = base.ReadBlockArrayData<DecalVerticesBlock>(binaryReader, pointerQueue.Dequeue());
            this.DecalIndices = base.ReadBlockArrayData<IndicesBlock>(binaryReader, pointerQueue.Dequeue());
            this.SpriteVertices = base.ReadBlockArrayData<SpriteVerticesBlock>(binaryReader, pointerQueue.Dequeue());
            this.SpriteIndices = base.ReadBlockArrayData<IndicesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Placements);
            queueableBinaryWriter.QueueWrite(this.DecalVertices);
            queueableBinaryWriter.QueueWrite(this.DecalIndices);
            queueableBinaryWriter.QueueWrite(this.SpriteVertices);
            queueableBinaryWriter.QueueWrite(this.SpriteIndices);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.Placements);
            queueableBinaryWriter.WritePointer(this.DecalVertices);
            queueableBinaryWriter.WritePointer(this.DecalIndices);
            queueableBinaryWriter.Write(this.DecalVertexBuffer);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.SpriteVertices);
            queueableBinaryWriter.WritePointer(this.SpriteIndices);
            queueableBinaryWriter.Write(this.SpriteVertexBuffer);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
    }
}
