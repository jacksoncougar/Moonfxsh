// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPitchRangeParametersBlock : SoundGestaltPitchRangeParametersBlockBase
    {
        public SoundGestaltPitchRangeParametersBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 10, Alignment = 4 )]
    public class SoundGestaltPitchRangeParametersBlockBase : IGuerilla
    {
        internal short naturalPitchCents;

        /// <summary>
        /// the range of pitches that will be represented using this sample.
        /// </summary>
        internal int bendBoundsCents;

        internal int maxGainPitchBoundsCents;

        internal SoundGestaltPitchRangeParametersBlockBase( BinaryReader binaryReader )
        {
            naturalPitchCents = binaryReader.ReadInt16( );
            bendBoundsCents = binaryReader.ReadInt32( );
            maxGainPitchBoundsCents = binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( naturalPitchCents );
                binaryWriter.Write( bendBoundsCents );
                binaryWriter.Write( maxGainPitchBoundsCents );
                return nextAddress;
            }
        }
    };
}