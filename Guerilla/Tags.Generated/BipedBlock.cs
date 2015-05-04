// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Bipd = (TagClass)"bipd";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bipd")]
    public partial class BipedBlock : BipedBlockBase
    {
        public BipedBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 296, Alignment = 4)]
    public class BipedBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 788; } }
        public override int Alignment { get { return 4; } }
        public BipedBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            movingTurningSpeedDegreesPerSecond = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
            stationaryTurningThreshold = binaryReader.ReadSingle();
            jumpVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            maximumSoftLandingTimeSeconds = binaryReader.ReadSingle();
            maximumHardLandingTimeSeconds = binaryReader.ReadSingle();
            minimumSoftLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            minimumHardLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            maximumHardLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            deathHardLandingVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            stunDuration = binaryReader.ReadSingle();
            standingCameraHeightWorldUnits = binaryReader.ReadSingle();
            crouchingCameraHeightWorldUnits = binaryReader.ReadSingle();
            crouchTransitionTimeSeconds = binaryReader.ReadSingle();
            cameraInterpolationStartDegrees = binaryReader.ReadSingle();
            cameraInterpolationEndDegrees = binaryReader.ReadSingle();
            cameraForwardMovementScale = binaryReader.ReadSingle();
            cameraSideMovementScale = binaryReader.ReadSingle();
            cameraVerticalMovementScale = binaryReader.ReadSingle();
            cameraExclusionDistanceWorldUnits = binaryReader.ReadSingle();
            autoaimWidthWorldUnits = binaryReader.ReadSingle();
            lockOnData = new BipedLockOnDataStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(lockOnData.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(16);
            headShotAccScale = binaryReader.ReadSingle();
            areaDamageEffect = binaryReader.ReadTagReference();
            physics = new CharacterPhysicsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(physics.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<ContactPointBlock>(binaryReader));
            reanimationCharacter = binaryReader.ReadTagReference();
            deathSpawnCharacter = binaryReader.ReadTagReference();
            deathSpawnCount = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lockOnData.ReadPointers(binaryReader, blamPointers);
            physics.ReadPointers(binaryReader, blamPointers);
            contactPoints = ReadBlockArrayData<ContactPointBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(movingTurningSpeedDegreesPerSecond);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(stationaryTurningThreshold);
                binaryWriter.Write(jumpVelocityWorldUnitsPerSecond);
                binaryWriter.Write(maximumSoftLandingTimeSeconds);
                binaryWriter.Write(maximumHardLandingTimeSeconds);
                binaryWriter.Write(minimumSoftLandingVelocityWorldUnitsPerSecond);
                binaryWriter.Write(minimumHardLandingVelocityWorldUnitsPerSecond);
                binaryWriter.Write(maximumHardLandingVelocityWorldUnitsPerSecond);
                binaryWriter.Write(deathHardLandingVelocityWorldUnitsPerSecond);
                binaryWriter.Write(stunDuration);
                binaryWriter.Write(standingCameraHeightWorldUnits);
                binaryWriter.Write(crouchingCameraHeightWorldUnits);
                binaryWriter.Write(crouchTransitionTimeSeconds);
                binaryWriter.Write(cameraInterpolationStartDegrees);
                binaryWriter.Write(cameraInterpolationEndDegrees);
                binaryWriter.Write(cameraForwardMovementScale);
                binaryWriter.Write(cameraSideMovementScale);
                binaryWriter.Write(cameraVerticalMovementScale);
                binaryWriter.Write(cameraExclusionDistanceWorldUnits);
                binaryWriter.Write(autoaimWidthWorldUnits);
                lockOnData.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(headShotAccScale);
                binaryWriter.Write(areaDamageEffect);
                physics.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<ContactPointBlock>(binaryWriter, contactPoints, nextAddress);
                binaryWriter.Write(reanimationCharacter);
                binaryWriter.Write(deathSpawnCharacter);
                binaryWriter.Write(deathSpawnCount);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
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
