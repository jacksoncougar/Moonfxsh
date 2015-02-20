using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("unit")]
    public  partial class UnitBlock : UnitBlockBase
    {
        public  UnitBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 304)]
    public class UnitBlockBase : ObjectBlock
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
        internal  UnitBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.defaultTeam = (DefaultTeam)binaryReader.ReadInt16();
            this.constantSoundVolume = (ConstantSoundVolume)binaryReader.ReadInt16();
            this.integratedLightToggle = binaryReader.ReadTagReference();
            this.cameraFieldOfViewDegrees = binaryReader.ReadSingle();
            this.cameraStiffness = binaryReader.ReadSingle();
            this.unitCamera = new UnitCameraStructBlock(binaryReader);
            this.acceleration = new UnitSeatAccelerationStructBlock(binaryReader);
            this.softPingThreshold01 = binaryReader.ReadSingle();
            this.softPingInterruptTimeSeconds = binaryReader.ReadSingle();
            this.hardPingThreshold01 = binaryReader.ReadSingle();
            this.hardPingInterruptTimeSeconds = binaryReader.ReadSingle();
            this.hardDeathThreshold01 = binaryReader.ReadSingle();
            this.feignDeathThreshold01 = binaryReader.ReadSingle();
            this.feignDeathTimeSeconds = binaryReader.ReadSingle();
            this.distanceOfEvadeAnimWorldUnits = binaryReader.ReadSingle();
            this.distanceOfDiveAnimWorldUnits = binaryReader.ReadSingle();
            this.stunnedMovementThreshold01 = binaryReader.ReadSingle();
            this.feignDeathChance01 = binaryReader.ReadSingle();
            this.feignRepeatChance01 = binaryReader.ReadSingle();
            this.spawnedTurretCharacter = binaryReader.ReadTagReference();
            this.spawnedActorCount = binaryReader.ReadInt32();
            this.spawnedVelocity = binaryReader.ReadSingle();
            this.aimingVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            this.aimingAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            this.casualAimingModifier01 = binaryReader.ReadSingle();
            this.lookingVelocityMaximumDegreesPerSecond = binaryReader.ReadSingle();
            this.lookingAccelerationMaximumDegreesPerSecondSquared = binaryReader.ReadSingle();
            this.rightHandNode = binaryReader.ReadStringID();
            this.leftHandNode = binaryReader.ReadStringID();
            this.moreDamnNodes = new UnitAdditionalNodeNamesStructBlock(binaryReader);
            this.meleeDamage = binaryReader.ReadTagReference();
            this.yourMomma = new UnitBoardingMeleeStructBlock(binaryReader);
            this.motionSensorBlipSize = (MotionSensorBlipSize)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.postures = ReadUnitPosturesBlockArray(binaryReader);
            this.nEWHUDINTERFACES = ReadUnitHudReferenceBlockArray(binaryReader);
            this.dialogueVariants = ReadDialogueVariantBlockArray(binaryReader);
            this.grenadeVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.grenadeType = (GrenadeType)binaryReader.ReadInt16();
            this.grenadeCount = binaryReader.ReadInt16();
            this.poweredSeats = ReadPoweredSeatBlockArray(binaryReader);
            this.weapons = ReadUnitWeaponBlockArray(binaryReader);
            this.seats = ReadUnitSeatBlockArray(binaryReader);
            this.boost = new UnitBoostStructBlock(binaryReader);
            this.lipsync = new UnitLipsyncScalesStructBlock(binaryReader);
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
        internal  virtual UnitPosturesBlock[] ReadUnitPosturesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitPosturesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitPosturesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitPosturesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UnitHudReferenceBlock[] ReadUnitHudReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitHudReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitHudReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitHudReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DialogueVariantBlock[] ReadDialogueVariantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DialogueVariantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DialogueVariantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DialogueVariantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PoweredSeatBlock[] ReadPoweredSeatBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PoweredSeatBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PoweredSeatBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PoweredSeatBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UnitWeaponBlock[] ReadUnitWeaponBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitWeaponBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitWeaponBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitWeaponBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UnitSeatBlock[] ReadUnitSeatBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitSeatBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitSeatBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitSeatBlock(binaryReader);
                }
            }
            return array;
        }
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
