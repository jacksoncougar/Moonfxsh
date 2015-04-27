// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Unit = (TagClass)"unit";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("unit")]
    public partial class UnitBlock : UnitBlockBase
    {
        public  UnitBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 304, Alignment = 4)]
    public class UnitBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal DefaultTeam defaultTeam;
        internal ConstantSoundVolume constantSoundVolume;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference integratedLightToggle;
        internal float cameraFieldOfViewDegrees;
        internal float cameraStiffness;
        internal UnitCameraStructBlock unitCamera;
        internal UnitSeatAccelerationStructBlock acceleration;
        internal float softPingThreshold01;
        internal float softPingInterruptTimeSeconds;
        internal float hardPingThreshold01;
        internal float hardPingInterruptTimeSeconds;
        internal float hardDeathThreshold01;
        internal float feignDeathThreshold01;
        internal float feignDeathTimeSeconds;
        /// <summary>
        /// this must be set to tell the AI how far it should expect our evade animation to move us
        /// </summary>
        internal float distanceOfEvadeAnimWorldUnits;
        /// <summary>
        /// this must be set to tell the AI how far it should expect our dive animation to move us
        /// </summary>
        internal float distanceOfDiveAnimWorldUnits;
        /// <summary>
        /// if we take this much damage in a short space of time we will play our 'stunned movement' animations
        /// </summary>
        internal float stunnedMovementThreshold01;
        internal float feignDeathChance01;
        internal float feignRepeatChance01;
        /// <summary>
        /// automatically created character when this unit is driven
        /// </summary>
        [TagReference("char")]
        internal Moonfish.Tags.TagReference spawnedTurretCharacter;
        /// <summary>
        /// number of actors which we spawn
        /// </summary>
        internal int spawnedActorCount;
        /// <summary>
        /// velocity at which we throw spawned actors
        /// </summary>
        internal float spawnedVelocity;
        internal float aimingVelocityMaximumDegreesPerSecond;
        internal float aimingAccelerationMaximumDegreesPerSecondSquared;
        internal float casualAimingModifier01;
        internal float lookingVelocityMaximumDegreesPerSecond;
        internal float lookingAccelerationMaximumDegreesPerSecondSquared;
        /// <summary>
        /// where the primary weapon is attached
        /// </summary>
        internal Moonfish.Tags.StringID rightHandNode;
        /// <summary>
        /// where the seconday weapon is attached (for dual-pistol modes)
        /// </summary>
        internal Moonfish.Tags.StringID leftHandNode;
        internal UnitAdditionalNodeNamesStructBlock moreDamnNodes;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference meleeDamage;
        internal UnitBoardingMeleeStructBlock yourMomma;
        internal MotionSensorBlipSize motionSensorBlipSize;
        internal byte[] invalidName_;
        internal UnitPosturesBlock[] postures;
        internal UnitHudReferenceBlock[] nEWHUDINTERFACES;
        internal DialogueVariantBlock[] dialogueVariants;
        internal float grenadeVelocityWorldUnitsPerSecond;
        internal GrenadeType grenadeType;
        internal short grenadeCount;
        internal PoweredSeatBlock[] poweredSeats;
        internal UnitWeaponBlock[] weapons;
        internal UnitSeatBlock[] seats;
        internal UnitBoostStructBlock boost;
        internal UnitLipsyncScalesStructBlock lipsync;
        
        public override int SerializedSize{get { return 304; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            defaultTeam = (DefaultTeam)binaryReader.ReadInt16();
            constantSoundVolume = (ConstantSoundVolume)binaryReader.ReadInt16();
            integratedLightToggle = binaryReader.ReadTagReference();
            cameraFieldOfViewDegrees = binaryReader.ReadSingle();
            cameraStiffness = binaryReader.ReadSingle();
            unitCamera = new UnitCameraStructBlock(binaryReader);
            acceleration = new UnitSeatAccelerationStructBlock(binaryReader);
            softPingThreshold01 = binaryReader.ReadSingle();
            softPingInterruptTimeSeconds = binaryReader.ReadSingle();
            hardPingThreshold01 = binaryReader.ReadSingle();
            hardPingInterruptTimeSeconds = binaryReader.ReadSingle();
            hardDeathThreshold01 = binaryReader.ReadSingle();
            feignDeathThreshold01 = binaryReader.ReadSingle();
            feignDeathTimeSeconds = binaryReader.ReadSingle();
            distanceOfEvadeAnimWorldUnits = binaryReader.ReadSingle();
            distanceOfDiveAnimWorldUnits = binaryReader.ReadSingle();
            stunnedMovementThreshold01 = binaryReader.ReadSingle();
            feignDeathChance01 = binaryReader.ReadSingle();
            feignRepeatChance01 = binaryReader.ReadSingle();
            spawnedTurretCharacter = binaryReader.ReadTagReference();
            spawnedActorCount = binaryReader.ReadInt32();
            spawnedVelocity = binaryReader.ReadSingle();
            aimingVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            aimingAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            casualAimingModifier01 = binaryReader.ReadSingle();
            lookingVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            lookingAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            rightHandNode = binaryReader.ReadStringID();
            leftHandNode = binaryReader.ReadStringID();
            moreDamnNodes = new UnitAdditionalNodeNamesStructBlock(binaryReader);
            meleeDamage = binaryReader.ReadTagReference();
            yourMomma = new UnitBoardingMeleeStructBlock(binaryReader);
            motionSensorBlipSize = (MotionSensorBlipSize)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            postures = Guerilla.ReadBlockArray<UnitPosturesBlock>(binaryReader);
            nEWHUDINTERFACES = Guerilla.ReadBlockArray<UnitHudReferenceBlock>(binaryReader);
            dialogueVariants = Guerilla.ReadBlockArray<DialogueVariantBlock>(binaryReader);
            grenadeVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            grenadeType = (GrenadeType)binaryReader.ReadInt16();
            grenadeCount = binaryReader.ReadInt16();
            poweredSeats = Guerilla.ReadBlockArray<PoweredSeatBlock>(binaryReader);
            weapons = Guerilla.ReadBlockArray<UnitWeaponBlock>(binaryReader);
            seats = Guerilla.ReadBlockArray<UnitSeatBlock>(binaryReader);
            boost = new UnitBoostStructBlock(binaryReader);
            lipsync = new UnitLipsyncScalesStructBlock(binaryReader);
        }
        public  UnitBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            defaultTeam = (DefaultTeam)binaryReader.ReadInt16();
            constantSoundVolume = (ConstantSoundVolume)binaryReader.ReadInt16();
            integratedLightToggle = binaryReader.ReadTagReference();
            cameraFieldOfViewDegrees = binaryReader.ReadSingle();
            cameraStiffness = binaryReader.ReadSingle();
            unitCamera = new UnitCameraStructBlock(binaryReader);
            acceleration = new UnitSeatAccelerationStructBlock(binaryReader);
            softPingThreshold01 = binaryReader.ReadSingle();
            softPingInterruptTimeSeconds = binaryReader.ReadSingle();
            hardPingThreshold01 = binaryReader.ReadSingle();
            hardPingInterruptTimeSeconds = binaryReader.ReadSingle();
            hardDeathThreshold01 = binaryReader.ReadSingle();
            feignDeathThreshold01 = binaryReader.ReadSingle();
            feignDeathTimeSeconds = binaryReader.ReadSingle();
            distanceOfEvadeAnimWorldUnits = binaryReader.ReadSingle();
            distanceOfDiveAnimWorldUnits = binaryReader.ReadSingle();
            stunnedMovementThreshold01 = binaryReader.ReadSingle();
            feignDeathChance01 = binaryReader.ReadSingle();
            feignRepeatChance01 = binaryReader.ReadSingle();
            spawnedTurretCharacter = binaryReader.ReadTagReference();
            spawnedActorCount = binaryReader.ReadInt32();
            spawnedVelocity = binaryReader.ReadSingle();
            aimingVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            aimingAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            casualAimingModifier01 = binaryReader.ReadSingle();
            lookingVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            lookingAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            rightHandNode = binaryReader.ReadStringID();
            leftHandNode = binaryReader.ReadStringID();
            moreDamnNodes = new UnitAdditionalNodeNamesStructBlock(binaryReader);
            meleeDamage = binaryReader.ReadTagReference();
            yourMomma = new UnitBoardingMeleeStructBlock(binaryReader);
            motionSensorBlipSize = (MotionSensorBlipSize)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            postures = Guerilla.ReadBlockArray<UnitPosturesBlock>(binaryReader);
            nEWHUDINTERFACES = Guerilla.ReadBlockArray<UnitHudReferenceBlock>(binaryReader);
            dialogueVariants = Guerilla.ReadBlockArray<DialogueVariantBlock>(binaryReader);
            grenadeVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            grenadeType = (GrenadeType)binaryReader.ReadInt16();
            grenadeCount = binaryReader.ReadInt16();
            poweredSeats = Guerilla.ReadBlockArray<PoweredSeatBlock>(binaryReader);
            weapons = Guerilla.ReadBlockArray<UnitWeaponBlock>(binaryReader);
            seats = Guerilla.ReadBlockArray<UnitSeatBlock>(binaryReader);
            boost = new UnitBoostStructBlock(binaryReader);
            lipsync = new UnitLipsyncScalesStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)defaultTeam);
                binaryWriter.Write((Int16)constantSoundVolume);
                binaryWriter.Write(integratedLightToggle);
                binaryWriter.Write(cameraFieldOfViewDegrees);
                binaryWriter.Write(cameraStiffness);
                unitCamera.Write(binaryWriter);
                acceleration.Write(binaryWriter);
                binaryWriter.Write(softPingThreshold01);
                binaryWriter.Write(softPingInterruptTimeSeconds);
                binaryWriter.Write(hardPingThreshold01);
                binaryWriter.Write(hardPingInterruptTimeSeconds);
                binaryWriter.Write(hardDeathThreshold01);
                binaryWriter.Write(feignDeathThreshold01);
                binaryWriter.Write(feignDeathTimeSeconds);
                binaryWriter.Write(distanceOfEvadeAnimWorldUnits);
                binaryWriter.Write(distanceOfDiveAnimWorldUnits);
                binaryWriter.Write(stunnedMovementThreshold01);
                binaryWriter.Write(feignDeathChance01);
                binaryWriter.Write(feignRepeatChance01);
                binaryWriter.Write(spawnedTurretCharacter);
                binaryWriter.Write(spawnedActorCount);
                binaryWriter.Write(spawnedVelocity);
                binaryWriter.Write(aimingVelocityMaximumDegreesPerSecond);
                binaryWriter.Write(aimingAccelerationMaximumDegreesPerSecondSquared);
                binaryWriter.Write(casualAimingModifier01);
                binaryWriter.Write(lookingVelocityMaximumDegreesPerSecond);
                binaryWriter.Write(lookingAccelerationMaximumDegreesPerSecondSquared);
                binaryWriter.Write(rightHandNode);
                binaryWriter.Write(leftHandNode);
                moreDamnNodes.Write(binaryWriter);
                binaryWriter.Write(meleeDamage);
                yourMomma.Write(binaryWriter);
                binaryWriter.Write((Int16)motionSensorBlipSize);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<UnitPosturesBlock>(binaryWriter, postures, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UnitHudReferenceBlock>(binaryWriter, nEWHUDINTERFACES, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DialogueVariantBlock>(binaryWriter, dialogueVariants, nextAddress);
                binaryWriter.Write(grenadeVelocityWorldUnitsPerSecond);
                binaryWriter.Write((Int16)grenadeType);
                binaryWriter.Write(grenadeCount);
                nextAddress = Guerilla.WriteBlockArray<PoweredSeatBlock>(binaryWriter, poweredSeats, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UnitWeaponBlock>(binaryWriter, weapons, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UnitSeatBlock>(binaryWriter, seats, nextAddress);
                boost.Write(binaryWriter);
                lipsync.Write(binaryWriter);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            CircularAiming = 1,
            DestroyedAfterDying = 2,
            HalfSpeedInterpolation = 4,
            FiresFromCamera = 8,
            EntranceInsideBoundingSphere = 16,
            DoesntShowReadiedWeapon = 32,
            CausesPassengerDialogue = 64,
            ResistsPings = 128,
            MeleeAttackIsFatal = 256,
            DontRefaceDuringPings = 512,
            HasNoAiming = 1024,
            SimpleCreature = 2048,
            ImpactMeleeAttachesToUnit = 4096,
            ImpactMeleeDiesOnShields = 8192,
            CannotOpenDoorsAutomatically = 16384,
            MeleeAttackersCannotAttach = 32768,
            NotInstantlyKilledByMelee = 65536,
            ShieldSapping = 131072,
            RunsAroundFlaming = 262144,
            Inconsequential = 524288,
            SpecialCinematicUnit = 1048576,
            IgnoredByAutoaiming = 2097152,
            ShieldsFryInfectionForms = 4194304,
            Unused = 8388608,
            Unused0 = 16777216,
            ActsAsGunnerForParent = 33554432,
            ControlledByParentGunner = 67108864,
            ParentsPrimaryWeapon = 134217728,
            UnitHasBoost = 268435456,
        };
        internal enum DefaultTeam : short
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
        };
        internal enum ConstantSoundVolume : short
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        };
        internal enum MotionSensorBlipSize : short
        {
            Medium = 0,
            Small = 1,
            Large = 2,
        };
        internal enum GrenadeType : short
        {
            HumanFragmentation = 0,
            CovenantPlasma = 1,
        };
    };
}
