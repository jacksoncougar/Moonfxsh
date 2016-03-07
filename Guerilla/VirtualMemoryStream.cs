using System;
using System.IO;

namespace Moonfish.Guerilla
{
    internal class VirtualMemoryStream : MemoryStream
    {
        private VirtualMappedAddress map;

        public VirtualMemoryStream(string path, int virtualAddress)
            : base(File.ReadAllBytes(path))
        {
            map = new VirtualMappedAddress()
            {
                Address = virtualAddress,
                Length = (int) Length,
                Magic = virtualAddress
            };
        }

        public sealed override long Length => base.Length;

        public override long Seek(long offset, SeekOrigin origin)
        {
            return base.Seek(CheckOffset(offset), origin);
        }

        public override long Position
        {
            get { return base.Position; }
            set { base.Position = CheckOffset(value); }
        }

        private long CheckOffset(long value)
        {
            if (value < 0 || value > Length)
            {
                return PointerToOffset((int) value);
            }
            return value;
        }

        private int PointerToOffset(int value)
        {
            if (map.ContainsVirtualOffset(value))
                return map.GetOffset(value);
            throw new InvalidOperationException();
        }
    }
}