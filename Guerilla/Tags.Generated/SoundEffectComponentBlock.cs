// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectComponentBlock : SoundEffectComponentBlockBase
    {
        public SoundEffectComponentBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class SoundEffectComponentBlockBase : IGuerilla
    {
        [TagReference( "null" )] internal Moonfish.Tags.TagReference sound;

        /// <summary>
        /// additional attenuation to sound
        /// </summary>
        internal float gainDB;

        internal Flags flags;

        internal SoundEffectComponentBlockBase( BinaryReader binaryReader )
        {
            sound = binaryReader.ReadTagReference( );
            gainDB = binaryReader.ReadSingle( );
            flags = ( Flags ) binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( sound );
                binaryWriter.Write( gainDB );
                binaryWriter.Write( ( Int32 ) flags );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DontPlayAtStart = 1,
            PlayOnStop = 2,
            InvalidName = 4,
            PlayAlternate = 8,
            InvalidName0 = 16,
            SyncWithOriginLoopingSound = 32,
        };
    };
}