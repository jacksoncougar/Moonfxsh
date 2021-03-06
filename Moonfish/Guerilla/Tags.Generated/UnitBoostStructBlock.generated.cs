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
    
    public partial class UnitBoostStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float BoostPeakPower;
        public float BoostRisePower;
        public float BoostPeakTime;
        public float BoostFallPower;
        public float DeadTime;
        public override int SerializedSize
        {
            get
            {
                return 20;
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
            this.BoostPeakPower = binaryReader.ReadSingle();
            this.BoostRisePower = binaryReader.ReadSingle();
            this.BoostPeakTime = binaryReader.ReadSingle();
            this.BoostFallPower = binaryReader.ReadSingle();
            this.DeadTime = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.BoostPeakPower);
            queueableBinaryWriter.Write(this.BoostRisePower);
            queueableBinaryWriter.Write(this.BoostPeakTime);
            queueableBinaryWriter.Write(this.BoostFallPower);
            queueableBinaryWriter.Write(this.DeadTime);
        }
    }
}
