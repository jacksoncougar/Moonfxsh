// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplatePostprocessDefinitionNewBlock : ShaderTemplatePostprocessDefinitionNewBlockBase
    {
        public  ShaderTemplatePostprocessDefinitionNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderTemplatePostprocessDefinitionNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class ShaderTemplatePostprocessDefinitionNewBlockBase : GuerillaBlock
    {
        internal ShaderTemplatePostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        internal TagBlockIndexBlock[] layers;
        internal ShaderTemplatePostprocessPassNewBlock[] passes;
        internal ShaderTemplatePostprocessImplementationNewBlock[] implementations;
        internal ShaderTemplatePostprocessRemappingNewBlock[] remappings;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderTemplatePostprocessDefinitionNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            levelsOfDetail = Guerilla.ReadBlockArray<ShaderTemplatePostprocessLevelOfDetailNewBlock>(binaryReader);
            layers = Guerilla.ReadBlockArray<TagBlockIndexBlock>(binaryReader);
            passes = Guerilla.ReadBlockArray<ShaderTemplatePostprocessPassNewBlock>(binaryReader);
            implementations = Guerilla.ReadBlockArray<ShaderTemplatePostprocessImplementationNewBlock>(binaryReader);
            remappings = Guerilla.ReadBlockArray<ShaderTemplatePostprocessRemappingNewBlock>(binaryReader);
        }
        public  ShaderTemplatePostprocessDefinitionNewBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            levelsOfDetail = Guerilla.ReadBlockArray<ShaderTemplatePostprocessLevelOfDetailNewBlock>(binaryReader);
            layers = Guerilla.ReadBlockArray<TagBlockIndexBlock>(binaryReader);
            passes = Guerilla.ReadBlockArray<ShaderTemplatePostprocessPassNewBlock>(binaryReader);
            implementations = Guerilla.ReadBlockArray<ShaderTemplatePostprocessImplementationNewBlock>(binaryReader);
            remappings = Guerilla.ReadBlockArray<ShaderTemplatePostprocessRemappingNewBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessLevelOfDetailNewBlock>(binaryWriter, levelsOfDetail, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TagBlockIndexBlock>(binaryWriter, layers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessPassNewBlock>(binaryWriter, passes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessImplementationNewBlock>(binaryWriter, implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessRemappingNewBlock>(binaryWriter, remappings, nextAddress);
                return nextAddress;
            }
        }
    };
}
