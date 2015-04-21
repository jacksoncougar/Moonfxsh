// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GrenadeHudSoundBlock : GrenadeHudSoundBlockBase
    {
        public GrenadeHudSoundBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 48, Alignment = 4 )]
    public class GrenadeHudSoundBlockBase : IGuerilla
    {
        [TagReference( "null" )] internal Moonfish.Tags.TagReference sound;
        internal LatchedTo latchedTo;
        internal float scale;
        internal byte[] invalidName_;

        internal GrenadeHudSoundBlockBase( BinaryReader binaryReader )
        {
            sound = binaryReader.ReadTagReference( );
            latchedTo = ( LatchedTo ) binaryReader.ReadInt32( );
            scale = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 32 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( sound );
                binaryWriter.Write( ( Int32 ) latchedTo );
                binaryWriter.Write( scale );
                binaryWriter.Write( invalidName_, 0, 32 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum LatchedTo : int
        {
            LowGrenadeCount = 1,
            NoGrenadesLeft = 2,
            ThrowOnNoGrenades = 4,
        };
    };
}