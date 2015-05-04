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
        public static readonly TagClass Hmt = (TagClass)"hmt ";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hmt ")]
    public partial class HudMessageTextBlock : HudMessageTextBlockBase
    {
        public HudMessageTextBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class HudMessageTextBlockBase : GuerillaBlock
    {
        internal byte[] textData;
        internal HudMessageElementsBlock[] messageElements;
        internal HudMessagesBlock[] messages;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 108; } }
        public override int Alignment { get { return 4; } }
        public HudMessageTextBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudMessageElementsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudMessagesBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(84);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            textData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            messageElements = ReadBlockArrayData<HudMessageElementsBlock>(binaryReader, blamPointers.Dequeue());
            messages = ReadBlockArrayData<HudMessagesBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_[24].ReadPointers(binaryReader, blamPointers);
            invalidName_[25].ReadPointers(binaryReader, blamPointers);
            invalidName_[26].ReadPointers(binaryReader, blamPointers);
            invalidName_[27].ReadPointers(binaryReader, blamPointers);
            invalidName_[28].ReadPointers(binaryReader, blamPointers);
            invalidName_[29].ReadPointers(binaryReader, blamPointers);
            invalidName_[30].ReadPointers(binaryReader, blamPointers);
            invalidName_[31].ReadPointers(binaryReader, blamPointers);
            invalidName_[32].ReadPointers(binaryReader, blamPointers);
            invalidName_[33].ReadPointers(binaryReader, blamPointers);
            invalidName_[34].ReadPointers(binaryReader, blamPointers);
            invalidName_[35].ReadPointers(binaryReader, blamPointers);
            invalidName_[36].ReadPointers(binaryReader, blamPointers);
            invalidName_[37].ReadPointers(binaryReader, blamPointers);
            invalidName_[38].ReadPointers(binaryReader, blamPointers);
            invalidName_[39].ReadPointers(binaryReader, blamPointers);
            invalidName_[40].ReadPointers(binaryReader, blamPointers);
            invalidName_[41].ReadPointers(binaryReader, blamPointers);
            invalidName_[42].ReadPointers(binaryReader, blamPointers);
            invalidName_[43].ReadPointers(binaryReader, blamPointers);
            invalidName_[44].ReadPointers(binaryReader, blamPointers);
            invalidName_[45].ReadPointers(binaryReader, blamPointers);
            invalidName_[46].ReadPointers(binaryReader, blamPointers);
            invalidName_[47].ReadPointers(binaryReader, blamPointers);
            invalidName_[48].ReadPointers(binaryReader, blamPointers);
            invalidName_[49].ReadPointers(binaryReader, blamPointers);
            invalidName_[50].ReadPointers(binaryReader, blamPointers);
            invalidName_[51].ReadPointers(binaryReader, blamPointers);
            invalidName_[52].ReadPointers(binaryReader, blamPointers);
            invalidName_[53].ReadPointers(binaryReader, blamPointers);
            invalidName_[54].ReadPointers(binaryReader, blamPointers);
            invalidName_[55].ReadPointers(binaryReader, blamPointers);
            invalidName_[56].ReadPointers(binaryReader, blamPointers);
            invalidName_[57].ReadPointers(binaryReader, blamPointers);
            invalidName_[58].ReadPointers(binaryReader, blamPointers);
            invalidName_[59].ReadPointers(binaryReader, blamPointers);
            invalidName_[60].ReadPointers(binaryReader, blamPointers);
            invalidName_[61].ReadPointers(binaryReader, blamPointers);
            invalidName_[62].ReadPointers(binaryReader, blamPointers);
            invalidName_[63].ReadPointers(binaryReader, blamPointers);
            invalidName_[64].ReadPointers(binaryReader, blamPointers);
            invalidName_[65].ReadPointers(binaryReader, blamPointers);
            invalidName_[66].ReadPointers(binaryReader, blamPointers);
            invalidName_[67].ReadPointers(binaryReader, blamPointers);
            invalidName_[68].ReadPointers(binaryReader, blamPointers);
            invalidName_[69].ReadPointers(binaryReader, blamPointers);
            invalidName_[70].ReadPointers(binaryReader, blamPointers);
            invalidName_[71].ReadPointers(binaryReader, blamPointers);
            invalidName_[72].ReadPointers(binaryReader, blamPointers);
            invalidName_[73].ReadPointers(binaryReader, blamPointers);
            invalidName_[74].ReadPointers(binaryReader, blamPointers);
            invalidName_[75].ReadPointers(binaryReader, blamPointers);
            invalidName_[76].ReadPointers(binaryReader, blamPointers);
            invalidName_[77].ReadPointers(binaryReader, blamPointers);
            invalidName_[78].ReadPointers(binaryReader, blamPointers);
            invalidName_[79].ReadPointers(binaryReader, blamPointers);
            invalidName_[80].ReadPointers(binaryReader, blamPointers);
            invalidName_[81].ReadPointers(binaryReader, blamPointers);
            invalidName_[82].ReadPointers(binaryReader, blamPointers);
            invalidName_[83].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, textData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudMessageElementsBlock>(binaryWriter, messageElements, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudMessagesBlock>(binaryWriter, messages, nextAddress);
                binaryWriter.Write(invalidName_, 0, 84);
                return nextAddress;
            }
        }
    };
}
