// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitWeaponBlock : UnitWeaponBlockBase
    {
        public  UnitWeaponBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitWeaponBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UnitWeaponBlockBase : GuerillaBlock
    {
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference weapon;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitWeaponBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
        }
        public  UnitWeaponBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weapon);
                return nextAddress;
            }
        }
    };
}
