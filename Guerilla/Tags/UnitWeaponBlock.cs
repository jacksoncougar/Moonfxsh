using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitWeaponBlock : UnitWeaponBlockBase
    {
        public UnitWeaponBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 8 )]
    public class UnitWeaponBlockBase
    {
        [TagReference( "weap" )]
        internal TagReference weapon;
        internal UnitWeaponBlockBase( BinaryReader binaryReader )
        {
            this.weapon = binaryReader.ReadTagReference();
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.Count ];
            if ( blamPointer.Count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
    };
}
