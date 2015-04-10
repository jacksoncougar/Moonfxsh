using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ligh")]
    public  partial class LightBlock : LightBlockBase
    {
        public  LightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 228)]
    public class LightBlockBase
    {
        internal Flags flags;
        internal Type type;
        internal byte[] invalidName_;
        /// <summary>
        /// how the light's size changes with external scale
        /// </summary>
        internal Moonfish.Model.Range sizeModifer;
        /// <summary>
        /// larger positive numbers improve quality, larger negative numbers improve speed
        /// </summary>
        internal float shadowQualityBias;
        /// <summary>
        /// the less taps you use, the faster the light (but edges can look worse)
        /// </summary>
        internal ShadowTapBiasTheLessTapsYouUseTheFasterTheLightButEdgesCanLookWorse shadowTapBias;
        internal byte[] invalidName_0;
        /// <summary>
        /// the radius at which illumination falls off to zero
        /// </summary>
        internal float radiusWorldUnits;
        /// <summary>
        /// the radius at which specular highlights fall off to zero (if zero, same as maximum radius)
        /// </summary>
        internal float specularRadiusWorldUnits;
        /// <summary>
        /// width of the frustum light at its near plane
        /// </summary>
        internal float nearWidthWorldUnits;
        /// <summary>
        /// how much the gel is stretched vertically (0.0 or 1.0 = aspect ratio same as gel)
        /// </summary>
        internal float heightStretch;
        /// <summary>
        /// horizontal angle that the frustum light covers (0.0 = no spread, a parallel beam)
        /// </summary>
        internal float fieldOfViewDegrees;
        /// <summary>
        /// distance from near plane to where the light falloff starts
        /// </summary>
        internal float falloffDistance;
        /// <summary>
        /// distance from near plane to where illumination falls off to zero
        /// </summary>
        internal float cutoffDistance;
        internal InterpolationFlags interpolationFlags;
        internal Moonfish.Model.Range bloomBounds02;
        internal Moonfish.Tags.ColorR8G8B8 specularLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 specularUpperBound;
        internal Moonfish.Tags.ColorR8G8B8 diffuseLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 diffuseUpperBound;
        internal Moonfish.Model.Range brightnessBounds02;
        /// <summary>
        /// must be a cubemap for spherical light and a 2d texture for frustum light
        /// </summary>
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference gelMap;
        internal SpecularMask specularMask;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal FalloffFunction falloffFunction;
        internal DiffuseContrast diffuseContrast;
        internal SpecularContrast specularContrast;
        internal FalloffGeometry falloffGeometry;
        [TagReference("lens")]
        internal Moonfish.Tags.TagReference lensFlare;
        /// <summary>
        /// used to generate a bounding radius for lensflare-only lights
        /// </summary>
        internal float boundingRadiusWorldUnits;
        [TagReference("MGS2")]
        internal Moonfish.Tags.TagReference lightVolume;
        internal DefaultLightmapSetting defaultLightmapSetting;
        internal byte[] invalidName_3;
        internal float lightmapHalfLife;
        internal float lightmapLightScale;
        /// <summary>
        /// the light will last this long when created by an effect
        /// </summary>
        internal float durationSeconds;
        internal byte[] invalidName_4;
        /// <summary>
        /// the scale of the light will diminish over time according to this function
        /// </summary>
        internal FalloffFunctionTheScaleOfTheLightWillDiminishOverTimeAccordingToThisFunction falloffFunction0;
        internal IlluminationFade illuminationFade;
        internal ShadowFade shadowFade;
        internal SpecularFade specularFade;
        internal byte[] invalidName_5;
        internal Flags flags0;
        internal LightBrightnessAnimationBlock[] brightnessAnimation;
        internal LightColorAnimationBlock[] colorAnimation;
        internal LightGelAnimationBlock[] gelAnimation;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal  LightBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.sizeModifer = binaryReader.ReadRange();
            this.shadowQualityBias = binaryReader.ReadSingle();
            this.shadowTapBias = (ShadowTapBiasTheLessTapsYouUseTheFasterTheLightButEdgesCanLookWorse)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.radiusWorldUnits = binaryReader.ReadSingle();
            this.specularRadiusWorldUnits = binaryReader.ReadSingle();
            this.nearWidthWorldUnits = binaryReader.ReadSingle();
            this.heightStretch = binaryReader.ReadSingle();
            this.fieldOfViewDegrees = binaryReader.ReadSingle();
            this.falloffDistance = binaryReader.ReadSingle();
            this.cutoffDistance = binaryReader.ReadSingle();
            this.interpolationFlags = (InterpolationFlags)binaryReader.ReadInt32();
            this.bloomBounds02 = binaryReader.ReadRange();
            this.specularLowerBound = binaryReader.ReadColorR8G8B8();
            this.specularUpperBound = binaryReader.ReadColorR8G8B8();
            this.diffuseLowerBound = binaryReader.ReadColorR8G8B8();
            this.diffuseUpperBound = binaryReader.ReadColorR8G8B8();
            this.brightnessBounds02 = binaryReader.ReadRange();
            this.gelMap = binaryReader.ReadTagReference();
            this.specularMask = (SpecularMask)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.falloffFunction = (FalloffFunction)binaryReader.ReadInt16();
            this.diffuseContrast = (DiffuseContrast)binaryReader.ReadInt16();
            this.specularContrast = (SpecularContrast)binaryReader.ReadInt16();
            this.falloffGeometry = (FalloffGeometry)binaryReader.ReadInt16();
            this.lensFlare = binaryReader.ReadTagReference();
            this.boundingRadiusWorldUnits = binaryReader.ReadSingle();
            this.lightVolume = binaryReader.ReadTagReference();
            this.defaultLightmapSetting = (DefaultLightmapSetting)binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.lightmapHalfLife = binaryReader.ReadSingle();
            this.lightmapLightScale = binaryReader.ReadSingle();
            this.durationSeconds = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.falloffFunction0 = (FalloffFunctionTheScaleOfTheLightWillDiminishOverTimeAccordingToThisFunction)binaryReader.ReadInt16();
            this.illuminationFade = (IlluminationFade)binaryReader.ReadInt16();
            this.shadowFade = (ShadowFade)binaryReader.ReadInt16();
            this.specularFade = (SpecularFade)binaryReader.ReadInt16();
            this.invalidName_5 = binaryReader.ReadBytes(2);
            this.flags0 = (Flags)binaryReader.ReadInt32();
            this.brightnessAnimation = ReadLightBrightnessAnimationBlockArray(binaryReader);
            this.colorAnimation = ReadLightColorAnimationBlockArray(binaryReader);
            this.gelAnimation = ReadLightGelAnimationBlockArray(binaryReader);
            this.shader = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual LightBrightnessAnimationBlock[] ReadLightBrightnessAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightBrightnessAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightBrightnessAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightBrightnessAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightColorAnimationBlock[] ReadLightColorAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightColorAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightColorAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightColorAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightGelAnimationBlock[] ReadLightGelAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightGelAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightGelAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightGelAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            NoIlluminationDontCastAnyPerPixelDynamicLight = 1,
            NoSpecularDontCastAnySpecularHighlights = 2,
            ForceCastEnvironmentShadowsThroughPortals = 4,
            NoShadowDontCastAnyStencilShadows = 8,
            ForceFrustumVisibilityOnSmallLight = 16,
            OnlyRenderInFirstPerson = 32,
            OnlyRenderInThirdPerson = 64,
            DontFadeWhenInvisibleDontFadeOutThisLightWhenUnderActiveCamouflage = 128,
            MultiplayerOverrideDontTurnOffInMultiplayer = 256,
            AnimatedGel = 512,
            OnlyInDynamicEnvmapOnlyDrawThisLightInDynamicReflectionMaps = 1024,
            IgnoreParentObjectDontIlluminateOrShadowTheSingleObjectWeAreAttachedTo = 2048,
            DontShadowParentDontShadowTheObjectWeAreAttachedTo = 4096,
            IgnoreAllParentsDontIlluminateOrShadowAllTheWayUpToOurParentObject = 8192,
            MarchMilestoneHackDontClickThisUnlessYouKnowWhatYoureDoing = 16384,
            ForceLightInsideWorldEveryUpdateWillPushLightBackInsideTheWorld = 32768,
            EnvironmentDoesntCastStencilShadowsEnvironmentInThisLightWillNotCastStencilShadows = 65536,
            ObjectsDontCastStencilShadowsObjectsInThisLightWillNotCastStencilShadows = 131072,
            FirstPersonFromCamera = 262144,
            TextureCameraGel = 524288,
            LightFramerateKiller = 1048576,
            AllowedInSplitScreen = 2097152,
            OnlyOnParentBipeds = 4194304,
        };
        internal enum Type : short
        
        {
            Sphere = 0,
            Orthogonal = 1,
            Projective = 2,
            Pyramid = 3,
        };
        internal enum ShadowTapBiasTheLessTapsYouUseTheFasterTheLightButEdgesCanLookWorse : short
        
        {
            InvalidName3Tap = 0,
            UNUSED = 1,
            InvalidName1Tap = 2,
        };
        [FlagsAttribute]
        internal enum InterpolationFlags : int
        
        {
            BlendInHsvBlendsColorsInHsvRatherThanRgbSpace = 1,
            MoreColorsBlendsColorsThroughMoreHuesGoesTheLongWayAroundTheColorWheel = 2,
        };
        internal enum SpecularMask : short
        
        {
            Default = 0,
            NoneNoMask = 1,
            GelAlpha = 2,
            GelColor = 3,
        };
        internal enum FalloffFunction : short
        
        {
            Default = 0,
            Narrow = 1,
            Broad = 2,
            VeryBroad = 3,
        };
        internal enum DiffuseContrast : short
        
        {
            DefaultLinear = 0,
            High = 1,
            Low = 2,
            VeryLow = 3,
        };
        internal enum SpecularContrast : short
        
        {
            DefaultOne = 0,
            HighLinear = 1,
            Low = 2,
            VeryLow = 3,
        };
        internal enum FalloffGeometry : short
        
        {
            Default = 0,
            Directional = 1,
            Spherical = 2,
        };
        internal enum DefaultLightmapSetting : short
        
        {
            DynamicOnly = 0,
            DynamicWithLightmaps = 1,
            LightmapsOnly = 2,
        };
        internal enum FalloffFunctionTheScaleOfTheLightWillDiminishOverTimeAccordingToThisFunction : short
        
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
        internal enum IlluminationFade : short
        
        {
            FadeVeryFar = 0,
            FadeFar = 1,
            FadeMedium = 2,
            FadeClose = 3,
            FadeVeryClose = 4,
        };
        internal enum ShadowFade : short
        
        {
            FadeVeryFar = 0,
            FadeFar = 1,
            FadeMedium = 2,
            FadeClose = 3,
            FadeVeryClose = 4,
        };
        internal enum SpecularFade : short
        
        {
            FadeVeryFar = 0,
            FadeFar = 1,
            FadeMedium = 2,
            FadeClose = 3,
            FadeVeryClose = 4,
        };
        [FlagsAttribute]
        internal enum Flags0 : int
        
        {
            Synchronized = 1,
        };
    };
}
