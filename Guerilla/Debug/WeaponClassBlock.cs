// ReSharper disable All
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
        public  WeaponClassBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class WeaponClassBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal WeaponTypeBlock[] weaponTypeAABBCC;
        internal AnimationIkBlock[] weaponIkAABBCC;
        internal  WeaponClassBlockBase(System.IO.BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            ReadWeaponTypeBlockArray(binaryReader);
            ReadAnimationIkBlockArray(binaryReader);
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
        internal  virtual WeaponTypeBlock[] ReadWeaponTypeBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual AnimationIkBlock[] ReadAnimationIkBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponTypeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationIkBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                WriteWeaponTypeBlockArray(binaryWriter);
                WriteAnimationIkBlockArray(binaryWriter);
            }
        }
    };
}
