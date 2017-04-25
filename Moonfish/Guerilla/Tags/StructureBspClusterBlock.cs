using System;
using System.IO;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    partial class StructureBspClusterBlock : IResourceDescriptor<GlobalGeometryBlockResourceBlock>,
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

        void IResourceBlock<StructureBspClusterDataBlockNew>.ReadResource(Func<IResourceBlock, int, Stream> @delegate, int index = -1)
        {
            ClusterData = new[]
            {
                ResourceLinker.ReadResource<StructureBspClusterBlock, StructureBspClusterDataBlockNew>(this, @delegate,
                    GeometryBlockInfo)
            };
        }

        void IResourceBlock<StructureBspClusterDataBlockNew>.WriteResource(Stream output, int index = -1)
        {
            ResourceLinker.WriteResource(this, output);
        }
    }
}