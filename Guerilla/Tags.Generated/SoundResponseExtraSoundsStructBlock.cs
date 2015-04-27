// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundResponseExtraSoundsStructBlock : SoundResponseExtraSoundsStructBlockBase
    {
        public  SoundResponseExtraSoundsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundResponseExtraSoundsStructBlock(): base()
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
        
        public override int SerializedSize{get { return 64; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundResponseExtraSoundsStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            japaneseSound = binaryReader.ReadTagReference();
            germanSound = binaryReader.ReadTagReference();
            frenchSound = binaryReader.ReadTagReference();
            spanishSound = binaryReader.ReadTagReference();
            italianSound = binaryReader.ReadTagReference();
            koreanSound = binaryReader.ReadTagReference();
            chineseSound = binaryReader.ReadTagReference();
            portugueseSound = binaryReader.ReadTagReference();
        }
        public  SoundResponseExtraSoundsStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            japaneseSound = binaryReader.ReadTagReference();
            germanSound = binaryReader.ReadTagReference();
            frenchSound = binaryReader.ReadTagReference();
            spanishSound = binaryReader.ReadTagReference();
            italianSound = binaryReader.ReadTagReference();
            koreanSound = binaryReader.ReadTagReference();
            chineseSound = binaryReader.ReadTagReference();
            portugueseSound = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
