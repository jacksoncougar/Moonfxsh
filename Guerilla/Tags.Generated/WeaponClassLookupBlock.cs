// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponClassLookupBlock : WeaponClassLookupBlockBase
    {
        public  WeaponClassLookupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponClassLookupBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class WeaponClassLookupBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent weaponName;
        internal Moonfish.Tags.StringIdent weaponClass;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponClassLookupBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            weaponName = binaryReader.ReadStringID();
            weaponClass = binaryReader.ReadStringID();
        }
        public  WeaponClassLookupBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            weaponName = binaryReader.ReadStringID();
            weaponClass = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
