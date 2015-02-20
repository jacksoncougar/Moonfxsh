using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla
{
    class VirtualMemoryStream : MemoryStream
    {
        VirtualMappedAddress map;

        public VirtualMemoryStream(string path, int virtualAddress)
            : base(File.ReadAllBytes(path))
        {
            map = new VirtualMappedAddress() { Address = virtualAddress, Length = (int)this.Length, Magic = virtualAddress };
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return base.Seek(CheckOffset(offset), origin);
        }
        public override long Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                base.Position = CheckOffset(value);
            }
        }
        private long CheckOffset(long value)
        {
            if (value < 0 || value > this.Length)
            {
                return PointerToOffset((int)value);
            }
            else return value;
        }
        private int PointerToOffset(int value)
        {
            if (map.GetOffset(ref value, true, false)) return value;

            throw new InvalidOperationException();
        }
    }
}
