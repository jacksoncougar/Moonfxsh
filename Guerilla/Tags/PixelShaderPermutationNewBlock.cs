using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderPermutationNewBlock : PixelShaderPermutationNewBlockBase
    {
        public  PixelShaderPermutationNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6)]
    public class PixelShaderPermutationNewBlockBase
    {
        internal short enumIndex;
        internal short flags;
        internal TagBlockIndexStructBlock combiners;
        internal  PixelShaderPermutationNewBlockBase(BinaryReader binaryReader)
        {
            this.enumIndex = binaryReader.ReadInt16();
            this.flags = binaryReader.ReadInt16();
            this.combiners = new TagBlockIndexStructBlock(binaryReader);
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
