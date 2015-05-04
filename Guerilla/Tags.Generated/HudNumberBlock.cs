// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public HudNumberBlock() : base()
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
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public HudNumberBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            digitsBitmap = binaryReader.ReadTagReference();
            bitmapDigitWidth = binaryReader.ReadByte();
            screenDigitWidth = binaryReader.ReadByte();
            xOffset = binaryReader.ReadByte();
            yOffset = binaryReader.ReadByte();
            decimalPointWidth = binaryReader.ReadByte();
            colonWidth = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(76);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[24].ReadPointers(binaryReader, blamPointers);
            invalidName_0[25].ReadPointers(binaryReader, blamPointers);
            invalidName_0[26].ReadPointers(binaryReader, blamPointers);
            invalidName_0[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[28].ReadPointers(binaryReader, blamPointers);
            invalidName_0[29].ReadPointers(binaryReader, blamPointers);
            invalidName_0[30].ReadPointers(binaryReader, blamPointers);
            invalidName_0[31].ReadPointers(binaryReader, blamPointers);
            invalidName_0[32].ReadPointers(binaryReader, blamPointers);
            invalidName_0[33].ReadPointers(binaryReader, blamPointers);
            invalidName_0[34].ReadPointers(binaryReader, blamPointers);
            invalidName_0[35].ReadPointers(binaryReader, blamPointers);
            invalidName_0[36].ReadPointers(binaryReader, blamPointers);
            invalidName_0[37].ReadPointers(binaryReader, blamPointers);
            invalidName_0[38].ReadPointers(binaryReader, blamPointers);
            invalidName_0[39].ReadPointers(binaryReader, blamPointers);
            invalidName_0[40].ReadPointers(binaryReader, blamPointers);
            invalidName_0[41].ReadPointers(binaryReader, blamPointers);
            invalidName_0[42].ReadPointers(binaryReader, blamPointers);
            invalidName_0[43].ReadPointers(binaryReader, blamPointers);
            invalidName_0[44].ReadPointers(binaryReader, blamPointers);
            invalidName_0[45].ReadPointers(binaryReader, blamPointers);
            invalidName_0[46].ReadPointers(binaryReader, blamPointers);
            invalidName_0[47].ReadPointers(binaryReader, blamPointers);
            invalidName_0[48].ReadPointers(binaryReader, blamPointers);
            invalidName_0[49].ReadPointers(binaryReader, blamPointers);
            invalidName_0[50].ReadPointers(binaryReader, blamPointers);
            invalidName_0[51].ReadPointers(binaryReader, blamPointers);
            invalidName_0[52].ReadPointers(binaryReader, blamPointers);
            invalidName_0[53].ReadPointers(binaryReader, blamPointers);
            invalidName_0[54].ReadPointers(binaryReader, blamPointers);
            invalidName_0[55].ReadPointers(binaryReader, blamPointers);
            invalidName_0[56].ReadPointers(binaryReader, blamPointers);
            invalidName_0[57].ReadPointers(binaryReader, blamPointers);
            invalidName_0[58].ReadPointers(binaryReader, blamPointers);
            invalidName_0[59].ReadPointers(binaryReader, blamPointers);
            invalidName_0[60].ReadPointers(binaryReader, blamPointers);
            invalidName_0[61].ReadPointers(binaryReader, blamPointers);
            invalidName_0[62].ReadPointers(binaryReader, blamPointers);
            invalidName_0[63].ReadPointers(binaryReader, blamPointers);
            invalidName_0[64].ReadPointers(binaryReader, blamPointers);
            invalidName_0[65].ReadPointers(binaryReader, blamPointers);
            invalidName_0[66].ReadPointers(binaryReader, blamPointers);
            invalidName_0[67].ReadPointers(binaryReader, blamPointers);
            invalidName_0[68].ReadPointers(binaryReader, blamPointers);
            invalidName_0[69].ReadPointers(binaryReader, blamPointers);
            invalidName_0[70].ReadPointers(binaryReader, blamPointers);
            invalidName_0[71].ReadPointers(binaryReader, blamPointers);
            invalidName_0[72].ReadPointers(binaryReader, blamPointers);
            invalidName_0[73].ReadPointers(binaryReader, blamPointers);
            invalidName_0[74].ReadPointers(binaryReader, blamPointers);
            invalidName_0[75].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
