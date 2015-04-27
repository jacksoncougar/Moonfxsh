// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultiplayerUniversalBlock : MultiplayerUniversalBlockBase
    {
        public MultiplayerUniversalBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class MultiplayerUniversalBlockBase : GuerillaBlock
    {
        [TagReference( "unic" )] internal Moonfish.Tags.TagReference randomPlayerNames;
        [TagReference( "unic" )] internal Moonfish.Tags.TagReference teamNames;
        internal MultiplayerColorBlock[] teamColors;
        [TagReference( "unic" )] internal Moonfish.Tags.TagReference multiplayerText;

        public override int SerializedSize
        {
            get { return 32; }
        }

        internal MultiplayerUniversalBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            randomPlayerNames = binaryReader.ReadTagReference( );
            teamNames = binaryReader.ReadTagReference( );
            teamColors = Guerilla.ReadBlockArray<MultiplayerColorBlock>( binaryReader );
            multiplayerText = binaryReader.ReadTagReference( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( randomPlayerNames );
                binaryWriter.Write( teamNames );
                nextAddress = Guerilla.WriteBlockArray<MultiplayerColorBlock>( binaryWriter, teamColors, nextAddress );
                binaryWriter.Write( multiplayerText );
                return nextAddress;
            }
        }
    };
}