// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudMessagesBlock : HudMessagesBlockBase
    {
        public HudMessagesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class HudMessagesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal short startIndexIntoTextBlob;
        internal short startIndexOfMessageBlock;
        internal byte panelCount;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 64; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public HudMessagesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            startIndexIntoTextBlob = binaryReader.ReadInt16();
            startIndexOfMessageBlock = binaryReader.ReadInt16();
            panelCount = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            invalidName_0 = binaryReader.ReadBytes(24);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(startIndexIntoTextBlob);
                binaryWriter.Write(startIndexOfMessageBlock);
                binaryWriter.Write(panelCount);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(invalidName_0, 0, 24);
                return nextAddress;
            }
        }
    };
}