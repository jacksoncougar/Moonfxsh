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
        public static readonly TagClass Shad = (TagClass)"shad";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("shad")]
    public partial class ShaderBlock : ShaderBlockBase
    {
        public  ShaderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class ShaderBlockBase : GuerillaBlock
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
        internal float addedDepthBiasOffset;
        internal float addedDepthBiasSlopeScale;
        
        public override int SerializedSize{get { return 84; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            template = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            runtimeProperties = Guerilla.ReadBlockArray<ShaderPropertiesBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            parameters = Guerilla.ReadBlockArray<GlobalShaderParameterBlock>(binaryReader);
            postprocessDefinition = Guerilla.ReadBlockArray<ShaderPostprocessDefinitionNewBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(4);
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            lightResponse = binaryReader.ReadTagReference();
            shaderLODBias = (ShaderLODBias)binaryReader.ReadInt16();
            specularType = (SpecularType)binaryReader.ReadInt16();
            lightmapType = (LightmapType)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            lightmapSpecularBrightness = binaryReader.ReadSingle();
            lightmapAmbientBias11 = binaryReader.ReadSingle();
            addedDepthBiasOffset = binaryReader.ReadSingle();
            addedDepthBiasSlopeScale = binaryReader.ReadSingle();
        }
        public  ShaderBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            template = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            runtimeProperties = Guerilla.ReadBlockArray<ShaderPropertiesBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            parameters = Guerilla.ReadBlockArray<GlobalShaderParameterBlock>(binaryReader);
            postprocessDefinition = Guerilla.ReadBlockArray<ShaderPostprocessDefinitionNewBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(4);
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            lightResponse = binaryReader.ReadTagReference();
            shaderLODBias = (ShaderLODBias)binaryReader.ReadInt16();
            specularType = (SpecularType)binaryReader.ReadInt16();
            lightmapType = (LightmapType)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            lightmapSpecularBrightness = binaryReader.ReadSingle();
            lightmapAmbientBias11 = binaryReader.ReadSingle();
            addedDepthBiasOffset = binaryReader.ReadSingle();
            addedDepthBiasSlopeScale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(template);
                binaryWriter.Write(materialName);
                nextAddress = Guerilla.WriteBlockArray<ShaderPropertiesBlock>(binaryWriter, runtimeProperties, nextAddress);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)flags);
                nextAddress = Guerilla.WriteBlockArray<GlobalShaderParameterBlock>(binaryWriter, parameters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessDefinitionNewBlock>(binaryWriter, postprocessDefinition, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<PredictedResourceBlock>(binaryWriter, predictedResources, nextAddress);
                binaryWriter.Write(lightResponse);
                binaryWriter.Write((Int16)shaderLODBias);
                binaryWriter.Write((Int16)specularType);
                binaryWriter.Write((Int16)lightmapType);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(lightmapSpecularBrightness);
                binaryWriter.Write(lightmapAmbientBias11);
                binaryWriter.Write(addedDepthBiasOffset);
                binaryWriter.Write(addedDepthBiasSlopeScale);
                return nextAddress;
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
