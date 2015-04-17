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
        public static readonly TagClass Egor = ( TagClass ) "egor";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "egor" )]
    public partial class ScreenEffectBlock : ScreenEffectBlockBase
    {
        public ScreenEffectBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 144, Alignment = 4 )]
    public class ScreenEffectBlockBase : IGuerilla
    {
        internal byte[] invalidName_;
        [TagReference( "shad" )] internal Moonfish.Tags.TagReference shader;
        internal byte[] invalidName_0;
        internal RasterizerScreenEffectPassReferenceBlock[] passReferences;

        internal ScreenEffectBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 64 );
            shader = binaryReader.ReadTagReference( );
            invalidName_0 = binaryReader.ReadBytes( 64 );
            passReferences = Guerilla.ReadBlockArray<RasterizerScreenEffectPassReferenceBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 64 );
                binaryWriter.Write( shader );
                binaryWriter.Write( invalidName_0, 0, 64 );
                nextAddress = Guerilla.WriteBlockArray<RasterizerScreenEffectPassReferenceBlock>( binaryWriter,
                    passReferences, nextAddress );
                return nextAddress;
            }
        }
    };
}