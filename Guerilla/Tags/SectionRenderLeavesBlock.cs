using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SectionRenderLeavesBlock : SectionRenderLeavesBlockBase
    {
        public  SectionRenderLeavesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SectionRenderLeavesBlockBase
    {
        internal NodeRenderLeavesBlock[] nodeRenderLeaves;
        internal  SectionRenderLeavesBlockBase(BinaryReader binaryReader)
        {
            this.nodeRenderLeaves = ReadNodeRenderLeavesBlockArray(binaryReader);
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
        internal  virtual NodeRenderLeavesBlock[] ReadNodeRenderLeavesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(NodeRenderLeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new NodeRenderLeavesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new NodeRenderLeavesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
