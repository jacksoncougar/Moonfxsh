// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterPlacementBlock : CharacterPlacementBlockBase
    {
        public CharacterPlacementBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class CharacterPlacementBlockBase : IGuerilla
    {
        internal byte[] invalidName_;
        internal float fewUpgradeChanceEasy;
        internal float fewUpgradeChanceNormal;
        internal float fewUpgradeChanceHeroic;
        internal float fewUpgradeChanceLegendary;
        internal float normalUpgradeChanceEasy;
        internal float normalUpgradeChanceNormal;
        internal float normalUpgradeChanceHeroic;
        internal float normalUpgradeChanceLegendary;
        internal float manyUpgradeChanceEasy;
        internal float manyUpgradeChanceNormal;
        internal float manyUpgradeChanceHeroic;
        internal float manyUpgradeChanceLegendary;

        internal CharacterPlacementBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 4 );
            fewUpgradeChanceEasy = binaryReader.ReadSingle( );
            fewUpgradeChanceNormal = binaryReader.ReadSingle( );
            fewUpgradeChanceHeroic = binaryReader.ReadSingle( );
            fewUpgradeChanceLegendary = binaryReader.ReadSingle( );
            normalUpgradeChanceEasy = binaryReader.ReadSingle( );
            normalUpgradeChanceNormal = binaryReader.ReadSingle( );
            normalUpgradeChanceHeroic = binaryReader.ReadSingle( );
            normalUpgradeChanceLegendary = binaryReader.ReadSingle( );
            manyUpgradeChanceEasy = binaryReader.ReadSingle( );
            manyUpgradeChanceNormal = binaryReader.ReadSingle( );
            manyUpgradeChanceHeroic = binaryReader.ReadSingle( );
            manyUpgradeChanceLegendary = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( fewUpgradeChanceEasy );
                binaryWriter.Write( fewUpgradeChanceNormal );
                binaryWriter.Write( fewUpgradeChanceHeroic );
                binaryWriter.Write( fewUpgradeChanceLegendary );
                binaryWriter.Write( normalUpgradeChanceEasy );
                binaryWriter.Write( normalUpgradeChanceNormal );
                binaryWriter.Write( normalUpgradeChanceHeroic );
                binaryWriter.Write( normalUpgradeChanceLegendary );
                binaryWriter.Write( manyUpgradeChanceEasy );
                binaryWriter.Write( manyUpgradeChanceNormal );
                binaryWriter.Write( manyUpgradeChanceHeroic );
                binaryWriter.Write( manyUpgradeChanceLegendary );
                return nextAddress;
            }
        }
    };
}