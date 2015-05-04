// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalDetailObjectBlock : GlobalDetailObjectBlockBase
    {
        public GlobalDetailObjectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class GlobalDetailObjectBlockBase : GuerillaBlock
    {
        internal byte invalidName_;
        internal byte invalidName_0;
        internal byte invalidName_1;
        internal byte invalidName_2;
        internal short invalidName_3;
        public override int SerializedSize { get { return 6; } }
        public override int Alignment { get { return 4; } }
        public GlobalDetailObjectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadByte();
            invalidName_3 = binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2);
                binaryWriter.Write(invalidName_3);
                return nextAddress;
            }
        }
    };
}
