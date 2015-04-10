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
        public  ModelAnimationRuntimeDataStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelAnimationRuntimeDataStructBlockBase(BinaryReader binaryReader)
        {
            this.inheritenceListBBAAAA = ReadInheritedAnimationBlockArray(binaryReader);
            this.weaponListBBAAAA = ReadWeaponClassLookupBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(32);
            this.invalidName_0 = binaryReader.ReadBytes(32);
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
        internal  virtual InheritedAnimationBlock[] ReadInheritedAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InheritedAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InheritedAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InheritedAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponClassLookupBlock[] ReadWeaponClassLookupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponClassLookupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponClassLookupBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponClassLookupBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
