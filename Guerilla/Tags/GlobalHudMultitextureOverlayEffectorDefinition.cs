// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalHudMultitextureOverlayEffectorDefinition :
        GlobalHudMultitextureOverlayEffectorDefinitionBase
    {
        public GlobalHudMultitextureOverlayEffectorDefinition( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 220, Alignment = 4 )]
    public class GlobalHudMultitextureOverlayEffectorDefinitionBase : IGuerilla
    {
        internal byte[] invalidName_;
        internal DestinationType destinationType;
        internal Destination destination;
        internal Source source;
        internal byte[] invalidName_0;
        internal Moonfish.Model.Range inBoundsSourceUnits;
        internal Moonfish.Model.Range outBoundsPixels;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ColorR8G8B8 tintColorLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 tintColorUpperBound;
        internal PeriodicFunction periodicFunction;
        internal byte[] invalidName_2;
        internal float functionPeriodSeconds;
        internal float functionPhaseSeconds;
        internal byte[] invalidName_3;

        internal GlobalHudMultitextureOverlayEffectorDefinitionBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 64 );
            destinationType = ( DestinationType ) binaryReader.ReadInt16( );
            destination = ( Destination ) binaryReader.ReadInt16( );
            source = ( Source ) binaryReader.ReadInt16( );
            invalidName_0 = binaryReader.ReadBytes( 2 );
            inBoundsSourceUnits = binaryReader.ReadRange( );
            outBoundsPixels = binaryReader.ReadRange( );
            invalidName_1 = binaryReader.ReadBytes( 64 );
            tintColorLowerBound = binaryReader.ReadColorR8G8B8( );
            tintColorUpperBound = binaryReader.ReadColorR8G8B8( );
            periodicFunction = ( PeriodicFunction ) binaryReader.ReadInt16( );
            invalidName_2 = binaryReader.ReadBytes( 2 );
            functionPeriodSeconds = binaryReader.ReadSingle( );
            functionPhaseSeconds = binaryReader.ReadSingle( );
            invalidName_3 = binaryReader.ReadBytes( 32 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 64 );
                binaryWriter.Write( ( Int16 ) destinationType );
                binaryWriter.Write( ( Int16 ) destination );
                binaryWriter.Write( ( Int16 ) source );
                binaryWriter.Write( invalidName_0, 0, 2 );
                binaryWriter.Write( inBoundsSourceUnits );
                binaryWriter.Write( outBoundsPixels );
                binaryWriter.Write( invalidName_1, 0, 64 );
                binaryWriter.Write( tintColorLowerBound );
                binaryWriter.Write( tintColorUpperBound );
                binaryWriter.Write( ( Int16 ) periodicFunction );
                binaryWriter.Write( invalidName_2, 0, 2 );
                binaryWriter.Write( functionPeriodSeconds );
                binaryWriter.Write( functionPhaseSeconds );
                binaryWriter.Write( invalidName_3, 0, 32 );
                return nextAddress;
            }
        }

        internal enum DestinationType : short
        {
            Tint01 = 0,
            HorizontalOffset = 1,
            VerticalOffset = 2,
            Fade01 = 3,
        };

        internal enum Destination : short
        {
            GeometryOffset = 0,
            PrimaryMap = 1,
            SecondaryMap = 2,
            TertiaryMap = 3,
        };

        internal enum Source : short
        {
            PlayerPitch = 0,
            PlayerPitchTangent = 1,
            PlayerYaw = 2,
            WeaponRoundsLoaded = 3,
            WeaponRoundsInventory = 4,
            WeaponHeat = 5,
            ExplicitUsesLowBound = 6,
            WeaponZoomLevel = 7,
        };

        internal enum PeriodicFunction : short
        {
            One = 0,
            Zero = 1,
            Cosine = 2,
            CosineVariablePeriod = 3,
            DiagonalWave = 4,
            DiagonalWaveVariablePeriod = 5,
            Slide = 6,
            SlideVariablePeriod = 7,
            Noise = 8,
            Jitter = 9,
            Wander = 10,
            Spark = 11,
        };
    };
}