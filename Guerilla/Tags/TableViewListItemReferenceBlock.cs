// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TableViewListItemReferenceBlock : TableViewListItemReferenceBlockBase
    {
        public  TableViewListItemReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class TableViewListItemReferenceBlockBase  : IGuerilla
    {
        internal TextFlags textFlags;
        internal short cellWidth;
        internal byte[] invalidName_;
        internal Moonfish.Tags.Point bitmapTopLeftIfThereIsABitmap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmapTag;
        internal Moonfish.Tags.StringID stringId;
        internal short renderDepthBias;
        internal byte[] invalidName_0;
        internal  TableViewListItemReferenceBlockBase(BinaryReader binaryReader)
        {
            textFlags = (TextFlags)binaryReader.ReadInt32();
            cellWidth = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmapTopLeftIfThereIsABitmap = binaryReader.ReadPoint();
            bitmapTag = binaryReader.ReadTagReference();
            stringId = binaryReader.ReadStringID();
            renderDepthBias = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)textFlags);
                binaryWriter.Write(cellWidth);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(bitmapTopLeftIfThereIsABitmap);
                binaryWriter.Write(bitmapTag);
                binaryWriter.Write(stringId);
                binaryWriter.Write(renderDepthBias);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum TextFlags : int
        {
            LeftJustifyText = 1,
            RightJustifyText = 2,
            PulsatingText = 4,
            CalloutText = 8,
            Small31CharBuffer = 16,
        };
    };
}
