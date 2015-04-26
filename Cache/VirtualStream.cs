using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override long Position
        {
            get { return (int)base.Position + _virtualOrigin; }
            set { base.Position = value - _virtualOrigin; }
        }
    }
}
