// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CachedDataBlock : CachedDataBlockBase
    {
        public CachedDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class CachedDataBlockBase : IGuerilla
    {
        internal Moonfish.Tags.VertexBuffer vertexBuffer;

        internal CachedDataBlockBase( BinaryReader binaryReader )
        {
            vertexBuffer = binaryReader.ReadVertexBuffer( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( vertexBuffer );
                return nextAddress;
            }
        }
    };
}