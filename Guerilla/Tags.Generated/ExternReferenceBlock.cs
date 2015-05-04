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
    public partial class ExternReferenceBlock : ExternReferenceBlockBase
    {
        public ExternReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ExternReferenceBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte externIndex;
        public override int SerializedSize { get { return 2; } }
        public override int Alignment { get { return 4; } }
        public ExternReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterIndex = binaryReader.ReadByte();
            externIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(externIndex);
                return nextAddress;
            }
        }
    };
}
