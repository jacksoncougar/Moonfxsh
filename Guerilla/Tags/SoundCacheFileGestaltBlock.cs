// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Ugh!Class = (TagClass)"ugh!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ugh!")]
    public  partial class SoundCacheFileGestaltBlock : SoundCacheFileGestaltBlockBase
    {
        public  SoundCacheFileGestaltBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class SoundCacheFileGestaltBlockBase  : IGuerilla
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
            playbacks = Guerilla.ReadBlockArray<SoundGestaltPlaybackBlock>(binaryReader);
            scales = Guerilla.ReadBlockArray<SoundGestaltScaleBlock>(binaryReader);
            importNames = Guerilla.ReadBlockArray<SoundGestaltImportNamesBlock>(binaryReader);
            pitchRangeParameters = Guerilla.ReadBlockArray<SoundGestaltPitchRangeParametersBlock>(binaryReader);
            pitchRanges = Guerilla.ReadBlockArray<SoundGestaltPitchRangesBlock>(binaryReader);
            permutations = Guerilla.ReadBlockArray<SoundGestaltPermutationsBlock>(binaryReader);
            customPlaybacks = Guerilla.ReadBlockArray<SoundGestaltCustomPlaybackBlock>(binaryReader);
            runtimePermutationFlags = Guerilla.ReadBlockArray<SoundGestaltRuntimePermutationBitVectorBlock>(binaryReader);
            chunks = Guerilla.ReadBlockArray<SoundPermutationChunkBlock>(binaryReader);
            promotions = Guerilla.ReadBlockArray<SoundGestaltPromotionsBlock>(binaryReader);
            extraInfos = Guerilla.ReadBlockArray<SoundGestaltExtraInfoBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<SoundGestaltPlaybackBlock>(binaryWriter, playbacks, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltScaleBlock>(binaryWriter, scales, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltImportNamesBlock>(binaryWriter, importNames, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltPitchRangeParametersBlock>(binaryWriter, pitchRangeParameters, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltPitchRangesBlock>(binaryWriter, pitchRanges, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltPermutationsBlock>(binaryWriter, permutations, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltCustomPlaybackBlock>(binaryWriter, customPlaybacks, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltRuntimePermutationBitVectorBlock>(binaryWriter, runtimePermutationFlags, nextAddress);
                Guerilla.WriteBlockArray<SoundPermutationChunkBlock>(binaryWriter, chunks, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltPromotionsBlock>(binaryWriter, promotions, nextAddress);
                Guerilla.WriteBlockArray<SoundGestaltExtraInfoBlock>(binaryWriter, extraInfos, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
