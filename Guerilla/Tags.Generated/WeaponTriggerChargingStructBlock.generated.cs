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
    
    public partial class WeaponTriggerChargingStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float ChargingTime;
        public float ChargedTime;
        public OverchargedActionEnum OverchargedAction;
        private byte[] fieldpad = new byte[2];
        public float ChargedIllumination;
        public float SpewTime;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference ChargingEffect;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ChargingDamageEffect;
        public override int SerializedSize
        {
            get
            {
                return 36;
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
            this.ChargingTime = binaryReader.ReadSingle();
            this.ChargedTime = binaryReader.ReadSingle();
            this.OverchargedAction = ((OverchargedActionEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ChargedIllumination = binaryReader.ReadSingle();
            this.SpewTime = binaryReader.ReadSingle();
            this.ChargingEffect = binaryReader.ReadTagReference();
            this.ChargingDamageEffect = binaryReader.ReadTagReference();
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
            queueableBinaryWriter.Write(this.ChargingTime);
            queueableBinaryWriter.Write(this.ChargedTime);
            queueableBinaryWriter.Write(((short)(this.OverchargedAction)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.ChargedIllumination);
            queueableBinaryWriter.Write(this.SpewTime);
            queueableBinaryWriter.Write(this.ChargingEffect);
            queueableBinaryWriter.Write(this.ChargingDamageEffect);
        }
        public enum OverchargedActionEnum : short
        {
            None = 0,
            Explode = 1,
            Discharge = 2,
        }
    }
}
