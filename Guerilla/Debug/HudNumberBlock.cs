// ReSharper disable All
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
        public  HudNumberBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  HudNumberBlockBase(System.IO.BinaryReader binaryReader)
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
                binaryWriter.Write(digitsBitmap);
                binaryWriter.Write(bitmapDigitWidth);
                binaryWriter.Write(screenDigitWidth);
                binaryWriter.Write(xOffset);
                binaryWriter.Write(yOffset);
                binaryWriter.Write(decimalPointWidth);
                binaryWriter.Write(colonWidth);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 76);
            }
        }
    };
}
