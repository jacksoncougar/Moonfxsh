// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalTagImportInfoBlock : GlobalTagImportInfoBlockBase
    {
        public GlobalTagImportInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 592, Alignment = 4)]
    public class GlobalTagImportInfoBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 592; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalTagImportInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            build = binaryReader.ReadInt32();
            version = binaryReader.ReadString256();
            importDate = binaryReader.ReadString32();
            culprit = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(96);
            importTime = binaryReader.ReadString32();
            invalidName_0 = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<TagImportFileBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(128);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            files = ReadBlockArrayData<TagImportFileBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
                return nextAddress;
            }
        }
    };
}