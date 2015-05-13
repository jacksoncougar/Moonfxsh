using System.Collections.Generic;
using Moonfish.Guerilla.Tags;

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
            SectionBuffers = new List<Mesh>(new[] {new Mesh(item.ClusterData[0].Section, null)});
        }

        public RenderObject(StructureBspInstancedGeometryDefinitionBlock item)
        {
            SectionBuffers = new List<Mesh>(new[] {new Mesh(item.RenderInfo.RenderData[0].Section, null)});
        }
    }
}