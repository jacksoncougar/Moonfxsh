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
    public partial class PixelShaderFragmentBlock : PixelShaderFragmentBlockBase
    {
        public PixelShaderFragmentBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PixelShaderFragmentBlockBase : GuerillaBlock
    {
        internal byte switchParameterIndex;
        internal byte[] invalidName_;
        internal TagBlockIndexStructBlock permutationsIndex;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public PixelShaderFragmentBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            switchParameterIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            permutationsIndex = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(permutationsIndex.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            permutationsIndex.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(switchParameterIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                permutationsIndex.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
