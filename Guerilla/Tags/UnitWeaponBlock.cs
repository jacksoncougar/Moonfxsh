// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitWeaponBlock : UnitWeaponBlockBase
    {
        public  UnitWeaponBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UnitWeaponBlockBase  : IGuerilla
    {
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference weapon;
        internal  UnitWeaponBlockBase(BinaryReader binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weapon);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
