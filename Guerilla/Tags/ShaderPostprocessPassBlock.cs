// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessPassBlock : ShaderPostprocessPassBlockBase
    {
        public  ShaderPostprocessPassBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderPostprocessPassBlockBase  : IGuerilla
    {
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference shaderPass;
        internal TagBlockIndexStructBlock implementations;
        internal  ShaderPostprocessPassBlockBase(BinaryReader binaryReader)
        {
            shaderPass = binaryReader.ReadTagReference();
            implementations = new TagBlockIndexStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shaderPass);
                implementations.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
