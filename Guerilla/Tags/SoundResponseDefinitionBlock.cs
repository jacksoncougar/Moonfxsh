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
        public  SoundResponseDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundResponseDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.soundFlags = (SoundFlags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.englishSound = binaryReader.ReadTagReference();
            this.extraSounds = new SoundResponseExtraSoundsStructBlock(binaryReader);
            this.probability = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum SoundFlags : short
        
        {
            AnnouncerSound = 1,
        };
    };
}
