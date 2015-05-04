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
    public partial class NodeRenderLeavesBlock : NodeRenderLeavesBlockBase
    {
        public NodeRenderLeavesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class NodeRenderLeavesBlockBase : GuerillaBlock
    {
        internal BspLeafBlock[] collisionLeaves;
        internal BspSurfaceReferenceBlock[] surfaceReferences;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public NodeRenderLeavesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BspLeafBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BspSurfaceReferenceBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            collisionLeaves = ReadBlockArrayData<BspLeafBlock>(binaryReader, blamPointers.Dequeue());
            surfaceReferences = ReadBlockArrayData<BspSurfaceReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<BspLeafBlock>(binaryWriter, collisionLeaves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BspSurfaceReferenceBlock>(binaryWriter, surfaceReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}
