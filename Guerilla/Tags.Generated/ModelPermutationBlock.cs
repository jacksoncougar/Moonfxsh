// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelPermutationBlock : ModelPermutationBlockBase
    {
        public  ModelPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ModelPermutationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ModelPermutationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal byte collisionPermutationIndex;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ModelPermutationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadByte();
            collisionPermutationIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  ModelPermutationBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
