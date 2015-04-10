// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TagImportFileBlock : TagImportFileBlockBase
    {
        public  TagImportFileBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 528)]
    public class TagImportFileBlockBase
    {
        internal Moonfish.Tags.String256 path;
        internal Moonfish.Tags.String32 modificationDate;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal int checksumCrc32;
        internal int sizeBytes;
        internal byte[] zippedData;
        internal byte[] invalidName_1;
        internal  TagImportFileBlockBase(System.IO.BinaryReader binaryReader)
        {
            path = binaryReader.ReadString256();
            modificationDate = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            invalidName_0 = binaryReader.ReadBytes(88);
            checksumCrc32 = binaryReader.ReadInt32();
            sizeBytes = binaryReader.ReadInt32();
            zippedData = ReadData(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(128);
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
                binaryWriter.Write(path);
                binaryWriter.Write(modificationDate);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(invalidName_0, 0, 88);
                binaryWriter.Write(checksumCrc32);
                binaryWriter.Write(sizeBytes);
                WriteData(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 128);
            }
        }
    };
}
