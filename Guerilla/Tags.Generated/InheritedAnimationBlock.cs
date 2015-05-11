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
    public partial class InheritedAnimationBlock : InheritedAnimationBlockBase
    {
        public InheritedAnimationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class InheritedAnimationBlockBase : GuerillaBlock
    {
        [TagReference("jmad")] internal Moonfish.Tags.TagReference inheritedGraph;
        internal InheritedAnimationNodeMapBlock[] nodeMap;
        internal InheritedAnimationNodeMapFlagBlock[] nodeMapFlags;
        internal float rootZOffset;
        internal int inheritanceFlags;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public InheritedAnimationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            inheritedGraph = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<InheritedAnimationNodeMapBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<InheritedAnimationNodeMapFlagBlock>(binaryReader));
            rootZOffset = binaryReader.ReadSingle();
            inheritanceFlags = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            nodeMap = ReadBlockArrayData<InheritedAnimationNodeMapBlock>(binaryReader, blamPointers.Dequeue());
            nodeMapFlags = ReadBlockArrayData<InheritedAnimationNodeMapFlagBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inheritedGraph);
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationNodeMapBlock>(binaryWriter, nodeMap,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationNodeMapFlagBlock>(binaryWriter, nodeMapFlags,
                    nextAddress);
                binaryWriter.Write(rootZOffset);
                binaryWriter.Write(inheritanceFlags);
                return nextAddress;
            }
        }
    };
}