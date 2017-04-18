﻿using System;
using System.IO;
using System.Linq;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureBspClusterBlock : IResourceBlock, IResourceDescriptor<GlobalGeometryBlockResourceBlock>,
        IResourceBlock<StructureBspClusterDataBlockNew>
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
            if (resourceStreamWrapper == null)
                return;

            var clusterBlock = new StructureBspClusterDataBlockNew();
            using (var binaryReader = new BlamBinaryReader(resourceStreamWrapper))
            {
                clusterBlock.Read(binaryReader);

                var vertexBufferResources =
                    GeometryBlockInfo.Resources.Where(
                        x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();
                for (var i = 0; i < clusterBlock.Section.VertexBuffers.Length && i < vertexBufferResources.Length; ++i)
                {
                    clusterBlock.Section.VertexBuffers[i].VertexBuffer.Data =
                        resourceStreamWrapper.GetResourceData(vertexBufferResources[i]);
                }
            }
            ClusterData = new[] {clusterBlock};
        }

        GlobalGeometryBlockResourceBlock[] IResourceDescriptor<GlobalGeometryBlockResourceBlock>.GetDescriptors()
        {
            return GeometryBlockInfo.Resources;
        }

        void IResourceDescriptor<GlobalGeometryBlockResourceBlock>.SetDescriptors(GlobalGeometryBlockResourceBlock[] descriptors)
        {
            GeometryBlockInfo.Resources = descriptors;
        }

        StructureBspClusterDataBlockNew IResourceBlock<StructureBspClusterDataBlockNew>.GetResource(int index)
        {
            return ClusterData[index];
        }

        void IResourceBlock<StructureBspClusterDataBlockNew>.ReadResource(Func<IResourceBlock, int, Stream> @delegate)
        {
            ResourceLinker.ReadResource<StructureBspClusterBlock, StructureBspClusterDataBlockNew>(this, @delegate);
        }

        void IResourceBlock<StructureBspClusterDataBlockNew>.WriteResource(Stream output)
        {
            throw new NotImplementedException();
        }
    }
}