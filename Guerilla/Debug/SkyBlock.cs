// ReSharper disable All
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
        public  SkyBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SkyBlockBase(System.IO.BinaryReader binaryReader)
        {
            renderModel = binaryReader.ReadTagReference();
            animationGraph = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            renderModelScale = binaryReader.ReadSingle();
            movementScale = binaryReader.ReadSingle();
            ReadSkyCubemapBlockArray(binaryReader);
            indoorAmbientColor = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(4);
            outdoorAmbientColor = binaryReader.ReadColorR8G8B8();
            invalidName_0 = binaryReader.ReadBytes(4);
            fogSpreadDistanceWorldUnits = binaryReader.ReadSingle();
            ReadSkyAtmosphericFogBlockArray(binaryReader);
            ReadSkyAtmosphericFogBlockArray(binaryReader);
            ReadSkyFogBlockArray(binaryReader);
            ReadSkyPatchyFogBlockArray(binaryReader);
            amount01 = binaryReader.ReadSingle();
            threshold01 = binaryReader.ReadSingle();
            brightness01 = binaryReader.ReadSingle();
            gammaPower = binaryReader.ReadSingle();
            ReadSkyLightBlockArray(binaryReader);
            globalSkyRotation = binaryReader.ReadSingle();
            ReadSkyShaderFunctionBlockArray(binaryReader);
            ReadSkyAnimationBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(12);
            clearColor = binaryReader.ReadColorR8G8B8();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyCubemapBlock[] ReadSkyCubemapBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyAtmosphericFogBlock[] ReadSkyAtmosphericFogBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyFogBlock[] ReadSkyFogBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyPatchyFogBlock[] ReadSkyPatchyFogBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyLightBlock[] ReadSkyLightBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyShaderFunctionBlock[] ReadSkyShaderFunctionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SkyAnimationBlock[] ReadSkyAnimationBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyCubemapBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyAtmosphericFogBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyFogBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyPatchyFogBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyLightBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyShaderFunctionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSkyAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(renderModel);
                binaryWriter.Write(animationGraph);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(renderModelScale);
                binaryWriter.Write(movementScale);
                WriteSkyCubemapBlockArray(binaryWriter);
                binaryWriter.Write(indoorAmbientColor);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(outdoorAmbientColor);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(fogSpreadDistanceWorldUnits);
                WriteSkyAtmosphericFogBlockArray(binaryWriter);
                WriteSkyAtmosphericFogBlockArray(binaryWriter);
                WriteSkyFogBlockArray(binaryWriter);
                WriteSkyPatchyFogBlockArray(binaryWriter);
                binaryWriter.Write(amount01);
                binaryWriter.Write(threshold01);
                binaryWriter.Write(brightness01);
                binaryWriter.Write(gammaPower);
                WriteSkyLightBlockArray(binaryWriter);
                binaryWriter.Write(globalSkyRotation);
                WriteSkyShaderFunctionBlockArray(binaryWriter);
                WriteSkyAnimationBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 12);
                binaryWriter.Write(clearColor);
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
