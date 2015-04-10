using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sky ")]
    public  partial class SkyBlock : SkyBlockBase
    {
        public  SkyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172)]
    public class SkyBlockBase
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
            this.renderModel = binaryReader.ReadTagReference();
            this.animationGraph = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.renderModelScale = binaryReader.ReadSingle();
            this.movementScale = binaryReader.ReadSingle();
            this.cubeMap = ReadSkyCubemapBlockArray(binaryReader);
            this.indoorAmbientColor = binaryReader.ReadColorR8G8B8();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.outdoorAmbientColor = binaryReader.ReadColorR8G8B8();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.fogSpreadDistanceWorldUnits = binaryReader.ReadSingle();
            this.atmosphericFog = ReadSkyAtmosphericFogBlockArray(binaryReader);
            this.secondaryFog = ReadSkyAtmosphericFogBlockArray(binaryReader);
            this.skyFog = ReadSkyFogBlockArray(binaryReader);
            this.patchyFog = ReadSkyPatchyFogBlockArray(binaryReader);
            this.amount01 = binaryReader.ReadSingle();
            this.threshold01 = binaryReader.ReadSingle();
            this.brightness01 = binaryReader.ReadSingle();
            this.gammaPower = binaryReader.ReadSingle();
            this.lights = ReadSkyLightBlockArray(binaryReader);
            this.globalSkyRotation = binaryReader.ReadSingle();
            this.shaderFunctions = ReadSkyShaderFunctionBlockArray(binaryReader);
            this.animations = ReadSkyAnimationBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(12);
            this.clearColor = binaryReader.ReadColorR8G8B8();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual SkyCubemapBlock[] ReadSkyCubemapBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyCubemapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyCubemapBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyCubemapBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyAtmosphericFogBlock[] ReadSkyAtmosphericFogBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyAtmosphericFogBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyAtmosphericFogBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyAtmosphericFogBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyFogBlock[] ReadSkyFogBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyFogBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyFogBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyFogBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyPatchyFogBlock[] ReadSkyPatchyFogBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyPatchyFogBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyPatchyFogBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyPatchyFogBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyLightBlock[] ReadSkyLightBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyLightBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyLightBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyLightBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyShaderFunctionBlock[] ReadSkyShaderFunctionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyShaderFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyShaderFunctionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyShaderFunctionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SkyAnimationBlock[] ReadSkyAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SkyAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SkyAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SkyAnimationBlock(binaryReader);
                }
            }
            return array;
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
