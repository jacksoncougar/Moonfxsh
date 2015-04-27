// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Hud = (TagClass)"hud#";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hud#")]
    public partial class HudNumberBlock : HudNumberBlockBase
    {
        public  HudNumberBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HudNumberBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class HudNumberBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference digitsBitmap;
        internal byte bitmapDigitWidth;
        internal byte screenDigitWidth;
        internal byte xOffset;
        internal byte yOffset;
        internal byte decimalPointWidth;
        internal byte colonWidth;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 92; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudNumberBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            digitsBitmap = binaryReader.ReadTagReference();
            bitmapDigitWidth = binaryReader.ReadByte();
            screenDigitWidth = binaryReader.ReadByte();
            xOffset = binaryReader.ReadByte();
            yOffset = binaryReader.ReadByte();
            decimalPointWidth = binaryReader.ReadByte();
            colonWidth = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(76);
        }
        public  HudNumberBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            digitsBitmap = binaryReader.ReadTagReference();
            bitmapDigitWidth = binaryReader.ReadByte();
            screenDigitWidth = binaryReader.ReadByte();
            xOffset = binaryReader.ReadByte();
            yOffset = binaryReader.ReadByte();
            decimalPointWidth = binaryReader.ReadByte();
            colonWidth = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(76);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(digitsBitmap);
                binaryWriter.Write(bitmapDigitWidth);
                binaryWriter.Write(screenDigitWidth);
                binaryWriter.Write(xOffset);
                binaryWriter.Write(yOffset);
                binaryWriter.Write(decimalPointWidth);
                binaryWriter.Write(colonWidth);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 76);
                return nextAddress;
            }
        }
    };
}
