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
        public  GlobalTagImportInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 592, Alignment = 4)]
    public class GlobalTagImportInfoBlockBase  : IGuerilla
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
        internal  GlobalTagImportInfoBlockBase(BinaryReader binaryReader)
        {
            build = binaryReader.ReadInt32();
            version = binaryReader.ReadString256();
            importDate = binaryReader.ReadString32();
            culprit = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(96);
            importTime = binaryReader.ReadString32();
            invalidName_0 = binaryReader.ReadBytes(4);
            files = Guerilla.ReadBlockArray<TagImportFileBlock>(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(128);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<TagImportFileBlock>(binaryWriter, files, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 128);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
