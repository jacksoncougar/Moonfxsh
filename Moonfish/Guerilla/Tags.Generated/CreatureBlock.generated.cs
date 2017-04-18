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
    
    [TagClassAttribute("crea")]
    public partial class CreatureBlock : ObjectBlock, IWriteQueueable
    {
        public CreatureFlags CreatureCreatureFlags;
        public DefaultTeamEnum DefaultTeam;
        public MotionSensorBlipSizeEnum MotionSensorBlipSize;
        public float TurningVelocityMaximum;
        public float TurningAccelerationMaximum;
        public float CasualTurningModifier;
        public float AutoaimWidth;
        public CharacterPhysicsStructBlock Physics = new CharacterPhysicsStructBlock();
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ImpactDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ImpactShieldDamage;
        public Moonfish.Model.Range DestroyAfterDeathTime;
        public override int SerializedSize
        {
            get
            {
                return 384;
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
            this.CreatureCreatureFlags = ((CreatureFlags)(binaryReader.ReadInt32()));
            this.DefaultTeam = ((DefaultTeamEnum)(binaryReader.ReadInt16()));
            this.MotionSensorBlipSize = ((MotionSensorBlipSizeEnum)(binaryReader.ReadInt16()));
            this.TurningVelocityMaximum = binaryReader.ReadSingle();
            this.TurningAccelerationMaximum = binaryReader.ReadSingle();
            this.CasualTurningModifier = binaryReader.ReadSingle();
            this.AutoaimWidth = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Physics.ReadFields(binaryReader)));
            this.ImpactDamage = binaryReader.ReadTagReference();
            this.ImpactShieldDamage = binaryReader.ReadTagReference();
            this.DestroyAfterDeathTime = binaryReader.ReadRange();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Physics.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.Physics.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((int)(this.CreatureCreatureFlags)));
            queueableBlamBinaryWriter.Write(((short)(this.DefaultTeam)));
            queueableBlamBinaryWriter.Write(((short)(this.MotionSensorBlipSize)));
            queueableBlamBinaryWriter.Write(this.TurningVelocityMaximum);
            queueableBlamBinaryWriter.Write(this.TurningAccelerationMaximum);
            queueableBlamBinaryWriter.Write(this.CasualTurningModifier);
            queueableBlamBinaryWriter.Write(this.AutoaimWidth);
            this.Physics.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.ImpactDamage);
            queueableBlamBinaryWriter.Write(this.ImpactShieldDamage);
            queueableBlamBinaryWriter.Write(this.DestroyAfterDeathTime);
        }
        [System.FlagsAttribute()]
        public enum CreatureFlags : int
        {
            None = 0,
            Unused = 1,
            InfectionForm = 2,
            ImmuneToFallingDamage = 4,
            RotateWhileAirborne = 8,
            ZappedByShields = 16,
            AttachUponImpact = 32,
            NotOnMotionSensor = 64,
        }
        public enum DefaultTeamEnum : short
        {
            Default = 0,
            Player = 1,
            Human = 2,
            Covenant = 3,
            Flood = 4,
            Sentinel = 5,
            Heretic = 6,
            Prophet = 7,
            Unused8 = 8,
            Unused9 = 9,
            Unused10 = 10,
            Unused11 = 11,
            Unused12 = 12,
            Unused13 = 13,
            Unused14 = 14,
            Unused15 = 15,
        }
        public enum MotionSensorBlipSizeEnum : short
        {
            Medium = 0,
            Small = 1,
            Large = 2,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Crea = ((TagClass)("crea"));
    }
}
