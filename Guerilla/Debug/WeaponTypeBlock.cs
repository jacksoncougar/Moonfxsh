// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponTypeBlock : WeaponTypeBlockBase
    {
        public  WeaponTypeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class WeaponTypeBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationEntryBlock[] actionsAABBCC;
        internal AnimationEntryBlock[] overlaysAABBCC;
        internal DamageAnimationBlock[] deathAndDamageAABBCC;
        internal AnimationTransitionBlock[] transitionsAABBCC;
        internal PrecacheListBlock[] highPrecacheCCCCC;
        internal PrecacheListBlock[] lowPrecacheCCCCC;
        internal  WeaponTypeBlockBase(System.IO.BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            ReadAnimationEntryBlockArray(binaryReader);
            ReadAnimationEntryBlockArray(binaryReader);
            ReadDamageAnimationBlockArray(binaryReader);
            ReadAnimationTransitionBlockArray(binaryReader);
            ReadPrecacheListBlockArray(binaryReader);
            ReadPrecacheListBlockArray(binaryReader);
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
        internal  virtual AnimationEntryBlock[] ReadAnimationEntryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationEntryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationEntryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationEntryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DamageAnimationBlock[] ReadDamageAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationTransitionBlock[] ReadAnimationTransitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationTransitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationTransitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationTransitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrecacheListBlock[] ReadPrecacheListBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrecacheListBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrecacheListBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrecacheListBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationEntryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDamageAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationTransitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrecacheListBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                WriteAnimationEntryBlockArray(binaryWriter);
                WriteAnimationEntryBlockArray(binaryWriter);
                WriteDamageAnimationBlockArray(binaryWriter);
                WriteAnimationTransitionBlockArray(binaryWriter);
                WritePrecacheListBlockArray(binaryWriter);
                WritePrecacheListBlockArray(binaryWriter);
            }
        }
    };
}
