using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("jpt!")]
    public  partial class DamageEffectBlock : DamageEffectBlockBase
    {
        public  DamageEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 200)]
    public class DamageEffectBlockBase
    {
        internal Moonfish.Model.Range radiusWorldUnits;
        internal float cutoffScale01;
        internal Flags flags;
        internal SideEffect sideEffect;
        internal Category category;
        internal Flags flags0;
        /// <summary>
        /// if this is area of effect damage
        /// </summary>
        internal float aOECoreRadiusWorldUnits;
        internal float damageLowerBound;
        internal Moonfish.Model.Range damageUpperBound;
        internal float dmgInnerConeAngle;
        internal DamageOuterConeAngleStructBlock blah;
        /// <summary>
        /// how much more visible this damage makes a player who is active camouflaged
        /// </summary>
        internal float activeCamouflageDamage01;
        /// <summary>
        /// amount of stun added to damaged unit
        /// </summary>
        internal float stun01;
        /// <summary>
        /// damaged unit's stun will never exceed this amount
        /// </summary>
        internal float maximumStun01;
        /// <summary>
        /// duration of stun due to this damage
        /// </summary>
        internal float stunTimeSeconds;
        internal float instantaneousAcceleration0Inf;
        internal float riderDirectDamageScale;
        internal float riderMaximumTransferDamageScale;
        internal float riderMinimumTransferDamageScale;
        internal Moonfish.Tags.StringID generalDamage;
        internal Moonfish.Tags.StringID specificDamage;
        internal float aIStunRadiusWorldUnits;
        internal Moonfish.Model.Range aIStunBounds01;
        internal float shakeRadius;
        internal float eMPRadius;
        internal DamageEffectPlayerResponseBlock[] playerResponses;
        internal float durationSeconds;
        internal FadeFunction fadeFunction;
        internal byte[] invalidName_;
        internal float rotationDegrees;
        internal float pushbackWorldUnits;
        internal Moonfish.Model.Range jitterWorldUnits;
        /// <summary>
        /// the effect will last for this duration.
        /// </summary>
        internal float durationSeconds0;
        /// <summary>
        /// a function to envelope the effect's magnitude over time
        /// </summary>
        internal FalloffFunctionAFunctionToEnvelopeTheEffectsMagnitudeOverTime falloffFunction;
        internal byte[] invalidName_0;
        /// <summary>
        /// random translation in all directions
        /// </summary>
        internal float randomTranslationWorldUnits;
        /// <summary>
        /// random rotation in all directions
        /// </summary>
        internal float randomRotationDegrees;
        /// <summary>
        /// a function to perturb the effect's behavior over time
        /// </summary>
        internal WobbleFunctionAFunctionToPerturbTheEffectsBehaviorOverTime wobbleFunction;
        internal byte[] invalidName_1;
        internal float wobbleFunctionPeriodSeconds;
        /// <summary>
        /// a value of 0.0 signifies that the wobble function has no effect; a value of 1.0 signifies that the effect will not be felt when the wobble function's value is zero.
        /// </summary>
        internal float wobbleWeight;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal float forwardVelocityWorldUnitsPerSecond;
        internal float forwardRadiusWorldUnits;
        internal float forwardExponent;
        internal float outwardVelocityWorldUnitsPerSecond;
        internal float outwardRadiusWorldUnits;
        internal float outwardExponent;
        internal  DamageEffectBlockBase(BinaryReader binaryReader)
        {
            this.radiusWorldUnits = binaryReader.ReadRange();
            this.cutoffScale01 = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.sideEffect = (SideEffect)binaryReader.ReadInt16();
            this.category = (Category)binaryReader.ReadInt16();
            this.flags0 = (Flags)binaryReader.ReadInt32();
            this.aOECoreRadiusWorldUnits = binaryReader.ReadSingle();
            this.damageLowerBound = binaryReader.ReadSingle();
            this.damageUpperBound = binaryReader.ReadRange();
            this.dmgInnerConeAngle = binaryReader.ReadSingle();
            this.blah = new DamageOuterConeAngleStructBlock(binaryReader);
            this.activeCamouflageDamage01 = binaryReader.ReadSingle();
            this.stun01 = binaryReader.ReadSingle();
            this.maximumStun01 = binaryReader.ReadSingle();
            this.stunTimeSeconds = binaryReader.ReadSingle();
            this.instantaneousAcceleration0Inf = binaryReader.ReadSingle();
            this.riderDirectDamageScale = binaryReader.ReadSingle();
            this.riderMaximumTransferDamageScale = binaryReader.ReadSingle();
            this.riderMinimumTransferDamageScale = binaryReader.ReadSingle();
            this.generalDamage = binaryReader.ReadStringID();
            this.specificDamage = binaryReader.ReadStringID();
            this.aIStunRadiusWorldUnits = binaryReader.ReadSingle();
            this.aIStunBounds01 = binaryReader.ReadRange();
            this.shakeRadius = binaryReader.ReadSingle();
            this.eMPRadius = binaryReader.ReadSingle();
            this.playerResponses = ReadDamageEffectPlayerResponseBlockArray(binaryReader);
            this.durationSeconds = binaryReader.ReadSingle();
            this.fadeFunction = (FadeFunction)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.rotationDegrees = binaryReader.ReadSingle();
            this.pushbackWorldUnits = binaryReader.ReadSingle();
            this.jitterWorldUnits = binaryReader.ReadRange();
            this.durationSeconds0 = binaryReader.ReadSingle();
            this.falloffFunction = (FalloffFunctionAFunctionToEnvelopeTheEffectsMagnitudeOverTime)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.randomTranslationWorldUnits = binaryReader.ReadSingle();
            this.randomRotationDegrees = binaryReader.ReadSingle();
            this.wobbleFunction = (WobbleFunctionAFunctionToPerturbTheEffectsBehaviorOverTime)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.wobbleFunctionPeriodSeconds = binaryReader.ReadSingle();
            this.wobbleWeight = binaryReader.ReadSingle();
            this.sound = binaryReader.ReadTagReference();
            this.forwardVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.forwardRadiusWorldUnits = binaryReader.ReadSingle();
            this.forwardExponent = binaryReader.ReadSingle();
            this.outwardVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.outwardRadiusWorldUnits = binaryReader.ReadSingle();
            this.outwardExponent = binaryReader.ReadSingle();
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
        internal  virtual DamageEffectPlayerResponseBlock[] ReadDamageEffectPlayerResponseBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageEffectPlayerResponseBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageEffectPlayerResponseBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageEffectPlayerResponseBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DontScaleDamageByDistance = 1,
            AreaDamagePlayersOnlyAreaOfEffectDamageOnlyAffectsPlayers = 2,
        };
        internal enum SideEffect : short
        
        {
            None = 0,
            Harmless = 1,
            LethalToTheUnsuspecting = 2,
            Emp = 3,
        };
        internal enum Category : short
        
        {
            None = 0,
            Falling = 1,
            Bullet = 2,
            Grenade = 3,
            HighExplosive = 4,
            Sniper = 5,
            Melee = 6,
            Flame = 7,
            MountedWeapon = 8,
            Vehicle = 9,
            Plasma = 10,
            Needle = 11,
            Shotgun = 12,
        };
        [FlagsAttribute]
        internal enum Flags0 : int
        
        {
            DoesNotHurtOwner = 1,
            CanCauseHeadshots = 2,
            PingsResistantUnits = 4,
            DoesNotHurtFriends = 8,
            DoesNotPingUnits = 16,
            DetonatesExplosives = 32,
            OnlyHurtsShields = 64,
            CausesFlamingDeath = 128,
            DamageIndicatorsAlwaysPointDown = 256,
            SkipsShields = 512,
            OnlyHurtsOneInfectionForm = 1024,
            ObsoleteWasCanCauseMultiplayerHeadshots = 2048,
            InfectionFormPop = 4096,
            IgnoreSeatScaleForDirDmg = 8192,
            ForcesHardPing = 16384,
            DoesNotHurtPlayers = 32768,
        };
        internal enum FadeFunction : short
        
        {
            Linear = 0,
            Late = 1,
            VeryLate = 2,
            Early = 3,
            VeryEarly = 4,
            Cosine = 5,
            Zero = 6,
            One = 7,
        };
        internal enum FalloffFunctionAFunctionToEnvelopeTheEffectsMagnitudeOverTime : short
        
        {
            Linear = 0,
            Late = 1,
            VeryLate = 2,
            Early = 3,
            VeryEarly = 4,
            Cosine = 5,
            Zero = 6,
            One = 7,
        };
        internal enum WobbleFunctionAFunctionToPerturbTheEffectsBehaviorOverTime : short
        
        {
            One = 0,
            Zero = 1,
            Cosine = 2,
            CosineVariablePeriod = 3,
            DiagonalWave = 4,
            DiagonalWaveVariablePeriod = 5,
            Slide = 6,
            SlideVariablePeriod = 7,
            Noise = 8,
            Jitter = 9,
            Wander = 10,
            Spark = 11,
        };
    };
}
