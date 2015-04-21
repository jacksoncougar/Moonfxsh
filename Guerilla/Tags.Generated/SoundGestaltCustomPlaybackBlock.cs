// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltCustomPlaybackBlock : SoundGestaltCustomPlaybackBlockBase
    {
        public SoundGestaltCustomPlaybackBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
    public class SoundGestaltCustomPlaybackBlockBase : IGuerilla
    {
        internal SimplePlatformSoundPlaybackStructBlock playbackDefinition;

        internal SoundGestaltCustomPlaybackBlockBase( BinaryReader binaryReader )
        {
            playbackDefinition = new SimplePlatformSoundPlaybackStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                playbackDefinition.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}