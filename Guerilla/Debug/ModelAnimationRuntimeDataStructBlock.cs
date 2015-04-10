// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelAnimationRuntimeDataStructBlock : ModelAnimationRuntimeDataStructBlockBase
    {
        public  ModelAnimationRuntimeDataStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class ModelAnimationRuntimeDataStructBlockBase
    {
        internal InheritedAnimationBlock[] inheritenceListBBAAAA;
        internal WeaponClassLookupBlock[] weaponListBBAAAA;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ModelAnimationRuntimeDataStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadInheritedAnimationBlockArray(binaryReader);
            ReadWeaponClassLookupBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
            invalidName_0 = binaryReader.ReadBytes(32);
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
        internal  virtual InheritedAnimationBlock[] ReadInheritedAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InheritedAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InheritedAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InheritedAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponClassLookupBlock[] ReadWeaponClassLookupBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponClassLookupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponClassLookupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponClassLookupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteInheritedAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponClassLookupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteInheritedAnimationBlockArray(binaryWriter);
                WriteWeaponClassLookupBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 32);
                binaryWriter.Write(invalidName_0, 0, 32);
            }
        }
    };
}
