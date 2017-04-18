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
    
    public partial class TorqueCurveStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float MinTorque;
        public float MaxTorque;
        public float PeakTorqueScale;
        public float PastPeakTorqueExponent;
        public float TorqueAtMaxAngularVelocity;
        public float TorqueAt2xMaxAngularVelocity;
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            this.MinTorque = binaryReader.ReadSingle();
            this.MaxTorque = binaryReader.ReadSingle();
            this.PeakTorqueScale = binaryReader.ReadSingle();
            this.PastPeakTorqueExponent = binaryReader.ReadSingle();
            this.TorqueAtMaxAngularVelocity = binaryReader.ReadSingle();
            this.TorqueAt2xMaxAngularVelocity = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.MinTorque);
            queueableBlamBinaryWriter.Write(this.MaxTorque);
            queueableBlamBinaryWriter.Write(this.PeakTorqueScale);
            queueableBlamBinaryWriter.Write(this.PastPeakTorqueExponent);
            queueableBlamBinaryWriter.Write(this.TorqueAtMaxAngularVelocity);
            queueableBlamBinaryWriter.Write(this.TorqueAt2xMaxAngularVelocity);
        }
    }
}
