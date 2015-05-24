using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Guerilla.Tags;

namespace Moonfish.Cache
{
    public class VirtualStream : MemoryStream
    {
        public int VirtualOrigin { get; private set; }

        public VirtualStream(byte[] buffer, int virtualOrigin)
            : base(
                buffer)
        {
            VirtualOrigin = virtualOrigin;
        }

        public VirtualStream(int virtualOrigin)
        {
            VirtualOrigin = virtualOrigin;
        }

        public override long Seek(long offset, SeekOrigin loc)
        {
            return IsPointer(offset) && loc == SeekOrigin.Begin
                ? base.Seek(offset - VirtualOrigin, loc) + VirtualOrigin
                : base.Seek(offset, loc) + VirtualOrigin;
        }

        public override long Position
        {
            get { return (int) base.Position + VirtualOrigin; }
            set { base.Position = IsPointer(value) ? value - VirtualOrigin : value; }
        }

        private bool IsPointer(long value)
        {
            // if 'value' is a Pointer
            return (value < 0 || value > Length);
        }
    }
}