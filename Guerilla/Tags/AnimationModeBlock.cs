using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationModeBlock : AnimationModeBlockBase
    {
        public  AnimationModeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class AnimationModeBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal WeaponClassBlock[] weaponClassAABBCC;
        internal AnimationIkBlock[] modeIkAABBCC;
        internal  AnimationModeBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.weaponClassAABBCC = ReadWeaponClassBlockArray(binaryReader);
            this.modeIkAABBCC = ReadAnimationIkBlockArray(binaryReader);
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
        internal  virtual WeaponClassBlock[] ReadWeaponClassBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponClassBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponClassBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponClassBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationIkBlock[] ReadAnimationIkBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationIkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationIkBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationIkBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
