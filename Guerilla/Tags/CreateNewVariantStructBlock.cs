using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CreateNewVariantStructBlock : CreateNewVariantStructBlockBase
    {
        public  CreateNewVariantStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class CreateNewVariantStructBlockBase
    {
        internal Moonfish.Tags.StringID invalidName_;
        internal InvalidName invalidName_0;
        internal GDefaultVariantSettingsBlock[] settings;
        internal byte invalidName_1;
        internal byte[] invalidName_2;
        internal  CreateNewVariantStructBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadStringID();
            this.invalidName_0 = (InvalidName)binaryReader.ReadInt32();
            this.settings = ReadGDefaultVariantSettingsBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadByte();
            this.invalidName_2 = binaryReader.ReadBytes(3);
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
