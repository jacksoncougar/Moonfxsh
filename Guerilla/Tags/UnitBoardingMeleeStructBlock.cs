using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitBoardingMeleeStructBlock : UnitBoardingMeleeStructBlockBase
    {
        public UnitBoardingMeleeStructBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 40 )]
    public class UnitBoardingMeleeStructBlockBase
    {
        [TagReference( "jpt!" )]
        internal TagReference boardingMeleeDamage;
        [TagReference( "jpt!" )]
        internal TagReference boardingMeleeResponse;
        [TagReference( "jpt!" )]
        internal TagReference landingMeleeDamage;
        [TagReference( "jpt!" )]
        internal TagReference flurryMeleeDamage;
        [TagReference( "jpt!" )]
        internal TagReference obstacleSmashDamage;
        internal UnitBoardingMeleeStructBlockBase( BinaryReader binaryReader )
        {
            this.boardingMeleeDamage = binaryReader.ReadTagReference();
            this.boardingMeleeResponse = binaryReader.ReadTagReference();
            this.landingMeleeDamage = binaryReader.ReadTagReference();
            this.flurryMeleeDamage = binaryReader.ReadTagReference();
            this.obstacleSmashDamage = binaryReader.ReadTagReference();
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
