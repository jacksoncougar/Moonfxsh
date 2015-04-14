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
        public static readonly TagClass JptClass = (TagClass)"jpt!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("jpt!")]
    public  partial class DamageEffectBlock : DamageEffectBlockBase
    {
        public  DamageEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 200, Alignment = 4)]
    public class DamageEffectBlockBase  : IGuerilla
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
            radiusWorldUnits = binaryReader.ReadRange();
            cutoffScale01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
            sideEffect = (SideEffect)binaryReader.ReadInt16();
            category = (Category)binaryReader.ReadInt16();
            flags0 = (Flags)binaryReader.ReadInt32();
            aOECoreRadiusWorldUnits = binaryReader.ReadSingle();
            damageLowerBound = binaryReader.ReadSingle();
            damageUpperBound = binaryReader.ReadRange();
            dmgInnerConeAngle = binaryReader.ReadSingle();
            blah = new DamageOuterConeAngleStructBlock(binaryReader);
            activeCamouflageDamage01 = binaryReader.ReadSingle();
            stun01 = binaryReader.ReadSingle();
            maximumStun01 = binaryReader.ReadSingle();
            stunTimeSeconds = binaryReader.ReadSingle();
            instantaneousAcceleration0Inf = binaryReader.ReadSingle();
            riderDirectDamageScale = binaryReader.ReadSingle();
            riderMaximumTransferDamageScale = binaryReader.ReadSingle();
            riderMinimumTransferDamageScale = binaryReader.ReadSingle();
            generalDamage = binaryReader.ReadStringID();
            specificDamage = binaryReader.ReadStringID();
            aIStunRadiusWorldUnits = binaryReader.ReadSingle();
            aIStunBounds01 = binaryReader.ReadRange();
            shakeRadius = binaryReader.ReadSingle();
            eMPRadius = binaryReader.ReadSingle();
            playerResponses = Guerilla.ReadBlockArray<DamageEffectPlayerResponseBlock>(binaryReader);
            durationSeconds = binaryReader.ReadSingle();
            fadeFunction = (FadeFunction)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            rotationDegrees = binaryReader.ReadSingle();
            pushbackWorldUnits = binaryReader.ReadSingle();
            jitterWorldUnits = binaryReader.ReadRange();
            durationSeconds0 = binaryReader.ReadSingle();
            falloffFunction = (FalloffFunctionAFunctionToEnvelopeTheEffectsMagnitudeOverTime)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            randomTranslationWorldUnits = binaryReader.ReadSingle();
            randomRotationDegrees = binaryReader.ReadSingle();
            wobbleFunction = (WobbleFunctionAFunctionToPerturbTheEffectsBehaviorOverTime)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            wobbleFunctionPeriodSeconds = binaryReader.ReadSingle();
            wobbleWeight = binaryReader.ReadSingle();
            sound = binaryReader.ReadTagReference();
            forwardVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            forwardRadiusWorldUnits = binaryReader.ReadSingle();
            forwardExponent = binaryReader.ReadSingle();
            outwardVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            outwardRadiusWorldUnits = binaryReader.ReadSingle();
            outwardExponent = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(radiusWorldUnits);
                binaryWriter.Write(cutoffScale01);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)sideEffect);
                binaryWriter.Write((Int16)category);
                binaryWriter.Write((Int32)flags0);
                binaryWriter.Write(aOECoreRadiusWorldUnits);
                binaryWriter.Write(damageLowerBound);
                binaryWriter.Write(damageUpperBound);
                binaryWriter.Write(dmgInnerConeAngle);
                blah.Write(binaryWriter);
                binaryWriter.Write(activeCamouflageDamage01);
                binaryWriter.Write(stun01);
                binaryWriter.Write(maximumStun01);
                binaryWriter.Write(stunTimeSeconds);
                binaryWriter.Write(instantaneousAcceleration0Inf);
                binaryWriter.Write(riderDirectDamageScale);
                binaryWriter.Write(riderMaximumTransferDamageScale);
                binaryWriter.Write(riderMinimumTransferDamageScale);
                binaryWriter.Write(generalDamage);
                binaryWriter.Write(specificDamage);
                binaryWriter.Write(aIStunRadiusWorldUnits);
                binaryWriter.Write(aIStunBounds01);
                binaryWriter.Write(shakeRadius);
                binaryWriter.Write(eMPRadius);
                Guerilla.WriteBlockArray<DamageEffectPlayerResponseBlock>(binaryWriter, playerResponses, nextAddress);
                binaryWriter.Write(durationSeconds);
                binaryWriter.Write((Int16)fadeFunction);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(rotationDegrees);
                binaryWriter.Write(pushbackWorldUnits);
                binaryWriter.Write(jitterWorldUnits);
                binaryWriter.Write(durationSeconds0);
                binaryWriter.Write((Int16)falloffFunction);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(randomTranslationWorldUnits);
                binaryWriter.Write(randomRotationDegrees);
                binaryWriter.Write((Int16)wobbleFunction);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(wobbleFunctionPeriodSeconds);
                binaryWriter.Write(wobbleWeight);
                binaryWriter.Write(sound);
                binaryWriter.Write(forwardVelocityWorldUnitsPerSecond);
                binaryWriter.Write(forwardRadiusWorldUnits);
                binaryWriter.Write(forwardExponent);
                binaryWriter.Write(outwardVelocityWorldUnitsPerSecond);
                binaryWriter.Write(outwardRadiusWorldUnits);
                binaryWriter.Write(outwardExponent);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
