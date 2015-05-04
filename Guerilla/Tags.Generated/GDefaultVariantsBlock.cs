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
    public partial class GDefaultVariantsBlock : GDefaultVariantsBlockBase
    {
        public GDefaultVariantsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class GDefaultVariantsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent variantName;
        internal VariantType variantType;
        internal GDefaultVariantSettingsBlock[] settings;
        internal byte descriptionIndex;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public GDefaultVariantsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            variantName = binaryReader.ReadStringID();
            variantType = (VariantType)binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<GDefaultVariantSettingsBlock>(binaryReader));
            descriptionIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            settings = ReadBlockArrayData<GDefaultVariantSettingsBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantName);
                binaryWriter.Write((Int32)variantType);
                nextAddress = Guerilla.WriteBlockArray<GDefaultVariantSettingsBlock>(binaryWriter, settings, nextAddress);
                binaryWriter.Write(descriptionIndex);
                binaryWriter.Write(invalidName_, 0, 3);
                return nextAddress;
            }
        }
        internal enum VariantType : int
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
