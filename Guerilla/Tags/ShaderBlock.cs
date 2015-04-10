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
        public  ShaderBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderBlockBase(BinaryReader binaryReader)
        {
            this.template = binaryReader.ReadTagReference();
            this.materialName = binaryReader.ReadStringID();
            this.runtimeProperties = ReadShaderPropertiesBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.parameters = ReadGlobalShaderParameterBlockArray(binaryReader);
            this.postprocessDefinition = ReadShaderPostprocessDefinitionNewBlockArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.predictedResources = ReadPredictedResourceBlockArray(binaryReader);
            this.lightResponse = binaryReader.ReadTagReference();
            this.shaderLODBias = (ShaderLODBias)binaryReader.ReadInt16();
            this.specularType = (SpecularType)binaryReader.ReadInt16();
            this.lightmapType = (LightmapType)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.lightmapSpecularBrightness = binaryReader.ReadSingle();
            this.lightmapAmbientBias11 = binaryReader.ReadSingle();
            this.postprocessProperties = ReadLongBlockArray(binaryReader);
            this.addedDepthBiasOffset = binaryReader.ReadSingle();
            this.addedDepthBiasSlopeScale = binaryReader.ReadSingle();
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
        internal  virtual ShaderPropertiesBlock[] ReadShaderPropertiesBlockArray(BinaryReader binaryReader)
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
        internal  virtual GlobalShaderParameterBlock[] ReadGlobalShaderParameterBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessDefinitionNewBlock[] ReadShaderPostprocessDefinitionNewBlockArray(BinaryReader binaryReader)
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
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(BinaryReader binaryReader)
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
        internal  virtual LongBlock[] ReadLongBlockArray(BinaryReader binaryReader)
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
