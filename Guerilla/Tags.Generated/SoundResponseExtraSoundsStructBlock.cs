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
    public partial class SoundResponseExtraSoundsStructBlock : SoundResponseExtraSoundsStructBlockBase
    {
        public SoundResponseExtraSoundsStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class SoundResponseExtraSoundsStructBlockBase : GuerillaBlock
    {
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference japaneseSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference germanSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference frenchSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference spanishSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference italianSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference koreanSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference chineseSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference portugueseSound;
        public override int SerializedSize { get { return 64; } }
        public override int Alignment { get { return 4; } }
        public SoundResponseExtraSoundsStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            japaneseSound = binaryReader.ReadTagReference();
            germanSound = binaryReader.ReadTagReference();
            frenchSound = binaryReader.ReadTagReference();
            spanishSound = binaryReader.ReadTagReference();
            italianSound = binaryReader.ReadTagReference();
            koreanSound = binaryReader.ReadTagReference();
            chineseSound = binaryReader.ReadTagReference();
            portugueseSound = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(japaneseSound);
                binaryWriter.Write(germanSound);
                binaryWriter.Write(frenchSound);
                binaryWriter.Write(spanishSound);
                binaryWriter.Write(italianSound);
                binaryWriter.Write(koreanSound);
                binaryWriter.Write(chineseSound);
                binaryWriter.Write(portugueseSound);
                return nextAddress;
            }
        }
    };
}
