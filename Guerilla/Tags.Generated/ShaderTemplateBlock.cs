// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public ShaderTemplateBlock() : base()
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
        public override int SerializedSize { get { return 96; } }
        public override int Alignment { get { return 4; } }
        public ShaderTemplateBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            defaultMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplatePropertyBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplateCategoryBlock>(binaryReader));
            lightResponse = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplateLevelOfDetailBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader));
            aux1Shader = binaryReader.ReadTagReference();
            aux1Layer = (Aux1Layer)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            aux2Shader = binaryReader.ReadTagReference();
            aux2Layer = (Aux2Layer)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplatePostprocessDefinitionNewBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            documentation = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            properties = ReadBlockArrayData<ShaderTemplatePropertyBlock>(binaryReader, blamPointers.Dequeue());
            categories = ReadBlockArrayData<ShaderTemplateCategoryBlock>(binaryReader, blamPointers.Dequeue());
            lODs = ReadBlockArrayData<ShaderTemplateLevelOfDetailBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING = ReadBlockArrayData<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING0 = ReadBlockArrayData<ShaderTemplateRuntimeExternalLightResponseIndexBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            postprocessDefinition = ReadBlockArrayData<ShaderTemplatePostprocessDefinitionNewBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
