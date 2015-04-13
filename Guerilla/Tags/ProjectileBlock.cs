using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("proj")]
    public  partial class ProjectileBlock : ProjectileBlockBase
    {
        public  ProjectileBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 232)]
    public class ProjectileBlockBase : ObjectBlock
    {
        internal Flags flags;
        internal DetonationTimerStarts detonationTimerStarts;
        internal ImpactNoise impactNoise;
        internal float aIPerceptionRadiusWorldUnits;
        internal float collisionRadiusWorldUnits;
        /// <summary>
        /// won't detonate before this time elapses
        /// </summary>
        internal float armingTimeSeconds;
        internal float dangerRadiusWorldUnits;
        /// <summary>
        /// detonation countdown (zero is untimed)
        /// </summary>
        internal Moonfish.Model.Range timerSeconds;
        /// <summary>
        /// detonates when slowed below this velocity
        /// </summary>
        internal float minimumVelocityWorldUnitsPerSecond;
        /// <summary>
        /// detonates after travelling this distance
        /// </summary>
        internal float maximumRangeWorldUnits;
        internal DetonationNoise detonationNoise;
        internal short superDetProjectileCount;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference detonationStarted;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference detonationEffectAirborne;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference detonationEffectGround;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference detonationDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference attachedDetonationDamage;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference superDetonation;
        internal SuperDetonationDamageStructBlock yourMomma;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference detonationSound;
        internal DamageReportingType damageReportingType;
        internal byte[] invalidName_;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference superAttachedDetonationDamage;
        /// <summary>
        /// radius within we will generate material effects
        /// </summary>
        internal float materialEffectRadius;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference flybySound;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference impactEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference impactDamage;
        internal float boardingDetonationTime;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference boardingDetonationDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference boardingAttachedDetonationDamage;
        /// <summary>
        /// the proportion of normal gravity applied to the projectile when in air.
        /// </summary>
        internal float airGravityScale;
        /// <summary>
        /// the range over which damage is scaled when the projectile is in air.
        /// </summary>
        internal Moonfish.Model.Range airDamageRangeWorldUnits;
        /// <summary>
        /// the proportion of normal gravity applied to the projectile when in water.
        /// </summary>
        internal float waterGravityScale;
        /// <summary>
        /// the range over which damage is scaled when the projectile is in water.
        /// </summary>
        internal Moonfish.Model.Range waterDamageRangeWorldUnits;
        /// <summary>
        /// bullet's velocity when inflicting maximum damage
        /// </summary>
        internal float initialVelocityWorldUnitsPerSecond;
        /// <summary>
        /// bullet's velocity when inflicting minimum damage
        /// </summary>
        internal float finalVelocityWorldUnitsPerSecond;
        internal AngularVelocityLowerBoundStructBlock blah;
        internal float guidedAngularVelocityUpperDegreesPerSecond;
        /// <summary>
        /// what distance range the projectile goes from initial velocity to final velocity
        /// </summary>
        internal Moonfish.Model.Range accelerationRangeWorldUnits;
        internal byte[] invalidName_0;
        internal float targetedLeadingFraction;
        internal ProjectileMaterialResponseBlock[] materialResponses;
        internal  ProjectileBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.detonationTimerStarts = (DetonationTimerStarts)binaryReader.ReadInt16();
            this.impactNoise = (ImpactNoise)binaryReader.ReadInt16();
            this.aIPerceptionRadiusWorldUnits = binaryReader.ReadSingle();
            this.collisionRadiusWorldUnits = binaryReader.ReadSingle();
            this.armingTimeSeconds = binaryReader.ReadSingle();
            this.dangerRadiusWorldUnits = binaryReader.ReadSingle();
            this.timerSeconds = binaryReader.ReadRange();
            this.minimumVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.maximumRangeWorldUnits = binaryReader.ReadSingle();
            this.detonationNoise = (DetonationNoise)binaryReader.ReadInt16();
            this.superDetProjectileCount = binaryReader.ReadInt16();
            this.detonationStarted = binaryReader.ReadTagReference();
            this.detonationEffectAirborne = binaryReader.ReadTagReference();
            this.detonationEffectGround = binaryReader.ReadTagReference();
            this.detonationDamage = binaryReader.ReadTagReference();
            this.attachedDetonationDamage = binaryReader.ReadTagReference();
            this.superDetonation = binaryReader.ReadTagReference();
            this.yourMomma = new SuperDetonationDamageStructBlock(binaryReader);
            this.detonationSound = binaryReader.ReadTagReference();
            this.damageReportingType = (DamageReportingType)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.superAttachedDetonationDamage = binaryReader.ReadTagReference();
            this.materialEffectRadius = binaryReader.ReadSingle();
            this.flybySound = binaryReader.ReadTagReference();
            this.impactEffect = binaryReader.ReadTagReference();
            this.impactDamage = binaryReader.ReadTagReference();
            this.boardingDetonationTime = binaryReader.ReadSingle();
            this.boardingDetonationDamage = binaryReader.ReadTagReference();
            this.boardingAttachedDetonationDamage = binaryReader.ReadTagReference();
            this.airGravityScale = binaryReader.ReadSingle();
            this.airDamageRangeWorldUnits = binaryReader.ReadRange();
            this.waterGravityScale = binaryReader.ReadSingle();
            this.waterDamageRangeWorldUnits = binaryReader.ReadRange();
            this.initialVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.finalVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.blah = new AngularVelocityLowerBoundStructBlock(binaryReader);
            this.guidedAngularVelocityUpperDegreesPerSecond = binaryReader.ReadSingle();
            this.accelerationRangeWorldUnits = binaryReader.ReadRange();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.targetedLeadingFraction = binaryReader.ReadSingle();
            this.materialResponses = ReadProjectileMaterialResponseBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual ProjectileMaterialResponseBlock[] ReadProjectileMaterialResponseBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ProjectileMaterialResponseBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ProjectileMaterialResponseBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ProjectileMaterialResponseBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            OrientedAlongVelocity = 1,
            AIMustUseBallisticAiming = 2,
            DetonationMaxTimeIfAttached = 4,
            HasSuperCombiningExplosion = 8,
            DamageScalesBasedOnDistance = 16,
            TravelsInstantaneously = 32,
            SteeringAdjustsOrientation = 64,
            DontNoiseUpSteering = 128,
            CanTrackBehindItself = 256,
            ROBOTRONSTEERING = 512,
            FasterWhenOwnedByPlayer = 1024,
        };
        internal enum DetonationTimerStarts : short
        
        {
            Immediately = 0,
            AfterFirstBounce = 1,
            WhenAtRest = 2,
            AfterFirstBounceOffAnySurface = 3,
        };
        internal enum ImpactNoise : short
        
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        };
        internal enum DetonationNoise : short
        
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        };
        internal enum DamageReportingType : byte
        
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
    };
}
