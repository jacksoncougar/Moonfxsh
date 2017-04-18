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
    
    public partial class RenderModelSectionGroupBlock : GuerillaBlock, IWriteQueueable
    {
        public DetailLevels RenderModelSectionGroupDetailLevels;
        private byte[] fieldpad = new byte[2];
        public RenderModelCompoundNodeBlock[] CompoundNodes = new RenderModelCompoundNodeBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 12;
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
            this.RenderModelSectionGroupDetailLevels = ((DetailLevels)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.CompoundNodes = base.ReadBlockArrayData<RenderModelCompoundNodeBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.CompoundNodes);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((short)(this.RenderModelSectionGroupDetailLevels)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.WritePointer(this.CompoundNodes);
        }
        [System.FlagsAttribute()]
        public enum DetailLevels : short
        {
            None = 0,
            L1superLow = 1,
            L2low = 2,
            L3medium = 4,
            L4high = 8,
            L5superHigh = 16,
            L6hollywood = 32,
        }
    }
}
