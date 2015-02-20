using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 8)]
    public  partial class ModelPermutationBlock : ModelPermutationBlockBase
    {
        public  ModelPermutationBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelPermutationBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadByte();
            this.collisionPermutationIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
        internal enum Flags : byte
        {
            CannotBeChosenRandomly = 1,
        };
    };
}
