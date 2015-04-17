// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mulg = ( TagClass ) "mulg";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "mulg" )]
    public partial class MultiplayerGlobalsBlock : MultiplayerGlobalsBlockBase
    {
        public MultiplayerGlobalsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class MultiplayerGlobalsBlockBase : IGuerilla
    {
        internal MultiplayerUniversalBlock[] universal;
        internal MultiplayerRuntimeBlock[] runtime;

        internal MultiplayerGlobalsBlockBase( BinaryReader binaryReader )
        {
            universal = Guerilla.ReadBlockArray<MultiplayerUniversalBlock>( binaryReader );
            runtime = Guerilla.ReadBlockArray<MultiplayerRuntimeBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<MultiplayerUniversalBlock>( binaryWriter, universal, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<MultiplayerRuntimeBlock>( binaryWriter, runtime, nextAddress );
                return nextAddress;
            }
        }
    };
}