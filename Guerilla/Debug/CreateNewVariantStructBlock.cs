// ReSharper disable All
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
        public  CreateNewVariantStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CreateNewVariantStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadStringID();
            invalidName_0 = (InvalidName)binaryReader.ReadInt32();
            ReadGDefaultVariantSettingsBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadByte();
            invalidName_2 = binaryReader.ReadBytes(3);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual GDefaultVariantSettingsBlock[] ReadGDefaultVariantSettingsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GDefaultVariantSettingsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GDefaultVariantSettingsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GDefaultVariantSettingsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGDefaultVariantSettingsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_);
                binaryWriter.Write((Int32)invalidName_0);
                WriteGDefaultVariantSettingsBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2, 0, 3);
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
