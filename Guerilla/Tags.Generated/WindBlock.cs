// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Wind = ( TagClass ) "wind";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "wind" )]
    public partial class WindBlock : WindBlockBase
    {
        public WindBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class WindBlockBase : IGuerilla
    {
        /// <summary>
        /// the wind magnitude in the weather region scales the wind between these bounds
        /// </summary>
        internal Moonfish.Model.Range velocityWorldUnits;

        /// <summary>
        /// the wind direction varies inside a box defined by these angles on either side of the direction from the weather region.
        /// </summary>
        internal OpenTK.Vector2 variationArea;

        internal float localVariationWeight;
        internal float localVariationRate;
        internal float damping;
        internal byte[] invalidName_;

        internal WindBlockBase( BinaryReader binaryReader )
        {
            velocityWorldUnits = binaryReader.ReadRange( );
            variationArea = binaryReader.ReadVector2( );
            localVariationWeight = binaryReader.ReadSingle( );
            localVariationRate = binaryReader.ReadSingle( );
            damping = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 36 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( velocityWorldUnits );
                binaryWriter.Write( variationArea );
                binaryWriter.Write( localVariationWeight );
                binaryWriter.Write( localVariationRate );
                binaryWriter.Write( damping );
                binaryWriter.Write( invalidName_, 0, 36 );
                return nextAddress;
            }
        }
    };
}