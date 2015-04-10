// ReSharper disable All
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
        public  AnimationGraphResourcesStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationGraphResourcesStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            parentAnimationGraph = binaryReader.ReadTagReference();
            inheritanceFlags = (InheritanceFlags)binaryReader.ReadByte();
            privateFlags = (PrivateFlags)binaryReader.ReadByte();
            animationCodecPack = binaryReader.ReadInt16();
            ReadAnimationGraphNodeBlockArray(binaryReader);
            ReadAnimationGraphSoundReferenceBlockArray(binaryReader);
            ReadAnimationGraphEffectReferenceBlockArray(binaryReader);
            ReadAnimationBlendScreenBlockArray(binaryReader);
            ReadAnimationPoolBlockArray(binaryReader);
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
        internal  virtual AnimationGraphNodeBlock[] ReadAnimationGraphNodeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationGraphNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationGraphNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationGraphNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationGraphSoundReferenceBlock[] ReadAnimationGraphSoundReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationGraphSoundReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationGraphSoundReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationGraphSoundReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationGraphEffectReferenceBlock[] ReadAnimationGraphEffectReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationGraphEffectReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationGraphEffectReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationGraphEffectReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationBlendScreenBlock[] ReadAnimationBlendScreenBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationBlendScreenBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationBlendScreenBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationBlendScreenBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationPoolBlock[] ReadAnimationPoolBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationPoolBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationPoolBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationPoolBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationGraphNodeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationGraphSoundReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationGraphEffectReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationBlendScreenBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationPoolBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentAnimationGraph);
                binaryWriter.Write((Byte)inheritanceFlags);
                binaryWriter.Write((Byte)privateFlags);
                binaryWriter.Write(animationCodecPack);
                WriteAnimationGraphNodeBlockArray(binaryWriter);
                WriteAnimationGraphSoundReferenceBlockArray(binaryWriter);
                WriteAnimationGraphEffectReferenceBlockArray(binaryWriter);
                WriteAnimationBlendScreenBlockArray(binaryWriter);
                WriteAnimationPoolBlockArray(binaryWriter);
            }
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
