// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundPlaybackBlock : PlatformSoundPlaybackBlockBase
    {
        public PlatformSoundPlaybackBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 56, Alignment = 4 )]
    public class PlatformSoundPlaybackBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal PlatformSoundPlaybackStructBlock playback;

        public override int SerializedSize
        {
            get { return 56; }
        }

        internal PlatformSoundPlaybackBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
            playback = new PlatformSoundPlaybackStructBlock( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                playback.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}