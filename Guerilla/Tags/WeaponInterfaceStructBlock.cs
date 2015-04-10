using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponInterfaceStructBlock : WeaponInterfaceStructBlockBase
    {
        public WeaponInterfaceStructBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 32 )]
    public class WeaponInterfaceStructBlockBase
    {
        internal WeaponSharedInterfaceStructBlock sharedInterface;
        internal WeaponFirstPersonInterfaceBlock[] firstPerson;
        [TagReference( "nhdt" )]
        internal TagReference newHudInterface;
        internal WeaponInterfaceStructBlockBase( BinaryReader binaryReader )
        {
            this.sharedInterface = new WeaponSharedInterfaceStructBlock( binaryReader );
            this.firstPerson = ReadWeaponFirstPersonInterfaceBlockArray( binaryReader );
            this.newHudInterface = binaryReader.ReadTagReference();
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
        internal virtual WeaponFirstPersonInterfaceBlock[] ReadWeaponFirstPersonInterfaceBlockArray( BinaryReader binaryReader )
        {
            var elementSize = Deserializer.SizeOf( typeof( WeaponFirstPersonInterfaceBlock ) );
            var blamPointer = binaryReader.ReadBlamPointer( elementSize );
            var array = new WeaponFirstPersonInterfaceBlock[ blamPointer.Count ];
            using ( binaryReader.BaseStream.Pin() )
            {
                for ( int i = 0; i < blamPointer.Count; ++i )
                {
                    binaryReader.BaseStream.Position = blamPointer[ i ];
                    array[ i ] = new WeaponFirstPersonInterfaceBlock( binaryReader );
                }
            }
            return array;
        }
    };
}
