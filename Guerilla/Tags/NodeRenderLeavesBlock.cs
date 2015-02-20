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
    [LayoutAttribute(Size = 16)]
    public class NodeRenderLeavesBlockBase
    {
        internal BspLeafBlock[] collisionLeaves;
        internal BspSurfaceReferenceBlock[] surfaceReferences;
        internal  NodeRenderLeavesBlockBase(BinaryReader binaryReader)
        {
            this.collisionLeaves = ReadBspLeafBlockArray(binaryReader);
            this.surfaceReferences = ReadBspSurfaceReferenceBlockArray(binaryReader);
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
        internal  virtual BspLeafBlock[] ReadBspLeafBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BspLeafBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BspLeafBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BspLeafBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BspSurfaceReferenceBlock[] ReadBspSurfaceReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BspSurfaceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BspSurfaceReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BspSurfaceReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
