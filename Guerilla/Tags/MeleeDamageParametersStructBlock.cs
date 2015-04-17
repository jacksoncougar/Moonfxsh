// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MeleeDamageParametersStructBlock : MeleeDamageParametersStructBlockBase
    {
        public MeleeDamageParametersStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 76, Alignment = 4 )]
    public class MeleeDamageParametersStructBlockBase : IGuerilla
    {
        internal OpenTK.Vector2 damagePyramidAngles;
        internal float damagePyramidDepth;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference invalidName_1StHitMeleeDamage;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference invalidName_1StHitMeleeResponse;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference invalidName_2NdHitMeleeDamage;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference invalidName_2NdHitMeleeResponse;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference invalidName_3RdHitMeleeDamage;
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference invalidName_3RdHitMeleeResponse;

        /// <summary>
        /// this is only important for the energy sword
        /// </summary>
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference lungeMeleeDamage;

        /// <summary>
        /// this is only important for the energy sword
        /// </summary>
        [TagReference( "jpt!" )] internal Moonfish.Tags.TagReference lungeMeleeResponse;

        internal MeleeDamageParametersStructBlockBase( BinaryReader binaryReader )
        {
            damagePyramidAngles = binaryReader.ReadVector2( );
            damagePyramidDepth = binaryReader.ReadSingle( );
            invalidName_1StHitMeleeDamage = binaryReader.ReadTagReference( );
            invalidName_1StHitMeleeResponse = binaryReader.ReadTagReference( );
            invalidName_2NdHitMeleeDamage = binaryReader.ReadTagReference( );
            invalidName_2NdHitMeleeResponse = binaryReader.ReadTagReference( );
            invalidName_3RdHitMeleeDamage = binaryReader.ReadTagReference( );
            invalidName_3RdHitMeleeResponse = binaryReader.ReadTagReference( );
            lungeMeleeDamage = binaryReader.ReadTagReference( );
            lungeMeleeResponse = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( damagePyramidAngles );
                binaryWriter.Write( damagePyramidDepth );
                binaryWriter.Write( invalidName_1StHitMeleeDamage );
                binaryWriter.Write( invalidName_1StHitMeleeResponse );
                binaryWriter.Write( invalidName_2NdHitMeleeDamage );
                binaryWriter.Write( invalidName_2NdHitMeleeResponse );
                binaryWriter.Write( invalidName_3RdHitMeleeDamage );
                binaryWriter.Write( invalidName_3RdHitMeleeResponse );
                binaryWriter.Write( lungeMeleeDamage );
                binaryWriter.Write( lungeMeleeResponse );
                return nextAddress;
            }
        }
    };
}