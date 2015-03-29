using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Graphics
{
    public class RenderObject
    {
        protected List<Mesh> SectionBuffers;

        public RenderObject()
        {
            SectionBuffers = new List<Mesh>();
        }

        public RenderObject(StructureBspClusterBlockBase item)
        {
            SectionBuffers = new List<Mesh>(new[] { new Mesh(item.clusterData[0].section) });
        }

        public RenderObject(StructureBspInstancedGeometryDefinitionBlockBase item)
        {
            SectionBuffers = new List<Mesh>(new[] { new Mesh(item.renderInfo.renderData[0].section) });
        }
    }
}
