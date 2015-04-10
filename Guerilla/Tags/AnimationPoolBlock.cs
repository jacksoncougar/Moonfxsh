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
    [LayoutAttribute(Size = 108)]
    public class AnimationPoolBlockBase
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
        internal  AnimationPoolBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nodeListChecksum = binaryReader.ReadInt32();
            this.productionChecksum = binaryReader.ReadInt32();
            this.importChecksum = binaryReader.ReadInt32();
            this.type = (Type)binaryReader.ReadByte();
            this.frameInfoType = (FrameInfoType)binaryReader.ReadByte();
            this.blendScreen = binaryReader.ReadByteBlockIndex1();
            this.nodeCount = binaryReader.ReadByte();
            this.frameCount = binaryReader.ReadInt16();
            this.internalFlags = (InternalFlags)binaryReader.ReadByte();
            this.productionFlags = (ProductionFlags)binaryReader.ReadByte();
            this.playbackFlags = (PlaybackFlags)binaryReader.ReadInt16();
            this.desiredCompression = (DesiredCompression)binaryReader.ReadByte();
            this.currentCompression = (CurrentCompression)binaryReader.ReadByte();
            this.weight = binaryReader.ReadSingle();
            this.parentGraphIndex = binaryReader.ReadInt32();
            this.parentGraphBlockIndex = binaryReader.ReadInt32();
            this.parentGraphBlockOffset = binaryReader.ReadInt32();
            this.parentGraphStartingPointIndex = binaryReader.ReadInt16();
            this.loopFrameIndex = binaryReader.ReadInt16();
            this.parentAnimation = binaryReader.ReadShortBlockIndex1();
            this.nextAnimation = binaryReader.ReadShortBlockIndex1();
            this.animationData = ReadData(binaryReader);
            this.dataSizes = new PackedDataSizesStructBlock(binaryReader);
            this.frameEventsABCDCC = ReadAnimationFrameEventBlockArray(binaryReader);
            this.soundEventsABCDCC = ReadAnimationSoundEventBlockArray(binaryReader);
            this.effectEventsABCDCC = ReadAnimationEffectEventBlockArray(binaryReader);
            this.objectSpaceParentNodesABCDCC = ReadObjectSpaceNodeDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual AnimationFrameEventBlock[] ReadAnimationFrameEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationFrameEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationFrameEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationFrameEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationSoundEventBlock[] ReadAnimationSoundEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationSoundEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationSoundEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationSoundEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationEffectEventBlock[] ReadAnimationEffectEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationEffectEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationEffectEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationEffectEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectSpaceNodeDataBlock[] ReadObjectSpaceNodeDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectSpaceNodeDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectSpaceNodeDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectSpaceNodeDataBlock(binaryReader);
                }
            }
            return array;
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
