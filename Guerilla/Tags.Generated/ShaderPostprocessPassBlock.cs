// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessPassBlock : ShaderPostprocessPassBlockBase
    {
        public  ShaderPostprocessPassBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessPassBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderPostprocessPassBlockBase : GuerillaBlock
    {
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference shaderPass;
        internal TagBlockIndexStructBlock implementations;
        
        public override int SerializedSize{get { return 10; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessPassBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            shaderPass = binaryReader.ReadTagReference();
            implementations = new TagBlockIndexStructBlock(binaryReader);
        }
        public  ShaderPostprocessPassBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            shaderPass = binaryReader.ReadTagReference();
            implementations = new TagBlockIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shaderPass);
                implementations.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
