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
    [LayoutAttribute(Size = 12)]
    public class CharacterVariantsBlockBase
    {
        internal Moonfish.Tags.StringID variantName;
        internal short variantIndex;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID variantDesignator;
        internal  CharacterVariantsBlockBase(BinaryReader binaryReader)
        {
            this.variantName = binaryReader.ReadStringID();
            this.variantIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.variantDesignator = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
