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
    public partial class CharacterVariantsBlock : CharacterVariantsBlockBase
    {
        public CharacterVariantsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CharacterVariantsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent variantName;
        internal short variantIndex;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent variantDesignator;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public CharacterVariantsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            variantName = binaryReader.ReadStringID();
            variantIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            variantDesignator = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantName);
                binaryWriter.Write(variantIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(variantDesignator);
                return nextAddress;
            }
        }
    };
}
