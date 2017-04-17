using System;
using System.IO;
using System.Linq;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureBspClusterBlock : IResourceBlock
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

        public bool IsClusterDataLoaded => ClusterData.Length > 0;

        public void LoadClusterData()
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
            ClusterData = new[] {clusterBlock};
        }
        public void DeleteClusterData()
        {
            if ( ClusterData.Length <= 0 ) return;

            foreach ( var globalGeometrySectionVertexBufferBlock in ClusterData[0].Section.VertexBuffers )
            {
                globalGeometrySectionVertexBufferBlock.VertexBuffer.Data = null;
            }
        }
    }
}