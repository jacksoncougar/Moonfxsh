// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationGraphResourcesStructBlock : AnimationGraphResourcesStructBlockBase
    {
        public  AnimationGraphResourcesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationGraphResourcesStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class AnimationGraphResourcesStructBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationGraphResourcesStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parentAnimationGraph = binaryReader.ReadTagReference();
            inheritanceFlags = (InheritanceFlags)binaryReader.ReadByte();
            privateFlags = (PrivateFlags)binaryReader.ReadByte();
            animationCodecPack = binaryReader.ReadInt16();
            skeletonNodesABCDCC = Guerilla.ReadBlockArray<AnimationGraphNodeBlock>(binaryReader);
            soundReferencesABCDCC = Guerilla.ReadBlockArray<AnimationGraphSoundReferenceBlock>(binaryReader);
            effectReferencesABCDCC = Guerilla.ReadBlockArray<AnimationGraphEffectReferenceBlock>(binaryReader);
            blendScreensABCDCC = Guerilla.ReadBlockArray<AnimationBlendScreenBlock>(binaryReader);
            animationsABCDCC = Guerilla.ReadBlockArray<AnimationPoolBlock>(binaryReader);
        }
        public  AnimationGraphResourcesStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            parentAnimationGraph = binaryReader.ReadTagReference();
            inheritanceFlags = (InheritanceFlags)binaryReader.ReadByte();
            privateFlags = (PrivateFlags)binaryReader.ReadByte();
            animationCodecPack = binaryReader.ReadInt16();
            skeletonNodesABCDCC = Guerilla.ReadBlockArray<AnimationGraphNodeBlock>(binaryReader);
            soundReferencesABCDCC = Guerilla.ReadBlockArray<AnimationGraphSoundReferenceBlock>(binaryReader);
            effectReferencesABCDCC = Guerilla.ReadBlockArray<AnimationGraphEffectReferenceBlock>(binaryReader);
            blendScreensABCDCC = Guerilla.ReadBlockArray<AnimationBlendScreenBlock>(binaryReader);
            animationsABCDCC = Guerilla.ReadBlockArray<AnimationPoolBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentAnimationGraph);
                binaryWriter.Write((Byte)inheritanceFlags);
                binaryWriter.Write((Byte)privateFlags);
                binaryWriter.Write(animationCodecPack);
                nextAddress = Guerilla.WriteBlockArray<AnimationGraphNodeBlock>(binaryWriter, skeletonNodesABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationGraphSoundReferenceBlock>(binaryWriter, soundReferencesABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationGraphEffectReferenceBlock>(binaryWriter, effectReferencesABCDCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationBlendScreenBlock>(binaryWriter, blendScreensABCDCC, nextAddress);
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
