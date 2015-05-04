// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PixelShaderPermutationBlock : PixelShaderPermutationBlockBase
    {
        public PixelShaderPermutationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PixelShaderPermutationBlockBase : GuerillaBlock
    {
        internal short enumIndex;
        internal Flags flags;
        internal TagBlockIndexStructBlock constants;
        internal TagBlockIndexStructBlock combiners;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public PixelShaderPermutationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            enumIndex = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            constants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(constants.ReadFields(binaryReader)));
            combiners = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(combiners.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(4);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            constants.ReadPointers(binaryReader, blamPointers);
            combiners.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
