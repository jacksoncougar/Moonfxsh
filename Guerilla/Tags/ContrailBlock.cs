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
        public static readonly TagClass ContClass = (TagClass)"cont";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("cont")]
    public  partial class ContrailBlock : ContrailBlockBase
    {
        public  ContrailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 240, Alignment = 4)]
    public class ContrailBlockBase  : IGuerilla
    {
        internal Flags flags;
        /// <summary>
        /// these flags determine which fields are scaled by the contrail density
        /// </summary>
        internal ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity scaleFlags;
        /// <summary>
        /// this many points are generated per second
        /// </summary>
        internal float pointGenerationRatePointsPerSecond;
        /// <summary>
        /// velocity added to each point's initial velocity
        /// </summary>
        internal Moonfish.Model.Range pointVelocityWorldUnitsPerSecond;
        /// <summary>
        /// initial velocity is inside the cone defined by the marker's forward vector and this angle
        /// </summary>
        internal float pointVelocityConeAngleDegrees;
        /// <summary>
        /// fraction of parent object's velocity that is inherited by contrail points.
        /// </summary>
        internal float inheritedVelocityFraction;
        /// <summary>
        /// this specifies how the contrail is oriented in space
        /// </summary>
        internal RenderTypeThisSpecifiesHowTheContrailIsOrientedInSpace renderType;
        internal byte[] invalidName_;
        /// <summary>
        /// texture repeats per contrail segment
        /// </summary>
        internal float textureRepeatsU;
        /// <summary>
        /// texture repeats across contrail width
        /// </summary>
        internal float textureRepeatsV;
        /// <summary>
        /// the texture along the contrail is animated by this value
        /// </summary>
        internal float textureAnimationURepeatsPerSecond;
        /// <summary>
        /// the texture across the contrail is animated by this value
        /// </summary>
        internal float textureAnimationVRepeatsPerSecond;
        internal float animationRateFramesPerSecond;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal short firstSequenceIndex;
        internal short sequenceCount;
        internal byte[] invalidName_0;
        internal ShaderFlags shaderFlags;
        internal FramebufferBlendFunction framebufferBlendFunction;
        internal FramebufferFadeMode framebufferFadeMode;
        internal MapFlags mapFlags;
        internal byte[] invalidName_1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap0;
        internal Anchor anchor;
        internal Flags flags0;
        internal byte[] invalidName_2;
        internal UAnimationFunction uAnimationFunction;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float uAnimationPeriodSeconds;
        internal float uAnimationPhase;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float uAnimationScaleRepeats;
        internal byte[] invalidName_3;
        internal VAnimationFunction vAnimationFunction;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float vAnimationPeriodSeconds;
        internal float vAnimationPhase;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float vAnimationScaleRepeats;
        internal byte[] invalidName_4;
        internal RotationAnimationFunction rotationAnimationFunction;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float rotationAnimationPeriodSeconds;
        internal float rotationAnimationPhase;
        /// <summary>
        /// 0 defaults to 360
        /// </summary>
        internal float rotationAnimationScaleDegrees;
        internal OpenTK.Vector2 rotationAnimationCenter;
        internal byte[] invalidName_5;
        internal float zspriteRadiusScale;
        internal byte[] invalidName_6;
        internal ContrailPointStatesBlock[] pointStates;
        internal  ContrailBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            scaleFlags = (ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity)binaryReader.ReadInt16();
            pointGenerationRatePointsPerSecond = binaryReader.ReadSingle();
            pointVelocityWorldUnitsPerSecond = binaryReader.ReadRange();
            pointVelocityConeAngleDegrees = binaryReader.ReadSingle();
            inheritedVelocityFraction = binaryReader.ReadSingle();
            renderType = (RenderTypeThisSpecifiesHowTheContrailIsOrientedInSpace)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            textureRepeatsU = binaryReader.ReadSingle();
            textureRepeatsV = binaryReader.ReadSingle();
            textureAnimationURepeatsPerSecond = binaryReader.ReadSingle();
            textureAnimationVRepeatsPerSecond = binaryReader.ReadSingle();
            animationRateFramesPerSecond = binaryReader.ReadSingle();
            bitmap = binaryReader.ReadTagReference();
            firstSequenceIndex = binaryReader.ReadInt16();
            sequenceCount = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(40);
            shaderFlags = (ShaderFlags)binaryReader.ReadInt16();
            framebufferBlendFunction = (FramebufferBlendFunction)binaryReader.ReadInt16();
            framebufferFadeMode = (FramebufferFadeMode)binaryReader.ReadInt16();
            mapFlags = (MapFlags)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(28);
            bitmap0 = binaryReader.ReadTagReference();
            anchor = (Anchor)binaryReader.ReadInt16();
            flags0 = (Flags)binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            uAnimationFunction = (UAnimationFunction)binaryReader.ReadInt16();
            uAnimationPeriodSeconds = binaryReader.ReadSingle();
            uAnimationPhase = binaryReader.ReadSingle();
            uAnimationScaleRepeats = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(2);
            vAnimationFunction = (VAnimationFunction)binaryReader.ReadInt16();
            vAnimationPeriodSeconds = binaryReader.ReadSingle();
            vAnimationPhase = binaryReader.ReadSingle();
            vAnimationScaleRepeats = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(2);
            rotationAnimationFunction = (RotationAnimationFunction)binaryReader.ReadInt16();
            rotationAnimationPeriodSeconds = binaryReader.ReadSingle();
            rotationAnimationPhase = binaryReader.ReadSingle();
            rotationAnimationScaleDegrees = binaryReader.ReadSingle();
            rotationAnimationCenter = binaryReader.ReadVector2();
            invalidName_5 = binaryReader.ReadBytes(4);
            zspriteRadiusScale = binaryReader.ReadSingle();
            invalidName_6 = binaryReader.ReadBytes(20);
            pointStates = Guerilla.ReadBlockArray<ContrailPointStatesBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)scaleFlags);
                binaryWriter.Write(pointGenerationRatePointsPerSecond);
                binaryWriter.Write(pointVelocityWorldUnitsPerSecond);
                binaryWriter.Write(pointVelocityConeAngleDegrees);
                binaryWriter.Write(inheritedVelocityFraction);
                binaryWriter.Write((Int16)renderType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(textureRepeatsU);
                binaryWriter.Write(textureRepeatsV);
                binaryWriter.Write(textureAnimationURepeatsPerSecond);
                binaryWriter.Write(textureAnimationVRepeatsPerSecond);
                binaryWriter.Write(animationRateFramesPerSecond);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(firstSequenceIndex);
                binaryWriter.Write(sequenceCount);
                binaryWriter.Write(invalidName_0, 0, 40);
                binaryWriter.Write((Int16)shaderFlags);
                binaryWriter.Write((Int16)framebufferBlendFunction);
                binaryWriter.Write((Int16)framebufferFadeMode);
                binaryWriter.Write((Int16)mapFlags);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(bitmap0);
                binaryWriter.Write((Int16)anchor);
                binaryWriter.Write((Int16)flags0);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write((Int16)uAnimationFunction);
                binaryWriter.Write(uAnimationPeriodSeconds);
                binaryWriter.Write(uAnimationPhase);
                binaryWriter.Write(uAnimationScaleRepeats);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write((Int16)vAnimationFunction);
                binaryWriter.Write(vAnimationPeriodSeconds);
                binaryWriter.Write(vAnimationPhase);
                binaryWriter.Write(vAnimationScaleRepeats);
                binaryWriter.Write(invalidName_4, 0, 2);
                binaryWriter.Write((Int16)rotationAnimationFunction);
                binaryWriter.Write(rotationAnimationPeriodSeconds);
                binaryWriter.Write(rotationAnimationPhase);
                binaryWriter.Write(rotationAnimationScaleDegrees);
                binaryWriter.Write(rotationAnimationCenter);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(zspriteRadiusScale);
                binaryWriter.Write(invalidName_6, 0, 20);
                nextAddress = Guerilla.WriteBlockArray<ContrailPointStatesBlock>(binaryWriter, pointStates, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            FirstPointUnfaded = 1,
            LastPointUnfaded = 2,
            PointsStartPinnedToMedia = 4,
            PointsStartPinnedToGround = 8,
            PointsAlwaysPinnedToMedia = 16,
            PointsAlwaysPinnedToGround = 32,
            EdgeEffectFadesSlowly = 64,
            DonttInheritObjectChangeColor = 128,
        };
        [FlagsAttribute]
        internal enum ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity : short
        {
            PointGenerationRate = 1,
            PointVelocity = 2,
            PointVelocityDelta = 4,
            PointVelocityConeAngle = 8,
            InheritedVelocityFraction = 16,
            SequenceAnimationRate = 32,
            TextureScaleU = 64,
            TextureScaleV = 128,
            TextureAnimationU = 256,
            TextureAnimationV = 512,
        };
        internal enum RenderTypeThisSpecifiesHowTheContrailIsOrientedInSpace : short
        {
            VerticalOrientation = 0,
            HorizontalOrientation = 1,
            MediaMapped = 2,
            GroundMapped = 3,
            ViewerFacing = 4,
            DoubleMarkerLinked = 5,
        };
        [FlagsAttribute]
        internal enum ShaderFlags : short
        {
            SortBias = 1,
            NonlinearTint = 2,
            DontOverdrawFpWeapon = 4,
        };
        internal enum FramebufferBlendFunction : short
        {
            AlphaBlend = 0,
            Multiply = 1,
            DoubleMultiply = 2,
            Add = 3,
            Subtract = 4,
            ComponentMin = 5,
            ComponentMax = 6,
            AlphaMultiplyAdd = 7,
            ConstantColorBlend = 8,
            InverseConstantColorBlend = 9,
            None = 10,
        };
        internal enum FramebufferFadeMode : short
        {
            None = 0,
            FadeWhenPerpendicular = 1,
            FadeWhenParallel = 2,
        };
        [FlagsAttribute]
        internal enum MapFlags : short
        {
            Unfiltered = 1,
        };
        internal enum Anchor : short
        {
            WithPrimary = 0,
            WithScreenSpace = 1,
            Zsprite = 2,
        };
        [FlagsAttribute]
        internal enum Flags0 : short
        {
            Unfiltered = 1,
        };
        internal enum UAnimationFunction : short
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
        internal enum VAnimationFunction : short
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
        internal enum RotationAnimationFunction : short
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
