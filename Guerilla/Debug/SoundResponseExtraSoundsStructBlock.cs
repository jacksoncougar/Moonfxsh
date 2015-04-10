// ReSharper disable All
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
        public  SoundResponseExtraSoundsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundResponseExtraSoundsStructBlockBase(System.IO.BinaryReader binaryReader)
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
                binaryWriter.Write(japaneseSound);
                binaryWriter.Write(germanSound);
                binaryWriter.Write(frenchSound);
                binaryWriter.Write(spanishSound);
                binaryWriter.Write(italianSound);
                binaryWriter.Write(koreanSound);
                binaryWriter.Write(chineseSound);
                binaryWriter.Write(portugueseSound);
            }
        }
    };
}
