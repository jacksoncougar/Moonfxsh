// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelVariantPermutationBlock : ModelVariantPermutationBlockBase
    {
        public  ModelVariantPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ModelVariantPermutationBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID permutationName;
        internal byte[] invalidName_;
        internal Flags flags;
        internal byte[] invalidName_0;
        internal float probability0Inf;
        internal ModelVariantStateBlock[] states;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  ModelVariantPermutationBlockBase(BinaryReader binaryReader)
        {
            permutationName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            flags = (Flags)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(2);
            probability0Inf = binaryReader.ReadSingle();
            states = Guerilla.ReadBlockArray<ModelVariantStateBlock>(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(5);
            invalidName_2 = binaryReader.ReadBytes(7);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
