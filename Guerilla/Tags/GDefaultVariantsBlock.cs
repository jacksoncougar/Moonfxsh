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
    [LayoutAttribute(Size = 20)]
    public class GDefaultVariantsBlockBase
    {
        internal Moonfish.Tags.StringID variantName;
        internal VariantType variantType;
        internal GDefaultVariantSettingsBlock[] settings;
        internal byte descriptionIndex;
        internal byte[] invalidName_;
        internal  GDefaultVariantsBlockBase(BinaryReader binaryReader)
        {
            this.variantName = binaryReader.ReadStringID();
            this.variantType = (VariantType)binaryReader.ReadInt32();
            this.settings = ReadGDefaultVariantSettingsBlockArray(binaryReader);
            this.descriptionIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual GDefaultVariantSettingsBlock[] ReadGDefaultVariantSettingsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GDefaultVariantSettingsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GDefaultVariantSettingsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GDefaultVariantSettingsBlock(binaryReader);
                }
            }
            return array;
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
