// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundOverrideMixbinsBlock : PlatformSoundOverrideMixbinsBlockBase
    {
        public PlatformSoundOverrideMixbinsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class PlatformSoundOverrideMixbinsBlockBase : GuerillaBlock
    {
        internal Mixbin mixbin;
        internal float gainDB;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal PlatformSoundOverrideMixbinsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            mixbin = ( Mixbin ) binaryReader.ReadInt32( );
            gainDB = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) mixbin );
                binaryWriter.Write( gainDB );
                return nextAddress;
            }
        }

        internal enum Mixbin : int
        {
            FrontLeft = 0,
            FrontRight = 1,
            BackLeft = 2,
            BackRight = 3,
            Center = 4,
            LowFrequency = 5,
            Reverb = 6,
            InvalidName3DFrontLeft = 7,
            InvalidName3DFrontRight = 8,
            InvalidName3DBackLeft = 9,
            InvalidName3DBackRight = 10,
            DefaultLeftSpeakers = 11,
            DefaultRightSpeakers = 12,
        };
    };
}