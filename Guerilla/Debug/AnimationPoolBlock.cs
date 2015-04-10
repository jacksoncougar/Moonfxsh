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
        public  AnimationPoolBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationPoolBlockBase(System.IO.BinaryReader binaryReader)
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
            parentGraphIndex = binaryReader.ReadInt32();
            parentGraphBlockIndex = binaryReader.ReadInt32();
            parentGraphBlockOffset = binaryReader.ReadInt32();
            parentGraphStartingPointIndex = binaryReader.ReadInt16();
            loopFrameIndex = binaryReader.ReadInt16();
            parentAnimation = binaryReader.ReadShortBlockIndex1();
            nextAnimation = binaryReader.ReadShortBlockIndex1();
            animationData = ReadData(binaryReader);
            dataSizes = new PackedDataSizesStructBlock(binaryReader);
            ReadAnimationFrameEventBlockArray(binaryReader);
            ReadAnimationSoundEventBlockArray(binaryReader);
            ReadAnimationEffectEventBlockArray(binaryReader);
            ReadObjectSpaceNodeDataBlockArray(binaryReader);
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
        internal  virtual AnimationFrameEventBlock[] ReadAnimationFrameEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual AnimationSoundEventBlock[] ReadAnimationSoundEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual AnimationEffectEventBlock[] ReadAnimationEffectEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ObjectSpaceNodeDataBlock[] ReadObjectSpaceNodeDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationFrameEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationSoundEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationEffectEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectSpaceNodeDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
                binaryWriter.Write(parentGraphIndex);
                binaryWriter.Write(parentGraphBlockIndex);
                binaryWriter.Write(parentGraphBlockOffset);
                binaryWriter.Write(parentGraphStartingPointIndex);
                binaryWriter.Write(loopFrameIndex);
                binaryWriter.Write(parentAnimation);
                binaryWriter.Write(nextAnimation);
                WriteData(binaryWriter);
                dataSizes.Write(binaryWriter);
                WriteAnimationFrameEventBlockArray(binaryWriter);
                WriteAnimationSoundEventBlockArray(binaryWriter);
                WriteAnimationEffectEventBlockArray(binaryWriter);
                WriteObjectSpaceNodeDataBlockArray(binaryWriter);
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
