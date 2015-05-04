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
    public partial class GlobalGeometryBlockInfoStructBlock : GlobalGeometryBlockInfoStructBlockBase
    {
        public GlobalGeometryBlockInfoStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class GlobalGeometryBlockInfoStructBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 36; } }
        public override int Alignment { get { return 4; } }
        public GlobalGeometryBlockInfoStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blockOffset = binaryReader.ReadInt32();
            blockSize = binaryReader.ReadInt32();
            sectionDataSize = binaryReader.ReadInt32();
            resourceDataSize = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryBlockResourceBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            ownerTagSectionOffset = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            resources = ReadBlockArrayData<GlobalGeometryBlockResourceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(blockOffset);
                binaryWriter.Write(blockSize);
                binaryWriter.Write(sectionDataSize);
                binaryWriter.Write(resourceDataSize);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryBlockResourceBlock>(binaryWriter, resources, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(ownerTagSectionOffset);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 4);
                return nextAddress;
            }
        }
    };
}
