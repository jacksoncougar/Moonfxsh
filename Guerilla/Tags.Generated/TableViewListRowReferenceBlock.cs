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
    public partial class TableViewListRowReferenceBlock : TableViewListRowReferenceBlockBase
    {
        public TableViewListRowReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class TableViewListRowReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal short rowHeight;
        internal byte[] invalidName_;
        internal TableViewListItemReferenceBlock[] rowCells;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public TableViewListRowReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            rowHeight = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<TableViewListItemReferenceBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            rowCells = ReadBlockArrayData<TableViewListItemReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(rowHeight);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<TableViewListItemReferenceBlock>(binaryWriter, rowCells, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };
    };
}
