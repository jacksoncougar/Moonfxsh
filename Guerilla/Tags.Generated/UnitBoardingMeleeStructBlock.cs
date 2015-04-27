// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitBoardingMeleeStructBlock : UnitBoardingMeleeStructBlockBase
    {
        public UnitBoardingMeleeStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class UnitBoardingMeleeStructBlockBase : GuerillaBlock
    {
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference boardingMeleeDamage;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference boardingMeleeResponse;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference landingMeleeDamage;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference flurryMeleeDamage;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference obstacleSmashDamage;

        public override int SerializedSize
        {
            get { return 40; }
        }

        internal UnitBoardingMeleeStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            boardingMeleeDamage = binaryReader.ReadTagReference( );
            boardingMeleeResponse = binaryReader.ReadTagReference( );
            landingMeleeDamage = binaryReader.ReadTagReference( );
            flurryMeleeDamage = binaryReader.ReadTagReference( );
            obstacleSmashDamage = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( boardingMeleeDamage );
                binaryWriter.Write( boardingMeleeResponse );
                binaryWriter.Write( landingMeleeDamage );
                binaryWriter.Write( flurryMeleeDamage );
                binaryWriter.Write( obstacleSmashDamage );
                return nextAddress;
            }
        }
    };
}