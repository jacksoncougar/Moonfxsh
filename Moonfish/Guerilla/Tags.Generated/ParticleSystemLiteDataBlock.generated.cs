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
    
    public partial class ParticleSystemLiteDataBlock : GuerillaBlock, IWriteQueueable
    {
        public ParticlesRenderDataBlock[] ParticlesRenderData = new ParticlesRenderDataBlock[0];
        public ParticlesUpdateDataBlock[] ParticlesOtherData = new ParticlesUpdateDataBlock[0];
        private byte[] fieldpad = new byte[32];
        public override int SerializedSize
        {
            get
            {
                return 48;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(19));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            this.fieldpad = binaryReader.ReadBytes(32);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ParticlesRenderData = base.ReadBlockArrayData<ParticlesRenderDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.ParticlesOtherData = base.ReadBlockArrayData<ParticlesUpdateDataBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.ParticlesRenderData);
            queueableBinaryWriter.QueueWrite(this.ParticlesOtherData);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.ParticlesRenderData);
            queueableBinaryWriter.WritePointer(this.ParticlesOtherData);
            queueableBinaryWriter.Write(this.fieldpad);
        }
    }
}
