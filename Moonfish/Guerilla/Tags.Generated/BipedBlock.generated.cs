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
    
    [TagClassAttribute("bipd")]
    public partial class BipedBlock : UnitBlock, IWriteQueueable
    {
        public float MovingTurningSpeed;
        public BipedFlags BipedBipedFlags;
        public float StationaryTurningThreshold;
        public float JumpVelocity;
        public float MaximumSoftLandingTime;
        public float MaximumHardLandingTime;
        public float MinimumSoftLandingVelocity;
        public float MinimumHardLandingVelocity;
        public float MaximumHardLandingVelocity;
        public float DeathHardLandingVelocity;
        public float StunDuration;
        public float StandingCameraHeight;
        public float CrouchingCameraHeight;
        public float CrouchTransitionTime;
        public float CameraInterpolationStart;
        public float CameraInterpolationEnd;
        public float CameraForwardMovementScale;
        public float CameraSideMovementScale;
        public float CameraVerticalMovementScale;
        public float CameraExclusionDistance;
        public float AutoaimWidth;
        public BipedLockOnDataStructBlock LockonData = new BipedLockOnDataStructBlock();
        private byte[] fieldpad4 = new byte[16];
        public float HeadShotAccScale;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference AreaDamageEffect;
        public CharacterPhysicsStructBlock Physics = new CharacterPhysicsStructBlock();
        public ContactPointBlock[] ContactPoints = new ContactPointBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("char")]
        public Moonfish.Tags.TagReference ReanimationCharacter;
        [Moonfish.Tags.TagReferenceAttribute("char")]
        public Moonfish.Tags.TagReference DeathSpawnCharacter;
        public short DeathSpawnCount;
        private byte[] fieldpad5 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 788;
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
            this.MovingTurningSpeed = binaryReader.ReadSingle();
            this.BipedBipedFlags = ((BipedFlags)(binaryReader.ReadInt32()));
            this.StationaryTurningThreshold = binaryReader.ReadSingle();
            this.JumpVelocity = binaryReader.ReadSingle();
            this.MaximumSoftLandingTime = binaryReader.ReadSingle();
            this.MaximumHardLandingTime = binaryReader.ReadSingle();
            this.MinimumSoftLandingVelocity = binaryReader.ReadSingle();
            this.MinimumHardLandingVelocity = binaryReader.ReadSingle();
            this.MaximumHardLandingVelocity = binaryReader.ReadSingle();
            this.DeathHardLandingVelocity = binaryReader.ReadSingle();
            this.StunDuration = binaryReader.ReadSingle();
            this.StandingCameraHeight = binaryReader.ReadSingle();
            this.CrouchingCameraHeight = binaryReader.ReadSingle();
            this.CrouchTransitionTime = binaryReader.ReadSingle();
            this.CameraInterpolationStart = binaryReader.ReadSingle();
            this.CameraInterpolationEnd = binaryReader.ReadSingle();
            this.CameraForwardMovementScale = binaryReader.ReadSingle();
            this.CameraSideMovementScale = binaryReader.ReadSingle();
            this.CameraVerticalMovementScale = binaryReader.ReadSingle();
            this.CameraExclusionDistance = binaryReader.ReadSingle();
            this.AutoaimWidth = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.LockonData.ReadFields(binaryReader)));
            this.fieldpad4 = binaryReader.ReadBytes(16);
            this.HeadShotAccScale = binaryReader.ReadSingle();
            this.AreaDamageEffect = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Physics.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            this.ReanimationCharacter = binaryReader.ReadTagReference();
            this.DeathSpawnCharacter = binaryReader.ReadTagReference();
            this.DeathSpawnCount = binaryReader.ReadInt16();
            this.fieldpad5 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.LockonData.ReadInstances(binaryReader, pointerQueue);
            this.Physics.ReadInstances(binaryReader, pointerQueue);
            this.ContactPoints = base.ReadBlockArrayData<ContactPointBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.LockonData.QueueWrites(queueableBinaryWriter);
            this.Physics.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.ContactPoints);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MovingTurningSpeed);
            queueableBinaryWriter.Write(((int)(this.BipedBipedFlags)));
            queueableBinaryWriter.Write(this.StationaryTurningThreshold);
            queueableBinaryWriter.Write(this.JumpVelocity);
            queueableBinaryWriter.Write(this.MaximumSoftLandingTime);
            queueableBinaryWriter.Write(this.MaximumHardLandingTime);
            queueableBinaryWriter.Write(this.MinimumSoftLandingVelocity);
            queueableBinaryWriter.Write(this.MinimumHardLandingVelocity);
            queueableBinaryWriter.Write(this.MaximumHardLandingVelocity);
            queueableBinaryWriter.Write(this.DeathHardLandingVelocity);
            queueableBinaryWriter.Write(this.StunDuration);
            queueableBinaryWriter.Write(this.StandingCameraHeight);
            queueableBinaryWriter.Write(this.CrouchingCameraHeight);
            queueableBinaryWriter.Write(this.CrouchTransitionTime);
            queueableBinaryWriter.Write(this.CameraInterpolationStart);
            queueableBinaryWriter.Write(this.CameraInterpolationEnd);
            queueableBinaryWriter.Write(this.CameraForwardMovementScale);
            queueableBinaryWriter.Write(this.CameraSideMovementScale);
            queueableBinaryWriter.Write(this.CameraVerticalMovementScale);
            queueableBinaryWriter.Write(this.CameraExclusionDistance);
            queueableBinaryWriter.Write(this.AutoaimWidth);
            this.LockonData.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad4);
            queueableBinaryWriter.Write(this.HeadShotAccScale);
            queueableBinaryWriter.Write(this.AreaDamageEffect);
            this.Physics.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.ContactPoints);
            queueableBinaryWriter.Write(this.ReanimationCharacter);
            queueableBinaryWriter.Write(this.DeathSpawnCharacter);
            queueableBinaryWriter.Write(this.DeathSpawnCount);
            queueableBinaryWriter.Write(this.fieldpad5);
        }
        [System.FlagsAttribute()]
        public enum BipedFlags : int
        {
            None = 0,
            TurnsWithoutAnimating = 1,
            PassesThroughOtherBipeds = 2,
            ImmuneToFallingDamage = 4,
            RotateWhileAirborne = 8,
            UsesLimpBodyPhysics = 16,
            Unused = 32,
            RandomSpeedIncrease = 64,
            Unused0 = 128,
            SpawnDeathChildrenOnDestroy = 256,
            StunnedByEmpDamage = 512,
            DeadPhysicsWhenStunned = 1024,
            AlwaysRagdollWhenDead = 2048,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Bipd = ((TagClass)("bipd"));
    }
}
