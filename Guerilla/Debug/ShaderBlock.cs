// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("shad")]
    public  partial class ShaderBlock : ShaderBlockBase
    {
        public  ShaderBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class ShaderBlockBase
    {
        [TagReference("stem")]
        internal Moonfish.Tags.TagReference template;
        internal Moonfish.Tags.StringID materialName;
        internal ShaderPropertiesBlock[] runtimeProperties;
        internal byte[] invalidName_;
        internal Flags flags;
        internal GlobalShaderParameterBlock[] parameters;
        internal ShaderPostprocessDefinitionNewBlock[] postprocessDefinition;
        internal byte[] invalidName_0;
        internal PredictedResourceBlock[] predictedResources;
        [TagReference("slit")]
        internal Moonfish.Tags.TagReference lightResponse;
        internal ShaderLODBias shaderLODBias;
        internal SpecularType specularType;
        internal LightmapType lightmapType;
        internal byte[] invalidName_1;
        internal float lightmapSpecularBrightness;
        internal float lightmapAmbientBias11;
        internal LongBlock[] postprocessProperties;
        internal float addedDepthBiasOffset;
        internal float addedDepthBiasSlopeScale;
        internal  ShaderBlockBase(System.IO.BinaryReader binaryReader)
        {
            template = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            ReadShaderPropertiesBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            ReadGlobalShaderParameterBlockArray(binaryReader);
            ReadShaderPostprocessDefinitionNewBlockArray(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(4);
            ReadPredictedResourceBlockArray(binaryReader);
            lightResponse = binaryReader.ReadTagReference();
            shaderLODBias = (ShaderLODBias)binaryReader.ReadInt16();
            specularType = (SpecularType)binaryReader.ReadInt16();
            lightmapType = (LightmapType)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            lightmapSpecularBrightness = binaryReader.ReadSingle();
            lightmapAmbientBias11 = binaryReader.ReadSingle();
            ReadLongBlockArray(binaryReader);
            addedDepthBiasOffset = binaryReader.ReadSingle();
            addedDepthBiasSlopeScale = binaryReader.ReadSingle();
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
        internal  virtual ShaderPropertiesBlock[] ReadShaderPropertiesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPropertiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPropertiesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPropertiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalShaderParameterBlock[] ReadGlobalShaderParameterBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalShaderParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalShaderParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalShaderParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessDefinitionNewBlock[] ReadShaderPostprocessDefinitionNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessDefinitionNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessDefinitionNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessDefinitionNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedResourceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LongBlock[] ReadLongBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LongBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LongBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LongBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPropertiesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalShaderParameterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessDefinitionNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePredictedResourceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLongBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(template);
                binaryWriter.Write(materialName);
                WriteShaderPropertiesBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)flags);
                WriteGlobalShaderParameterBlockArray(binaryWriter);
                WriteShaderPostprocessDefinitionNewBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 4);
                WritePredictedResourceBlockArray(binaryWriter);
                binaryWriter.Write(lightResponse);
                binaryWriter.Write((Int16)shaderLODBias);
                binaryWriter.Write((Int16)specularType);
                binaryWriter.Write((Int16)lightmapType);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(lightmapSpecularBrightness);
                binaryWriter.Write(lightmapAmbientBias11);
                WriteLongBlockArray(binaryWriter);
                binaryWriter.Write(addedDepthBiasOffset);
                binaryWriter.Write(addedDepthBiasSlopeScale);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Water = 1,
            SortFirst = 2,
            NoActiveCamo = 4,
        };
        internal enum ShaderLODBias : short
        
        {
            None = 0,
            InvalidName4XSize = 1,
            InvalidName2XSize = 2,
            InvalidName12Size = 3,
            InvalidName14Size = 4,
            Never = 5,
            Cinematic = 6,
        };
        internal enum SpecularType : short
        
        {
            None = 0,
            Default = 1,
            Dull = 2,
            Shiny = 3,
        };
        internal enum LightmapType : short
        
        {
            Diffuse = 0,
            DefaultSpecular = 1,
            DullSpecular = 2,
            ShinySpecular = 3,
        };
    };
}
