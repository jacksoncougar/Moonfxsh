using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.ResourceManagement
{
    using Moonfish.Guerilla.Tags;

    public static class ResourceStreamStaticMethods
    {
        public static BlamPointer ReadBlamPointer(this BinaryReader binaryReader, int elementSize)
        {
            if (binaryReader.BaseStream is ResourceStream)
            {
                var stream = binaryReader.BaseStream as ResourceStream;
                var offset = stream.Position;
                binaryReader.BaseStream.Seek(8, SeekOrigin.Current);
                var resource =
                    stream.Resources
                        .SingleOrDefault(x => x.PrimaryLocator == offset &&
                                              x.Type != GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer);
                if (resource == null)
                {
                    return new BlamPointer(0, 0, elementSize);
                }
                var count = resource.ResourceDataSize/resource.SecondaryLocator;
                var address = resource.ResourceDataOffset + stream.HeaderSize;
                return new BlamPointer(count, address, elementSize);
            }
            return new BlamPointer(binaryReader.ReadInt32(), binaryReader.ReadInt32(), elementSize);
        }
    }

    public class ResourceStream : MemoryStream
    {
        private Guerilla.Tags.GlobalGeometryBlockInfoStructBlock blockInfo;

        public IList<Guerilla.Tags.GlobalGeometryBlockResourceBlock> Resources { get; private set; }

        public int HeaderSize { get; private set; }

        public ResourceStream(byte[] buffer, Guerilla.Tags.GlobalGeometryBlockInfoStructBlock blockInfo)
            : base(buffer)
        {
            HeaderSize = blockInfo.SectionDataSize;
            Resources = blockInfo.Resources;
        }

        public byte[] GetResourceData(GlobalGeometryBlockResourceBlock resource)
        {
            this.Seek(resource.ResourceDataOffset, SeekOrigin.Data);
            var buffer = new byte[resource.ResourceDataSize];
            this.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        public enum SeekOrigin
        {
            Header,
            Data,
        }

        public long Seek(long offset, SeekOrigin loc)
        {
            switch (loc)
            {
                case SeekOrigin.Header:
                    return base.Seek(offset, System.IO.SeekOrigin.Begin);
                case SeekOrigin.Data:
                    return base.Seek(HeaderSize + offset, System.IO.SeekOrigin.Begin);
            }
            return base.Seek(offset, System.IO.SeekOrigin.Begin);
        }
    }
}