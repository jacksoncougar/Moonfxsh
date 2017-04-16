using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla.Tags;

namespace Moonfish.ResourceManagement
{
    using Moonfish.Guerilla.Tags;

    //TODO remove this 
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