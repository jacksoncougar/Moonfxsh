// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelPermutationBlock : ModelPermutationBlockBase
    {
        public  ModelPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ModelPermutationBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal byte collisionPermutationIndex;
        internal byte[] invalidName_;
        internal  ModelPermutationBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadByte();
            collisionPermutationIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(collisionPermutationIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        {
            CannotBeChosenRandomly = 1,
        };
    };
}
