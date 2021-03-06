//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class AnimationPoolBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public int NodeListChecksum;
        public int ProductionChecksum;
        public int ImportChecksum;
        public TypeEnum Type;
        public FrameInfoTypeEnum FrameInfoType;
        public Moonfish.Tags.ByteBlockIndex1 BlendScreen;
        public byte NodeCount;
        public short FrameCount;
        public InternalFlags AnimationPoolInternalFlags;
        public ProductionFlags AnimationPoolProductionFlags;
        public PlaybackFlags AnimationPoolPlaybackFlags;
        public DesiredCompressionEnum DesiredCompression;
        public CurrentCompressionEnum CurrentCompression;
        public float Weight;
        public int ParentGraphIndex;
        public int ParentGraphBlockIndex;
        public int ParentGraphBlockOffset;
        public short ParentGraphStartingPointIndex;
        public short LoopFrameIndex;
        public Moonfish.Tags.ShortBlockIndex1 ParentAnimation;
        public Moonfish.Tags.ShortBlockIndex1 NextAnimation;
        public byte[] AnimationData;
        public PackedDataSizesStructBlock DataSizes = new PackedDataSizesStructBlock();
        public AnimationFrameEventBlock[] FrameEventsABCDCC = new AnimationFrameEventBlock[0];
        public AnimationSoundEventBlock[] SoundEventsABCDCC = new AnimationSoundEventBlock[0];
        public AnimationEffectEventBlock[] EffectEventsABCDCC = new AnimationEffectEventBlock[0];
        public ObjectSpaceNodeDataBlock[] ObjectspaceParentNodesABCDCC = new ObjectSpaceNodeDataBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 108;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadStringID();
            this.NodeListChecksum = binaryReader.ReadInt32();
            this.ProductionChecksum = binaryReader.ReadInt32();
            this.ImportChecksum = binaryReader.ReadInt32();
            this.Type = ((TypeEnum)(binaryReader.ReadByte()));
            this.FrameInfoType = ((FrameInfoTypeEnum)(binaryReader.ReadByte()));
            this.BlendScreen = binaryReader.ReadByteBlockIndex1();
            this.NodeCount = binaryReader.ReadByte();
            this.FrameCount = binaryReader.ReadInt16();
            this.AnimationPoolInternalFlags = ((InternalFlags)(binaryReader.ReadByte()));
            this.AnimationPoolProductionFlags = ((ProductionFlags)(binaryReader.ReadByte()));
            this.AnimationPoolPlaybackFlags = ((PlaybackFlags)(binaryReader.ReadInt16()));
            this.DesiredCompression = ((DesiredCompressionEnum)(binaryReader.ReadByte()));
            this.CurrentCompression = ((CurrentCompressionEnum)(binaryReader.ReadByte()));
            this.Weight = binaryReader.ReadSingle();
            this.ParentGraphIndex = binaryReader.ReadInt32();
            this.ParentGraphBlockIndex = binaryReader.ReadInt32();
            this.ParentGraphBlockOffset = binaryReader.ReadInt32();
            this.ParentGraphStartingPointIndex = binaryReader.ReadInt16();
            this.LoopFrameIndex = binaryReader.ReadInt16();
            this.ParentAnimation = binaryReader.ReadShortBlockIndex1();
            this.NextAnimation = binaryReader.ReadShortBlockIndex1();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.DataSizes.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.AnimationData = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.DataSizes.ReadInstances(binaryReader, pointerQueue);
            this.FrameEventsABCDCC = base.ReadBlockArrayData<AnimationFrameEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundEventsABCDCC = base.ReadBlockArrayData<AnimationSoundEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.EffectEventsABCDCC = base.ReadBlockArrayData<AnimationEffectEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.ObjectspaceParentNodesABCDCC = base.ReadBlockArrayData<ObjectSpaceNodeDataBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.AnimationData);
            this.DataSizes.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.FrameEventsABCDCC);
            queueableBinaryWriter.QueueWrite(this.SoundEventsABCDCC);
            queueableBinaryWriter.QueueWrite(this.EffectEventsABCDCC);
            queueableBinaryWriter.QueueWrite(this.ObjectspaceParentNodesABCDCC);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.NodeListChecksum);
            queueableBinaryWriter.Write(this.ProductionChecksum);
            queueableBinaryWriter.Write(this.ImportChecksum);
            queueableBinaryWriter.Write(((byte)(this.Type)));
            queueableBinaryWriter.Write(((byte)(this.FrameInfoType)));
            queueableBinaryWriter.Write(this.BlendScreen);
            queueableBinaryWriter.Write(this.NodeCount);
            queueableBinaryWriter.Write(this.FrameCount);
            queueableBinaryWriter.Write(((byte)(this.AnimationPoolInternalFlags)));
            queueableBinaryWriter.Write(((byte)(this.AnimationPoolProductionFlags)));
            queueableBinaryWriter.Write(((short)(this.AnimationPoolPlaybackFlags)));
            queueableBinaryWriter.Write(((byte)(this.DesiredCompression)));
            queueableBinaryWriter.Write(((byte)(this.CurrentCompression)));
            queueableBinaryWriter.Write(this.Weight);
            queueableBinaryWriter.Write(this.ParentGraphIndex);
            queueableBinaryWriter.Write(this.ParentGraphBlockIndex);
            queueableBinaryWriter.Write(this.ParentGraphBlockOffset);
            queueableBinaryWriter.Write(this.ParentGraphStartingPointIndex);
            queueableBinaryWriter.Write(this.LoopFrameIndex);
            queueableBinaryWriter.Write(this.ParentAnimation);
            queueableBinaryWriter.Write(this.NextAnimation);
            queueableBinaryWriter.WritePointer(this.AnimationData);
            this.DataSizes.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.FrameEventsABCDCC);
            queueableBinaryWriter.WritePointer(this.SoundEventsABCDCC);
            queueableBinaryWriter.WritePointer(this.EffectEventsABCDCC);
            queueableBinaryWriter.WritePointer(this.ObjectspaceParentNodesABCDCC);
        }
        public enum TypeEnum : byte
        {
            Base = 0,
            Overlay = 1,
            Replacement = 2,
        }
        public enum FrameInfoTypeEnum : byte
        {
            None = 0,
            Dxdy = 1,
            Dxdydyaw = 2,
            Dxdydzdyaw = 3,
        }
        [System.FlagsAttribute()]
        public enum InternalFlags : byte
        {
            None = 0,
            unused0 = 1,
            WorldRelative = 2,
            unused1 = 4,
            unused2 = 8,
            unused3 = 16,
            CompressionDisabled = 32,
            OldProductionChecksum = 64,
            ValidProductionChecksum = 128,
        }
        [System.FlagsAttribute()]
        public enum ProductionFlags : byte
        {
            None = 0,
            DoNotMonitorChanges = 1,
            VerifySoundEvents = 2,
            DoNotInheritForPlayerGraphs = 4,
        }
        [System.FlagsAttribute()]
        public enum PlaybackFlags : short
        {
            None = 0,
            DisableInterpolationIn = 1,
            DisableInterpolationOut = 2,
            DisableModeIk = 4,
            DisableWeaponIk = 8,
            DisableWeaponAim1stPerson = 16,
            DisableLookScreen = 32,
            DisableTransitionAdjustment = 64,
        }
        public enum DesiredCompressionEnum : byte
        {
            BestScore = 0,
            BestCompression = 1,
            BestAccuracy = 2,
            BestFullframe = 3,
            BestSmallKeyframe = 4,
            BestLargeKeyframe = 5,
        }
        public enum CurrentCompressionEnum : byte
        {
            BestScore = 0,
            BestCompression = 1,
            BestAccuracy = 2,
            BestFullframe = 3,
            BestSmallKeyframe = 4,
            BestLargeKeyframe = 5,
        }
    }
}
