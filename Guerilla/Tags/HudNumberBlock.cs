using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hud#")]
    public  partial class HudNumberBlock : HudNumberBlockBase
    {
        public  HudNumberBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class HudNumberBlockBase
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
        internal  HudNumberBlockBase(BinaryReader binaryReader)
        {
            this.digitsBitmap = binaryReader.ReadTagReference();
            this.bitmapDigitWidth = binaryReader.ReadByte();
            this.screenDigitWidth = binaryReader.ReadByte();
            this.xOffset = binaryReader.ReadByte();
            this.yOffset = binaryReader.ReadByte();
            this.decimalPointWidth = binaryReader.ReadByte();
            this.colonWidth = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(76);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
