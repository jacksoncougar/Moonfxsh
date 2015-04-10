// ReSharper disable All
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
        public  SectionRenderLeavesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SectionRenderLeavesBlockBase
    {
        internal NodeRenderLeavesBlock[] nodeRenderLeaves;
        internal  SectionRenderLeavesBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadNodeRenderLeavesBlockArray(binaryReader);
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
        internal  virtual NodeRenderLeavesBlock[] ReadNodeRenderLeavesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteNodeRenderLeavesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteNodeRenderLeavesBlockArray(binaryWriter);
            }
        }
    };
}
