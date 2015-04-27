// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessLayerBlock : ShaderPostprocessLayerBlockBase
    {
        public  ShaderPostprocessLayerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessLayerBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ShaderPostprocessLayerBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock passes;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessLayerBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            passes = new TagBlockIndexStructBlock(binaryReader);
        }
        public  ShaderPostprocessLayerBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                passes.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
