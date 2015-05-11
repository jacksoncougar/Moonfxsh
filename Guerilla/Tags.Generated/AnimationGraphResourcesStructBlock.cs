// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationGraphResourcesStructBlock : AnimationGraphResourcesStructBlockBase
    {
        public AnimationGraphResourcesStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class AnimationGraphResourcesStructBlockBase : GuerillaBlock
    {
        [TagReference("jmad")] internal Moonfish.Tags.TagReference parentAnimationGraph;
        internal InheritanceFlags inheritanceFlags;
        internal PrivateFlags privateFlags;
        internal short animationCodecPack;
        internal AnimationGraphNodeBlock[] skeletonNodesABCDCC;
        internal AnimationGraphSoundReferenceBlock[] soundReferencesABCDCC;
        internal AnimationGraphEffectReferenceBlock[] effectReferencesABCDCC;
        internal AnimationBlendScreenBlock[] blendScreensABCDCC;
        internal AnimationPoolBlock[] animationsABCDCC;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AnimationGraphResourcesStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parentAnimationGraph = binaryReader.ReadTagReference();
            inheritanceFlags = (InheritanceFlags) binaryReader.ReadByte();
            privateFlags = (PrivateFlags) binaryReader.ReadByte();
            animationCodecPack = binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationGraphNodeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationGraphSoundReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationGraphEffectReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationBlendScreenBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationPoolBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            skeletonNodesABCDCC = ReadBlockArrayData<AnimationGraphNodeBlock>(binaryReader, blamPointers.Dequeue());
            soundReferencesABCDCC = ReadBlockArrayData<AnimationGraphSoundReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
            effectReferencesABCDCC = ReadBlockArrayData<AnimationGraphEffectReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
            blendScreensABCDCC = ReadBlockArrayData<AnimationBlendScreenBlock>(binaryReader, blamPointers.Dequeue());
            animationsABCDCC = ReadBlockArrayData<AnimationPoolBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentAnimationGraph);
                binaryWriter.Write((Byte) inheritanceFlags);
                binaryWriter.Write((Byte) privateFlags);
                binaryWriter.Write(animationCodecPack);
                nextAddress = Guerilla.WriteBlockArray<AnimationGraphNodeBlock>(binaryWriter, skeletonNodesABCDCC,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationGraphSoundReferenceBlock>(binaryWriter,
                    soundReferencesABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationGraphEffectReferenceBlock>(binaryWriter,
                    effectReferencesABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationBlendScreenBlock>(binaryWriter, blendScreensABCDCC,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationPoolBlock>(binaryWriter, animationsABCDCC, nextAddress);
                return nextAddress;
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