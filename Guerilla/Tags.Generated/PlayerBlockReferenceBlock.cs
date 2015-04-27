// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlayerBlockReferenceBlock : PlayerBlockReferenceBlockBase
    {
        public  PlayerBlockReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlayerBlockReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class PlayerBlockReferenceBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlayerBlockReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            skin = binaryReader.ReadTagReference();
            bottomLeft = binaryReader.ReadPoint();
            tableOrder = (TableOrder)binaryReader.ReadByte();
            maximumPlayerCount = binaryReader.ReadByte();
            rowCount = binaryReader.ReadByte();
            columnCount = binaryReader.ReadByte();
            rowHeight = binaryReader.ReadInt16();
            columnWidth = binaryReader.ReadInt16();
        }
        public  PlayerBlockReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(skin);
                binaryWriter.Write(bottomLeft);
                binaryWriter.Write((Byte)tableOrder);
                binaryWriter.Write(maximumPlayerCount);
                binaryWriter.Write(rowCount);
                binaryWriter.Write(columnCount);
                binaryWriter.Write(rowHeight);
                binaryWriter.Write(columnWidth);
                return nextAddress;
            }
        }
        internal enum TableOrder : byte
        {
            RowMajor = 0,
            ColumnMajor = 1,
        };
    };
}
