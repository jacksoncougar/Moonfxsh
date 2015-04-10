using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponClassBlock : WeaponClassBlockBase
    {
        public  WeaponClassBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class WeaponClassBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal WeaponTypeBlock[] weaponTypeAABBCC;
        internal AnimationIkBlock[] weaponIkAABBCC;
        internal  WeaponClassBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.weaponTypeAABBCC = ReadWeaponTypeBlockArray(binaryReader);
            this.weaponIkAABBCC = ReadAnimationIkBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual WeaponTypeBlock[] ReadWeaponTypeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponTypeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponTypeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponTypeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationIkBlock[] ReadAnimationIkBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationIkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationIkBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationIkBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
