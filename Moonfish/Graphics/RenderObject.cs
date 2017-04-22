using System.Collections.Generic;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class RenderObject
    {
        public List<Mesh> sectionBuffers;

        public RenderObject( )
        {
            sectionBuffers = new List<Mesh>( );
        }

        public RenderObject( StructureBspClusterBlock item )
        {
            sectionBuffers = new List<Mesh>( new[] {new Mesh( item.ClusterData[ 0 ].Section, null )} );
        }

        public RenderObject( StructureBspInstancedGeometryDefinitionBlock item )
        {
            item.RenderInfo.LoadRenderData( );
            sectionBuffers = item.RenderInfo.RenderData.Length > 0
                ? new List<Mesh>( new[] {new Mesh( item.RenderInfo.RenderData[ 0 ].Section, null )} )
                : new List<Mesh>( );
        }

        public IEnumerable<RenderBatch> Batches
        {
            get
            {
                foreach ( var sectionBuffer in sectionBuffers )
                {

                    foreach ( var globalGeometryPartBlockNew in sectionBuffer.Parts )
                    {
                        var batch = new RenderBatch
                        {
                            ElementStartIndex = globalGeometryPartBlockNew.StripStartIndex * sizeof ( ushort ),
                            ElementLength = globalGeometryPartBlockNew.StripLength
                        };

                        batch.AssignUniform( "WorldMatrixUniform", Matrix4.Identity );
                        batch.Shader = new ShaderReference( ShaderReference.ReferenceType.Halo2,
                            globalGeometryPartBlockNew.Material );
                        batch.PrimitiveType =
                            globalGeometryPartBlockNew.GlobalGeometryPartNewFlags.HasFlag(
                                GlobalGeometryPartBlockNew.Flags.OverrideTriangleList )
                                ? PrimitiveType.Triangles
                                : PrimitiveType.TriangleStrip;
                        batch.BatchObject = sectionBuffer.TriangleBatch;

                        yield return batch;
                    }
                }
            }
        }
    };
}