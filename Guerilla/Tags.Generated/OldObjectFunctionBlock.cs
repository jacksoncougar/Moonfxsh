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
    public partial class OldObjectFunctionBlock : OldObjectFunctionBlockBase
    {
        public OldObjectFunctionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class OldObjectFunctionBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent invalidName_0;
        public override int SerializedSize { get { return 80; } }
        public override int Alignment { get { return 4; } }
        public OldObjectFunctionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(76);
            invalidName_0 = binaryReader.ReadStringID();
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
                binaryWriter.Write(invalidName_, 0, 76);
                binaryWriter.Write(invalidName_0);
                return nextAddress;
            }
        }
    };
}
