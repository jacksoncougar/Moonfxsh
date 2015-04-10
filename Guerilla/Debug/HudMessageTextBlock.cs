// ReSharper disable All
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
        public  HudMessageTextBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  HudMessageTextBlockBase(System.IO.BinaryReader binaryReader)
        {
            textData = ReadData(binaryReader);
            ReadHudMessageElementsBlockArray(binaryReader);
            ReadHudMessagesBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(84);
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
        internal  virtual HudMessageElementsBlock[] ReadHudMessageElementsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudMessageElementsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudMessageElementsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudMessageElementsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudMessagesBlock[] ReadHudMessagesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudMessagesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudMessagesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudMessagesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudMessageElementsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudMessagesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteData(binaryWriter);
                WriteHudMessageElementsBlockArray(binaryWriter);
                WriteHudMessagesBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 84);
            }
        }
    };
}
