using System;
using System.Collections.Generic;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorCacheBlockBlock : IResourceBlock, IResourceDescriptor<GlobalGeometryBlockResourceBlock>, IResourceBlock<DecoratorCacheBlockDataBlock>
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

        GlobalGeometryBlockResourceBlock[] IResourceDescriptor<GlobalGeometryBlockResourceBlock>.GetDescriptors()
        {
            return GeometryBlockInfo.Resources;
        }

        void IResourceDescriptor<GlobalGeometryBlockResourceBlock>.SetDescriptors(GlobalGeometryBlockResourceBlock[] descriptors)
        {
            GeometryBlockInfo.Resources = descriptors;
        }

        DecoratorCacheBlockDataBlock IResourceBlock<DecoratorCacheBlockDataBlock>.GetResource(int index)
        {
            return CacheBlockData[index];
        }

        void IResourceBlock<DecoratorCacheBlockDataBlock>.ReadResource(Func<IResourceBlock, int, Stream> @delegate, int index = -1)
        {
            CacheBlockData = new[]
            {
                ResourceLinker.ReadResource<DecoratorCacheBlockBlock, DecoratorCacheBlockDataBlock>(this, @delegate,
                    GeometryBlockInfo)
            };
        }

        void IResourceBlock<DecoratorCacheBlockDataBlock>.WriteResource(Stream output, int index = -1)
        {
            throw new NotImplementedException();
        }
    }
}