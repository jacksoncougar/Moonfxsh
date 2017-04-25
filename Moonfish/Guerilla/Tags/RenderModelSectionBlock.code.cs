using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{

    partial class RenderModelSectionBlock : IResourceBlock<RenderModelSectionDataBlock>,
        IResourceDescriptor<GlobalGeometryBlockResourceBlock>
    {
        private Stream[] vertexBufferStreams;

        ResourcePointer IResourceBlock.GetResourcePointer(int index)
        {
            return GeometryBlockInfo.BlockOffset;
        }

        int IResourceBlock.GetResourceLength(int index)
        {
            return GeometryBlockInfo.BlockSize;
        }

        void IResourceBlock.SetResourcePointer(ResourcePointer pointer, int index)
        {
            GeometryBlockInfo.BlockOffset = pointer;
        }

        void IResourceBlock.SetResourceLength(int length, int index)
        {
            GeometryBlockInfo.BlockSize = length;
        }

        RenderModelSectionDataBlock IResourceBlock<RenderModelSectionDataBlock>.GetResource(int index)
        {
            return SectionData.Length > index ? SectionData[index] : null;
        }

        void IResourceBlock<RenderModelSectionDataBlock>.ReadResource(Func<IResourceBlock, int, Stream> @delegate, int index = -1)
        {
            var stream = new ResourceStreamWrapper(@delegate(this, 0), GeometryBlockInfo);

            if (stream.Length != ((IResourceBlock) this).GetResourceLength())
                throw new InvalidDataException();

            var sectionBlock = new RenderModelSectionDataBlock();

            using (var binaryReader = new BlamBinaryReader(stream))
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


        void IResourceBlock<RenderModelSectionDataBlock>.WriteResource(Stream output, int index = -1)
        {
            ResourceLinker.WriteResource(this, output);
        }

        GlobalGeometryBlockResourceBlock[] IResourceDescriptor<GlobalGeometryBlockResourceBlock>.
            GetDescriptors()
        {
            return GeometryBlockInfo.Resources;
        }

        void IResourceDescriptor<GlobalGeometryBlockResourceBlock>.SetDescriptors(
            GlobalGeometryBlockResourceBlock[] descriptors)
        {
            GeometryBlockInfo.Resources = descriptors;
        }
    }
}