// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VertexShaderReferenceBlock : VertexShaderReferenceBlockBase
    {
        public VertexShaderReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class VertexShaderReferenceBlockBase : IGuerilla
    {
        [TagReference( "vrtx" )] internal Moonfish.Tags.TagReference vertexShader;

        internal VertexShaderReferenceBlockBase( BinaryReader binaryReader )
        {
            vertexShader = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( vertexShader );
                return nextAddress;
            }
        }
    };
}