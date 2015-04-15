// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterVariantsBlock : CharacterVariantsBlockBase
    {
        public  CharacterVariantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CharacterVariantsBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID variantName;
        internal short variantIndex;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID variantDesignator;
        internal  CharacterVariantsBlockBase(BinaryReader binaryReader)
        {
            variantName = binaryReader.ReadStringID();
            variantIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            variantDesignator = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
