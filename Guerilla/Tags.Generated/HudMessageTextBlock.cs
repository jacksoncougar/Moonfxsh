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
        public static readonly TagClass Hmt = (TagClass)"hmt ";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hmt ")]
    public partial class HudMessageTextBlock : HudMessageTextBlockBase
    {
        public  HudMessageTextBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HudMessageTextBlock(): base()
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
        
        public override int SerializedSize{get { return 108; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudMessageTextBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            textData = Guerilla.ReadData(binaryReader);
            messageElements = Guerilla.ReadBlockArray<HudMessageElementsBlock>(binaryReader);
            messages = Guerilla.ReadBlockArray<HudMessagesBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(84);
        }
        public  HudMessageTextBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
