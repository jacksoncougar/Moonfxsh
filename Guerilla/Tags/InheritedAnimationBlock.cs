// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class InheritedAnimationBlock : InheritedAnimationBlockBase
    {
        public  InheritedAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class InheritedAnimationBlockBase  : IGuerilla
    {
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference inheritedGraph;
        internal InheritedAnimationNodeMapBlock[] nodeMap;
        internal InheritedAnimationNodeMapFlagBlock[] nodeMapFlags;
        internal float rootZOffset;
        internal int inheritanceFlags;
        internal  InheritedAnimationBlockBase(BinaryReader binaryReader)
        {
            inheritedGraph = binaryReader.ReadTagReference();
            nodeMap = Guerilla.ReadBlockArray<InheritedAnimationNodeMapBlock>(binaryReader);
            nodeMapFlags = Guerilla.ReadBlockArray<InheritedAnimationNodeMapFlagBlock>(binaryReader);
            rootZOffset = binaryReader.ReadSingle();
            inheritanceFlags = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inheritedGraph);
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationNodeMapBlock>(binaryWriter, nodeMap, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationNodeMapFlagBlock>(binaryWriter, nodeMapFlags, nextAddress);
                binaryWriter.Write(rootZOffset);
                binaryWriter.Write(inheritanceFlags);
                return nextAddress;
            }
        }
    };
}
