// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ugh!")]
    public  partial class SoundCacheFileGestaltBlock : SoundCacheFileGestaltBlockBase
    {
        public  SoundCacheFileGestaltBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88)]
    public class SoundCacheFileGestaltBlockBase
    {
        internal SoundGestaltPlaybackBlock[] playbacks;
        internal SoundGestaltScaleBlock[] scales;
        internal SoundGestaltImportNamesBlock[] importNames;
        internal SoundGestaltPitchRangeParametersBlock[] pitchRangeParameters;
        internal SoundGestaltPitchRangesBlock[] pitchRanges;
        internal SoundGestaltPermutationsBlock[] permutations;
        internal SoundGestaltCustomPlaybackBlock[] customPlaybacks;
        internal SoundGestaltRuntimePermutationBitVectorBlock[] runtimePermutationFlags;
        internal SoundPermutationChunkBlock[] chunks;
        internal SoundGestaltPromotionsBlock[] promotions;
        internal SoundGestaltExtraInfoBlock[] extraInfos;
        internal  SoundCacheFileGestaltBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadSoundGestaltPlaybackBlockArray(binaryReader);
            ReadSoundGestaltScaleBlockArray(binaryReader);
            ReadSoundGestaltImportNamesBlockArray(binaryReader);
            ReadSoundGestaltPitchRangeParametersBlockArray(binaryReader);
            ReadSoundGestaltPitchRangesBlockArray(binaryReader);
            ReadSoundGestaltPermutationsBlockArray(binaryReader);
            ReadSoundGestaltCustomPlaybackBlockArray(binaryReader);
            ReadSoundGestaltRuntimePermutationBitVectorBlockArray(binaryReader);
            ReadSoundPermutationChunkBlockArray(binaryReader);
            ReadSoundGestaltPromotionsBlockArray(binaryReader);
            ReadSoundGestaltExtraInfoBlockArray(binaryReader);
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
        internal  virtual SoundGestaltPlaybackBlock[] ReadSoundGestaltPlaybackBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPlaybackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltScaleBlock[] ReadSoundGestaltScaleBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltScaleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltScaleBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltScaleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltImportNamesBlock[] ReadSoundGestaltImportNamesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltImportNamesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltImportNamesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltImportNamesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPitchRangeParametersBlock[] ReadSoundGestaltPitchRangeParametersBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPitchRangeParametersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPitchRangeParametersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPitchRangeParametersBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPitchRangesBlock[] ReadSoundGestaltPitchRangesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPitchRangesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPitchRangesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPitchRangesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPermutationsBlock[] ReadSoundGestaltPermutationsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPermutationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPermutationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPermutationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltCustomPlaybackBlock[] ReadSoundGestaltCustomPlaybackBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltCustomPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltCustomPlaybackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltCustomPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltRuntimePermutationBitVectorBlock[] ReadSoundGestaltRuntimePermutationBitVectorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltRuntimePermutationBitVectorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltRuntimePermutationBitVectorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltRuntimePermutationBitVectorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundPermutationChunkBlock[] ReadSoundPermutationChunkBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationChunkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationChunkBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationChunkBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPromotionsBlock[] ReadSoundGestaltPromotionsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPromotionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPromotionsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPromotionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltExtraInfoBlock[] ReadSoundGestaltExtraInfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltExtraInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltExtraInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltExtraInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltPlaybackBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltScaleBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltImportNamesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltPitchRangeParametersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltPitchRangesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltPermutationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltCustomPlaybackBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltRuntimePermutationBitVectorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundPermutationChunkBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltPromotionsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGestaltExtraInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteSoundGestaltPlaybackBlockArray(binaryWriter);
                WriteSoundGestaltScaleBlockArray(binaryWriter);
                WriteSoundGestaltImportNamesBlockArray(binaryWriter);
                WriteSoundGestaltPitchRangeParametersBlockArray(binaryWriter);
                WriteSoundGestaltPitchRangesBlockArray(binaryWriter);
                WriteSoundGestaltPermutationsBlockArray(binaryWriter);
                WriteSoundGestaltCustomPlaybackBlockArray(binaryWriter);
                WriteSoundGestaltRuntimePermutationBitVectorBlockArray(binaryWriter);
                WriteSoundPermutationChunkBlockArray(binaryWriter);
                WriteSoundGestaltPromotionsBlockArray(binaryWriter);
                WriteSoundGestaltExtraInfoBlockArray(binaryWriter);
            }
        }
    };
}
