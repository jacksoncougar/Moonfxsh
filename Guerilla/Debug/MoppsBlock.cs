// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MoppsBlock : MoppsBlockBase
    {
        public  MoppsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class MoppsBlockBase
    {
        internal byte[] invalidName_;
        internal short size;
        internal short count;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ShortBlockIndex1 list;
        internal int codeOffset;
        internal  MoppsBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(2);
            list = binaryReader.ReadShortBlockIndex1();
            codeOffset = binaryReader.ReadInt32();
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
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(list);
                binaryWriter.Write(codeOffset);
            }
        }
    };
}
