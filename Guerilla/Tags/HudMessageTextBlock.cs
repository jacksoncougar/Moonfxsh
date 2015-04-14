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
        public static readonly TagClass HmtClass = (TagClass)"hmt ";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hmt ")]
    public  partial class HudMessageTextBlock : HudMessageTextBlockBase
    {
        public  HudMessageTextBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class HudMessageTextBlockBase  : IGuerilla
    {
        internal byte[] textData;
        internal HudMessageElementsBlock[] messageElements;
        internal HudMessagesBlock[] messages;
        internal byte[] invalidName_;
        internal  HudMessageTextBlockBase(BinaryReader binaryReader)
        {
            textData = Guerilla.ReadData(binaryReader);
            messageElements = Guerilla.ReadBlockArray<HudMessageElementsBlock>(binaryReader);
            messages = Guerilla.ReadBlockArray<HudMessagesBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(84);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteData(binaryWriter);
                Guerilla.WriteBlockArray<HudMessageElementsBlock>(binaryWriter, messageElements, nextAddress);
                Guerilla.WriteBlockArray<HudMessagesBlock>(binaryWriter, messages, nextAddress);
                binaryWriter.Write(invalidName_, 0, 84);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
