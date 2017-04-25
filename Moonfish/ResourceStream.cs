using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla;

namespace Moonfish.ResourceManagement
{
    using Guerilla.Tags;

    /// <summary>
    /// Wraps a resource stream so it can be read as a <see cref="GuerillaBlock"/> 
    /// </summary>
    /// <seealso cref="Stream" />
    public class ResourceStreamWrapper : StreamAddressWrapper<Stream>
    {
        public IList<GlobalGeometryBlockResourceBlock> Resources { get; private set; }

        public int HeaderSize { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceStreamWrapper"/> class.
        /// </summary>
        /// <param name="stream">The stream containing the resource data.</param>
        /// <param name="blockInfo">The information about the resource data layout.</param>
        /// <remarks>Creates two virtual maps within the stream: (1) to remap address 0 to address 8.
        /// (2) to remap address 116 to 124.
        /// This is needed because the resource stream has some extra data inserted into it.</remarks>
        public ResourceStreamWrapper(Stream stream, GlobalGeometryBlockInfoStructBlock blockInfo) : base(stream)
        {
            HeaderSize = blockInfo.SectionDataSize;
            Resources = blockInfo.Resources;

            RemoveAddresses(0, 8);

            Seek(0, System.IO.SeekOrigin.Begin);
        }

        public byte[] GetResourceData(GlobalGeometryBlockResourceBlock resource)
        {
            Seek(resource.ResourceDataOffset, SeekOrigin.Data);
            var buffer = new byte[resource.ResourceDataSize];
            Read(buffer, 0, buffer.Length);
            return buffer;
        }

        private enum SeekOrigin
        {
            Header,
            Data,
        }

        private long Seek(long offset, SeekOrigin loc)
        {
            switch (loc)
            {
                case SeekOrigin.Header:
                    return Seek(offset, System.IO.SeekOrigin.Begin);
                case SeekOrigin.Data:
                    return Seek(HeaderSize + offset, System.IO.SeekOrigin.Begin);
                default:
                    return Seek(offset, System.IO.SeekOrigin.Begin);
            }
        }

        public override void Flush()
        {
            BaseStream.Flush();
        }

        public override void SetLength(long value)
        {
            BaseStream.SetLength(value);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return BaseStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            BaseStream.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get { return BaseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return BaseStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return BaseStream.CanWrite; }
        }

        public override long Length
        {
            get { return BaseStream.Length; }
        }
    }
}