// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GDefaultVariantsBlock : GDefaultVariantsBlockBase
    {
        public  GDefaultVariantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class GDefaultVariantsBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID variantName;
        internal VariantType variantType;
        internal GDefaultVariantSettingsBlock[] settings;
        internal byte descriptionIndex;
        internal byte[] invalidName_;
        internal  GDefaultVariantsBlockBase(BinaryReader binaryReader)
        {
            variantName = binaryReader.ReadStringID();
            variantType = (VariantType)binaryReader.ReadInt32();
            settings = Guerilla.ReadBlockArray<GDefaultVariantSettingsBlock>(binaryReader);
            descriptionIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantName);
                binaryWriter.Write((Int32)variantType);
                nextAddress = Guerilla.WriteBlockArray<GDefaultVariantSettingsBlock>(binaryWriter, settings, nextAddress);
                binaryWriter.Write(descriptionIndex);
                binaryWriter.Write(invalidName_, 0, 3);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
