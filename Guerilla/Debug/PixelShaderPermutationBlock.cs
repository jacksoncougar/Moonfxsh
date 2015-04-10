// ReSharper disable All
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
        public  PixelShaderPermutationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PixelShaderPermutationBlockBase(System.IO.BinaryReader binaryReader)
        {
            enumIndex = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            constants = new TagBlockIndexStructBlock(binaryReader);
            combiners = new TagBlockIndexStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(enumIndex);
                binaryWriter.Write((Int16)flags);
                constants.Write(binaryWriter);
                combiners.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 4);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            HasFinalCombiner = 1,
        };
    };
}
