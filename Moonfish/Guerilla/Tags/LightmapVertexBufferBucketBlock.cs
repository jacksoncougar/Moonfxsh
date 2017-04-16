using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapVertexBufferBucketBlock : IResourceBlock
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

        public void LoadCacheData()
        {
            throw new NotImplementedException();
            ResourceStream resourceStream = null; //GeometryBlockInfo.GetResourceFromCache();
            if (resourceStream == null) return;

            LightmapVertexBufferBucketCacheDataBlock sectionBlock = new LightmapVertexBufferBucketCacheDataBlock();
            using (BinaryReader binaryReader = new BinaryReader(resourceStream))
            {
                sectionBlock.Read(binaryReader);

                GlobalGeometryBlockResourceBlock[] vertexBufferResources = GeometryBlockInfo.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();
                for (int i = 0;
                    i < sectionBlock.VertexBuffers.Length && i < vertexBufferResources.Length;
                    ++i)
                {
                    sectionBlock.VertexBuffers[i].VertexBuffer.Data =
                        resourceStream.GetResourceData(vertexBufferResources[i]);
                }
            }
            CacheData = new[] { sectionBlock };
        }
    }
}
