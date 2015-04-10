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
        public  ModelPermutationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ModelPermutationBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal byte collisionPermutationIndex;
        internal byte[] invalidName_;
        internal  ModelPermutationBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadByte();
            collisionPermutationIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(name);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(collisionPermutationIndex);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            CannotBeChosenRandomly = 1,
        };
    };
}
