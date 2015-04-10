// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundResponseDefinitionBlock : SoundResponseDefinitionBlockBase
    {
        public  SoundResponseDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class SoundResponseDefinitionBlockBase
    {
        internal SoundFlags soundFlags;
        internal byte[] invalidName_;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference englishSound;
        internal SoundResponseExtraSoundsStructBlock extraSounds;
        internal float probability;
        internal  SoundResponseDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            soundFlags = (SoundFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            englishSound = binaryReader.ReadTagReference();
            extraSounds = new SoundResponseExtraSoundsStructBlock(binaryReader);
            probability = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16)soundFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(englishSound);
                extraSounds.Write(binaryWriter);
                binaryWriter.Write(probability);
            }
        }
        [FlagsAttribute]
        internal enum SoundFlags : short
        
        {
            AnnouncerSound = 1,
        };
    };
}
