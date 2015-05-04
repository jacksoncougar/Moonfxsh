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
    public partial class MagazineObjects : MagazineObjectsBase
    {
        public MagazineObjects() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MagazineObjectsBase : GuerillaBlock
    {
        internal short rounds;
        internal byte[] invalidName_;
        [TagReference("eqip")] internal Moonfish.Tags.TagReference equipment;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MagazineObjectsBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            rounds = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            equipment = binaryReader.ReadTagReference();
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
                binaryWriter.Write(rounds);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(equipment);
                return nextAddress;
            }
        }
    };
}