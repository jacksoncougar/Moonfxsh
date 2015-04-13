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
        public  WeaponTypeBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  WeaponTypeBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.actionsAABBCC = ReadAnimationEntryBlockArray(binaryReader);
            this.overlaysAABBCC = ReadAnimationEntryBlockArray(binaryReader);
            this.deathAndDamageAABBCC = ReadDamageAnimationBlockArray(binaryReader);
            this.transitionsAABBCC = ReadAnimationTransitionBlockArray(binaryReader);
            this.highPrecacheCCCCC = ReadPrecacheListBlockArray(binaryReader);
            this.lowPrecacheCCCCC = ReadPrecacheListBlockArray(binaryReader);
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
        internal  virtual AnimationEntryBlock[] ReadAnimationEntryBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationEntryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationEntryBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationEntryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DamageAnimationBlock[] ReadDamageAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DamageAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DamageAnimationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DamageAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AnimationTransitionBlock[] ReadAnimationTransitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationTransitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationTransitionBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationTransitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrecacheListBlock[] ReadPrecacheListBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrecacheListBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrecacheListBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrecacheListBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
