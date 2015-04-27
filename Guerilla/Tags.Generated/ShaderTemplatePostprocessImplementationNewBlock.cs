// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplatePostprocessImplementationNewBlock : ShaderTemplatePostprocessImplementationNewBlockBase
    {
        public  ShaderTemplatePostprocessImplementationNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderTemplatePostprocessImplementationNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock bitmaps;
        internal TagBlockIndexStructBlock pixelConstants;
        internal TagBlockIndexStructBlock vertexConstants;
        
        public override int SerializedSize{get { return 6; }}
        
        internal  ShaderTemplatePostprocessImplementationNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmaps = new TagBlockIndexStructBlock(binaryReader);
            pixelConstants = new TagBlockIndexStructBlock(binaryReader);
            vertexConstants = new TagBlockIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                bitmaps.Write(binaryWriter);
                pixelConstants.Write(binaryWriter);
                vertexConstants.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
