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
        public static readonly TagClass Weap = (TagClass)"weap";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("weap")]
    public partial class WeaponBlock : WeaponBlockBase
    {
        public  WeaponBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 496, Alignment = 4)]
    public class WeaponBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 496; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadStringID();
            secondaryTriggerMode = (SecondaryTriggerMode)binaryReader.ReadInt16();
            maximumAlternateShotsLoaded = binaryReader.ReadInt16();
            turnOnTime = binaryReader.ReadSingle();
            readyTimeSeconds = binaryReader.ReadSingle();
            readyEffect = binaryReader.ReadTagReference();
            readyDamageEffect = binaryReader.ReadTagReference();
            heatRecoveryThreshold01 = binaryReader.ReadSingle();
            overheatedThreshold01 = binaryReader.ReadSingle();
            heatDetonationThreshold01 = binaryReader.ReadSingle();
            heatDetonationFraction01 = binaryReader.ReadSingle();
            heatLossPerSecond01 = binaryReader.ReadSingle();
            heatIllumination01 = binaryReader.ReadSingle();
            overheatedHeatLossPerSecond01 = binaryReader.ReadSingle();
            overheated = binaryReader.ReadTagReference();
            overheatedDamageEffect = binaryReader.ReadTagReference();
            detonation = binaryReader.ReadTagReference();
            detonationDamageEffect = binaryReader.ReadTagReference();
            playerMeleeDamage = binaryReader.ReadTagReference();
            playerMeleeResponse = binaryReader.ReadTagReference();
            meleeAimAssist = new MeleeAimAssistStructBlock(binaryReader);
            meleeDamageParameters = new MeleeDamageParametersStructBlock(binaryReader);
            meleeDamageReportingType = (MeleeDamageReportingType)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(1);
            magnificationLevels = binaryReader.ReadInt16();
            magnificationRange = binaryReader.ReadRange();
            weaponAimAssist = new AimAssistStructBlock(binaryReader);
            movementPenalized = (MovementPenalized)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            forwardMovementPenalty = binaryReader.ReadSingle();
            sidewaysMovementPenalty = binaryReader.ReadSingle();
            aIScariness = binaryReader.ReadSingle();
            weaponPowerOnTimeSeconds = binaryReader.ReadSingle();
            weaponPowerOffTimeSeconds = binaryReader.ReadSingle();
            weaponPowerOnEffect = binaryReader.ReadTagReference();
            weaponPowerOffEffect = binaryReader.ReadTagReference();
            ageHeatRecoveryPenalty = binaryReader.ReadSingle();
            ageRateOfFirePenalty = binaryReader.ReadSingle();
            ageMisfireStart01 = binaryReader.ReadSingle();
            ageMisfireChance01 = binaryReader.ReadSingle();
            pickupSound = binaryReader.ReadTagReference();
            zoomInSound = binaryReader.ReadTagReference();
            zoomOutSound = binaryReader.ReadTagReference();
            activeCamoDing = binaryReader.ReadSingle();
            activeCamoRegrowthRate = binaryReader.ReadSingle();
            handleNode = binaryReader.ReadStringID();
            weaponClass = binaryReader.ReadStringID();
            weaponName = binaryReader.ReadStringID();
            multiplayerWeaponType = (MultiplayerWeaponType)binaryReader.ReadInt16();
            weaponType = (WeaponType)binaryReader.ReadInt16();
            tracking = new WeaponTrackingStructBlock(binaryReader);
            playerInterface = new WeaponInterfaceStructBlock(binaryReader);
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            magazines = Guerilla.ReadBlockArray<Magazines>(binaryReader);
            newTriggers = Guerilla.ReadBlockArray<WeaponTriggers>(binaryReader);
            barrels = Guerilla.ReadBlockArray<WeaponBarrels>(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(8);
            maxMovementAcceleration = binaryReader.ReadSingle();
            maxMovementVelocity = binaryReader.ReadSingle();
            maxTurningAcceleration = binaryReader.ReadSingle();
            maxTurningVelocity = binaryReader.ReadSingle();
            deployedVehicle = binaryReader.ReadTagReference();
            ageEffect = binaryReader.ReadTagReference();
            agedWeapon = binaryReader.ReadTagReference();
            firstPersonWeaponOffset = binaryReader.ReadVector3();
            firstPersonScopeSize = binaryReader.ReadVector2();
        }
        public  WeaponBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadStringID();
            secondaryTriggerMode = (SecondaryTriggerMode)binaryReader.ReadInt16();
            maximumAlternateShotsLoaded = binaryReader.ReadInt16();
            turnOnTime = binaryReader.ReadSingle();
            readyTimeSeconds = binaryReader.ReadSingle();
            readyEffect = binaryReader.ReadTagReference();
            readyDamageEffect = binaryReader.ReadTagReference();
            heatRecoveryThreshold01 = binaryReader.ReadSingle();
            overheatedThreshold01 = binaryReader.ReadSingle();
            heatDetonationThreshold01 = binaryReader.ReadSingle();
            heatDetonationFraction01 = binaryReader.ReadSingle();
            heatLossPerSecond01 = binaryReader.ReadSingle();
            heatIllumination01 = binaryReader.ReadSingle();
            overheatedHeatLossPerSecond01 = binaryReader.ReadSingle();
            overheated = binaryReader.ReadTagReference();
            overheatedDamageEffect = binaryReader.ReadTagReference();
            detonation = binaryReader.ReadTagReference();
            detonationDamageEffect = binaryReader.ReadTagReference();
            playerMeleeDamage = binaryReader.ReadTagReference();
            playerMeleeResponse = binaryReader.ReadTagReference();
            meleeAimAssist = new MeleeAimAssistStructBlock(binaryReader);
            meleeDamageParameters = new MeleeDamageParametersStructBlock(binaryReader);
            meleeDamageReportingType = (MeleeDamageReportingType)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(1);
            magnificationLevels = binaryReader.ReadInt16();
            magnificationRange = binaryReader.ReadRange();
            weaponAimAssist = new AimAssistStructBlock(binaryReader);
            movementPenalized = (MovementPenalized)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            forwardMovementPenalty = binaryReader.ReadSingle();
            sidewaysMovementPenalty = binaryReader.ReadSingle();
            aIScariness = binaryReader.ReadSingle();
            weaponPowerOnTimeSeconds = binaryReader.ReadSingle();
            weaponPowerOffTimeSeconds = binaryReader.ReadSingle();
            weaponPowerOnEffect = binaryReader.ReadTagReference();
            weaponPowerOffEffect = binaryReader.ReadTagReference();
            ageHeatRecoveryPenalty = binaryReader.ReadSingle();
            ageRateOfFirePenalty = binaryReader.ReadSingle();
            ageMisfireStart01 = binaryReader.ReadSingle();
            ageMisfireChance01 = binaryReader.ReadSingle();
            pickupSound = binaryReader.ReadTagReference();
            zoomInSound = binaryReader.ReadTagReference();
            zoomOutSound = binaryReader.ReadTagReference();
            activeCamoDing = binaryReader.ReadSingle();
            activeCamoRegrowthRate = binaryReader.ReadSingle();
            handleNode = binaryReader.ReadStringID();
            weaponClass = binaryReader.ReadStringID();
            weaponName = binaryReader.ReadStringID();
            multiplayerWeaponType = (MultiplayerWeaponType)binaryReader.ReadInt16();
            weaponType = (WeaponType)binaryReader.ReadInt16();
            tracking = new WeaponTrackingStructBlock(binaryReader);
            playerInterface = new WeaponInterfaceStructBlock(binaryReader);
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            magazines = Guerilla.ReadBlockArray<Magazines>(binaryReader);
            newTriggers = Guerilla.ReadBlockArray<WeaponTriggers>(binaryReader);
            barrels = Guerilla.ReadBlockArray<WeaponBarrels>(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(8);
            maxMovementAcceleration = binaryReader.ReadSingle();
            maxMovementVelocity = binaryReader.ReadSingle();
            maxTurningAcceleration = binaryReader.ReadSingle();
            maxTurningVelocity = binaryReader.ReadSingle();
            deployedVehicle = binaryReader.ReadTagReference();
            ageEffect = binaryReader.ReadTagReference();
            agedWeapon = binaryReader.ReadTagReference();
            firstPersonWeaponOffset = binaryReader.ReadVector3();
            firstPersonScopeSize = binaryReader.ReadVector2();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write((Int16)secondaryTriggerMode);
                binaryWriter.Write(maximumAlternateShotsLoaded);
                binaryWriter.Write(turnOnTime);
                binaryWriter.Write(readyTimeSeconds);
                binaryWriter.Write(readyEffect);
                binaryWriter.Write(readyDamageEffect);
                binaryWriter.Write(heatRecoveryThreshold01);
                binaryWriter.Write(overheatedThreshold01);
                binaryWriter.Write(heatDetonationThreshold01);
                binaryWriter.Write(heatDetonationFraction01);
                binaryWriter.Write(heatLossPerSecond01);
                binaryWriter.Write(heatIllumination01);
                binaryWriter.Write(overheatedHeatLossPerSecond01);
                binaryWriter.Write(overheated);
                binaryWriter.Write(overheatedDamageEffect);
                binaryWriter.Write(detonation);
                binaryWriter.Write(detonationDamageEffect);
                binaryWriter.Write(playerMeleeDamage);
                binaryWriter.Write(playerMeleeResponse);
                meleeAimAssist.Write(binaryWriter);
                meleeDamageParameters.Write(binaryWriter);
                binaryWriter.Write((Byte)meleeDamageReportingType);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(magnificationLevels);
                binaryWriter.Write(magnificationRange);
                weaponAimAssist.Write(binaryWriter);
                binaryWriter.Write((Int16)movementPenalized);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(forwardMovementPenalty);
                binaryWriter.Write(sidewaysMovementPenalty);
                binaryWriter.Write(aIScariness);
                binaryWriter.Write(weaponPowerOnTimeSeconds);
                binaryWriter.Write(weaponPowerOffTimeSeconds);
                binaryWriter.Write(weaponPowerOnEffect);
                binaryWriter.Write(weaponPowerOffEffect);
                binaryWriter.Write(ageHeatRecoveryPenalty);
                binaryWriter.Write(ageRateOfFirePenalty);
                binaryWriter.Write(ageMisfireStart01);
                binaryWriter.Write(ageMisfireChance01);
                binaryWriter.Write(pickupSound);
                binaryWriter.Write(zoomInSound);
                binaryWriter.Write(zoomOutSound);
                binaryWriter.Write(activeCamoDing);
                binaryWriter.Write(activeCamoRegrowthRate);
                binaryWriter.Write(handleNode);
                binaryWriter.Write(weaponClass);
                binaryWriter.Write(weaponName);
                binaryWriter.Write((Int16)multiplayerWeaponType);
                binaryWriter.Write((Int16)weaponType);
                tracking.Write(binaryWriter);
                playerInterface.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<PredictedResourceBlock>(binaryWriter, predictedResources, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<Magazines>(binaryWriter, magazines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponTriggers>(binaryWriter, newTriggers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponBarrels>(binaryWriter, barrels, nextAddress);
                binaryWriter.Write(invalidName_2, 0, 8);
                binaryWriter.Write(maxMovementAcceleration);
                binaryWriter.Write(maxMovementVelocity);
                binaryWriter.Write(maxTurningAcceleration);
                binaryWriter.Write(maxTurningVelocity);
                binaryWriter.Write(deployedVehicle);
                binaryWriter.Write(ageEffect);
                binaryWriter.Write(agedWeapon);
                binaryWriter.Write(firstPersonWeaponOffset);
                binaryWriter.Write(firstPersonScopeSize);
                return nextAddress;
            }
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
