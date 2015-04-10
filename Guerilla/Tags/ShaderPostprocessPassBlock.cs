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
    [LayoutAttribute(Size = 10)]
    public class ShaderPostprocessPassBlockBase
    {
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference shaderPass;
        internal TagBlockIndexStructBlock implementations;
        internal  ShaderPostprocessPassBlockBase(BinaryReader binaryReader)
        {
            this.shaderPass = binaryReader.ReadTagReference();
            this.implementations = new TagBlockIndexStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
