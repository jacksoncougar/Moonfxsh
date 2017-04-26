using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Resources;
using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;
using Moonfish.Tags;

namespace Moonfish.Guerilla
{
    /// <summary> Converts a block resource <see cref="Stream"/> into a <see cref="GuerillaBlock"/> object. </summary>
    /// <remarks>
    /// What we have to work with:
    /// The <see cref="Stream"/> containing the resource data.
    /// The <see cref="GlobalGeometryBlockInfoStructBlock"/> object within the parent.
    /// 
    /// What we need to return:
    /// A <see cref="GuerillaBlock"/> containing the resource structure.
    /// 
    /// Problem:
    ///   <see cref="VertexBuffer"/>: vertex data streams have no storage location in the structure.
    /// Proposed Solution:
    ///   Can add a field to the <see cref="VertexBuffer"/> to hold the data.
    ///     pro: links description with data
    ///     con: editing the layout of a Blam! structure.
    /// 
    /// Problem:
    ///   No pointer addresses in the resource stream.
    /// Solution: 
    ///   Can restore the pointer, and then read normally (con: 2x pass process).
    ///   pro: 
    /// Solution
    ///   Can read the resources using only the descriptors (<see cref="GlobalGeometryBlockResourceBlock"/>)
    ///   pro: single pass io.
    ///   con: need to initialize the structure without "reading".
    ///   con: don't know which resource block belong to which <see cref="GuerillaBlock"/> object.
    /// 
    /// 
    /// 
    /// </remarks>
    public class BlockResourceDecompiler
    {
    }

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
        /// Writes the <see cref="GuerillaBlock" /> resource object to the given stream
        /// and updates the resource length, position, and
        /// <see cref="IResourceDescriptor{T}" />'s in the given <see cref="T" />
        /// block.
        /// </summary>
        /// <typeparam name="T">A <see cref="GuerillaBlock" /> object that implements
        /// <see cref="IResourceBlock{T}" />,
        /// <see cref="IResourceDescriptor{T}" /></typeparam>
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
                var vertexBuffer = base.ReadVertexBuffer();

                if (vertexBuffer.Type != VertexAttributeType.None)
                {
                    vertexBuffer.Data = ReadVertexBufferData(offset, vertexBuffer);
                }

                return vertexBuffer;
            }

            private byte[] ReadVertexBufferData(long offset, VertexBuffer vertexBuffer)
            {
                // reverse lookup the resource that contains this VertexBuffer field.
                var resource = info.Resources.SingleOrDefault(item => item.Contains(offset - info.SectionDataSize));

                // if no resource was found then the VertexBuffer must be in the head of the block.
                if (resource == null)
                {
                    resource =
                        info.Resources.Single(
                            item =>
                                item.PrimaryLocator == offset &&
                                item.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer);
                }
                // other wise find the apropriate VertexBuffer resource based on the index.
                else
                {
                    //note: this should floor the value.
                    var index = (int) (offset - info.SectionDataSize - resource.ResourceDataOffset)/
                                resource.SecondaryLocator;

                    resource =
                        info.Resources.Single(
                            item =>
                                item.PrimaryLocator == resource.PrimaryLocator && item.SecondaryLocator == index &&
                                item.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer);
                }

                //TODO: make this linear
                byte[] data;
                using (BaseStream.Pin())
                {
                    BaseStream.Position = resource.ResourceDataOffset + info.SectionDataSize;
                    data = ReadBytes(resource.ResourceDataSize);
                    var check = ReadTagClass();
                    if (check != TagClass.Rsrc && check != TagClass.Blkf)
                        throw new InvalidDataException("Not a resource!");
                }
                return data;
            }
        }
    };
}