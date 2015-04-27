// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlayerRepresentationBlock : PlayerRepresentationBlockBase
    {
        public PlayerRepresentationBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 188, Alignment = 4 )]
    public class PlayerRepresentationBlockBase : IGuerilla
    {
        [TagReference( "mode" )] internal Moonfish.Tags.TagReference firstPersonHands;
        [TagReference( "mode" )] internal Moonfish.Tags.TagReference firstPersonBody;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        [TagReference( "unit" )] internal Moonfish.Tags.TagReference thirdPersonUnit;
        internal Moonfish.Tags.StringID thirdPersonVariant;

        internal PlayerRepresentationBlockBase( BinaryReader binaryReader )
        {
            firstPersonHands = binaryReader.ReadTagReference( );
            firstPersonBody = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 40 );
            invalidName_0 = binaryReader.ReadBytes( 120 );
            thirdPersonUnit = binaryReader.ReadTagReference( );
            thirdPersonVariant = binaryReader.ReadStringID( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( firstPersonHands );
                binaryWriter.Write( firstPersonBody );
                binaryWriter.Write( invalidName_, 0, 40 );
                binaryWriter.Write( invalidName_0, 0, 120 );
                binaryWriter.Write( thirdPersonUnit );
                binaryWriter.Write( thirdPersonVariant );
                return nextAddress;
            }
        }
    };
}