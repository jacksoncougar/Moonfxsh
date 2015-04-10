using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sfx+")]
    public  partial class SoundEffectCollectionBlock : SoundEffectCollectionBlockBase
    {
        public  SoundEffectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SoundEffectCollectionBlockBase
    {
        internal PlatformSoundPlaybackBlock[] soundEffects;
        internal  SoundEffectCollectionBlockBase(BinaryReader binaryReader)
        {
            this.soundEffects = ReadPlatformSoundPlaybackBlockArray(binaryReader);
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
        internal  virtual PlatformSoundPlaybackBlock[] ReadPlatformSoundPlaybackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundPlaybackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
