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
    public partial class MultilingualUnicodeStringReferenceBlock : MultilingualUnicodeStringReferenceBlockBase
    {
        public MultilingualUnicodeStringReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class MultilingualUnicodeStringReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent stringId;
        internal int englishOffset;
        internal int japaneseOffset;
        internal int germanOffset;
        internal int frenchOffset;
        internal int spanishOffset;
        internal int italianOffset;
        internal int koreanOffset;
        internal int chineseOffset;
        internal int portugueseOffset;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MultilingualUnicodeStringReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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