// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryBlockInfoStructBlock : GlobalGeometryBlockInfoStructBlockBase
    {
        public  GlobalGeometryBlockInfoStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class GlobalGeometryBlockInfoStructBlockBase
    {
        internal int blockOffset;
        internal int blockSize;
        internal int sectionDataSize;
        internal int resourceDataSize;
        internal GlobalGeometryBlockResourceBlock[] resources;
        internal byte[] invalidName_;
        internal short ownerTagSectionOffset;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal  GlobalGeometryBlockInfoStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            blockOffset = binaryReader.ReadInt32();
            blockSize = binaryReader.ReadInt32();
            sectionDataSize = binaryReader.ReadInt32();
            resourceDataSize = binaryReader.ReadInt32();
            ReadGlobalGeometryBlockResourceBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            ownerTagSectionOffset = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
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
        internal  virtual GlobalGeometryBlockResourceBlock[] ReadGlobalGeometryBlockResourceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryBlockResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryBlockResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryBlockResourceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryBlockResourceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(blockOffset);
                binaryWriter.Write(blockSize);
                binaryWriter.Write(sectionDataSize);
                binaryWriter.Write(resourceDataSize);
                WriteGlobalGeometryBlockResourceBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(ownerTagSectionOffset);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 4);
            }
        }
    };
}
