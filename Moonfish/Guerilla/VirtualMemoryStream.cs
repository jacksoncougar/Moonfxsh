using System;
using System.IO;

namespace Moonfish.Guerilla
{
    internal class VirtualMemoryStream : MemoryStream
    {
		private VirtualStreamSection map;

        public VirtualMemoryStream(string path, int virtualAddress)
            : base(File.ReadAllBytes(path))
        {
			map = new VirtualStreamSection(virtualAddress, (int)Length, virtualAddress, this);
        }

        public sealed override long Length => base.Length;

        public override long Seek(long offset, SeekOrigin loc)
        {
			long position;

			if (map.Contains(offset, true))
				offset = map.ConvertPosition(offset, true, false);

			position = base.Seek(offset, loc);
			
			return position;
        }

        public override long Position
		{
			get { return base.Position; }
			set
			{
				if (map.Contains(value))
					base.Position = map.ConvertPosition(value);
				else base.Position = value;
			}
		}
    }
}