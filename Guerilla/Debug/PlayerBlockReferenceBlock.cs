// ReSharper disable All
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
        public  PlayerBlockReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PlayerBlockReferenceBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
            }
        }
        internal enum TableOrder : byte
        
        {
            RowMajor = 0,
            ColumnMajor = 1,
        };
    };
}
