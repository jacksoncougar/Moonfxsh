// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorShaderReferenceBlock : DecoratorShaderReferenceBlockBase
    {
        public DecoratorShaderReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class DecoratorShaderReferenceBlockBase : IGuerilla
    {
        [TagReference( "shad" )] internal Moonfish.Tags.TagReference shader;

        internal DecoratorShaderReferenceBlockBase( BinaryReader binaryReader )
        {
            shader = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( shader );
                return nextAddress;
            }
        }
    };
}