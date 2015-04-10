// ReSharper disable All
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
        public  SimplePlatformSoundPlaybackStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SimplePlatformSoundPlaybackStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadPlatformSoundOverrideMixbinsBlockArray(binaryReader);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(8);
            ReadPlatformSoundFilterBlockArray(binaryReader);
            ReadPlatformSoundPitchLfoBlockArray(binaryReader);
            ReadPlatformSoundFilterLfoBlockArray(binaryReader);
            ReadSoundEffectPlaybackBlockArray(binaryReader);
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
        internal  virtual PlatformSoundOverrideMixbinsBlock[] ReadPlatformSoundOverrideMixbinsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundOverrideMixbinsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundOverrideMixbinsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundOverrideMixbinsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundFilterBlock[] ReadPlatformSoundFilterBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundFilterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundFilterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundFilterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundPitchLfoBlock[] ReadPlatformSoundPitchLfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundPitchLfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundPitchLfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundPitchLfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlatformSoundFilterLfoBlock[] ReadPlatformSoundFilterLfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlatformSoundFilterLfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlatformSoundFilterLfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlatformSoundFilterLfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundEffectPlaybackBlock[] ReadSoundEffectPlaybackBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEffectPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEffectPlaybackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEffectPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundOverrideMixbinsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundFilterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundPitchLfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlatformSoundFilterLfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundEffectPlaybackBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WritePlatformSoundOverrideMixbinsBlockArray(binaryWriter);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_, 0, 8);
                WritePlatformSoundFilterBlockArray(binaryWriter);
                WritePlatformSoundPitchLfoBlockArray(binaryWriter);
                WritePlatformSoundFilterLfoBlockArray(binaryWriter);
                WriteSoundEffectPlaybackBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Use3DRadioHack = 1,
        };
    };
}
