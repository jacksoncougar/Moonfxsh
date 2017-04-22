//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("character_retreat_block")]
    public partial class CharacterRetreatBlock : GuerillaBlock, IWriteQueueable
    {
        public RetreatFlags CharacterRetreatRetreatFlags;
        public float ShieldThreshold;
        public float ScaryTargetThreshold;
        public float DangerThreshold;
        public float ProximityThreshold;
        public Moonfish.Model.Range MinmaxForcedCowerTimeBounds;
        public Moonfish.Model.Range MinmaxCowerTimeoutBounds;
        public float ProximityAmbushThreshold;
        public float AwarenessAmbushThreshold;
        public float LeaderDeadRetreatChance;
        public float PeerDeadRetreatChance;
        public float SecondPeerDeadRetreatChance;
        public float ZigzagAngle;
        public float ZigzagPeriod;
        public float RetreatGrenadeChance;
        [Moonfish.Tags.TagReferenceAttribute("weap")]
        public Moonfish.Tags.TagReference BackupWeapon;
        public override int SerializedSize
        {
            get
            {
                return 76;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.CharacterRetreatRetreatFlags = ((RetreatFlags)(binaryReader.ReadInt32()));
            this.ShieldThreshold = binaryReader.ReadSingle();
            this.ScaryTargetThreshold = binaryReader.ReadSingle();
            this.DangerThreshold = binaryReader.ReadSingle();
            this.ProximityThreshold = binaryReader.ReadSingle();
            this.MinmaxForcedCowerTimeBounds = binaryReader.ReadRange();
            this.MinmaxCowerTimeoutBounds = binaryReader.ReadRange();
            this.ProximityAmbushThreshold = binaryReader.ReadSingle();
            this.AwarenessAmbushThreshold = binaryReader.ReadSingle();
            this.LeaderDeadRetreatChance = binaryReader.ReadSingle();
            this.PeerDeadRetreatChance = binaryReader.ReadSingle();
            this.SecondPeerDeadRetreatChance = binaryReader.ReadSingle();
            this.ZigzagAngle = binaryReader.ReadSingle();
            this.ZigzagPeriod = binaryReader.ReadSingle();
            this.RetreatGrenadeChance = binaryReader.ReadSingle();
            this.BackupWeapon = binaryReader.ReadTagReference();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.CharacterRetreatRetreatFlags)));
            queueableBinaryWriter.Write(this.ShieldThreshold);
            queueableBinaryWriter.Write(this.ScaryTargetThreshold);
            queueableBinaryWriter.Write(this.DangerThreshold);
            queueableBinaryWriter.Write(this.ProximityThreshold);
            queueableBinaryWriter.Write(this.MinmaxForcedCowerTimeBounds);
            queueableBinaryWriter.Write(this.MinmaxCowerTimeoutBounds);
            queueableBinaryWriter.Write(this.ProximityAmbushThreshold);
            queueableBinaryWriter.Write(this.AwarenessAmbushThreshold);
            queueableBinaryWriter.Write(this.LeaderDeadRetreatChance);
            queueableBinaryWriter.Write(this.PeerDeadRetreatChance);
            queueableBinaryWriter.Write(this.SecondPeerDeadRetreatChance);
            queueableBinaryWriter.Write(this.ZigzagAngle);
            queueableBinaryWriter.Write(this.ZigzagPeriod);
            queueableBinaryWriter.Write(this.RetreatGrenadeChance);
            queueableBinaryWriter.Write(this.BackupWeapon);
        }
        [System.FlagsAttribute()]
        public enum RetreatFlags : int
        {
            None = 0,
            ZigzagWhenFleeing = 1,
            Unused1 = 2,
        }
    }
}
