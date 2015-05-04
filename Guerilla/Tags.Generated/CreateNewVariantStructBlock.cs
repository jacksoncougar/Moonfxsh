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
    public partial class CreateNewVariantStructBlock : CreateNewVariantStructBlockBase
    {
        public CreateNewVariantStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CreateNewVariantStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent invalidName_;
        internal InvalidName invalidName_0;
        internal GDefaultVariantSettingsBlock[] settings;
        internal byte invalidName_1;
        internal byte[] invalidName_2;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public CreateNewVariantStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadStringID();
            invalidName_0 = (InvalidName)binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<GDefaultVariantSettingsBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadBytes(3);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            settings = ReadBlockArrayData<GDefaultVariantSettingsBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write((Int32)invalidName_0);
                nextAddress = Guerilla.WriteBlockArray<GDefaultVariantSettingsBlock>(binaryWriter, settings, nextAddress);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2, 0, 3);
                return nextAddress;
            }
        }
        internal enum InvalidName : int
        {
            Slayer = 0,
            Oddball = 1,
            Juggernaut = 2,
            King = 3,
            Ctf = 4,
            Invasion = 5,
            Territories = 6,
        };
    };
}
