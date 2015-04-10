using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TableViewListRowReferenceBlock : TableViewListRowReferenceBlockBase
    {
        public  TableViewListRowReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class TableViewListRowReferenceBlockBase
    {
        internal Flags flags;
        internal short rowHeight;
        internal byte[] invalidName_;
        internal TableViewListItemReferenceBlock[] rowCells;
        internal  TableViewListRowReferenceBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.rowHeight = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.rowCells = ReadTableViewListItemReferenceBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual TableViewListItemReferenceBlock[] ReadTableViewListItemReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TableViewListItemReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TableViewListItemReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TableViewListItemReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Unused = 1,
        };
    };
}
