using System;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla
{
    public static class GeometryExtensions
    {
        public static GlobalGeometrySectionStructBlock LoadSectionData(
            this GlobalGeometryBlockInfoStructBlock geometryInfo )
        {
            throw new NotImplementedException();
            ResourceStreamWrapper resourceStreamWrapper = null;
            if ( resourceStreamWrapper == null ) return default(GlobalGeometrySectionStructBlock);

            GlobalGeometrySectionStructBlock sectionBlock = new GlobalGeometrySectionStructBlock( );
            using ( BinaryReader binaryReader = new BinaryReader( resourceStreamWrapper ) )
            {
                sectionBlock.Read( binaryReader );

                GlobalGeometryBlockResourceBlock[] vertexBufferResources = geometryInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer ).ToArray( );
                for ( int i = 0;
                    i < sectionBlock.VertexBuffers.Length && i < vertexBufferResources.Length;
                    ++i )
                {
                    sectionBlock.VertexBuffers[ i ].VertexBuffer.Data =
                        resourceStreamWrapper.GetResourceData( vertexBufferResources[ i ] );
                }
            }
            return sectionBlock;
        }
    }
}