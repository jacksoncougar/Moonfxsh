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
    [LayoutAttribute(Size = 28)]
    public class TableViewListItemReferenceBlockBase
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
            this.textFlags = (TextFlags)binaryReader.ReadInt32();
            this.cellWidth = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.bitmapTopLeftIfThereIsABitmap = binaryReader.ReadPoint();
            this.bitmapTag = binaryReader.ReadTagReference();
            this.stringId = binaryReader.ReadStringID();
            this.renderDepthBias = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
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
