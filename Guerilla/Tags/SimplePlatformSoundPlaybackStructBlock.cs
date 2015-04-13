using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SimplePlatformSoundPlaybackStructBlock : SimplePlatformSoundPlaybackStructBlockBase
    {
        public  SimplePlatformSoundPlaybackStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class SimplePlatformSoundPlaybackStructBlockBase
    {
        internal PlatformSoundOverrideMixbinsBlock[] platformSoundOverrideMixbinsBlock;
        internal Flags flags;
        internal byte[] invalidName_;
        internal PlatformSoundFilterBlock[] filter;
        internal PlatformSoundPitchLfoBlock[] pitchLfo;
        internal PlatformSoundFilterLfoBlock[] filterLfo;
        internal SoundEffectPlaybackBlock[] soundEffect;
        internal  SimplePlatformSoundPlaybackStructBlockBase(BinaryReader binaryReader)
        {
            this.platformSoundOverrideMixbinsBlock = ReadPlatformSoundOverrideMixbinsBlockArray(binaryReader);
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(8);
            this.filter = ReadPlatformSoundFilterBlockArray(binaryReader);
            this.pitchLfo = ReadPlatformSoundPitchLfoBlockArray(binaryReader);
            this.filterLfo = ReadPlatformSoundFilterLfoBlockArray(binaryReader);
            this.soundEffect = ReadSoundEffectPlaybackBlockArray(binaryReader);
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
        internal  virtual PlatformSoundOverrideMixbinsBlock[] ReadPlatformSoundOverrideMixbinsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundOverrideMixbinsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundOverrideMixbinsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundOverrideMixbinsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundFilterBlock[] ReadPlatformSoundFilterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundFilterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundFilterBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundFilterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundPitchLfoBlock[] ReadPlatformSoundPitchLfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundPitchLfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundPitchLfoBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundPitchLfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundFilterLfoBlock[] ReadPlatformSoundFilterLfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundFilterLfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundFilterLfoBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundFilterLfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundEffectPlaybackBlock[] ReadSoundEffectPlaybackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectPlaybackBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Use3DRadioHack = 1,
        };
    };
}
