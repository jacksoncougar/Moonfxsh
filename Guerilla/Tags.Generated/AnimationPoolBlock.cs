// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationPoolBlock : AnimationPoolBlockBase
    {
        public AnimationPoolBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class AnimationPoolBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal int nodeListChecksum;
        internal int productionChecksum;
        internal int importChecksum;
        internal Type type;
        internal FrameInfoType frameInfoType;
        internal Moonfish.Tags.ByteBlockIndex1 blendScreen;
        internal byte nodeCount;
        internal short frameCount;
        internal InternalFlags internalFlags;
        internal ProductionFlags productionFlags;
        internal PlaybackFlags playbackFlags;
        internal DesiredCompression desiredCompression;
        internal CurrentCompression currentCompression;
        internal float weight;
        internal int parentGraphIndex;
        internal int parentGraphBlockIndex;
        internal int parentGraphBlockOffset;
        internal short parentGraphStartingPointIndex;
        internal short loopFrameIndex;
        internal Moonfish.Tags.ShortBlockIndex1 parentAnimation;
        internal Moonfish.Tags.ShortBlockIndex1 nextAnimation;
        internal byte[] animationData;
        internal PackedDataSizesStructBlock dataSizes;
        internal AnimationFrameEventBlock[] frameEventsABCDCC;
        internal AnimationSoundEventBlock[] soundEventsABCDCC;
        internal AnimationEffectEventBlock[] effectEventsABCDCC;
        internal ObjectSpaceNodeDataBlock[] objectSpaceParentNodesABCDCC;
        public override int SerializedSize { get { return 108; } }
        public override int Alignment { get { return 4; } }
        public AnimationPoolBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            nodeListChecksum = binaryReader.ReadInt32();
            productionChecksum = binaryReader.ReadInt32();
            importChecksum = binaryReader.ReadInt32();
            type = (Type)binaryReader.ReadByte();
            frameInfoType = (FrameInfoType)binaryReader.ReadByte();
            blendScreen = binaryReader.ReadByteBlockIndex1();
            nodeCount = binaryReader.ReadByte();
            frameCount = binaryReader.ReadInt16();
            internalFlags = (InternalFlags)binaryReader.ReadByte();
            productionFlags = (ProductionFlags)binaryReader.ReadByte();
            playbackFlags = (PlaybackFlags)binaryReader.ReadInt16();
            desiredCompression = (DesiredCompression)binaryReader.ReadByte();
            currentCompression = (CurrentCompression)binaryReader.ReadByte();
            weight = binaryReader.ReadSingle();
            parentGraphIndex = binaryReader.ReadInt32();
            parentGraphBlockIndex = binaryReader.ReadInt32();
            parentGraphBlockOffset = binaryReader.ReadInt32();
            parentGraphStartingPointIndex = binaryReader.ReadInt16();
            loopFrameIndex = binaryReader.ReadInt16();
            parentAnimation = binaryReader.ReadShortBlockIndex1();
            nextAnimation = binaryReader.ReadShortBlockIndex1();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            dataSizes = new PackedDataSizesStructBlock();
            blamPointers.Concat(dataSizes.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationFrameEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationSoundEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationEffectEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ObjectSpaceNodeDataBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            animationData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            dataSizes.ReadPointers(binaryReader, blamPointers);
            frameEventsABCDCC = ReadBlockArrayData<AnimationFrameEventBlock>(binaryReader, blamPointers.Dequeue());
            soundEventsABCDCC = ReadBlockArrayData<AnimationSoundEventBlock>(binaryReader, blamPointers.Dequeue());
            effectEventsABCDCC = ReadBlockArrayData<AnimationEffectEventBlock>(binaryReader, blamPointers.Dequeue());
            objectSpaceParentNodesABCDCC = ReadBlockArrayData<ObjectSpaceNodeDataBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(nodeListChecksum);
                binaryWriter.Write(productionChecksum);
                binaryWriter.Write(importChecksum);
                binaryWriter.Write((Byte)type);
                binaryWriter.Write((Byte)frameInfoType);
                binaryWriter.Write(blendScreen);
                binaryWriter.Write(nodeCount);
                binaryWriter.Write(frameCount);
                binaryWriter.Write((Byte)internalFlags);
                binaryWriter.Write((Byte)productionFlags);
                binaryWriter.Write((Int16)playbackFlags);
                binaryWriter.Write((Byte)desiredCompression);
                binaryWriter.Write((Byte)currentCompression);
                binaryWriter.Write(weight);
                binaryWriter.Write(parentGraphIndex);
                binaryWriter.Write(parentGraphBlockIndex);
                binaryWriter.Write(parentGraphBlockOffset);
                binaryWriter.Write(parentGraphStartingPointIndex);
                binaryWriter.Write(loopFrameIndex);
                binaryWriter.Write(parentAnimation);
                binaryWriter.Write(nextAnimation);
                nextAddress = Guerilla.WriteData(binaryWriter, animationData, nextAddress);
                dataSizes.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<AnimationFrameEventBlock>(binaryWriter, frameEventsABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationSoundEventBlock>(binaryWriter, soundEventsABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationEffectEventBlock>(binaryWriter, effectEventsABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ObjectSpaceNodeDataBlock>(binaryWriter, objectSpaceParentNodesABCDCC, nextAddress);
                return nextAddress;
            }
        }
        internal enum Type : byte
        {
            Base = 0,
            Overlay = 1,
            Replacement = 2,
        };
        internal enum FrameInfoType : byte
        {
            None = 0,
            DxDy = 1,
            DxDyDyaw = 2,
            DxDyDzDyaw = 3,
        };
        [FlagsAttribute]
        internal enum InternalFlags : byte
        {
            Unused0 = 1,
            WorldRelative = 2,
            Unused1 = 4,
            Unused2 = 8,
            Unused3 = 16,
            CompressionDisabled = 32,
            OldProductionChecksum = 64,
            ValidProductionChecksum = 128,
        };
        [FlagsAttribute]
        internal enum ProductionFlags : byte
        {
            DoNotMonitorChanges = 1,
            VerifySoundEvents = 2,
            DoNotInheritForPlayerGraphs = 4,
        };
        [FlagsAttribute]
        internal enum PlaybackFlags : short
        {
            DisableInterpolationIn = 1,
            DisableInterpolationOut = 2,
            DisableModeIk = 4,
            DisableWeaponIk = 8,
            DisableWeaponAim1StPerson = 16,
            DisableLookScreen = 32,
            DisableTransitionAdjustment = 64,
        };
        internal enum DesiredCompression : byte
        {
            BestScore = 0,
            BestCompression = 1,
            BestAccuracy = 2,
            BestFullframe = 3,
            BestSmallKeyframe = 4,
            BestLargeKeyframe = 5,
        };
        internal enum CurrentCompression : byte
        {
            BestScore = 0,
            BestCompression = 1,
            BestAccuracy = 2,
            BestFullframe = 3,
            BestSmallKeyframe = 4,
            BestLargeKeyframe = 5,
        };
    };
}
