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
    [TagClassAttribute("proj")]
    [TagBlockOriginalNameAttribute("projectile_block")]
    public partial class ProjectileBlock : ObjectBlock, IWriteDeferrable
    {
        public ProjectileFlags ProjectileProjectileFlags;
        public DetonationTimerStartsEnum DetonationTimerStarts;
        public ImpactNoiseEnum ImpactNoise;
        public float AIPerceptionRadius;
        public float CollisionRadius;
        public float ArmingTime;
        public float DangerRadius;
        public Moonfish.Model.Range Timer;
        public float MinimumVelocity;
        public float MaximumRange;
        public DetonationNoiseEnum DetonationNoise;
        public short SuperDetProjectileCount;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference DetonationStarted;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference DetonationEffect;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference DetonationEffect0;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference DetonationDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference AttachedDetonationDamage;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference SuperDetonation;
        public SuperDetonationDamageStructBlock YourMomma = new SuperDetonationDamageStructBlock();
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference DetonationSound;
        public DamageReportingTypeEnum DamageReportingType;
        private byte[] fieldpad3 = new byte[3];
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference SuperAttachedDetonationDamage;
        public float MaterialEffectRadius;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference FlybySound;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference ImpactEffect;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ImpactDamage;
        public float BoardingDetonationTime;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference BoardingDetonationDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference BoardingAttachedDetonationDamage;
        public float AirGravityScale;
        public Moonfish.Model.Range AirDamageRange;
        public float WaterGravityScale;
        public Moonfish.Model.Range WaterDamageRange;
        public float InitialVelocity;
        public float FinalVelocity;
        public AngularVelocityLowerBoundStructBlock Blah = new AngularVelocityLowerBoundStructBlock();
        public float GuidedAngularVelocity;
        public Moonfish.Model.Range AccelerationRange;
        private byte[] fieldpad4 = new byte[4];
        public float TargetedLeadingFraction;
        public ProjectileMaterialResponseBlock[] MaterialResponses = new ProjectileMaterialResponseBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 420;
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
            this.ProjectileProjectileFlags = ((ProjectileFlags)(binaryReader.ReadInt32()));
            this.DetonationTimerStarts = ((DetonationTimerStartsEnum)(binaryReader.ReadInt16()));
            this.ImpactNoise = ((ImpactNoiseEnum)(binaryReader.ReadInt16()));
            this.AIPerceptionRadius = binaryReader.ReadSingle();
            this.CollisionRadius = binaryReader.ReadSingle();
            this.ArmingTime = binaryReader.ReadSingle();
            this.DangerRadius = binaryReader.ReadSingle();
            this.Timer = binaryReader.ReadRange();
            this.MinimumVelocity = binaryReader.ReadSingle();
            this.MaximumRange = binaryReader.ReadSingle();
            this.DetonationNoise = ((DetonationNoiseEnum)(binaryReader.ReadInt16()));
            this.SuperDetProjectileCount = binaryReader.ReadInt16();
            this.DetonationStarted = binaryReader.ReadTagReference();
            this.DetonationEffect = binaryReader.ReadTagReference();
            this.DetonationEffect0 = binaryReader.ReadTagReference();
            this.DetonationDamage = binaryReader.ReadTagReference();
            this.AttachedDetonationDamage = binaryReader.ReadTagReference();
            this.SuperDetonation = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.YourMomma.ReadFields(binaryReader)));
            this.DetonationSound = binaryReader.ReadTagReference();
            this.DamageReportingType = ((DamageReportingTypeEnum)(binaryReader.ReadByte()));
            this.fieldpad3 = binaryReader.ReadBytes(3);
            this.SuperAttachedDetonationDamage = binaryReader.ReadTagReference();
            this.MaterialEffectRadius = binaryReader.ReadSingle();
            this.FlybySound = binaryReader.ReadTagReference();
            this.ImpactEffect = binaryReader.ReadTagReference();
            this.ImpactDamage = binaryReader.ReadTagReference();
            this.BoardingDetonationTime = binaryReader.ReadSingle();
            this.BoardingDetonationDamage = binaryReader.ReadTagReference();
            this.BoardingAttachedDetonationDamage = binaryReader.ReadTagReference();
            this.AirGravityScale = binaryReader.ReadSingle();
            this.AirDamageRange = binaryReader.ReadRange();
            this.WaterGravityScale = binaryReader.ReadSingle();
            this.WaterDamageRange = binaryReader.ReadRange();
            this.InitialVelocity = binaryReader.ReadSingle();
            this.FinalVelocity = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Blah.ReadFields(binaryReader)));
            this.GuidedAngularVelocity = binaryReader.ReadSingle();
            this.AccelerationRange = binaryReader.ReadRange();
            this.fieldpad4 = binaryReader.ReadBytes(4);
            this.TargetedLeadingFraction = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(88));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.YourMomma.ReadInstances(binaryReader, pointerQueue);
            this.Blah.ReadInstances(binaryReader, pointerQueue);
            this.MaterialResponses = base.ReadBlockArrayData<ProjectileMaterialResponseBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            this.YourMomma.DeferReferences(queueableBinaryWriter);
            this.Blah.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.MaterialResponses);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.ProjectileProjectileFlags)));
            queueableBinaryWriter.Write(((short)(this.DetonationTimerStarts)));
            queueableBinaryWriter.Write(((short)(this.ImpactNoise)));
            queueableBinaryWriter.Write(this.AIPerceptionRadius);
            queueableBinaryWriter.Write(this.CollisionRadius);
            queueableBinaryWriter.Write(this.ArmingTime);
            queueableBinaryWriter.Write(this.DangerRadius);
            queueableBinaryWriter.Write(this.Timer);
            queueableBinaryWriter.Write(this.MinimumVelocity);
            queueableBinaryWriter.Write(this.MaximumRange);
            queueableBinaryWriter.Write(((short)(this.DetonationNoise)));
            queueableBinaryWriter.Write(this.SuperDetProjectileCount);
            queueableBinaryWriter.Write(this.DetonationStarted);
            queueableBinaryWriter.Write(this.DetonationEffect);
            queueableBinaryWriter.Write(this.DetonationEffect0);
            queueableBinaryWriter.Write(this.DetonationDamage);
            queueableBinaryWriter.Write(this.AttachedDetonationDamage);
            queueableBinaryWriter.Write(this.SuperDetonation);
            this.YourMomma.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.DetonationSound);
            queueableBinaryWriter.Write(((byte)(this.DamageReportingType)));
            queueableBinaryWriter.Write(this.fieldpad3);
            queueableBinaryWriter.Write(this.SuperAttachedDetonationDamage);
            queueableBinaryWriter.Write(this.MaterialEffectRadius);
            queueableBinaryWriter.Write(this.FlybySound);
            queueableBinaryWriter.Write(this.ImpactEffect);
            queueableBinaryWriter.Write(this.ImpactDamage);
            queueableBinaryWriter.Write(this.BoardingDetonationTime);
            queueableBinaryWriter.Write(this.BoardingDetonationDamage);
            queueableBinaryWriter.Write(this.BoardingAttachedDetonationDamage);
            queueableBinaryWriter.Write(this.AirGravityScale);
            queueableBinaryWriter.Write(this.AirDamageRange);
            queueableBinaryWriter.Write(this.WaterGravityScale);
            queueableBinaryWriter.Write(this.WaterDamageRange);
            queueableBinaryWriter.Write(this.InitialVelocity);
            queueableBinaryWriter.Write(this.FinalVelocity);
            this.Blah.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.GuidedAngularVelocity);
            queueableBinaryWriter.Write(this.AccelerationRange);
            queueableBinaryWriter.Write(this.fieldpad4);
            queueableBinaryWriter.Write(this.TargetedLeadingFraction);
            queueableBinaryWriter.WritePointer(this.MaterialResponses);
        }
        [System.FlagsAttribute()]
        public enum ProjectileFlags : int
        {
            None = 0,
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
        }
        public enum DetonationTimerStartsEnum : short
        {
            Immediately = 0,
            AfterFirstBounce = 1,
            WhenAtRest = 2,
            AfterFirstBounceOffAnySurface = 3,
        }
        public enum ImpactNoiseEnum : short
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        }
        public enum DetonationNoiseEnum : short
        {
            Silent = 0,
            Medium = 1,
            Loud = 2,
            Shout = 3,
            Quiet = 4,
        }
        public enum DamageReportingTypeEnum : byte
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
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Proj = ((TagClass)("proj"));
    }
}
