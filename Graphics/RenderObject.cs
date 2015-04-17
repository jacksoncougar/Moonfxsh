using System.Collections.Generic;
using Moonfish.Guerilla.Tags;

namespace Moonfish.Graphics
{
    public class RenderObject
    {
        protected List<Mesh> SectionBuffers;

        public RenderObject( )
        {
            SectionBuffers = new List<Mesh>( );
        }

        public RenderObject( StructureBspClusterBlockBase item )
        {
            SectionBuffers = new List<Mesh>( new[] {new Mesh( item.clusterData[ 0 ].section, null )} );
        }

        public RenderObject( StructureBspInstancedGeometryDefinitionBlockBase item )
        {
            SectionBuffers = new List<Mesh>( new[] {new Mesh( item.renderInfo.renderData[ 0 ].section, null )} );
        }
    }
}