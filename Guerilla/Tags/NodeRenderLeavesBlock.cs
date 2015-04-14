// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class NodeRenderLeavesBlock : NodeRenderLeavesBlockBase
    {
        public  NodeRenderLeavesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class NodeRenderLeavesBlockBase  : IGuerilla
    {
        internal BspLeafBlock[] collisionLeaves;
        internal BspSurfaceReferenceBlock[] surfaceReferences;
        internal  NodeRenderLeavesBlockBase(BinaryReader binaryReader)
        {
            collisionLeaves = Guerilla.ReadBlockArray<BspLeafBlock>(binaryReader);
            surfaceReferences = Guerilla.ReadBlockArray<BspSurfaceReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<BspLeafBlock>(binaryWriter, collisionLeaves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BspSurfaceReferenceBlock>(binaryWriter, surfaceReferences, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
