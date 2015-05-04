// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public SoundCacheFileGestaltBlock() : base()
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
        public override int SerializedSize { get { return 88; } }
        public override int Alignment { get { return 4; } }
        public SoundCacheFileGestaltBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltPlaybackBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltScaleBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltImportNamesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltPitchRangeParametersBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltPitchRangesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltPermutationsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltCustomPlaybackBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltRuntimePermutationBitVectorBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundPermutationChunkBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltPromotionsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGestaltExtraInfoBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            playbacks = ReadBlockArrayData<SoundGestaltPlaybackBlock>(binaryReader, blamPointers.Dequeue());
            scales = ReadBlockArrayData<SoundGestaltScaleBlock>(binaryReader, blamPointers.Dequeue());
            importNames = ReadBlockArrayData<SoundGestaltImportNamesBlock>(binaryReader, blamPointers.Dequeue());
            pitchRangeParameters = ReadBlockArrayData<SoundGestaltPitchRangeParametersBlock>(binaryReader, blamPointers.Dequeue());
            pitchRanges = ReadBlockArrayData<SoundGestaltPitchRangesBlock>(binaryReader, blamPointers.Dequeue());
            permutations = ReadBlockArrayData<SoundGestaltPermutationsBlock>(binaryReader, blamPointers.Dequeue());
            customPlaybacks = ReadBlockArrayData<SoundGestaltCustomPlaybackBlock>(binaryReader, blamPointers.Dequeue());
            runtimePermutationFlags = ReadBlockArrayData<SoundGestaltRuntimePermutationBitVectorBlock>(binaryReader, blamPointers.Dequeue());
            chunks = ReadBlockArrayData<SoundPermutationChunkBlock>(binaryReader, blamPointers.Dequeue());
            promotions = ReadBlockArrayData<SoundGestaltPromotionsBlock>(binaryReader, blamPointers.Dequeue());
            extraInfos = ReadBlockArrayData<SoundGestaltExtraInfoBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
