// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationPoolBlock : AnimationPoolBlockBase
    {
        public  AnimationPoolBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class AnimationPoolBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
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
        internal short loopFrameIndex;
        internal Moonfish.Tags.ShortBlockIndex1 invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal PackedDataSizesStructBlock packedDataSizesStruct;
        internal AnimationFrameEventBlock[] frameEventsABCDCC;
        internal AnimationSoundEventBlock[] soundEventsABCDCC;
        internal AnimationEffectEventBlock[] effectEventsABCDCC;
        internal ObjectSpaceNodeDataBlock[] objectSpaceParentNodesABCDCC;
        internal  AnimationPoolBlockBase(BinaryReader binaryReader)
        {
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
            loopFrameIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadShortBlockIndex1();
            invalidName_0 = binaryReader.ReadShortBlockIndex1();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = Guerilla.ReadData(binaryReader);
            packedDataSizesStruct = new PackedDataSizesStructBlock(binaryReader);
            frameEventsABCDCC = Guerilla.ReadBlockArray<AnimationFrameEventBlock>(binaryReader);
            soundEventsABCDCC = Guerilla.ReadBlockArray<AnimationSoundEventBlock>(binaryReader);
            effectEventsABCDCC = Guerilla.ReadBlockArray<AnimationEffectEventBlock>(binaryReader);
            objectSpaceParentNodesABCDCC = Guerilla.ReadBlockArray<ObjectSpaceNodeDataBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
                binaryWriter.Write(loopFrameIndex);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1, 0, 2);
                nextAddress = Guerilla.WriteData(binaryWriter, invalidName_2, nextAddress);
                packedDataSizesStruct.Write(binaryWriter);
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
