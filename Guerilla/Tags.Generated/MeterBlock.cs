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
        public static readonly TagClass Metr = ( TagClass ) "metr";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "metr" )]
    public partial class MeterBlock : MeterBlockBase
    {
        public MeterBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 144, Alignment = 4 )]
    public class MeterBlockBase : IGuerilla
    {
        internal Flags flags;

        /// <summary>
        /// two bitmaps specifying the mask and the meter levels
        /// </summary>
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference stencilBitmaps;

        /// <summary>
        /// optional bitmap to draw into the unmasked regions of the meter (modulated by the colors below)
        /// </summary>
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference sourceBitmap;

        internal short stencilSequenceIndex;
        internal short sourceSequenceIndex;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal InterpolateColors interpolateColors;
        internal AnchorColors anchorColors;
        internal byte[] invalidName_1;
        internal OpenTK.Vector4 emptyColor;
        internal OpenTK.Vector4 fullColor;
        internal byte[] invalidName_2;

        /// <summary>
        /// fade from fully masked to fully unmasked this distance beyond full (and below empty)
        /// </summary>
        internal float unmaskDistanceMeterUnits;

        /// <summary>
        /// fade from fully unmasked to fully masked this distance below full (and beyond empty)
        /// </summary>
        internal float maskDistanceMeterUnits;

        internal byte[] invalidName_3;
        internal byte[] encodedStencil;

        internal MeterBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            stencilBitmaps = binaryReader.ReadTagReference( );
            sourceBitmap = binaryReader.ReadTagReference( );
            stencilSequenceIndex = binaryReader.ReadInt16( );
            sourceSequenceIndex = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 16 );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            interpolateColors = ( InterpolateColors ) binaryReader.ReadInt16( );
            anchorColors = ( AnchorColors ) binaryReader.ReadInt16( );
            invalidName_1 = binaryReader.ReadBytes( 8 );
            emptyColor = binaryReader.ReadVector4( );
            fullColor = binaryReader.ReadVector4( );
            invalidName_2 = binaryReader.ReadBytes( 20 );
            unmaskDistanceMeterUnits = binaryReader.ReadSingle( );
            maskDistanceMeterUnits = binaryReader.ReadSingle( );
            invalidName_3 = binaryReader.ReadBytes( 20 );
            encodedStencil = Guerilla.ReadData( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( stencilBitmaps );
                binaryWriter.Write( sourceBitmap );
                binaryWriter.Write( stencilSequenceIndex );
                binaryWriter.Write( sourceSequenceIndex );
                binaryWriter.Write( invalidName_, 0, 16 );
                binaryWriter.Write( invalidName_0, 0, 4 );
                binaryWriter.Write( ( Int16 ) interpolateColors );
                binaryWriter.Write( ( Int16 ) anchorColors );
                binaryWriter.Write( invalidName_1, 0, 8 );
                binaryWriter.Write( emptyColor );
                binaryWriter.Write( fullColor );
                binaryWriter.Write( invalidName_2, 0, 20 );
                binaryWriter.Write( unmaskDistanceMeterUnits );
                binaryWriter.Write( maskDistanceMeterUnits );
                binaryWriter.Write( invalidName_3, 0, 20 );
                nextAddress = Guerilla.WriteData( binaryWriter, encodedStencil, nextAddress );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
        };

        internal enum InterpolateColors : short
        {
            Linearly = 0,
            FasterNearEmpty = 1,
            FasterNearFull = 2,
            ThroughRandomNoise = 3,
        };

        internal enum AnchorColors : short
        {
            AtBothEnds = 0,
            AtEmpty = 1,
            AtFull = 2,
        };
    };
}