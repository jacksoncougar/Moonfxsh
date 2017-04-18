using System;
using System.IO;
using System.Linq;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla.Tags
{
    partial class LightmapGeometrySectionBlock
    {
        public void LoadCacheData( )
        {
            throw new NotImplementedException();
            ResourceStreamWrapper resourceStreamWrapper = null;// GeometryBlockInfo.GetResourceFromCache( );
            if ( resourceStreamWrapper == null ) return;

            LightmapGeometrySectionCacheDataBlock sectionBlock = new LightmapGeometrySectionCacheDataBlock( );
            using ( BlamBinaryReader blamBinaryReader = new BlamBinaryReader( resourceStreamWrapper ) )
            {
                sectionBlock.Read( blamBinaryReader );

                GlobalGeometryBlockResourceBlock[] vertexBufferResources = GeometryBlockInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer ).ToArray( );
                for ( int i = 0;
                    i < sectionBlock.Geometry.VertexBuffers.Length && i < vertexBufferResources.Length;
                    ++i )
                {
                    sectionBlock.Geometry.VertexBuffers[ i ].VertexBuffer.Data =
                        resourceStreamWrapper.GetResourceData( vertexBufferResources[ i ] );
                }
            }
            CacheData = new[] {sectionBlock};
        }
    };
}
