// ReSharper disable All
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
        public  GlobalLeafConnectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalLeafConnectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            planeIndex = binaryReader.ReadInt32();
            backLeafIndex = binaryReader.ReadInt32();
            frontLeafIndex = binaryReader.ReadInt32();
            ReadLeafConnectionVertexBlockArray(binaryReader);
            area = binaryReader.ReadSingle();
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
        internal  virtual LeafConnectionVertexBlock[] ReadLeafConnectionVertexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLeafConnectionVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(planeIndex);
                binaryWriter.Write(backLeafIndex);
                binaryWriter.Write(frontLeafIndex);
                WriteLeafConnectionVertexBlockArray(binaryWriter);
                binaryWriter.Write(area);
            }
        }
    };
}
