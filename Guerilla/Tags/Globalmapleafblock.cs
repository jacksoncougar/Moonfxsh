using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalMapLeafBlock : GlobalMapLeafBlockBase
    {
        public  GlobalMapLeafBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GlobalMapLeafBlockBase
    {
        internal MapLeafFaceBlock[] faces;
        internal MapLeafConnectionIndexBlock[] connectionIndices;
        internal  GlobalMapLeafBlockBase(BinaryReader binaryReader)
        {
            this.faces = ReadMapLeafFaceBlockArray(binaryReader);
            this.connectionIndices = ReadMapLeafConnectionIndexBlockArray(binaryReader);
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
        internal  virtual MapLeafFaceBlock[] ReadMapLeafFaceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MapLeafFaceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MapLeafFaceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MapLeafFaceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MapLeafConnectionIndexBlock[] ReadMapLeafConnectionIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MapLeafConnectionIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MapLeafConnectionIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MapLeafConnectionIndexBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
