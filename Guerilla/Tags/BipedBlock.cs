using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bipd")]
    public  partial class BipedBlock : BipedBlockBase
    {
        public  BipedBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 296)]
    public class BipedBlockBase : UnitBlock
    {
        internal float movingTurningSpeedDegreesPerSecond;
        internal Flags flags;
        internal float stationaryTurningThreshold;
        internal float jumpVelocityWorldUnitsPerSecond;
        /// <summary>
        /// the longest amount of time the biped can take to recover from a soft landing
        /// </summary>
        internal float maximumSoftLandingTimeSeconds;
        /// <summary>
        /// the longest amount of time the biped can take to recover from a hard landing
        /// </summary>
        internal float maximumHardLandingTimeSeconds;
        /// <summary>
        /// below this velocity the biped does not react when landing
        /// </summary>
        internal float minimumSoftLandingVelocityWorldUnitsPerSecond;
        /// <summary>
        /// below this velocity the biped will not do a soft landing when returning to the ground
        /// </summary>
        internal float minimumHardLandingVelocityWorldUnitsPerSecond;
        /// <summary>
        /// the velocity corresponding to the maximum landing time
        /// </summary>
        internal float maximumHardLandingVelocityWorldUnitsPerSecond;
        /// <summary>
        /// the maximum velocity with which a character can strike the ground and live
        /// </summary>
        internal float deathHardLandingVelocityWorldUnitsPerSecond;
        /// <summary>
        /// 0 is the default.  Bipeds are stuned when damaged by vehicle collisions, also some are when they take emp damage
        /// </summary>
        internal float stunDuration;
        internal float standingCameraHeightWorldUnits;
        internal float crouchingCameraHeightWorldUnits;
        internal float crouchTransitionTimeSeconds;
        /// <summary>
        /// looking-downward angle that starts camera interpolation to fp position
        /// </summary>
        internal float cameraInterpolationStartDegrees;
        /// <summary>
        /// looking-downward angle at which camera interpolation to fp position is complete
        /// </summary>
        internal float cameraInterpolationEndDegrees;
        /// <summary>
        /// amount of fp camera movement forward and back (1.0 is full)
        /// </summary>
        internal float cameraForwardMovementScale;
        /// <summary>
        /// amount of fp camera movement side-to-side (1.0 is full)
        /// </summary>
        internal float cameraSideMovementScale;
        /// <summary>
        /// amount of fp camera movement vertically (1.0 is full)
        /// </summary>
        internal float cameraVerticalMovementScale;
        /// <summary>
        /// fp camera must always be at least this far out from root node
        /// </summary>
        internal float cameraExclusionDistanceWorldUnits;
        internal float autoaimWidthWorldUnits;
        internal BipedLockOnDataStructBlock lockOnData;
        internal byte[] invalidName_;
        /// <summary>
        /// when the biped ragdolls from a head shot it acceleartes based on this value.  0 defaults to the standard acceleration scale
        /// </summary>
        internal float headShotAccScale;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference areaDamageEffect;
        internal CharacterPhysicsStructBlock physics;
        /// <summary>
        /// these are the points where the biped touches the ground
        /// </summary>
        internal ContactPointBlock[] contactPoints;
        /// <summary>
        /// when the flood reanimate this guy, he turns into a ...
        /// </summary>
        [TagReference("char")]
        internal Moonfish.Tags.TagReference reanimationCharacter;
        /// <summary>
        /// when I die, out of the ashes of my death crawls a ...
        /// </summary>
        [TagReference("char")]
        internal Moonfish.Tags.TagReference deathSpawnCharacter;
        internal short deathSpawnCount;
        internal byte[] invalidName_0;
        internal  BipedBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.movingTurningSpeedDegreesPerSecond = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.stationaryTurningThreshold = binaryReader.ReadSingle();
            this.jumpVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.maximumSoftLandingTimeSeconds = binaryReader.ReadSingle();
            this.maximumHardLandingTimeSeconds = binaryReader.ReadSingle();
            this.minimumSoftLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.minimumHardLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.maximumHardLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.deathHardLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.stunDuration = binaryReader.ReadSingle();
            this.standingCameraHeightWorldUnits = binaryReader.ReadSingle();
            this.crouchingCameraHeightWorldUnits = binaryReader.ReadSingle();
            this.crouchTransitionTimeSeconds = binaryReader.ReadSingle();
            this.cameraInterpolationStartDegrees = binaryReader.ReadSingle();
            this.cameraInterpolationEndDegrees = binaryReader.ReadSingle();
            this.cameraForwardMovementScale = binaryReader.ReadSingle();
            this.cameraSideMovementScale = binaryReader.ReadSingle();
            this.cameraVerticalMovementScale = binaryReader.ReadSingle();
            this.cameraExclusionDistanceWorldUnits = binaryReader.ReadSingle();
            this.autoaimWidthWorldUnits = binaryReader.ReadSingle();
            this.lockOnData = new BipedLockOnDataStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.headShotAccScale = binaryReader.ReadSingle();
            this.areaDamageEffect = binaryReader.ReadTagReference();
            this.physics = new CharacterPhysicsStructBlock(binaryReader);
            this.contactPoints = ReadContactPointBlockArray(binaryReader);
            this.reanimationCharacter = binaryReader.ReadTagReference();
            this.deathSpawnCharacter = binaryReader.ReadTagReference();
            this.deathSpawnCount = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual ContactPointBlock[] ReadContactPointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ContactPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ContactPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ContactPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : int
        {
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
        };
    };
}
