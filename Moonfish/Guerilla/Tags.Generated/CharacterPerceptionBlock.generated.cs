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
    
    public partial class CharacterPerceptionBlock : GuerillaBlock, IWriteQueueable
    {
        public PerceptionFlags CharacterPerceptionPerceptionFlags;
        public float MaxVisionDistance;
        public float CentralVisionAngle;
        public float MaxVisionAngle;
        public float PeripheralVisionAngle;
        public float PeripheralDistance;
        public float HearingDistance;
        public float NoticeProjectileChance;
        public float NoticeVehicleChance;
        public float CombatPerceptionTime;
        public float GuardPerceptionTime;
        public float NoncombatPerceptionTime;
        public float FirstAckSurpriseDistance;
        public override int SerializedSize
        {
            get
            {
                return 52;
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
            this.CharacterPerceptionPerceptionFlags = ((PerceptionFlags)(binaryReader.ReadInt32()));
            this.MaxVisionDistance = binaryReader.ReadSingle();
            this.CentralVisionAngle = binaryReader.ReadSingle();
            this.MaxVisionAngle = binaryReader.ReadSingle();
            this.PeripheralVisionAngle = binaryReader.ReadSingle();
            this.PeripheralDistance = binaryReader.ReadSingle();
            this.HearingDistance = binaryReader.ReadSingle();
            this.NoticeProjectileChance = binaryReader.ReadSingle();
            this.NoticeVehicleChance = binaryReader.ReadSingle();
            this.CombatPerceptionTime = binaryReader.ReadSingle();
            this.GuardPerceptionTime = binaryReader.ReadSingle();
            this.NoncombatPerceptionTime = binaryReader.ReadSingle();
            this.FirstAckSurpriseDistance = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(((int)(this.CharacterPerceptionPerceptionFlags)));
            queueableBinaryWriter.Write(this.MaxVisionDistance);
            queueableBinaryWriter.Write(this.CentralVisionAngle);
            queueableBinaryWriter.Write(this.MaxVisionAngle);
            queueableBinaryWriter.Write(this.PeripheralVisionAngle);
            queueableBinaryWriter.Write(this.PeripheralDistance);
            queueableBinaryWriter.Write(this.HearingDistance);
            queueableBinaryWriter.Write(this.NoticeProjectileChance);
            queueableBinaryWriter.Write(this.NoticeVehicleChance);
            queueableBinaryWriter.Write(this.CombatPerceptionTime);
            queueableBinaryWriter.Write(this.GuardPerceptionTime);
            queueableBinaryWriter.Write(this.NoncombatPerceptionTime);
            queueableBinaryWriter.Write(this.FirstAckSurpriseDistance);
        }
        [System.FlagsAttribute()]
        public enum PerceptionFlags : int
        {
            None = 0,
            Flag1 = 1,
        }
    }
}
