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
        public  ShaderTemplateBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderTemplateBlockBase(BinaryReader binaryReader)
        {
            this.documentation = ReadData(binaryReader);
            this.defaultMaterialName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.properties = ReadShaderTemplatePropertyBlockArray(binaryReader);
            this.categories = ReadShaderTemplateCategoryBlockArray(binaryReader);
            this.lightResponse = binaryReader.ReadTagReference();
            this.lODs = ReadShaderTemplateLevelOfDetailBlockArray(binaryReader);
            this.eMPTYSTRING = ReadShaderTemplateRuntimeExternalLightResponseIndexBlockArray(binaryReader);
            this.eMPTYSTRING0 = ReadShaderTemplateRuntimeExternalLightResponseIndexBlockArray(binaryReader);
            this.aux1Shader = binaryReader.ReadTagReference();
            this.aux1Layer = (Aux1Layer)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.aux2Shader = binaryReader.ReadTagReference();
            this.aux2Layer = (Aux2Layer)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.postprocessDefinition = ReadShaderTemplatePostprocessDefinitionNewBlockArray(binaryReader);
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
        internal  virtual ShaderTemplatePropertyBlock[] ReadShaderTemplatePropertyBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplateCategoryBlock[] ReadShaderTemplateCategoryBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplateLevelOfDetailBlock[] ReadShaderTemplateLevelOfDetailBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplateRuntimeExternalLightResponseIndexBlock[] ReadShaderTemplateRuntimeExternalLightResponseIndexBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplatePostprocessDefinitionNewBlock[] ReadShaderTemplatePostprocessDefinitionNewBlockArray(BinaryReader binaryReader)
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
