using System.Collections.Generic;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class RenderObject
    {
        protected List<Mesh> SectionBuffers;

        public RenderObject()
        {
            SectionBuffers = new List<Mesh>();
        }

        public RenderObject(StructureBspClusterBlock item)
        {
            item.LoadClusterData();
            SectionBuffers = new List<Mesh>(new[] {new Mesh(item.ClusterData[0].Section, null)});
        }

        public RenderObject(StructureBspInstancedGeometryDefinitionBlock item)
        {
            item.RenderInfo.LoadRenderData();
            SectionBuffers = new List<Mesh>(new[] {new Mesh(item.RenderInfo.RenderData[0].Section, null)});
        }

        public IEnumerable<RenderBatch> Batches
        {
            get
            {
                foreach (var sectionBuffer in SectionBuffers)
                {
                    foreach (var globalGeometryPartBlockNew in sectionBuffer.Parts)
                    {
                        var batch = new RenderBatch
                        {
                            ElementStartIndex = globalGeometryPartBlockNew.StripStartIndex * sizeof (ushort),
                            ElementLength = globalGeometryPartBlockNew.StripLength
                        };

                        batch.AssignUniform("TexcoordRangeUniform", new Vector4(0, 1, 0, 1));
                        batch.AssignUniform("WorldMatrixUniform", Matrix4.Identity);
                        batch.AssignUniform("BoneMatrices[0]", Matrix4.Identity);
                        batch.Shader = new ShaderReference(ShaderReference.ReferenceType.Halo2,
                            globalGeometryPartBlockNew.Material);
                        batch.PrimitiveType = PrimitiveType.Triangles;
                        batch.BatchObject = sectionBuffer.TriangleBatch;

                        yield return batch;
                    }
                }
            }
        }
    }
}