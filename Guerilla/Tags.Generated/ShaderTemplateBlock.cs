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
        public static readonly TagClass Stem = (TagClass)"stem";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("stem")]
    public partial class ShaderTemplateBlock : ShaderTemplateBlockBase
    {
        public  ShaderTemplateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderTemplateBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class ShaderTemplateBlockBase : GuerillaBlock
    {
        internal byte[] documentation;
        internal Moonfish.Tags.StringIdent defaultMaterialName;
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
        
        public override int SerializedSize{get { return 96; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderTemplateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            documentation = Guerilla.ReadData(binaryReader);
            defaultMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            properties = Guerilla.ReadBlockArray<ShaderTemplatePropertyBlock>(binaryReader);
            categories = Guerilla.ReadBlockArray<ShaderTemplateCategoryBlock>(binaryReader);
            lightResponse = binaryReader.ReadTagReference();
            lODs = Guerilla.ReadBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryReader);
            eMPTYSTRING = Guerilla.ReadBlockArray<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader);
            eMPTYSTRING0 = Guerilla.ReadBlockArray<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader);
            aux1Shader = binaryReader.ReadTagReference();
            aux1Layer = (Aux1Layer)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            aux2Shader = binaryReader.ReadTagReference();
            aux2Layer = (Aux2Layer)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            postprocessDefinition = Guerilla.ReadBlockArray<ShaderTemplatePostprocessDefinitionNewBlock>(binaryReader);
        }
        public  ShaderTemplateBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            documentation = Guerilla.ReadData(binaryReader);
            defaultMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            properties = Guerilla.ReadBlockArray<ShaderTemplatePropertyBlock>(binaryReader);
            categories = Guerilla.ReadBlockArray<ShaderTemplateCategoryBlock>(binaryReader);
            lightResponse = binaryReader.ReadTagReference();
            lODs = Guerilla.ReadBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryReader);
            eMPTYSTRING = Guerilla.ReadBlockArray<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader);
            eMPTYSTRING0 = Guerilla.ReadBlockArray<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader);
            aux1Shader = binaryReader.ReadTagReference();
            aux1Layer = (Aux1Layer)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            aux2Shader = binaryReader.ReadTagReference();
            aux2Layer = (Aux2Layer)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            postprocessDefinition = Guerilla.ReadBlockArray<ShaderTemplatePostprocessDefinitionNewBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, documentation, nextAddress);
                binaryWriter.Write(defaultMaterialName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)flags);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePropertyBlock>(binaryWriter, properties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateCategoryBlock>(binaryWriter, categories, nextAddress);
                binaryWriter.Write(lightResponse);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryWriter, lODs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryWriter, eMPTYSTRING, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryWriter, eMPTYSTRING0, nextAddress);
                binaryWriter.Write(aux1Shader);
                binaryWriter.Write((Int16)aux1Layer);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(aux2Shader);
                binaryWriter.Write((Int16)aux2Layer);
                binaryWriter.Write(invalidName_1, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessDefinitionNewBlock>(binaryWriter, postprocessDefinition, nextAddress);
                return nextAddress;
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
