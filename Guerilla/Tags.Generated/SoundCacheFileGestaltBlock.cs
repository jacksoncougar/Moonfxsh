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
        public static readonly TagClass Ugh = (TagClass)"ugh!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ugh!")]
    public partial class SoundCacheFileGestaltBlock : SoundCacheFileGestaltBlockBase
    {
        public  SoundCacheFileGestaltBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class SoundCacheFileGestaltBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 88; }}
        
        internal  SoundCacheFileGestaltBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltPlaybackBlock>(binaryWriter, playbacks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltScaleBlock>(binaryWriter, scales, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltImportNamesBlock>(binaryWriter, importNames, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltPitchRangeParametersBlock>(binaryWriter, pitchRangeParameters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltPitchRangesBlock>(binaryWriter, pitchRanges, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltPermutationsBlock>(binaryWriter, permutations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltCustomPlaybackBlock>(binaryWriter, customPlaybacks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltRuntimePermutationBitVectorBlock>(binaryWriter, runtimePermutationFlags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundPermutationChunkBlock>(binaryWriter, chunks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltPromotionsBlock>(binaryWriter, promotions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGestaltExtraInfoBlock>(binaryWriter, extraInfos, nextAddress);
                return nextAddress;
            }
        }
    };
}
