using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlayerBlockReferenceBlock : PlayerBlockReferenceBlockBase
    {
        public  PlayerBlockReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class PlayerBlockReferenceBlockBase
    {
        internal byte[] invalidName_;
        [TagReference("skin")]
        internal Moonfish.Tags.TagReference skin;
        internal Moonfish.Tags.Point bottomLeft;
        internal TableOrder tableOrder;
        internal byte maximumPlayerCount;
        internal byte rowCount;
        internal byte columnCount;
        internal short rowHeight;
        internal short columnWidth;
        internal  PlayerBlockReferenceBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.skin = binaryReader.ReadTagReference();
            this.bottomLeft = binaryReader.ReadPoint();
            this.tableOrder = (TableOrder)binaryReader.ReadByte();
            this.maximumPlayerCount = binaryReader.ReadByte();
            this.rowCount = binaryReader.ReadByte();
            this.columnCount = binaryReader.ReadByte();
            this.rowHeight = binaryReader.ReadInt16();
            this.columnWidth = binaryReader.ReadInt16();
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
        internal enum TableOrder : byte
        
        {
            RowMajor = 0,
            ColumnMajor = 1,
        };
    };
}
