// ReSharper disable All
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
        public  GlobalMapLeafBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GlobalMapLeafBlockBase
    {
        internal MapLeafFaceBlock[] faces;
        internal MapLeafConnectionIndexBlock[] connectionIndices;
        internal  GlobalMapLeafBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadMapLeafFaceBlockArray(binaryReader);
            ReadMapLeafConnectionIndexBlockArray(binaryReader);
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
        internal  virtual MapLeafFaceBlock[] ReadMapLeafFaceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual MapLeafConnectionIndexBlock[] ReadMapLeafConnectionIndexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMapLeafFaceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMapLeafConnectionIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteMapLeafFaceBlockArray(binaryWriter);
                WriteMapLeafConnectionIndexBlockArray(binaryWriter);
            }
        }
    };
}
