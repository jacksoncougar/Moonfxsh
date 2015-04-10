// ReSharper disable All
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
        public  AnimationModeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class AnimationModeBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal WeaponClassBlock[] weaponClassAABBCC;
        internal AnimationIkBlock[] modeIkAABBCC;
        internal  AnimationModeBlockBase(System.IO.BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            ReadWeaponClassBlockArray(binaryReader);
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
        internal  virtual WeaponClassBlock[] ReadWeaponClassBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponClassBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponClassBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponClassBlock(binaryReader);
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
        internal  virtual void WriteWeaponClassBlockArray(System.IO.BinaryWriter binaryWriter)
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
                WriteWeaponClassBlockArray(binaryWriter);
                WriteAnimationIkBlockArray(binaryWriter);
            }
        }
    };
}
