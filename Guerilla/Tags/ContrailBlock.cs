using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("cont")]
    public  partial class ContrailBlock : ContrailBlockBase
    {
        public  ContrailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 240)]
    public class ContrailBlockBase
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
            this.flags = (Flags)binaryReader.ReadInt16();
            this.scaleFlags = (ScaleFlagsTheseFlagsDetermineWhichFieldsAreScaledByTheContrailDensity)binaryReader.ReadInt16();
            this.pointGenerationRatePointsPerSecond = binaryReader.ReadSingle();
            this.pointVelocityWorldUnitsPerSecond = binaryReader.ReadRange();
            this.pointVelocityConeAngleDegrees = binaryReader.ReadSingle();
            this.inheritedVelocityFraction = binaryReader.ReadSingle();
            this.renderType = (RenderTypeThisSpecifiesHowTheContrailIsOrientedInSpace)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.textureRepeatsU = binaryReader.ReadSingle();
            this.textureRepeatsV = binaryReader.ReadSingle();
            this.textureAnimationURepeatsPerSecond = binaryReader.ReadSingle();
            this.textureAnimationVRepeatsPerSecond = binaryReader.ReadSingle();
            this.animationRateFramesPerSecond = binaryReader.ReadSingle();
            this.bitmap = binaryReader.ReadTagReference();
            this.firstSequenceIndex = binaryReader.ReadInt16();
            this.sequenceCount = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(40);
            this.shaderFlags = (ShaderFlags)binaryReader.ReadInt16();
            this.framebufferBlendFunction = (FramebufferBlendFunction)binaryReader.ReadInt16();
            this.framebufferFadeMode = (FramebufferFadeMode)binaryReader.ReadInt16();
            this.mapFlags = (MapFlags)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(28);
            this.bitmap0 = binaryReader.ReadTagReference();
            this.anchor = (Anchor)binaryReader.ReadInt16();
            this.flags0 = (Flags)binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.uAnimationFunction = (UAnimationFunction)binaryReader.ReadInt16();
            this.uAnimationPeriodSeconds = binaryReader.ReadSingle();
            this.uAnimationPhase = binaryReader.ReadSingle();
            this.uAnimationScaleRepeats = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.vAnimationFunction = (VAnimationFunction)binaryReader.ReadInt16();
            this.vAnimationPeriodSeconds = binaryReader.ReadSingle();
            this.vAnimationPhase = binaryReader.ReadSingle();
            this.vAnimationScaleRepeats = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.rotationAnimationFunction = (RotationAnimationFunction)binaryReader.ReadInt16();
            this.rotationAnimationPeriodSeconds = binaryReader.ReadSingle();
            this.rotationAnimationPhase = binaryReader.ReadSingle();
            this.rotationAnimationScaleDegrees = binaryReader.ReadSingle();
            this.rotationAnimationCenter = binaryReader.ReadVector2();
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.zspriteRadiusScale = binaryReader.ReadSingle();
            this.invalidName_6 = binaryReader.ReadBytes(20);
            this.pointStates = ReadContrailPointStatesBlockArray(binaryReader);
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
        internal  virtual ContrailPointStatesBlock[] ReadContrailPointStatesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ContrailPointStatesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ContrailPointStatesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ContrailPointStatesBlock(binaryReader);
                }
            }
            return array;
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
