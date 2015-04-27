// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultilingualUnicodeStringReferenceBlock : MultilingualUnicodeStringReferenceBlockBase
    {
        public  MultilingualUnicodeStringReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MultilingualUnicodeStringReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class MultilingualUnicodeStringReferenceBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MultilingualUnicodeStringReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public  MultilingualUnicodeStringReferenceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
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
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
