// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Garb = (TagClass) "garb";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("garb")]
    public partial class GarbageBlock : GarbageBlockBase
    {
        public GarbageBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 168, Alignment = 4)]
    public class GarbageBlockBase : ItemBlock
    {
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 468; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GarbageBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(168);
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
                binaryWriter.Write(invalidName_, 0, 168);
                return nextAddress;
            }
        }
    };
}