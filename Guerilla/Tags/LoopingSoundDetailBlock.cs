// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LoopingSoundDetailBlock : LoopingSoundDetailBlockBase
    {
        public LoopingSoundDetailBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class LoopingSoundDetailBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference sound;

        /// <summary>
        /// the time between successive playings of this sound will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range randomPeriodBoundsSeconds;

        internal float invalidName_;
        internal Flags flags;

        /// <summary>
        /// the sound's position along the horizon will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range yawBoundsDegrees;

        /// <summary>
        /// the sound's position above (positive values) or below (negative values) the horizon will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range pitchBoundsDegrees;

        /// <summary>
        /// the sound's distance (from its spatialized looping sound or from the listener if the looping sound is stereo) will be randomly selected from this range.
        /// </summary>
        internal Moonfish.Model.Range distanceBoundsWorldUnits;

        internal LoopingSoundDetailBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            sound = binaryReader.ReadTagReference( );
            randomPeriodBoundsSeconds = binaryReader.ReadRange( );
            invalidName_ = binaryReader.ReadSingle( );
            flags = ( Flags ) binaryReader.ReadInt32( );
            yawBoundsDegrees = binaryReader.ReadRange( );
            pitchBoundsDegrees = binaryReader.ReadRange( );
            distanceBoundsWorldUnits = binaryReader.ReadRange( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( sound );
                binaryWriter.Write( randomPeriodBoundsSeconds );
                binaryWriter.Write( invalidName_ );
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( yawBoundsDegrees );
                binaryWriter.Write( pitchBoundsDegrees );
                binaryWriter.Write( distanceBoundsWorldUnits );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DontPlayWithAlternate = 1,
            DontPlayWithoutAlternate = 2,
            StartImmediatelyWithLoop = 4,
        };
    };
}