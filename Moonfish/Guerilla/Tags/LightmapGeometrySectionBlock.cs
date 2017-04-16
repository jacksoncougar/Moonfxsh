using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla.Tags
{
    partial class LightmapGeometrySectionBlock
    {
        public void LoadCacheData( )
        {
            throw new NotImplementedException();
            ResourceStream resourceStream = null;// GeometryBlockInfo.GetResourceFromCache( );
            if ( resourceStream == null ) return;

            LightmapGeometrySectionCacheDataBlock sectionBlock = new LightmapGeometrySectionCacheDataBlock( );
            using ( BinaryReader binaryReader = new BinaryReader( resourceStream ) )
            {
                sectionBlock.Read( binaryReader );

                GlobalGeometryBlockResourceBlock[] vertexBufferResources = GeometryBlockInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer ).ToArray( );
                for ( int i = 0;
                    i < sectionBlock.Geometry.VertexBuffers.Length && i < vertexBufferResources.Length;
                    ++i )
                {
                    sectionBlock.Geometry.VertexBuffers[ i ].VertexBuffer.Data =
                        resourceStream.GetResourceData( vertexBufferResources[ i ] );
                }
            }
            CacheData = new[] {sectionBlock};
        }
    };
}
