using System;
using Moonfish.ResourceManagement;
using System.IO;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureInstancedGeometryRenderInfoStructBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return GeometryBlockInfo.BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return GeometryBlockInfo.BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            GeometryBlockInfo.BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            GeometryBlockInfo.BlockSize = length;
        }

        public bool IsRenderDataLoaded => RenderData.Length > 0;

        public void LoadRenderData()
        {
            throw new NotImplementedException();
            ResourceStreamWrapper resourceStreamWrapper = null; //GeometryBlockInfo.GetResourceFromCache();
            if (resourceStreamWrapper == null) return;

            var clusterBlock = new StructureBspClusterDataBlockNew();
            using (var binaryReader = new BinaryReader(resourceStreamWrapper))
            {
                clusterBlock.Read(binaryReader);

                var vertexBufferResources = GeometryBlockInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();
                for (var i = 0;
                    i < clusterBlock.Section.VertexBuffers.Length && i < vertexBufferResources.Length;
                    ++i)
                {
                    clusterBlock.Section.VertexBuffers[i].VertexBuffer.Data =
                        resourceStreamWrapper.GetResourceData(vertexBufferResources[i]);
                }
            }
            RenderData = new[] { clusterBlock };
        }
    }
}