using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponClassLookupBlock : WeaponClassLookupBlockBase
    {
        public  WeaponClassLookupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class WeaponClassLookupBlockBase
    {
        internal Moonfish.Tags.StringID weaponName;
        internal Moonfish.Tags.StringID weaponClass;
        internal  WeaponClassLookupBlockBase(BinaryReader binaryReader)
        {
            this.weaponName = binaryReader.ReadStringID();
            this.weaponClass = binaryReader.ReadStringID();
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
    };
}
