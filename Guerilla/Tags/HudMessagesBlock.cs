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
        public  HudMessagesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  HudMessagesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.startIndexIntoTextBlob = binaryReader.ReadInt16();
            this.startIndexOfMessageBlock = binaryReader.ReadInt16();
            this.panelCount = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.invalidName_0 = binaryReader.ReadBytes(24);
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
