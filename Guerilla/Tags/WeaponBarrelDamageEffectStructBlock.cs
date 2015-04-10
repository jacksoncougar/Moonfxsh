using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponBarrelDamageEffectStructBlock : WeaponBarrelDamageEffectStructBlockBase
    {
        public WeaponBarrelDamageEffectStructBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 8 )]
    public class WeaponBarrelDamageEffectStructBlockBase
    {
        [TagReference( "jpt!" )]
        internal TagReference damageEffect;
        internal WeaponBarrelDamageEffectStructBlockBase( BinaryReader binaryReader )
        {
            this.damageEffect = binaryReader.ReadTagReference();
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
