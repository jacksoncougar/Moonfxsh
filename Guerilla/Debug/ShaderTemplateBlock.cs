// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("stem")]
    public  partial class ShaderTemplateBlock : ShaderTemplateBlockBase
    {
        public  ShaderTemplateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class ShaderTemplateBlockBase
    {
        internal byte[] documentation;
        internal Moonfish.Tags.StringID defaultMaterialName;
        internal byte[] invalidName_;
        internal Flags flags;
        internal ShaderTemplatePropertyBlock[] properties;
        internal ShaderTemplateCategoryBlock[] categories;
        [TagReference("slit")]
        internal Moonfish.Tags.TagReference lightResponse;
        internal ShaderTemplateLevelOfDetailBlock[] lODs;
        internal ShaderTemplateRuntimeExternalLightResponseIndexBlock[] eMPTYSTRING;
        internal ShaderTemplateRuntimeExternalLightResponseIndexBlock[] eMPTYSTRING0;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference aux1Shader;
        internal Aux1Layer aux1Layer;
        internal byte[] invalidName_0;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference aux2Shader;
        internal Aux2Layer aux2Layer;
        internal byte[] invalidName_1;
        internal ShaderTemplatePostprocessDefinitionNewBlock[] postprocessDefinition;
        internal  ShaderTemplateBlockBase(System.IO.BinaryReader binaryReader)
        {
            documentation = ReadData(binaryReader);
            defaultMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            ReadShaderTemplatePropertyBlockArray(binaryReader);
            ReadShaderTemplateCategoryBlockArray(binaryReader);
            lightResponse = binaryReader.ReadTagReference();
            ReadShaderTemplateLevelOfDetailBlockArray(binaryReader);
            ReadShaderTemplateRuntimeExternalLightResponseIndexBlockArray(binaryReader);
            ReadShaderTemplateRuntimeExternalLightResponseIndexBlockArray(binaryReader);
            aux1Shader = binaryReader.ReadTagReference();
            aux1Layer = (Aux1Layer)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            aux2Shader = binaryReader.ReadTagReference();
            aux2Layer = (Aux2Layer)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            ReadShaderTemplatePostprocessDefinitionNewBlockArray(binaryReader);
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
        internal  virtual ShaderTemplatePropertyBlock[] ReadShaderTemplatePropertyBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePropertyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplateCategoryBlock[] ReadShaderTemplateCategoryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateCategoryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateCategoryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateCategoryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplateLevelOfDetailBlock[] ReadShaderTemplateLevelOfDetailBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateLevelOfDetailBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateLevelOfDetailBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateLevelOfDetailBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplateRuntimeExternalLightResponseIndexBlock[] ReadShaderTemplateRuntimeExternalLightResponseIndexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateRuntimeExternalLightResponseIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateRuntimeExternalLightResponseIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateRuntimeExternalLightResponseIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplatePostprocessDefinitionNewBlock[] ReadShaderTemplatePostprocessDefinitionNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePostprocessDefinitionNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePostprocessDefinitionNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePostprocessDefinitionNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplatePropertyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplateCategoryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplateLevelOfDetailBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplateRuntimeExternalLightResponseIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplatePostprocessDefinitionNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteData(binaryWriter);
                binaryWriter.Write(defaultMaterialName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)flags);
                WriteShaderTemplatePropertyBlockArray(binaryWriter);
                WriteShaderTemplateCategoryBlockArray(binaryWriter);
                binaryWriter.Write(lightResponse);
                WriteShaderTemplateLevelOfDetailBlockArray(binaryWriter);
                WriteShaderTemplateRuntimeExternalLightResponseIndexBlockArray(binaryWriter);
                WriteShaderTemplateRuntimeExternalLightResponseIndexBlockArray(binaryWriter);
                binaryWriter.Write(aux1Shader);
                binaryWriter.Write((Int16)aux1Layer);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(aux2Shader);
                binaryWriter.Write((Int16)aux2Layer);
                binaryWriter.Write(invalidName_1, 0, 2);
                WriteShaderTemplatePostprocessDefinitionNewBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            ForceActiveCamo = 1,
            Water = 2,
            Foliage = 4,
            HideStandardParameters = 8,
        };
        internal enum Aux1Layer : short
        
        {
            Texaccum = 0,
            EnvironmentMap = 1,
            SelfIllumination = 2,
            Overlay = 3,
            Transparent = 4,
            LightmapIndirect = 5,
            Diffuse = 6,
            Specular = 7,
            ShadowGenerate = 8,
            ShadowApply = 9,
            Boom = 10,
            Fog = 11,
            ShPrt = 12,
            ActiveCamo = 13,
            WaterEdgeBlend = 14,
            Decal = 15,
            ActiveCamoStencilModulate = 16,
            Hologram = 17,
            LightAlbedo = 18,
        };
        internal enum Aux2Layer : short
        
        {
            Texaccum = 0,
            EnvironmentMap = 1,
            SelfIllumination = 2,
            Overlay = 3,
            Transparent = 4,
            LightmapIndirect = 5,
            Diffuse = 6,
            Specular = 7,
            ShadowGenerate = 8,
            ShadowApply = 9,
            Boom = 10,
            Fog = 11,
            ShPrt = 12,
            ActiveCamo = 13,
            WaterEdgeBlend = 14,
            Decal = 15,
            ActiveCamoStencilModulate = 16,
            Hologram = 17,
            LightAlbedo = 18,
        };
    };
}
