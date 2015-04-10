using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hmt ")]
    public  partial class HudMessageTextBlock : HudMessageTextBlockBase
    {
        public  HudMessageTextBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 108)]
    public class HudMessageTextBlockBase
    {
        internal byte[] textData;
        internal HudMessageElementsBlock[] messageElements;
        internal HudMessagesBlock[] messages;
        internal byte[] invalidName_;
        internal  HudMessageTextBlockBase(BinaryReader binaryReader)
        {
            this.textData = ReadData(binaryReader);
            this.messageElements = ReadHudMessageElementsBlockArray(binaryReader);
            this.messages = ReadHudMessagesBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(84);
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
        internal  virtual HudMessageElementsBlock[] ReadHudMessageElementsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudMessageElementsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudMessageElementsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudMessageElementsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudMessagesBlock[] ReadHudMessagesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudMessagesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudMessagesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudMessagesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
