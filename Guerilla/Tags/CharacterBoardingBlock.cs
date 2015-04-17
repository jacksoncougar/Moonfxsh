// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterBoardingBlock : CharacterBoardingBlockBase
    {
        public CharacterBoardingBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class CharacterBoardingBlockBase : IGuerilla
    {
        internal Flags flags;

        /// <summary>
        /// maximum distance from entry point that we will consider boarding
        /// </summary>
        internal float maxDistanceWus;

        /// <summary>
        /// give up trying to get in boarding seat if entry point is further away than this
        /// </summary>
        internal float abortDistanceWus;

        /// <summary>
        /// maximum speed at which we will consider boarding
        /// </summary>
        internal float maxSpeedWuS;

        internal CharacterBoardingBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            maxDistanceWus = binaryReader.ReadSingle( );
            abortDistanceWus = binaryReader.ReadSingle( );
            maxSpeedWuS = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( maxDistanceWus );
                binaryWriter.Write( abortDistanceWus );
                binaryWriter.Write( maxSpeedWuS );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            AirborneBoarding = 1,
        };
    };
}