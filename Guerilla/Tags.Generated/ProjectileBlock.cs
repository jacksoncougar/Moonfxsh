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
        public static readonly TagClass Proj = (TagClass) "proj";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("proj")]
    public partial class ProjectileBlock : ProjectileBlockBase
    {
        public ProjectileBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 232, Alignment = 4)]
    public class ProjectileBlockBase : GuerillaBlock
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
        [TagReference("effe")] internal Moonfish.Tags.TagReference detonationStarted;
        [TagReference("effe")] internal Moonfish.Tags.TagReference detonationEffectAirborne;
        [TagReference("effe")] internal Moonfish.Tags.TagReference detonationEffectGround;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference detonationDamage;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference attachedDetonationDamage;
        [TagReference("effe")] internal Moonfish.Tags.TagReference superDetonation;
        internal SuperDetonationDamageStructBlock yourMomma;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference detonationSound;
        internal DamageReportingType damageReportingType;
        internal byte[] invalidName_;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference superAttachedDetonationDamage;

        /// <summary>
        /// radius within we will generate material effects
        /// </summary>
        internal float materialEffectRadius;

        [TagReference("snd!")] internal Moonfish.Tags.TagReference flybySound;
        [TagReference("effe")] internal Moonfish.Tags.TagReference impactEffect;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference impactDamage;
        internal float boardingDetonationTime;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference boardingDetonationDamage;
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference boardingAttachedDetonationDamage;

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

        public override int SerializedSize
        {
            get { return 420; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ProjectileBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            detonationTimerStarts = (DetonationTimerStarts) binaryReader.ReadInt16();
            impactNoise = (ImpactNoise) binaryReader.ReadInt16();
            aIPerceptionRadiusWorldUnits = binaryReader.ReadSingle();
            collisionRadiusWorldUnits = binaryReader.ReadSingle();
            armingTimeSeconds = binaryReader.ReadSingle();
            dangerRadiusWorldUnits = binaryReader.ReadSingle();
            timerSeconds = binaryReader.ReadRange();
            minimumVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            maximumRangeWorldUnits = binaryReader.ReadSingle();
            detonationNoise = (DetonationNoise) binaryReader.ReadInt16();
            superDetProjectileCount = binaryReader.ReadInt16();
            detonationStarted = binaryReader.ReadTagReference();
            detonationEffectAirborne = binaryReader.ReadTagReference();
            detonationEffectGround = binaryReader.ReadTagReference();
            detonationDamage = binaryReader.ReadTagReference();
            attachedDetonationDamage = binaryReader.ReadTagReference();
            superDetonation = binaryReader.ReadTagReference();
            yourMomma = new SuperDetonationDamageStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(yourMomma.ReadFields(binaryReader)));
            detonationSound = binaryReader.ReadTagReference();
            damageReportingType = (DamageReportingType) binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            superAttachedDetonationDamage = binaryReader.ReadTagReference();
            materialEffectRadius = binaryReader.ReadSingle();
            flybySound = binaryReader.ReadTagReference();
            impactEffect = binaryReader.ReadTagReference();
            impactDamage = binaryReader.ReadTagReference();
            boardingDetonationTime = binaryReader.ReadSingle();
            boardingDetonationDamage = binaryReader.ReadTagReference();
            boardingAttachedDetonationDamage = binaryReader.ReadTagReference();
            airGravityScale = binaryReader.ReadSingle();
            airDamageRangeWorldUnits = binaryReader.ReadRange();
            waterGravityScale = binaryReader.ReadSingle();
            waterDamageRangeWorldUnits = binaryReader.ReadRange();
            initialVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            finalVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            blah = new AngularVelocityLowerBoundStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(blah.ReadFields(binaryReader)));
            guidedAngularVelocityUpperDegreesPerSecond = binaryReader.ReadSingle();
            accelerationRangeWorldUnits = binaryReader.ReadRange();
            invalidName_0 = binaryReader.ReadBytes(4);
            targetedLeadingFraction = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<ProjectileMaterialResponseBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            yourMomma.ReadPointers(binaryReader, blamPointers);
            blah.ReadPointers(binaryReader, blamPointers);
            materialResponses = ReadBlockArrayData<ProjectileMaterialResponseBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write((Int16) detonationTimerStarts);
                binaryWriter.Write((Int16) impactNoise);
                binaryWriter.Write(aIPerceptionRadiusWorldUnits);
                binaryWriter.Write(collisionRadiusWorldUnits);
                binaryWriter.Write(armingTimeSeconds);
                binaryWriter.Write(dangerRadiusWorldUnits);
                binaryWriter.Write(timerSeconds);
                binaryWriter.Write(minimumVelocityWorldUnitsPerSecond);
                binaryWriter.Write(maximumRangeWorldUnits);
                binaryWriter.Write((Int16) detonationNoise);
                binaryWriter.Write(superDetProjectileCount);
                binaryWriter.Write(detonationStarted);
                binaryWriter.Write(detonationEffectAirborne);
                binaryWriter.Write(detonationEffectGround);
                binaryWriter.Write(detonationDamage);
                binaryWriter.Write(attachedDetonationDamage);
                binaryWriter.Write(superDetonation);
                yourMomma.Write(binaryWriter);
                binaryWriter.Write(detonationSound);
                binaryWriter.Write((Byte) damageReportingType);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(superAttachedDetonationDamage);
                binaryWriter.Write(materialEffectRadius);
                binaryWriter.Write(flybySound);
                binaryWriter.Write(impactEffect);
                binaryWriter.Write(impactDamage);
                binaryWriter.Write(boardingDetonationTime);
                binaryWriter.Write(boardingDetonationDamage);
                binaryWriter.Write(boardingAttachedDetonationDamage);
                binaryWriter.Write(airGravityScale);
                binaryWriter.Write(airDamageRangeWorldUnits);
                binaryWriter.Write(waterGravityScale);
                binaryWriter.Write(waterDamageRangeWorldUnits);
                binaryWriter.Write(initialVelocityWorldUnitsPerSecond);
                binaryWriter.Write(finalVelocityWorldUnitsPerSecond);
                blah.Write(binaryWriter);
                binaryWriter.Write(guidedAngularVelocityUpperDegreesPerSecond);
                binaryWriter.Write(accelerationRangeWorldUnits);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(targetedLeadingFraction);
                nextAddress = Guerilla.WriteBlockArray<ProjectileMaterialResponseBlock>(binaryWriter, materialResponses,
                    nextAddress);
                return nextAddress;
            }
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