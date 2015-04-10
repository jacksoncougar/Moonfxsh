// ReSharper disable All
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
        public  MultilingualUnicodeStringReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MultilingualUnicodeStringReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            stringId = binaryReader.ReadStringID();
            englishOffset = binaryReader.ReadInt32();
            japaneseOffset = binaryReader.ReadInt32();
            germanOffset = binaryReader.ReadInt32();
            frenchOffset = binaryReader.ReadInt32();
            spanishOffset = binaryReader.ReadInt32();
            italianOffset = binaryReader.ReadInt32();
            koreanOffset = binaryReader.ReadInt32();
            chineseOffset = binaryReader.ReadInt32();
            portugueseOffset = binaryReader.ReadInt32();
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
                binaryWriter.Write(stringId);
                binaryWriter.Write(englishOffset);
                binaryWriter.Write(japaneseOffset);
                binaryWriter.Write(germanOffset);
                binaryWriter.Write(frenchOffset);
                binaryWriter.Write(spanishOffset);
                binaryWriter.Write(italianOffset);
                binaryWriter.Write(koreanOffset);
                binaryWriter.Write(chineseOffset);
                binaryWriter.Write(portugueseOffset);
            }
        }
    };
}
