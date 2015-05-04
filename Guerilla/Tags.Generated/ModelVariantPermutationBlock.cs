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
    public partial class ModelVariantPermutationBlock : ModelVariantPermutationBlockBase
    {
        public ModelVariantPermutationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ModelVariantPermutationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent permutationName;
        internal byte[] invalidName_;
        internal Flags flags;
        internal byte[] invalidName_0;
        internal float probability0Inf;
        internal ModelVariantStateBlock[] states;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public ModelVariantPermutationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            permutationName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            flags = (Flags)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(2);
            probability0Inf = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelVariantStateBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(5);
            invalidName_2 = binaryReader.ReadBytes(7);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            states = ReadBlockArrayData<ModelVariantStateBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(permutationName);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(probability0Inf);
                nextAddress = Guerilla.WriteBlockArray<ModelVariantStateBlock>(binaryWriter, states, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 5);
                binaryWriter.Write(invalidName_2, 0, 7);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        {
            CopyStatesToAllPermutations = 1,
        };
    };
}
