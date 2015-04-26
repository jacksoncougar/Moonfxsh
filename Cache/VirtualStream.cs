using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Guerilla.Tags;

namespace Moonfish.Cache
{
    class VirtualStream : MemoryStream
    {
        private readonly int _virtualOrigin;

        public VirtualStream(byte[] buffer, int virtualOrigin)
            : base(
                buffer)
        {
            _virtualOrigin = virtualOrigin;
        }

        public VirtualStream(int virtualOrigin)
        {
            _virtualOrigin = virtualOrigin;
        }

        public override long Seek( long offset, SeekOrigin loc )
        {
            return IsPointer( offset )
                ? base.Seek( offset - _virtualOrigin, loc ) + _virtualOrigin
                : base.Seek(offset, loc) + _virtualOrigin;
        }

        public override long Position
        {
            get { return (int)base.Position + _virtualOrigin; }
            set { base.Position = IsPointer(value) ? value - _virtualOrigin : value; }
        }

        private bool IsPointer(long value)
        {
            // if 'value' is a Pointer
            return ( value < 0 || value > Length );
        }
    }
}
