using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    /// <summary>
    ///     Contains generic methods to Write resources from IResourceBlocks and
    ///     update the internal resource values accordingly.
    /// </summary>
    public static class ResourceLinker
    {
        public static TV ReadResource<T, TV>(T block, Func<IResourceBlock, int, Stream> @delegate,
            GlobalGeometryBlockInfoStructBlock blockInfo)
            where T : IResourceBlock<TV>, IResourceDescriptor<GlobalGeometryBlockResourceBlock>
            where TV : GuerillaBlock, new()
        {
            var resource = new TV();
            GlobalGeometryBlockResourceBlock[] resources = block.GetDescriptors();

            var stream = new ResourceStreamWrapper(@delegate(block, 0), blockInfo);

            if (stream.Length != block.GetResourceLength())
                throw new InvalidDataException();

            using (var binaryReader = new ResourceReader(stream, blockInfo))
            {
                resource.Read(binaryReader);
            }

            return resource;
        }

        /// <summary>
        ///     Writes the <see cref="GuerillaBlock" /> resource object to the given stream
        ///     and updates the resource length, position, and
        ///     <see cref="IResourceDescriptor{T}" />'s in the given <see cref="T" />
        ///     block.
        /// </summary>
        /// <typeparam name="T">
        ///     A <see cref="GuerillaBlock" /> object that implements
        ///     <see cref="IResourceBlock{T}" />,
        ///     <see cref="IResourceDescriptor{T}" />
        /// </typeparam>
        /// <param name="block">The object which conatains the resource to write.</param>
        /// <param name="output">The output stream to write the resource to.</param>
        /// <param name="index">The index of the resource to write.</param>
        public static void WriteResource<T>(T block, Stream output, int index = 0)
            where T : GuerillaBlock, IResourceBlock<GuerillaBlock>,
                IResourceDescriptor<GlobalGeometryBlockResourceBlock>
        {
            var startAddress = output.Position;
            long endAddress;
            long length;

            var resourceObject = block.GetResource(index);

            var writer = new ResourceWriter(output);

            writer.Write(resourceObject);

            List<GlobalGeometryBlockResourceBlock> resourceBlocks = writer.ResourceDescriptors;

            endAddress = output.Position;
            length = endAddress - startAddress;

            block.SetDescriptors(resourceBlocks.ToArray());
            block.SetResourceLength((int) length);
            block.SetResourcePointer((int) startAddress);
        }

        /// <summary>
        ///     Writes the byte[] resource to the given stream and updates the
        ///     resource length and pointer member data.
        /// </summary>
        /// <typeparam name="T">Resource block containing a byte[] resource.</typeparam>
        /// <param name="resourceBlock">The resource block to operate on.</param>
        /// <param name="output">The stream to write the resource byte to.</param>
        /// <param name="index">The index of the resource to operate on.</param>
        public static void WriteResourceBytes<T>(T resourceBlock, Stream output, int index = 0)
            where T : IResourceBlock<byte[]>
        {
            var startAddress = output.Position;
            long endAddress;
            long length;

            byte[] bytes = resourceBlock.GetResource(index);
            if (bytes == null)
            {
                return;
            }
            output.Write(bytes, 0, bytes.Length);
            output.PackLength();

            endAddress = output.Position;
            length = endAddress - startAddress;

            resourceBlock.SetResourceLength((int) length);
            resourceBlock.SetResourcePointer((int) startAddress);
        }

        private class ResourceReader : QueueableBlamBinaryReader
        {
            private readonly GlobalGeometryBlockInfoStructBlock info;

            public ResourceReader(Stream input, GlobalGeometryBlockInfoStructBlock info)
                : base(input, info.SectionDataSize)
            {
                this.info = info;
            }

            public override VertexBuffer ReadVertexBuffer()
            {
                var offset = BaseStream.Position;

                var block = info.Resources.Single(item => item.PrimaryLocator == 56 && item.SecondaryLocator == 32);
                var index = (int) (offset - block.ResourceDataOffset - info.SectionDataSize)/block.SecondaryLocator;

                var vertexBufferInfo =
                    info.Resources.Single(item => item.PrimaryLocator == 56 && item.SecondaryLocator == index);

                var vertexBuffer = base.ReadVertexBuffer();

                //TODO: make this linear
                using (BaseStream.Pin())
                {
                    BaseStream.Position = vertexBufferInfo.ResourceDataOffset + info.SectionDataSize;
                    vertexBuffer.Data = ReadBytes(vertexBufferInfo.ResourceDataSize);
                    var check = ReadTagClass();
                    if (check != TagClass.Rsrc && check != TagClass.Blkf)
                        throw new InvalidDataException("Not a resource!");
                }

                return vertexBuffer;
            }
        }
    }
}