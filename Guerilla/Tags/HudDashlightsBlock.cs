// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudDashlightsBlock : HudDashlightsBlockBase
    {
        public HudDashlightsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class HudDashlightsBlockBase : IGuerilla
    {
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference bitmap;
        [TagReference( "shad" )] internal Moonfish.Tags.TagReference shader;
        internal short sequenceIndex;
        internal Flags flags;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference sound;

        internal HudDashlightsBlockBase( BinaryReader binaryReader )
        {
            bitmap = binaryReader.ReadTagReference( );
            shader = binaryReader.ReadTagReference( );
            sequenceIndex = binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            sound = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bitmap );
                binaryWriter.Write( shader );
                binaryWriter.Write( sequenceIndex );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( sound );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            DontScaleWhenPulsing = 1,
        };
    };
}