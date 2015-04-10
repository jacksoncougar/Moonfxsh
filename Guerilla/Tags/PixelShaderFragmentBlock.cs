using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderFragmentBlock : PixelShaderFragmentBlockBase
    {
        public  PixelShaderFragmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 3)]
    public class PixelShaderFragmentBlockBase
    {
        internal byte switchParameterIndex;
        internal TagBlockIndexStructBlock permutationsIndex;
        internal  PixelShaderFragmentBlockBase(BinaryReader binaryReader)
        {
            this.switchParameterIndex = binaryReader.ReadByte();
            this.permutationsIndex = new TagBlockIndexStructBlock(binaryReader);
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
