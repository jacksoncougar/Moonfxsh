// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessAnimatedParameterNewBlock : ShaderPostprocessAnimatedParameterNewBlockBase
    {
        public  ShaderPostprocessAnimatedParameterNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessAnimatedParameterNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ShaderPostprocessAnimatedParameterNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock overlayReferences;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessAnimatedParameterNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            overlayReferences = new TagBlockIndexStructBlock(binaryReader);
        }
        public  ShaderPostprocessAnimatedParameterNewBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            overlayReferences = new TagBlockIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                overlayReferences.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
