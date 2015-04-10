using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundResponseExtraSoundsStructBlock : SoundResponseExtraSoundsStructBlockBase
    {
        public  SoundResponseExtraSoundsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class SoundResponseExtraSoundsStructBlockBase
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
        internal  SoundResponseExtraSoundsStructBlockBase(BinaryReader binaryReader)
        {
            this.japaneseSound = binaryReader.ReadTagReference();
            this.germanSound = binaryReader.ReadTagReference();
            this.frenchSound = binaryReader.ReadTagReference();
            this.spanishSound = binaryReader.ReadTagReference();
            this.italianSound = binaryReader.ReadTagReference();
            this.koreanSound = binaryReader.ReadTagReference();
            this.chineseSound = binaryReader.ReadTagReference();
            this.portugueseSound = binaryReader.ReadTagReference();
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
