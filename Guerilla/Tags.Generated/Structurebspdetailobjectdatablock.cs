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
    public partial class StructureBspDetailObjectDataBlock : StructureBspDetailObjectDataBlockBase
    {
        public StructureBspDetailObjectDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class StructureBspDetailObjectDataBlockBase : GuerillaBlock
    {
        internal GlobalDetailObjectCellsBlock[] cells;
        internal GlobalDetailObjectBlock[] instances;
        internal GlobalDetailObjectCountsBlock[] counts;
        internal GlobalZReferenceVectorBlock[] zReferenceVectors;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 36; } }
        public override int Alignment { get { return 4; } }
        public StructureBspDetailObjectDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalDetailObjectCellsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalDetailObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalDetailObjectCountsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalZReferenceVectorBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(1);
            invalidName_0 = binaryReader.ReadBytes(3);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            cells = ReadBlockArrayData<GlobalDetailObjectCellsBlock>(binaryReader, blamPointers.Dequeue());
            instances = ReadBlockArrayData<GlobalDetailObjectBlock>(binaryReader, blamPointers.Dequeue());
            counts = ReadBlockArrayData<GlobalDetailObjectCountsBlock>(binaryReader, blamPointers.Dequeue());
            zReferenceVectors = ReadBlockArrayData<GlobalZReferenceVectorBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalDetailObjectCellsBlock>(binaryWriter, cells, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalDetailObjectBlock>(binaryWriter, instances, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalDetailObjectCountsBlock>(binaryWriter, counts, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalZReferenceVectorBlock>(binaryWriter, zReferenceVectors, nextAddress);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(invalidName_0, 0, 3);
                return nextAddress;
            }
        }
    };
}
