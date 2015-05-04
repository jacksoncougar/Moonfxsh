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
    public partial class TextValuePairReferenceBlock : TextValuePairReferenceBlockBase
    {
        public TextValuePairReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class TextValuePairReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal int value;
        internal Moonfish.Tags.StringIdent labelStringId;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public TextValuePairReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            value = binaryReader.ReadInt32();
            labelStringId = binaryReader.ReadStringID();
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
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(value);
                binaryWriter.Write(labelStringId);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            DefaultSetting = 1,
        };
    };
}
