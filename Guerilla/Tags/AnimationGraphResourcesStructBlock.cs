using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationGraphResourcesStructBlock : AnimationGraphResourcesStructBlockBase
    {
        public  AnimationGraphResourcesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class AnimationGraphResourcesStructBlockBase
    {
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference parentAnimationGraph;
        internal InheritanceFlags inheritanceFlags;
        internal PrivateFlags privateFlags;
        internal short animationCodecPack;
        internal AnimationGraphNodeBlock[] skeletonNodesABCDCC;
        internal AnimationGraphSoundReferenceBlock[] soundReferencesABCDCC;
        internal AnimationGraphEffectReferenceBlock[] effectReferencesABCDCC;
        internal AnimationBlendScreenBlock[] blendScreensABCDCC;
        internal AnimationPoolBlock[] animationsABCDCC;
        internal  AnimationGraphResourcesStructBlockBase(BinaryReader binaryReader)
        {
            this.parentAnimationGraph = binaryReader.ReadTagReference();
            this.inheritanceFlags = (InheritanceFlags)binaryReader.ReadByte();
            this.privateFlags = (PrivateFlags)binaryReader.ReadByte();
            this.animationCodecPack = binaryReader.ReadInt16();
            this.skeletonNodesABCDCC = ReadAnimationGraphNodeBlockArray(binaryReader);
            this.soundReferencesABCDCC = ReadAnimationGraphSoundReferenceBlockArray(binaryReader);
            this.effectReferencesABCDCC = ReadAnimationGraphEffectReferenceBlockArray(binaryReader);
            this.blendScreensABCDCC = ReadAnimationBlendScreenBlockArray(binaryReader);
            this.animationsABCDCC = ReadAnimationPoolBlockArray(binaryReader);
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
        internal  virtual AnimationGraphNodeBlock[] ReadAnimationGraphNodeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationGraphNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationGraphNodeBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationGraphNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationGraphSoundReferenceBlock[] ReadAnimationGraphSoundReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationGraphSoundReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationGraphSoundReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationGraphSoundReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationGraphEffectReferenceBlock[] ReadAnimationGraphEffectReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationGraphEffectReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationGraphEffectReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationGraphEffectReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationBlendScreenBlock[] ReadAnimationBlendScreenBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationBlendScreenBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationBlendScreenBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationBlendScreenBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationPoolBlock[] ReadAnimationPoolBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationPoolBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationPoolBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationPoolBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum InheritanceFlags : byte
        
        {
            InheritRootTransScaleOnly = 1,
            InheritForUseOnPlayer = 2,
        };
        [FlagsAttribute]
        internal enum PrivateFlags : byte
        
        {
            PreparedForCache = 1,
            Unused = 2,
            ImportedWithCodecCompressors = 4,
            UnusedSmellyFlag = 8,
            WrittenToCache = 16,
            AnimationDataReordered = 32,
        };
    };
}
