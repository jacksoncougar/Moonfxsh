using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponBarrels : WeaponBarrelsBase
    {
        public  WeaponBarrels(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 236)]
    public class WeaponBarrelsBase
    {
        internal Flags flags;
        /// <summary>
        /// the number of firing effects created per second
        /// </summary>
        internal Moonfish.Model.Range roundsPerSecond;
        /// <summary>
        /// the continuous firing time it takes for the weapon to achieve its final rounds per second
        /// </summary>
        internal float accelerationTimeSeconds;
        /// <summary>
        /// the continuous idle time it takes for the weapon to return from its final rounds per second to its initial
        /// </summary>
        internal float decelerationTimeSeconds;
        /// <summary>
        /// scale the barrel spin speed by this amount
        /// </summary>
        internal float barrelSpinScale;
        /// <summary>
        /// a percentage between 0 and 1 which controls how soon in its firing animation the weapon blurs
        /// </summary>
        internal float blurredRateOfFire;
        /// <summary>
        /// allows designer caps to the shots you can fire from one firing action
        /// </summary>
        internal int shotsPerFire;
        /// <summary>
        /// how long after a set of shots it takes before the barrel can fire again
        /// </summary>
        internal float fireRecoveryTimeSeconds;
        /// <summary>
        /// how much of the recovery allows shots to be queued
        /// </summary>
        internal float softRecoveryFraction;
        /// <summary>
        /// the magazine from which this trigger draws its ammunition
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 magazine;
        /// <summary>
        /// the number of rounds expended to create a single firing effect
        /// </summary>
        internal short roundsPerShot;
        /// <summary>
        /// the minimum number of rounds necessary to fire the weapon
        /// </summary>
        internal short minimumRoundsLoaded;
        /// <summary>
        /// the number of non-tracer rounds fired between tracers
        /// </summary>
        internal short roundsBetweenTracers;
        internal Moonfish.Tags.StringID optionalBarrelMarkerName;
        internal PredictionType predictionType;
        /// <summary>
        /// how loud this weapon appears to the AI
        /// </summary>
        internal FiringNoiseHowLoudThisWeaponAppearsToTheAI firingNoise;
        /// <summary>
        /// the continuous firing time it takes for the weapon to achieve its final error
        /// </summary>
        internal float accelerationTimeSeconds0;
        /// <summary>
        /// the continuous idle time it takes for the weapon to return to its initial error
        /// </summary>
        internal float decelerationTimeSeconds0;
        /// <summary>
        /// the range of angles (in degrees) that a damaged weapon will skew fire
        /// </summary>
        internal Moonfish.Model.Range damageError;
        /// <summary>
        /// the continuous firing time it takes for the weapon to achieve its final error
        /// </summary>
        internal float accelerationTimeSeconds1;
        /// <summary>
        /// the continuous idle time it takes for the weapon to return to its initial error
        /// </summary>
        internal float decelerationTimeSeconds1;
        internal byte[] invalidName_;
        internal float minimumErrorDegrees;
        internal Moonfish.Model.Range errorAngleDegrees;
        internal float dualWieldDamageScale;
        internal DistributionFunction distributionFunction;
        internal short projectilesPerShot;
        internal float distributionAngleDegrees;
        internal float minimumErrorDegrees0;
        internal Moonfish.Model.Range errorAngleDegrees0;
        /// <summary>
        /// +x is forward, +z is up, +y is left
        /// </summary>
        internal OpenTK.Vector3 firstPersonOffsetWorldUnits;
        internal DamageEffectReportingType damageEffectReportingType;
        internal byte[] invalidName_0;
        [TagReference("proj")]
        internal Moonfish.Tags.TagReference projectile;
        internal WeaponBarrelDamageEffectStructBlock eh;
        /// <summary>
        /// the amount of time (in seconds) it takes for the ejection port to transition from 1.0 (open) to 0.0 (closed) after a shot has been fired
        /// </summary>
        internal float ejectionPortRecoveryTime;
        /// <summary>
        /// the amount of time (in seconds) it takes the illumination function to transition from 1.0 (bright) to 0.0 (dark) after a shot has been fired
        /// </summary>
        internal float illuminationRecoveryTime;
        /// <summary>
        /// the amount of heat generated each time the trigger is fired
        /// </summary>
        internal float heatGeneratedPerRound01;
        /// <summary>
        /// the amount the weapon ages each time the trigger is fired
        /// </summary>
        internal float ageGeneratedPerRound01;
        /// <summary>
        /// the next trigger fires this often while holding down this trigger
        /// </summary>
        internal float overloadTimeSeconds;
        /// <summary>
        /// angleChangePerShot of the weapon during firing
        /// </summary>
        internal Moonfish.Model.Range angleChangePerShot;
        /// <summary>
        /// the continuous firing time it takes for the weapon to achieve its final angle change per shot
        /// </summary>
        internal float accelerationTimeSeconds2;
        /// <summary>
        /// the continuous idle time it takes for the weapon to return to its initial angle change per shot
        /// </summary>
        internal float decelerationTimeSeconds2;
        /// <summary>
        /// function used to scale between initial and final angle change per shot
        /// </summary>
        internal AngleChangeFunctionFunctionUsedToScaleBetweenInitialAndFinalAngleChangePerShot angleChangeFunction;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        /// <summary>
        /// firingEffects determine what happens when this trigger is fired
        /// </summary>
        internal BarrelFiringEffectBlock[] firingEffects;
        internal  WeaponBarrelsBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.roundsPerSecond = binaryReader.ReadRange();
            this.accelerationTimeSeconds = binaryReader.ReadSingle();
            this.decelerationTimeSeconds = binaryReader.ReadSingle();
            this.barrelSpinScale = binaryReader.ReadSingle();
            this.blurredRateOfFire = binaryReader.ReadSingle();
            this.shotsPerFire = binaryReader.ReadInt32();
            this.fireRecoveryTimeSeconds = binaryReader.ReadSingle();
            this.softRecoveryFraction = binaryReader.ReadSingle();
            this.magazine = binaryReader.ReadShortBlockIndex1();
            this.roundsPerShot = binaryReader.ReadInt16();
            this.minimumRoundsLoaded = binaryReader.ReadInt16();
            this.roundsBetweenTracers = binaryReader.ReadInt16();
            this.optionalBarrelMarkerName = binaryReader.ReadStringID();
            this.predictionType = (PredictionType)binaryReader.ReadInt16();
            this.firingNoise = (FiringNoiseHowLoudThisWeaponAppearsToTheAI)binaryReader.ReadInt16();
            this.accelerationTimeSeconds0 = binaryReader.ReadSingle();
            this.decelerationTimeSeconds0 = binaryReader.ReadSingle();
            this.damageError = binaryReader.ReadRange();
            this.accelerationTimeSeconds1 = binaryReader.ReadSingle();
            this.decelerationTimeSeconds1 = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(8);
            this.minimumErrorDegrees = binaryReader.ReadSingle();
            this.errorAngleDegrees = binaryReader.ReadRange();
            this.dualWieldDamageScale = binaryReader.ReadSingle();
            this.distributionFunction = (DistributionFunction)binaryReader.ReadInt16();
            this.projectilesPerShot = binaryReader.ReadInt16();
            this.distributionAngleDegrees = binaryReader.ReadSingle();
            this.minimumErrorDegrees0 = binaryReader.ReadSingle();
            this.errorAngleDegrees0 = binaryReader.ReadRange();
            this.firstPersonOffsetWorldUnits = binaryReader.ReadVector3();
            this.damageEffectReportingType = (DamageEffectReportingType)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(3);
            this.projectile = binaryReader.ReadTagReference();
            this.eh = new WeaponBarrelDamageEffectStructBlock(binaryReader);
            this.ejectionPortRecoveryTime = binaryReader.ReadSingle();
            this.illuminationRecoveryTime = binaryReader.ReadSingle();
            this.heatGeneratedPerRound01 = binaryReader.ReadSingle();
            this.ageGeneratedPerRound01 = binaryReader.ReadSingle();
            this.overloadTimeSeconds = binaryReader.ReadSingle();
            this.angleChangePerShot = binaryReader.ReadRange();
            this.accelerationTimeSeconds2 = binaryReader.ReadSingle();
            this.decelerationTimeSeconds2 = binaryReader.ReadSingle();
            this.angleChangeFunction = (AngleChangeFunctionFunctionUsedToScaleBetweenInitialAndFinalAngleChangePerShot)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(8);
            this.invalidName_3 = binaryReader.ReadBytes(24);
            this.firingEffects = ReadBarrelFiringEffectBlockArray(binaryReader);
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
        internal  virtual BarrelFiringEffectBlock[] ReadBarrelFiringEffectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BarrelFiringEffectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BarrelFiringEffectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BarrelFiringEffectBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            TracksFiredProjectilePooPooCaCaPeePee = 1,
            RandomFiringEffectsRatherThanBeingChosenSequentiallyFiringEffectsArePickedRandomly = 2,
            CanFireWithPartialAmmoAllowsAWeaponToBeFiredAsLongAsThereIsANonZeroAmountOfAmmunitionLoaded = 4,
            ProjectilesUseWeaponOriginInsteadOfComingOutOfTheMagicFirstPersonCameraOriginTheProjectilesForThisWeaponActuallyComeOutOfTheGun = 8,
            EjectsDuringChamberThisTriggersEjectionPortIsStartedDuringTheKeyFrameOfItsChamberAnimation = 16,
            UseErrorWhenUnzoomed = 32,
            ProjectileVectorCannotBeAdjustedProjectilesFiredByThisWeaponCannotHaveTheirDirectionAdjustedByTheAIToHitTheTarget = 64,
            ProjectilesHaveIdenticalError = 128,
            ProjectilesFireParallelIfThereAreMultipleGunsForThisTriggerTheProjectilesEmergeInParallelBeamsRatherThanIndependantAiming = 256,
            CantFireWhenOthersFiring = 512,
            CantFireWhenOthersRecovering = 1024,
            DontClearFireBitAfterRecovering = 2048,
            StaggerFireAcrossMultipleMarkers = 4096,
            FiresLockedProjectiles = 8192,
        };
        internal enum PredictionType : short
        
        {
            None = 0,
            Continuous = 1,
            Instant = 2,
        };
        internal enum FiringNoiseHowLoudThisWeaponAppearsToTheAI : short
        
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        };
        internal enum DistributionFunction : short
        
        {
            Point = 0,
            HorizontalFan = 1,
        };
        internal enum DamageEffectReportingType : byte
        
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
        internal enum AngleChangeFunctionFunctionUsedToScaleBetweenInitialAndFinalAngleChangePerShot : short
        
        {
            Linear = 0,
            Early = 1,
            VeryEarly = 2,
            Late = 3,
            VeryLate = 4,
            Cosine = 5,
            One = 6,
            Zero = 7,
        };
    };
}
