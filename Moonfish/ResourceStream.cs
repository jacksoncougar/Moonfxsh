using System.Collections.Generic;
using System.IO;
using Moonfish.Guerilla.Tags;

namespace Moonfish.ResourceManagement
{
    using Guerilla.Tags;

    public class ResourceStreamWrapper : Stream
    {
        private Stream BaseStream { get; }

        public IList<GlobalGeometryBlockResourceBlock> Resources { get; private set; }

        public int HeaderSize { get; }

        public ResourceStreamWrapper(Stream stream, GlobalGeometryBlockInfoStructBlock blockInfo)
        {
            BaseStream = stream;
            HeaderSize = blockInfo.SectionDataSize;
            Resources = blockInfo.Resources;
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
            }
            return Seek(offset, System.IO.SeekOrigin.Begin);
        }

        public override void Flush()
        {
            BaseStream.Flush();
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            return BaseStream.Seek(offset, origin);
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

        public override long Position
        {
            get { return BaseStream.Position; }
            set { BaseStream.Position = value; }
        }
    }
}