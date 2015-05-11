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
        public static readonly TagClass Bloc = (TagClass) "bloc";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bloc")]
    public partial class CrateBlock : CrateBlockBase
    {
        public CrateBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class CrateBlockBase : ObjectBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 192; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CrateBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            DoesNotBlockAOE = 1,
        };
    };
}