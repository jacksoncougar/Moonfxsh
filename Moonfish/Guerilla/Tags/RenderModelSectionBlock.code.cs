using System;
using System.IO;
using System.Linq;
using Moonfish.ResourceManagement;

namespace Moonfish.Guerilla.Tags
{
    partial class RenderModelSectionBlock : IResourceBlock<RenderModelSectionDataBlock>
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

        public RenderModelSectionDataBlock GetResource(int index = 0)
        {
            return SectionData[index];
        }

        public void LoadResource(Func<IResourceBlock, int, Stream> @delegate)
        {
            var stream = new ResourceStreamWrapper(@delegate(this, 0), GeometryBlockInfo);

            if (stream.Length != GetResourceLength()) throw new InvalidDataException();

            var sectionBlock = new RenderModelSectionDataBlock();

            using (var binaryReader = new BinaryReader(stream))
            {
                sectionBlock.Read(binaryReader);

                GlobalGeometryBlockResourceBlock[] vertexBufferResources =
                    GeometryBlockInfo.Resources.Where(
                        x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();

                for (var i = 0; i < sectionBlock.Section.VertexBuffers.Length && i < vertexBufferResources.Length; ++i)
                {
                    sectionBlock.Section.VertexBuffers[i].VertexBuffer.Data =
                        stream.GetResourceData(vertexBufferResources[i]);
                }
            }
            SectionData = new[] {sectionBlock};
        }
    }
}