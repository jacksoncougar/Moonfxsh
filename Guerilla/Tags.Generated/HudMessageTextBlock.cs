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
        public static readonly TagClass Hmt = (TagClass) "hmt ";
    };
} ;

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

        public override int SerializedSize
        {
            get { return 108; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

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
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, textData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudMessageElementsBlock>(binaryWriter, messageElements,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudMessagesBlock>(binaryWriter, messages, nextAddress);
                binaryWriter.Write(invalidName_, 0, 84);
                return nextAddress;
            }
        }
    };
}