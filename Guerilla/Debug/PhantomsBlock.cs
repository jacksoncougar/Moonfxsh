// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PhantomsBlock : PhantomsBlockBase
    {
        public  PhantomsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class PhantomsBlockBase
    {
        internal byte[] invalidName_;
        internal short size;
        internal short count;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal short size0;
        internal short count0;
        internal byte[] invalidName_4;
        internal  PhantomsBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(4);
            invalidName_2 = binaryReader.ReadBytes(4);
            invalidName_3 = binaryReader.ReadBytes(4);
            size0 = binaryReader.ReadInt16();
            count0 = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(4);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(size);
                binaryWriter.Write(count);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(size0);
                binaryWriter.Write(count0);
                binaryWriter.Write(invalidName_4, 0, 4);
            }
        }
    };
}
