// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponInterfaceStructBlock : WeaponInterfaceStructBlockBase
    {
        public  WeaponInterfaceStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class WeaponInterfaceStructBlockBase
    {
        internal WeaponSharedInterfaceStructBlock sharedInterface;
        internal WeaponFirstPersonInterfaceBlock[] firstPerson;
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference newHudInterface;
        internal  WeaponInterfaceStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            sharedInterface = new WeaponSharedInterfaceStructBlock(binaryReader);
            ReadWeaponFirstPersonInterfaceBlockArray(binaryReader);
            newHudInterface = binaryReader.ReadTagReference();
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
        internal  virtual WeaponFirstPersonInterfaceBlock[] ReadWeaponFirstPersonInterfaceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponFirstPersonInterfaceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponFirstPersonInterfaceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponFirstPersonInterfaceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponFirstPersonInterfaceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                sharedInterface.Write(binaryWriter);
                WriteWeaponFirstPersonInterfaceBlockArray(binaryWriter);
                binaryWriter.Write(newHudInterface);
            }
        }
    };
}
