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
    [TagBlockOriginalNameAttribute("weapon_barrels")]
    public partial class WeaponBarrels : GuerillaBlock, IWriteQueueable
    {
        public Flags WeaponBarrelsFlags;
        public Moonfish.Model.Range RoundsPerSecond;
        public float AccelerationTime;
        public float DecelerationTime;
        public float BarrelSpinScale;
        public float BlurredRateOfFire;
        public int ShotsPerFire;
        public float FireRecoveryTime;
        public float SoftRecoveryFraction;
        public Moonfish.Tags.ShortBlockIndex1 Magazine;
        public short RoundsPerShot;
        public short MinimumRoundsLoaded;
        public short RoundsBetweenTracers;
        public Moonfish.Tags.StringIdent OptionalBarrelMarkerName;
        public PredictionTypeEnum PredictionType;
        public FiringNoiseEnum FiringNoise;
        public float AccelerationTime0;
        public float DecelerationTime0;
        public Moonfish.Model.Range DamageError;
        public float AccelerationTime1;
        public float DecelerationTime1;
        private byte[] fieldpad = new byte[8];
        public float MinimumError;
        public Moonfish.Model.Range ErrorAngle;
        public float DualWieldDamageScale;
        public DistributionFunctionEnum DistributionFunction;
        public short ProjectilesPerShot;
        public float DistributionAngle;
        public float MinimumError0;
        public Moonfish.Model.Range ErrorAngle0;
        public OpenTK.Vector3 FirstPersonOffset;
        public DamageEffectReportingTypeEnum DamageEffectReportingType;
        private byte[] fieldpad0 = new byte[3];
        [Moonfish.Tags.TagReferenceAttribute("proj")]
        public Moonfish.Tags.TagReference Projectile;
        public WeaponBarrelDamageEffectStructBlock Eh = new WeaponBarrelDamageEffectStructBlock();
        public float EjectionPortRecoveryTime;
        public float IlluminationRecoveryTime;
        public float HeatGeneratedPerRound;
        public float AgeGeneratedPerRound;
        public float OverloadTime;
        public Moonfish.Model.Range AngleChangePerShot;
        public float AccelerationTime2;
        public float DecelerationTime2;
        public AngleChangeFunctionEnum AngleChangeFunction;
        private byte[] fieldpad1 = new byte[2];
        private byte[] fieldpad2 = new byte[8];
        private byte[] fieldpad3 = new byte[24];
        public BarrelFiringEffectBlock[] FiringEffects = new BarrelFiringEffectBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 236;
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
            this.WeaponBarrelsFlags = ((Flags)(binaryReader.ReadInt32()));
            this.RoundsPerSecond = binaryReader.ReadRange();
            this.AccelerationTime = binaryReader.ReadSingle();
            this.DecelerationTime = binaryReader.ReadSingle();
            this.BarrelSpinScale = binaryReader.ReadSingle();
            this.BlurredRateOfFire = binaryReader.ReadSingle();
            this.ShotsPerFire = binaryReader.ReadInt32();
            this.FireRecoveryTime = binaryReader.ReadSingle();
            this.SoftRecoveryFraction = binaryReader.ReadSingle();
            this.Magazine = binaryReader.ReadShortBlockIndex1();
            this.RoundsPerShot = binaryReader.ReadInt16();
            this.MinimumRoundsLoaded = binaryReader.ReadInt16();
            this.RoundsBetweenTracers = binaryReader.ReadInt16();
            this.OptionalBarrelMarkerName = binaryReader.ReadStringIdent();
            this.PredictionType = ((PredictionTypeEnum)(binaryReader.ReadInt16()));
            this.FiringNoise = ((FiringNoiseEnum)(binaryReader.ReadInt16()));
            this.AccelerationTime0 = binaryReader.ReadSingle();
            this.DecelerationTime0 = binaryReader.ReadSingle();
            this.DamageError = binaryReader.ReadRange();
            this.AccelerationTime1 = binaryReader.ReadSingle();
            this.DecelerationTime1 = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(8);
            this.MinimumError = binaryReader.ReadSingle();
            this.ErrorAngle = binaryReader.ReadRange();
            this.DualWieldDamageScale = binaryReader.ReadSingle();
            this.DistributionFunction = ((DistributionFunctionEnum)(binaryReader.ReadInt16()));
            this.ProjectilesPerShot = binaryReader.ReadInt16();
            this.DistributionAngle = binaryReader.ReadSingle();
            this.MinimumError0 = binaryReader.ReadSingle();
            this.ErrorAngle0 = binaryReader.ReadRange();
            this.FirstPersonOffset = binaryReader.ReadVector3();
            this.DamageEffectReportingType = ((DamageEffectReportingTypeEnum)(binaryReader.ReadByte()));
            this.fieldpad0 = binaryReader.ReadBytes(3);
            this.Projectile = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Eh.ReadFields(binaryReader)));
            this.EjectionPortRecoveryTime = binaryReader.ReadSingle();
            this.IlluminationRecoveryTime = binaryReader.ReadSingle();
            this.HeatGeneratedPerRound = binaryReader.ReadSingle();
            this.AgeGeneratedPerRound = binaryReader.ReadSingle();
            this.OverloadTime = binaryReader.ReadSingle();
            this.AngleChangePerShot = binaryReader.ReadRange();
            this.AccelerationTime2 = binaryReader.ReadSingle();
            this.DecelerationTime2 = binaryReader.ReadSingle();
            this.AngleChangeFunction = ((AngleChangeFunctionEnum)(binaryReader.ReadInt16()));
            this.fieldpad1 = binaryReader.ReadBytes(2);
            this.fieldpad2 = binaryReader.ReadBytes(8);
            this.fieldpad3 = binaryReader.ReadBytes(24);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(52));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Eh.ReadInstances(binaryReader, pointerQueue);
            this.FiringEffects = base.ReadBlockArrayData<BarrelFiringEffectBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.Eh.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.FiringEffects);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.WeaponBarrelsFlags)));
            queueableBinaryWriter.Write(this.RoundsPerSecond);
            queueableBinaryWriter.Write(this.AccelerationTime);
            queueableBinaryWriter.Write(this.DecelerationTime);
            queueableBinaryWriter.Write(this.BarrelSpinScale);
            queueableBinaryWriter.Write(this.BlurredRateOfFire);
            queueableBinaryWriter.Write(this.ShotsPerFire);
            queueableBinaryWriter.Write(this.FireRecoveryTime);
            queueableBinaryWriter.Write(this.SoftRecoveryFraction);
            queueableBinaryWriter.Write(this.Magazine);
            queueableBinaryWriter.Write(this.RoundsPerShot);
            queueableBinaryWriter.Write(this.MinimumRoundsLoaded);
            queueableBinaryWriter.Write(this.RoundsBetweenTracers);
            queueableBinaryWriter.Write(this.OptionalBarrelMarkerName);
            queueableBinaryWriter.Write(((short)(this.PredictionType)));
            queueableBinaryWriter.Write(((short)(this.FiringNoise)));
            queueableBinaryWriter.Write(this.AccelerationTime0);
            queueableBinaryWriter.Write(this.DecelerationTime0);
            queueableBinaryWriter.Write(this.DamageError);
            queueableBinaryWriter.Write(this.AccelerationTime1);
            queueableBinaryWriter.Write(this.DecelerationTime1);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.MinimumError);
            queueableBinaryWriter.Write(this.ErrorAngle);
            queueableBinaryWriter.Write(this.DualWieldDamageScale);
            queueableBinaryWriter.Write(((short)(this.DistributionFunction)));
            queueableBinaryWriter.Write(this.ProjectilesPerShot);
            queueableBinaryWriter.Write(this.DistributionAngle);
            queueableBinaryWriter.Write(this.MinimumError0);
            queueableBinaryWriter.Write(this.ErrorAngle0);
            queueableBinaryWriter.Write(this.FirstPersonOffset);
            queueableBinaryWriter.Write(((byte)(this.DamageEffectReportingType)));
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.Projectile);
            this.Eh.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.EjectionPortRecoveryTime);
            queueableBinaryWriter.Write(this.IlluminationRecoveryTime);
            queueableBinaryWriter.Write(this.HeatGeneratedPerRound);
            queueableBinaryWriter.Write(this.AgeGeneratedPerRound);
            queueableBinaryWriter.Write(this.OverloadTime);
            queueableBinaryWriter.Write(this.AngleChangePerShot);
            queueableBinaryWriter.Write(this.AccelerationTime2);
            queueableBinaryWriter.Write(this.DecelerationTime2);
            queueableBinaryWriter.Write(((short)(this.AngleChangeFunction)));
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.Write(this.fieldpad3);
            queueableBinaryWriter.WritePointer(this.FiringEffects);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            TracksFiredProjectilepooPooCaCaPeePee = 1,
            RandomFiringEffectsratherThanBeingChosenSequentiallyFiringEffectsArePickedRandomly = 2,
            CanFireWithPartialAmmoallowsAWeaponToBeFiredAsLongAsThereIsANonzeroAmountOfAmmunitionLoaded = 4,
            ProjectilesUseWeaponOrigininsteadOfComingOutOfTheMagicFirstPersonCameraOriginTheProjectilesForThisWeaponActuallyComeOutOfTheGun = 8,
            EjectsDuringChamberthisTriggersEjectionPortIsStartedDuringTheKeyFrameOfItsChamberAnimation = 16,
            UseErrorWhenUnzoomed = 32,
            ProjectileVectorCannotBeAdjustedprojectilesFiredByThisWeaponCannotHaveTheirDirectionAdjustedByTheAIToHitTheTarget = 64,
            ProjectilesHaveIdenticalError = 128,
            ProjectilesFireParallelIfThereAreMultipleGunsForThisTriggerTheProjectilesEmergeInParallelBeamsratherThanIndependantAiming = 256,
            CantFireWhenOthersFiring = 512,
            CantFireWhenOthersRecovering = 1024,
            DontClearFireBitAfterRecovering = 2048,
            StaggerFireAcrossMultipleMarkers = 4096,
            FiresLockedProjectiles = 8192,
        }
        /// <summary>
        /// what the behavior of this barrel is in a predicted network game
        /// </summary>
        public enum PredictionTypeEnum : short
        {
            None = 0,
            Continuous = 1,
            Instant = 2,
        }
        public enum FiringNoiseEnum : short
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        }
        public enum DistributionFunctionEnum : short
        {
            Point = 0,
            HorizontalFan = 1,
        }
        public enum DamageEffectReportingTypeEnum : byte
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
        }
        public enum AngleChangeFunctionEnum : short
        {
            Linear = 0,
            Early = 1,
            VeryEarly = 2,
            Late = 3,
            VeryLate = 4,
            Cosine = 5,
            One = 6,
            Zero = 7,
        }
    }
}
