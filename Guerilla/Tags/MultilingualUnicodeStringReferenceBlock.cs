using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultilingualUnicodeStringReferenceBlock : MultilingualUnicodeStringReferenceBlockBase
    {
        public  MultilingualUnicodeStringReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class MultilingualUnicodeStringReferenceBlockBase
    {
        internal Moonfish.Tags.StringID stringId;
        internal int englishOffset;
        internal int japaneseOffset;
        internal int germanOffset;
        internal int frenchOffset;
        internal int spanishOffset;
        internal int italianOffset;
        internal int koreanOffset;
        internal int chineseOffset;
        internal int portugueseOffset;
        internal  MultilingualUnicodeStringReferenceBlockBase(BinaryReader binaryReader)
        {
            this.stringId = binaryReader.ReadStringID();
            this.englishOffset = binaryReader.ReadInt32();
            this.japaneseOffset = binaryReader.ReadInt32();
            this.germanOffset = binaryReader.ReadInt32();
            this.frenchOffset = binaryReader.ReadInt32();
            this.spanishOffset = binaryReader.ReadInt32();
            this.italianOffset = binaryReader.ReadInt32();
            this.koreanOffset = binaryReader.ReadInt32();
            this.chineseOffset = binaryReader.ReadInt32();
            this.portugueseOffset = binaryReader.ReadInt32();
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
    };
}
