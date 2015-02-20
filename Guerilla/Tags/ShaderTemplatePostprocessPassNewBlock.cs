using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplatePostprocessPassNewBlock : ShaderTemplatePostprocessPassNewBlockBase
    {
        public  ShaderTemplatePostprocessPassNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10)]
    public class ShaderTemplatePostprocessPassNewBlockBase
    {
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference pass;
        internal TagBlockIndexStructBlock implementations;
        internal  ShaderTemplatePostprocessPassNewBlockBase(BinaryReader binaryReader)
        {
            this.pass = binaryReader.ReadTagReference();
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
