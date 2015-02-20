using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("weap")]
    public  partial class WeaponBlock : WeaponBlockBase
    {
        public  WeaponBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 496)]
    public class WeaponBlockBase : ItemBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.StringID invalidName_;
        internal SecondaryTriggerMode secondaryTriggerMode;
        /// <summary>
        /// if the second trigger loads alternate ammunition, this is the maximum number of shots that can be loaded at a time
        /// </summary>
        internal short maximumAlternateShotsLoaded;
        /// <summary>
        /// how long after being readied it takes this weapon to switch its 'turned_on' attachment to 1.0
        /// </summary>
        internal float turnOnTime;
        internal float readyTimeSeconds;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference readyEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference readyDamageEffect;
        /// <summary>
        /// the heat value a weapon must return to before leaving the overheated state, once it has become overheated in the first place
        /// </summary>
        internal float heatRecoveryThreshold01;
        /// <summary>
        /// the heat value over which a weapon first becomes overheated (should be greater than the heat recovery threshold)
        /// </summary>
        internal float overheatedThreshold01;
        /// <summary>
        /// the heat value above which the weapon has a chance of exploding each time it is fired
        /// </summary>
        internal float heatDetonationThreshold01;
        /// <summary>
        /// the percent chance (between 0.0 and 1.0) the weapon will explode when fired over the heat detonation threshold
        /// </summary>
        internal float heatDetonationFraction01;
        /// <summary>
        /// the amount of heat lost each second when the weapon is not being fired
        /// </summary>
        internal float heatLossPerSecond01;
        /// <summary>
        /// the amount of illumination given off when the weapon is overheated
        /// </summary>
        internal float heatIllumination01;
        /// <summary>
        /// the amount of heat lost each second when the weapon is not being fired
        /// </summary>
        internal float overheatedHeatLossPerSecond01;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference overheated;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference overheatedDamageEffect;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference detonation;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference detonationDamageEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference playerMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference playerMeleeResponse;
        internal MeleeAimAssistStructBlock meleeAimAssist;
        internal MeleeDamageParametersStructBlock meleeDamageParameters;
        internal MeleeDamageReportingType meleeDamageReportingType;
        internal byte[] invalidName_0;
        /// <summary>
        /// the number of magnificationLevels this weapon allows
        /// </summary>
        internal short magnificationLevels;
        internal Moonfish.Model.Range magnificationRange;
        internal AimAssistStructBlock weaponAimAssist;
        internal MovementPenalized movementPenalized;
        internal byte[] invalidName_1;
        /// <summary>
        /// percent slowdown to forward movement for units carrying this weapon
        /// </summary>
        internal float forwardMovementPenalty;
        /// <summary>
        /// percent slowdown to sideways and backward movement for units carrying this weapon
        /// </summary>
        internal float sidewaysMovementPenalty;
        internal float aIScariness;
        internal float weaponPowerOnTimeSeconds;
        internal float weaponPowerOffTimeSeconds;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference weaponPowerOnEffect;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference weaponPowerOffEffect;
        /// <summary>
        /// how much the weapon's heat recovery is penalized as it ages
        /// </summary>
        internal float ageHeatRecoveryPenalty;
        /// <summary>
        /// how much the weapon's rate of fire is penalized as it ages
        /// </summary>
        internal float ageRateOfFirePenalty;
        /// <summary>
        /// the age threshold when the weapon begins to misfire
        /// </summary>
        internal float ageMisfireStart01;
        /// <summary>
        /// at age 1.0, the misfire chance per shot
        /// </summary>
        internal float ageMisfireChance01;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference pickupSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference zoomInSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference zoomOutSound;
        /// <summary>
        /// how much to decrease active camo when a round is fired
        /// </summary>
        internal float activeCamoDing;
        /// <summary>
        /// how fast to increase active camo (per tick) when a round is fired
        /// </summary>
        internal float activeCamoRegrowthRate;
        /// <summary>
        /// the node that get's attached to the unit's hand
        /// </summary>
        internal Moonfish.Tags.StringID handleNode;
        internal Moonfish.Tags.StringID weaponClass;
        internal Moonfish.Tags.StringID weaponName;
        internal MultiplayerWeaponType multiplayerWeaponType;
        internal WeaponType weaponType;
        internal WeaponTrackingStructBlock tracking;
        internal WeaponInterfaceStructBlock playerInterface;
        internal PredictedResourceBlock[] predictedResources;
        internal Magazines[] magazines;
        internal WeaponTriggers[] newTriggers;
        internal WeaponBarrels[] barrels;
        internal byte[] invalidName_2;
        internal float maxMovementAcceleration;
        internal float maxMovementVelocity;
        internal float maxTurningAcceleration;
        internal float maxTurningVelocity;
        [TagReference("vehi")]
        internal Moonfish.Tags.TagReference deployedVehicle;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference ageEffect;
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference agedWeapon;
        internal OpenTK.Vector3 firstPersonWeaponOffset;
        internal OpenTK.Vector2 firstPersonScopeSize;
        internal  WeaponBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadStringID();
            this.secondaryTriggerMode = (SecondaryTriggerMode)binaryReader.ReadInt16();
            this.maximumAlternateShotsLoaded = binaryReader.ReadInt16();
            this.turnOnTime = binaryReader.ReadSingle();
            this.readyTimeSeconds = binaryReader.ReadSingle();
            this.readyEffect = binaryReader.ReadTagReference();
            this.readyDamageEffect = binaryReader.ReadTagReference();
            this.heatRecoveryThreshold01 = binaryReader.ReadSingle();
            this.overheatedThreshold01 = binaryReader.ReadSingle();
            this.heatDetonationThreshold01 = binaryReader.ReadSingle();
            this.heatDetonationFraction01 = binaryReader.ReadSingle();
            this.heatLossPerSecond01 = binaryReader.ReadSingle();
            this.heatIllumination01 = binaryReader.ReadSingle();
            this.overheatedHeatLossPerSecond01 = binaryReader.ReadSingle();
            this.overheated = binaryReader.ReadTagReference();
            this.overheatedDamageEffect = binaryReader.ReadTagReference();
            this.detonation = binaryReader.ReadTagReference();
            this.detonationDamageEffect = binaryReader.ReadTagReference();
            this.playerMeleeDamage = binaryReader.ReadTagReference();
            this.playerMeleeResponse = binaryReader.ReadTagReference();
            this.meleeAimAssist = new MeleeAimAssistStructBlock(binaryReader);
            this.meleeDamageParameters = new MeleeDamageParametersStructBlock(binaryReader);
            this.meleeDamageReportingType = (MeleeDamageReportingType)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(1);
            this.magnificationLevels = binaryReader.ReadInt16();
            this.magnificationRange = binaryReader.ReadRange();
            this.weaponAimAssist = new AimAssistStructBlock(binaryReader);
            this.movementPenalized = (MovementPenalized)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.forwardMovementPenalty = binaryReader.ReadSingle();
            this.sidewaysMovementPenalty = binaryReader.ReadSingle();
            this.aIScariness = binaryReader.ReadSingle();
            this.weaponPowerOnTimeSeconds = binaryReader.ReadSingle();
            this.weaponPowerOffTimeSeconds = binaryReader.ReadSingle();
            this.weaponPowerOnEffect = binaryReader.ReadTagReference();
            this.weaponPowerOffEffect = binaryReader.ReadTagReference();
            this.ageHeatRecoveryPenalty = binaryReader.ReadSingle();
            this.ageRateOfFirePenalty = binaryReader.ReadSingle();
            this.ageMisfireStart01 = binaryReader.ReadSingle();
            this.ageMisfireChance01 = binaryReader.ReadSingle();
            this.pickupSound = binaryReader.ReadTagReference();
            this.zoomInSound = binaryReader.ReadTagReference();
            this.zoomOutSound = binaryReader.ReadTagReference();
            this.activeCamoDing = binaryReader.ReadSingle();
            this.activeCamoRegrowthRate = binaryReader.ReadSingle();
            this.handleNode = binaryReader.ReadStringID();
            this.weaponClass = binaryReader.ReadStringID();
            this.weaponName = binaryReader.ReadStringID();
            this.multiplayerWeaponType = (MultiplayerWeaponType)binaryReader.ReadInt16();
            this.weaponType = (WeaponType)binaryReader.ReadInt16();
            this.tracking = new WeaponTrackingStructBlock(binaryReader);
            this.playerInterface = new WeaponInterfaceStructBlock(binaryReader);
            this.predictedResources = ReadPredictedResourceBlockArray(binaryReader);
            this.magazines = ReadMagazinesArray(binaryReader);
            this.newTriggers = ReadWeaponTriggersArray(binaryReader);
            this.barrels = ReadWeaponBarrelsArray(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(8);
            this.maxMovementAcceleration = binaryReader.ReadSingle();
            this.maxMovementVelocity = binaryReader.ReadSingle();
            this.maxTurningAcceleration = binaryReader.ReadSingle();
            this.maxTurningVelocity = binaryReader.ReadSingle();
            this.deployedVehicle = binaryReader.ReadTagReference();
            this.ageEffect = binaryReader.ReadTagReference();
            this.agedWeapon = binaryReader.ReadTagReference();
            this.firstPersonWeaponOffset = binaryReader.ReadVector3();
            this.firstPersonScopeSize = binaryReader.ReadVector2();
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
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedResourceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual Magazines[] ReadMagazinesArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Magazines));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Magazines[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Magazines(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponTriggers[] ReadWeaponTriggersArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponTriggers));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponTriggers[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponTriggers(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponBarrels[] ReadWeaponBarrelsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponBarrels));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponBarrels[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponBarrels(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            VerticalHeatDisplay = 1,
            MutuallyExclusiveTriggers = 2,
            AttacksAutomaticallyOnBump = 4,
            MustBeReadied = 8,
            DoesntCountTowardMaximum = 16,
            AimAssistsOnlyWhenZoomed = 32,
            PreventsGrenadeThrowing = 64,
            MustBePickedUp = 128,
            HoldsTriggersWhenDropped = 256,
            PreventsMeleeAttack = 512,
            DetonatesWhenDropped = 1024,
            CannotFireAtMaximumAge = 2048,
            SecondaryTriggerOverridesGrenades = 4096,
            OBSOLETEDoesNotDepowerActiveCamoInMultilplayer = 8192,
            EnablesIntegratedNightVision = 16384,
            AIsUseWeaponMeleeDamage = 32768,
            ForcesNoBinoculars = 65536,
            LoopFpFiringAnimation = 131072,
            PreventsSprinting = 262144,
            CannotFireWhileBoosting = 524288,
            PreventsDriving = 1048576,
            PreventsGunning = 2097152,
            CanBeDualWielded = 4194304,
            CanOnlyBeDualWielded = 8388608,
            MeleeOnly = 16777216,
            CantFireIfParentDead = 33554432,
            WeaponAgesWithEachKill = 67108864,
            WeaponUsesOldDualFireErrorCode = 134217728,
            PrimaryTriggerMeleeAttacks = 268435456,
            CannotBeUsedByPlayer = 536870912,
        };
        internal enum SecondaryTriggerMode : short
        
        {
            Normal = 0,
            SlavedToPrimary = 1,
            InhibitsPrimary = 2,
            LoadsAlterateAmmunition = 3,
            LoadsMultiplePrimaryAmmunition = 4,
        };
        internal enum MeleeDamageReportingType : byte
        
        {
            TehGuardians11 = 0,
            FallingDamage = 1,
            GenericCollisionDamage = 2,
            GenericMeleeDamage = 3,
            GenericExplosion = 4,
            MagnumPistol = 5,
            PlasmaPistol = 6,
            Needler = 7,
            Smg = 8,
            PlasmaRifle = 9,
            BattleRifle = 10,
            Carbine = 11,
            Shotgun = 12,
            SniperRifle = 13,
            BeamRifle = 14,
            RocketLauncher = 15,
            FlakCannon = 16,
            BruteShot = 17,
            Disintegrator = 18,
            BrutePlasmaRifle = 19,
            EnergySword = 20,
            FragGrenade = 21,
            PlasmaGrenade = 22,
            FlagMeleeDamage = 23,
            BombMeleeDamage = 24,
            BombExplosionDamage = 25,
            BallMeleeDamage = 26,
            HumanTurret = 27,
            PlasmaTurret = 28,
            Banshee = 29,
            Ghost = 30,
            Mongoose = 31,
            Scorpion = 32,
            SpectreDriver = 33,
            SpectreGunner = 34,
            WarthogDriver = 35,
            WarthogGunner = 36,
            Wraith = 37,
            Tank = 38,
            SentinelBeam = 39,
            SentinelRpg = 40,
            Teleporter = 41,
        };
        internal enum MovementPenalized : short
        
        {
            Always = 0,
            WhenZoomed = 1,
            WhenZoomedOrReloading = 2,
        };
        internal enum MultiplayerWeaponType : short
        
        {
            None = 0,
            CtfFlag = 1,
            OddballBall = 2,
            HeadhunterHead = 3,
            JuggernautPowerup = 4,
        };
        internal enum WeaponType : short
        
        {
            Undefined = 0,
            Shotgun = 1,
            Needler = 2,
            PlasmaPistol = 3,
            PlasmaRifle = 4,
            RocketLauncher = 5,
        };
    };
}
