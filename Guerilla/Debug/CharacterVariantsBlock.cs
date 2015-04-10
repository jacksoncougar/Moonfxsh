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
        public  CharacterVariantsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterVariantsBlockBase(System.IO.BinaryReader binaryReader)
        {
            variantName = binaryReader.ReadStringID();
            variantIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            variantDesignator = binaryReader.ReadStringID();
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
                binaryWriter.Write(variantName);
                binaryWriter.Write(variantIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(variantDesignator);
            }
        }
    };
}
