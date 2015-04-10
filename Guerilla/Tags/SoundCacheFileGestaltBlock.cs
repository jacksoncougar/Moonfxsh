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
        public  SoundCacheFileGestaltBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundCacheFileGestaltBlockBase(BinaryReader binaryReader)
        {
            this.playbacks = ReadSoundGestaltPlaybackBlockArray(binaryReader);
            this.scales = ReadSoundGestaltScaleBlockArray(binaryReader);
            this.importNames = ReadSoundGestaltImportNamesBlockArray(binaryReader);
            this.pitchRangeParameters = ReadSoundGestaltPitchRangeParametersBlockArray(binaryReader);
            this.pitchRanges = ReadSoundGestaltPitchRangesBlockArray(binaryReader);
            this.permutations = ReadSoundGestaltPermutationsBlockArray(binaryReader);
            this.customPlaybacks = ReadSoundGestaltCustomPlaybackBlockArray(binaryReader);
            this.runtimePermutationFlags = ReadSoundGestaltRuntimePermutationBitVectorBlockArray(binaryReader);
            this.chunks = ReadSoundPermutationChunkBlockArray(binaryReader);
            this.promotions = ReadSoundGestaltPromotionsBlockArray(binaryReader);
            this.extraInfos = ReadSoundGestaltExtraInfoBlockArray(binaryReader);
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
        internal  virtual SoundGestaltPlaybackBlock[] ReadSoundGestaltPlaybackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPlaybackBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltScaleBlock[] ReadSoundGestaltScaleBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltScaleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltScaleBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltScaleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltImportNamesBlock[] ReadSoundGestaltImportNamesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltImportNamesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltImportNamesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltImportNamesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPitchRangeParametersBlock[] ReadSoundGestaltPitchRangeParametersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPitchRangeParametersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPitchRangeParametersBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPitchRangeParametersBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPitchRangesBlock[] ReadSoundGestaltPitchRangesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPitchRangesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPitchRangesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPitchRangesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPermutationsBlock[] ReadSoundGestaltPermutationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPermutationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPermutationsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPermutationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltCustomPlaybackBlock[] ReadSoundGestaltCustomPlaybackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltCustomPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltCustomPlaybackBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltCustomPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltRuntimePermutationBitVectorBlock[] ReadSoundGestaltRuntimePermutationBitVectorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltRuntimePermutationBitVectorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltRuntimePermutationBitVectorBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltRuntimePermutationBitVectorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundPermutationChunkBlock[] ReadSoundPermutationChunkBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationChunkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationChunkBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationChunkBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltPromotionsBlock[] ReadSoundGestaltPromotionsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltPromotionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltPromotionsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltPromotionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGestaltExtraInfoBlock[] ReadSoundGestaltExtraInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGestaltExtraInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGestaltExtraInfoBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGestaltExtraInfoBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
