// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class TagImportFileBlock : TagImportFileBlockBase
    {
        public TagImportFileBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 528, Alignment = 4)]
    public class TagImportFileBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String256 path;
        internal Moonfish.Tags.String32 modificationDate;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal int checksumCrc32;
        internal int sizeBytes;
        internal byte[] zippedData;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 528; } }
        public override int Alignment { get { return 4; } }
        public TagImportFileBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            path = binaryReader.ReadString256();
            modificationDate = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            invalidName_0 = binaryReader.ReadBytes(88);
            checksumCrc32 = binaryReader.ReadInt32();
            sizeBytes = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            invalidName_1 = binaryReader.ReadBytes(128);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            zippedData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(path);
                binaryWriter.Write(modificationDate);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(invalidName_0, 0, 88);
                binaryWriter.Write(checksumCrc32);
                binaryWriter.Write(sizeBytes);
                nextAddress = Guerilla.WriteData(binaryWriter, zippedData, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 128);
                return nextAddress;
            }
        }
    };
}
