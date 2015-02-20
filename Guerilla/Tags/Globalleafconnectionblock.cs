using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalLeafConnectionBlock : GlobalLeafConnectionBlockBase
    {
        public  GlobalLeafConnectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class GlobalLeafConnectionBlockBase
    {
        internal int planeIndex;
        internal int backLeafIndex;
        internal int frontLeafIndex;
        internal LeafConnectionVertexBlock[] vertices;
        internal float area;
        internal  GlobalLeafConnectionBlockBase(BinaryReader binaryReader)
        {
            this.planeIndex = binaryReader.ReadInt32();
            this.backLeafIndex = binaryReader.ReadInt32();
            this.frontLeafIndex = binaryReader.ReadInt32();
            this.vertices = ReadLeafConnectionVertexBlockArray(binaryReader);
            this.area = binaryReader.ReadSingle();
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
        internal  virtual LeafConnectionVertexBlock[] ReadLeafConnectionVertexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LeafConnectionVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LeafConnectionVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LeafConnectionVertexBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
