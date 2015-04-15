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
        public static readonly TagClass Sky = (TagClass)"sky ";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sky ")]
    public  partial class SkyBlock : SkyBlockBase
    {
        public  SkyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172, Alignment = 4)]
    public class SkyBlockBase  : IGuerilla
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference renderModel;
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference animationGraph;
        internal Flags flags;
        /// <summary>
        /// Multiplier by which to scale the model's geometry up or down (0 defaults to standard, 0.03).
        /// </summary>
        internal float renderModelScale;
        /// <summary>
        /// How much the sky moves to remain centered on the player (0 defaults to 1.0, which means no parallax).
        /// </summary>
        internal float movementScale;
        internal SkyCubemapBlock[] cubeMap;
        /// <summary>
        /// Indoor ambient light color.
        /// </summary>
        internal Moonfish.Tags.ColorR8G8B8 indoorAmbientColor;
        internal byte[] invalidName_;
        /// <summary>
        /// Indoor ambient light color.
        /// </summary>
        internal Moonfish.Tags.ColorR8G8B8 outdoorAmbientColor;
        internal byte[] invalidName_0;
        /// <summary>
        /// How far fog spreads into adjacent clusters.
        /// </summary>
        internal float fogSpreadDistanceWorldUnits;
        internal SkyAtmosphericFogBlock[] atmosphericFog;
        internal SkyAtmosphericFogBlock[] secondaryFog;
        internal SkyFogBlock[] skyFog;
        internal SkyPatchyFogBlock[] patchyFog;
        internal float amount01;
        internal float threshold01;
        internal float brightness01;
        internal float gammaPower;
        internal SkyLightBlock[] lights;
        internal float globalSkyRotation;
        internal SkyShaderFunctionBlock[] shaderFunctions;
        internal SkyAnimationBlock[] animations;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ColorR8G8B8 clearColor;
        internal  SkyBlockBase(BinaryReader binaryReader)
        {
            renderModel = binaryReader.ReadTagReference();
            animationGraph = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            renderModelScale = binaryReader.ReadSingle();
            movementScale = binaryReader.ReadSingle();
            cubeMap = Guerilla.ReadBlockArray<SkyCubemapBlock>(binaryReader);
            indoorAmbientColor = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(4);
            outdoorAmbientColor = binaryReader.ReadColorR8G8B8();
            invalidName_0 = binaryReader.ReadBytes(4);
            fogSpreadDistanceWorldUnits = binaryReader.ReadSingle();
            atmosphericFog = Guerilla.ReadBlockArray<SkyAtmosphericFogBlock>(binaryReader);
            secondaryFog = Guerilla.ReadBlockArray<SkyAtmosphericFogBlock>(binaryReader);
            skyFog = Guerilla.ReadBlockArray<SkyFogBlock>(binaryReader);
            patchyFog = Guerilla.ReadBlockArray<SkyPatchyFogBlock>(binaryReader);
            amount01 = binaryReader.ReadSingle();
            threshold01 = binaryReader.ReadSingle();
            brightness01 = binaryReader.ReadSingle();
            gammaPower = binaryReader.ReadSingle();
            lights = Guerilla.ReadBlockArray<SkyLightBlock>(binaryReader);
            globalSkyRotation = binaryReader.ReadSingle();
            shaderFunctions = Guerilla.ReadBlockArray<SkyShaderFunctionBlock>(binaryReader);
            animations = Guerilla.ReadBlockArray<SkyAnimationBlock>(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(12);
            clearColor = binaryReader.ReadColorR8G8B8();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(renderModel);
                binaryWriter.Write(animationGraph);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(renderModelScale);
                binaryWriter.Write(movementScale);
                nextAddress = Guerilla.WriteBlockArray<SkyCubemapBlock>(binaryWriter, cubeMap, nextAddress);
                binaryWriter.Write(indoorAmbientColor);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(outdoorAmbientColor);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(fogSpreadDistanceWorldUnits);
                nextAddress = Guerilla.WriteBlockArray<SkyAtmosphericFogBlock>(binaryWriter, atmosphericFog, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyAtmosphericFogBlock>(binaryWriter, secondaryFog, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyFogBlock>(binaryWriter, skyFog, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyPatchyFogBlock>(binaryWriter, patchyFog, nextAddress);
                binaryWriter.Write(amount01);
                binaryWriter.Write(threshold01);
                binaryWriter.Write(brightness01);
                binaryWriter.Write(gammaPower);
                nextAddress = Guerilla.WriteBlockArray<SkyLightBlock>(binaryWriter, lights, nextAddress);
                binaryWriter.Write(globalSkyRotation);
                nextAddress = Guerilla.WriteBlockArray<SkyShaderFunctionBlock>(binaryWriter, shaderFunctions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SkyAnimationBlock>(binaryWriter, animations, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 12);
                binaryWriter.Write(clearColor);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            FixedInWorldSpace = 1,
            Depreciated = 2,
            SkyCastsLightFromBelow = 4,
            DisableSkyInLightmaps = 8,
            FogOnlyAffectsContainingClusters = 16,
            UseClearColor = 32,
        };
    };
}
