//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagClassAttribute("ugh!")]
    [TagBlockOriginalNameAttribute("sound_cache_file_gestalt_block")]
    public partial class SoundCacheFileGestaltBlock : GuerillaBlock, IWriteDeferrable
    {
        public SoundGestaltPlaybackBlock[] Playbacks = new SoundGestaltPlaybackBlock[0];
        public SoundGestaltScaleBlock[] Scales = new SoundGestaltScaleBlock[0];
        public SoundGestaltImportNamesBlock[] ImportNames = new SoundGestaltImportNamesBlock[0];
        public SoundGestaltPitchRangeParametersBlock[] PitchRangeParameters = new SoundGestaltPitchRangeParametersBlock[0];
        public SoundGestaltPitchRangesBlock[] PitchRanges = new SoundGestaltPitchRangesBlock[0];
        public SoundGestaltPermutationsBlock[] Permutations = new SoundGestaltPermutationsBlock[0];
        public SoundGestaltCustomPlaybackBlock[] CustomPlaybacks = new SoundGestaltCustomPlaybackBlock[0];
        public SoundGestaltRuntimePermutationBitVectorBlock[] RuntimePermutationFlags = new SoundGestaltRuntimePermutationBitVectorBlock[0];
        public SoundPermutationChunkBlock[] Chunks = new SoundPermutationChunkBlock[0];
        public SoundGestaltPromotionsBlock[] Promotions = new SoundGestaltPromotionsBlock[0];
        public SoundGestaltExtraInfoBlock[] ExtraInfos = new SoundGestaltExtraInfoBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 88;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(10));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(52));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(44));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Playbacks = base.ReadBlockArrayData<SoundGestaltPlaybackBlock>(binaryReader, pointerQueue.Dequeue());
            this.Scales = base.ReadBlockArrayData<SoundGestaltScaleBlock>(binaryReader, pointerQueue.Dequeue());
            this.ImportNames = base.ReadBlockArrayData<SoundGestaltImportNamesBlock>(binaryReader, pointerQueue.Dequeue());
            this.PitchRangeParameters = base.ReadBlockArrayData<SoundGestaltPitchRangeParametersBlock>(binaryReader, pointerQueue.Dequeue());
            this.PitchRanges = base.ReadBlockArrayData<SoundGestaltPitchRangesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Permutations = base.ReadBlockArrayData<SoundGestaltPermutationsBlock>(binaryReader, pointerQueue.Dequeue());
            this.CustomPlaybacks = base.ReadBlockArrayData<SoundGestaltCustomPlaybackBlock>(binaryReader, pointerQueue.Dequeue());
            this.RuntimePermutationFlags = base.ReadBlockArrayData<SoundGestaltRuntimePermutationBitVectorBlock>(binaryReader, pointerQueue.Dequeue());
            this.Chunks = base.ReadBlockArrayData<SoundPermutationChunkBlock>(binaryReader, pointerQueue.Dequeue());
            this.Promotions = base.ReadBlockArrayData<SoundGestaltPromotionsBlock>(binaryReader, pointerQueue.Dequeue());
            this.ExtraInfos = base.ReadBlockArrayData<SoundGestaltExtraInfoBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.Playbacks);
            queueableBinaryWriter.Defer(this.Scales);
            queueableBinaryWriter.Defer(this.ImportNames);
            queueableBinaryWriter.Defer(this.PitchRangeParameters);
            queueableBinaryWriter.Defer(this.PitchRanges);
            queueableBinaryWriter.Defer(this.Permutations);
            queueableBinaryWriter.Defer(this.CustomPlaybacks);
            queueableBinaryWriter.Defer(this.RuntimePermutationFlags);
            queueableBinaryWriter.Defer(this.Chunks);
            queueableBinaryWriter.Defer(this.Promotions);
            queueableBinaryWriter.Defer(this.ExtraInfos);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.Playbacks);
            queueableBinaryWriter.WritePointer(this.Scales);
            queueableBinaryWriter.WritePointer(this.ImportNames);
            queueableBinaryWriter.WritePointer(this.PitchRangeParameters);
            queueableBinaryWriter.WritePointer(this.PitchRanges);
            queueableBinaryWriter.WritePointer(this.Permutations);
            queueableBinaryWriter.WritePointer(this.CustomPlaybacks);
            queueableBinaryWriter.WritePointer(this.RuntimePermutationFlags);
            queueableBinaryWriter.WritePointer(this.Chunks);
            queueableBinaryWriter.WritePointer(this.Promotions);
            queueableBinaryWriter.WritePointer(this.ExtraInfos);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Ugh = ((TagClass)("ugh!"));
    }
}
