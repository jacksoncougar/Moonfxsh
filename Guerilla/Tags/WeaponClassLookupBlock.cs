// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class WeaponClassLookupBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID weaponName;
        internal Moonfish.Tags.StringID weaponClass;
        internal  WeaponClassLookupBlockBase(BinaryReader binaryReader)
        {
            weaponName = binaryReader.ReadStringID();
            weaponClass = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weaponName);
                binaryWriter.Write(weaponClass);
                return nextAddress;
            }
        }
    };
}
