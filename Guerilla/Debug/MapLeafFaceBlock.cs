// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MapLeafFaceBlock : MapLeafFaceBlockBase
    {
        public  MapLeafFaceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class MapLeafFaceBlockBase
    {
        internal int nodeIndex;
        internal MapLeafFaceVertexBlock[] vertices;
        internal  MapLeafFaceBlockBase(System.IO.BinaryReader binaryReader)
        {
            nodeIndex = binaryReader.ReadInt32();
            ReadMapLeafFaceVertexBlockArray(binaryReader);
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
        internal  virtual MapLeafFaceVertexBlock[] ReadMapLeafFaceVertexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MapLeafFaceVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MapLeafFaceVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MapLeafFaceVertexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMapLeafFaceVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeIndex);
                WriteMapLeafFaceVertexBlockArray(binaryWriter);
            }
        }
    };
}
