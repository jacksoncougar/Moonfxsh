// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
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
        public static readonly TagClass Ssce = (TagClass) "ssce";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ssce")]
    public partial class SoundSceneryBlock : SoundSceneryBlockBase
    {
        public SoundSceneryBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundSceneryBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 204; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundSceneryBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(16);
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
                binaryWriter.Write(invalidName_, 0, 16);
                return nextAddress;
            }
        }
    };
}