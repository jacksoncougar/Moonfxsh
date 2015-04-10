// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalTagImportInfoBlock : GlobalTagImportInfoBlockBase
    {
        public  GlobalTagImportInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 592)]
    public class GlobalTagImportInfoBlockBase
    {
        internal int build;
        internal Moonfish.Tags.String256 version;
        internal Moonfish.Tags.String32 importDate;
        internal Moonfish.Tags.String32 culprit;
        internal byte[] invalidName_;
        internal Moonfish.Tags.String32 importTime;
        internal byte[] invalidName_0;
        internal TagImportFileBlock[] files;
        internal byte[] invalidName_1;
        internal  GlobalTagImportInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            build = binaryReader.ReadInt32();
            version = binaryReader.ReadString256();
            importDate = binaryReader.ReadString32();
            culprit = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(96);
            importTime = binaryReader.ReadString32();
            invalidName_0 = binaryReader.ReadBytes(4);
            ReadTagImportFileBlockArray(binaryReader);
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
        internal  virtual TagImportFileBlock[] ReadTagImportFileBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TagImportFileBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TagImportFileBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TagImportFileBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTagImportFileBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(build);
                binaryWriter.Write(version);
                binaryWriter.Write(importDate);
                binaryWriter.Write(culprit);
                binaryWriter.Write(invalidName_, 0, 96);
                binaryWriter.Write(importTime);
                binaryWriter.Write(invalidName_0, 0, 4);
                WriteTagImportFileBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 128);
            }
        }
    };
}
