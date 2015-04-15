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
        public  PixelShaderPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PixelShaderPermutationBlockBase  : IGuerilla
    {
        internal short enumIndex;
        internal Flags flags;
        internal TagBlockIndexStructBlock constants;
        internal TagBlockIndexStructBlock combiners;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  PixelShaderPermutationBlockBase(BinaryReader binaryReader)
        {
            enumIndex = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            constants = new TagBlockIndexStructBlock(binaryReader);
            combiners = new TagBlockIndexStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(enumIndex);
                binaryWriter.Write((Int16)flags);
                constants.Write(binaryWriter);
                combiners.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 4);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            HasFinalCombiner = 1,
        };
    };
}
