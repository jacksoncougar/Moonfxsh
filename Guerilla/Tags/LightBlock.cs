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
        public static readonly TagClass LighClass = (TagClass)"ligh";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ligh")]
    public  partial class LightBlock : LightBlockBase
    {
        public  LightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 228, Alignment = 4)]
    public class LightBlockBase  : IGuerilla
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
            flags = (Flags)binaryReader.ReadInt32();
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            sizeModifer = binaryReader.ReadRange();
            shadowQualityBias = binaryReader.ReadSingle();
            shadowTapBias = (ShadowTapBiasTheLessTapsYouUseTheFasterTheLightButEdgesCanLookWorse)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            radiusWorldUnits = binaryReader.ReadSingle();
            specularRadiusWorldUnits = binaryReader.ReadSingle();
            nearWidthWorldUnits = binaryReader.ReadSingle();
            heightStretch = binaryReader.ReadSingle();
            fieldOfViewDegrees = binaryReader.ReadSingle();
            falloffDistance = binaryReader.ReadSingle();
            cutoffDistance = binaryReader.ReadSingle();
            interpolationFlags = (InterpolationFlags)binaryReader.ReadInt32();
            bloomBounds02 = binaryReader.ReadRange();
            specularLowerBound = binaryReader.ReadColorR8G8B8();
            specularUpperBound = binaryReader.ReadColorR8G8B8();
            diffuseLowerBound = binaryReader.ReadColorR8G8B8();
            diffuseUpperBound = binaryReader.ReadColorR8G8B8();
            brightnessBounds02 = binaryReader.ReadRange();
            gelMap = binaryReader.ReadTagReference();
            specularMask = (SpecularMask)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(4);
            falloffFunction = (FalloffFunction)binaryReader.ReadInt16();
            diffuseContrast = (DiffuseContrast)binaryReader.ReadInt16();
            specularContrast = (SpecularContrast)binaryReader.ReadInt16();
            falloffGeometry = (FalloffGeometry)binaryReader.ReadInt16();
            lensFlare = binaryReader.ReadTagReference();
            boundingRadiusWorldUnits = binaryReader.ReadSingle();
            lightVolume = binaryReader.ReadTagReference();
            defaultLightmapSetting = (DefaultLightmapSetting)binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            lightmapHalfLife = binaryReader.ReadSingle();
            lightmapLightScale = binaryReader.ReadSingle();
            durationSeconds = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(2);
            falloffFunction0 = (FalloffFunctionTheScaleOfTheLightWillDiminishOverTimeAccordingToThisFunction)binaryReader.ReadInt16();
            illuminationFade = (IlluminationFade)binaryReader.ReadInt16();
            shadowFade = (ShadowFade)binaryReader.ReadInt16();
            specularFade = (SpecularFade)binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(2);
            flags0 = (Flags)binaryReader.ReadInt32();
            brightnessAnimation = Guerilla.ReadBlockArray<LightBrightnessAnimationBlock>(binaryReader);
            colorAnimation = Guerilla.ReadBlockArray<LightColorAnimationBlock>(binaryReader);
            gelAnimation = Guerilla.ReadBlockArray<LightGelAnimationBlock>(binaryReader);
            shader = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(sizeModifer);
                binaryWriter.Write(shadowQualityBias);
                binaryWriter.Write((Int16)shadowTapBias);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(radiusWorldUnits);
                binaryWriter.Write(specularRadiusWorldUnits);
                binaryWriter.Write(nearWidthWorldUnits);
                binaryWriter.Write(heightStretch);
                binaryWriter.Write(fieldOfViewDegrees);
                binaryWriter.Write(falloffDistance);
                binaryWriter.Write(cutoffDistance);
                binaryWriter.Write((Int32)interpolationFlags);
                binaryWriter.Write(bloomBounds02);
                binaryWriter.Write(specularLowerBound);
                binaryWriter.Write(specularUpperBound);
                binaryWriter.Write(diffuseLowerBound);
                binaryWriter.Write(diffuseUpperBound);
                binaryWriter.Write(brightnessBounds02);
                binaryWriter.Write(gelMap);
                binaryWriter.Write((Int16)specularMask);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write((Int16)falloffFunction);
                binaryWriter.Write((Int16)diffuseContrast);
                binaryWriter.Write((Int16)specularContrast);
                binaryWriter.Write((Int16)falloffGeometry);
                binaryWriter.Write(lensFlare);
                binaryWriter.Write(boundingRadiusWorldUnits);
                binaryWriter.Write(lightVolume);
                binaryWriter.Write((Int16)defaultLightmapSetting);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(lightmapHalfLife);
                binaryWriter.Write(lightmapLightScale);
                binaryWriter.Write(durationSeconds);
                binaryWriter.Write(invalidName_4, 0, 2);
                binaryWriter.Write((Int16)falloffFunction0);
                binaryWriter.Write((Int16)illuminationFade);
                binaryWriter.Write((Int16)shadowFade);
                binaryWriter.Write((Int16)specularFade);
                binaryWriter.Write(invalidName_5, 0, 2);
                binaryWriter.Write((Int32)flags0);
                Guerilla.WriteBlockArray<LightBrightnessAnimationBlock>(binaryWriter, brightnessAnimation, nextAddress);
                Guerilla.WriteBlockArray<LightColorAnimationBlock>(binaryWriter, colorAnimation, nextAddress);
                Guerilla.WriteBlockArray<LightGelAnimationBlock>(binaryWriter, gelAnimation, nextAddress);
                binaryWriter.Write(shader);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
