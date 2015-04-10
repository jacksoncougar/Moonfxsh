// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PackedDataSizesStructBlock : PackedDataSizesStructBlockBase
    {
        public  PackedDataSizesStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class PackedDataSizesStructBlockBase
    {
        internal byte invalidName_;
        internal byte invalidName_0;
        internal short invalidName_1;
        internal short invalidName_2;
        internal short invalidName_3;
        internal int invalidName_4;
        internal int invalidName_5;
        internal  PackedDataSizesStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadInt32();
            invalidName_5 = binaryReader.ReadInt32();
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
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2);
                binaryWriter.Write(invalidName_3);
                binaryWriter.Write(invalidName_4);
                binaryWriter.Write(invalidName_5);
            }
        }
    };
}
