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
    public partial class PixelShaderPermutationNewBlock : PixelShaderPermutationNewBlockBase
    {
        public PixelShaderPermutationNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class PixelShaderPermutationNewBlockBase : GuerillaBlock
    {
        internal short enumIndex;
        internal short flags;
        internal TagBlockIndexStructBlock combiners;
        public override int SerializedSize { get { return 6; } }
        public override int Alignment { get { return 4; } }
        public PixelShaderPermutationNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            enumIndex = binaryReader.ReadInt16();
            flags = binaryReader.ReadInt16();
            combiners = new TagBlockIndexStructBlock();
            blamPointers.Concat(combiners.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            combiners.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(enumIndex);
                binaryWriter.Write(flags);
                combiners.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
