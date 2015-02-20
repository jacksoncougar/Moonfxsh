using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderPermutationBlock : PixelShaderPermutationBlockBase
    {
        public  PixelShaderPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class PixelShaderPermutationBlockBase
    {
        internal short enumIndex;
        internal Flags flags;
        internal TagBlockIndexStructBlock constants;
        internal TagBlockIndexStructBlock combiners;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  PixelShaderPermutationBlockBase(BinaryReader binaryReader)
        {
            this.enumIndex = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.constants = new TagBlockIndexStructBlock(binaryReader);
            this.combiners = new TagBlockIndexStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = binaryReader.ReadBytes(4);
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            HasFinalCombiner = 1,
        };
    };
}
