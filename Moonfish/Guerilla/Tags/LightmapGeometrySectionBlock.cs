using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    partial class LightmapGeometrySectionBlock
    {
        public void LoadCacheData( )
        {
            var resourceStream = Halo2.GetResourceBlock( GeometryBlockInfo );
            if ( resourceStream == null ) return;

            var sectionBlock = new LightmapGeometrySectionCacheDataBlock( );
            using ( var binaryReader = new BinaryReader( resourceStream ) )
            {
                sectionBlock.Read( binaryReader );

                var vertexBufferResources = GeometryBlockInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer ).ToArray( );
                for ( var i = 0;
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
