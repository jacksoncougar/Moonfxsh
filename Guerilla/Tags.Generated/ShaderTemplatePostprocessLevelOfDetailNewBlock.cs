// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplatePostprocessLevelOfDetailNewBlock : ShaderTemplatePostprocessLevelOfDetailNewBlockBase
    {
        public  ShaderTemplatePostprocessLevelOfDetailNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderTemplatePostprocessLevelOfDetailNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderTemplatePostprocessLevelOfDetailNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock layers;
        internal int availableLayers;
        internal float projectedHeightPercentage;
        
        public override int SerializedSize{get { return 10; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderTemplatePostprocessLevelOfDetailNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            layers = new TagBlockIndexStructBlock(binaryReader);
            availableLayers = binaryReader.ReadInt32();
            projectedHeightPercentage = binaryReader.ReadSingle();
        }
        public  ShaderTemplatePostprocessLevelOfDetailNewBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                layers.Write(binaryWriter);
                binaryWriter.Write(availableLayers);
                binaryWriter.Write(projectedHeightPercentage);
                return nextAddress;
            }
        }
    };
}
