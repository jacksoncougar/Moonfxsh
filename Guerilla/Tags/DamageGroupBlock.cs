using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageGroupBlock : DamageGroupBlockBase
    {
        public  DamageGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class DamageGroupBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal ArmorModifierBlock[] armorModifiers;
        internal  DamageGroupBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.armorModifiers = ReadArmorModifierBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual ArmorModifierBlock[] ReadArmorModifierBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ArmorModifierBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ArmorModifierBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ArmorModifierBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
