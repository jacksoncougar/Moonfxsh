// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapVertexBufferBucketCacheDataBlock : LightmapVertexBufferBucketCacheDataBlockBase
    {
        public LightmapVertexBufferBucketCacheDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class LightmapVertexBufferBucketCacheDataBlockBase : IGuerilla
    {
        internal GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;

        internal LightmapVertexBufferBucketCacheDataBlockBase( BinaryReader binaryReader )
        {
            vertexBuffers = Guerilla.ReadBlockArray<GlobalGeometrySectionVertexBufferBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionVertexBufferBlock>( binaryWriter,
                    vertexBuffers, nextAddress );
                return nextAddress;
            }
        }
    };
}