// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudMessagesBlock : HudMessagesBlockBase
    {
        public  HudMessagesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class HudMessagesBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal short startIndexIntoTextBlob;
        internal short startIndexOfMessageBlock;
        internal byte panelCount;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  HudMessagesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            startIndexIntoTextBlob = binaryReader.ReadInt16();
            startIndexOfMessageBlock = binaryReader.ReadInt16();
            panelCount = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            invalidName_0 = binaryReader.ReadBytes(24);
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
                binaryWriter.Write(name);
                binaryWriter.Write(startIndexIntoTextBlob);
                binaryWriter.Write(startIndexOfMessageBlock);
                binaryWriter.Write(panelCount);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(invalidName_0, 0, 24);
            }
        }
    };
}
