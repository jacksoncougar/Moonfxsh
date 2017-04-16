using System.IO;

namespace Moonfish
{
    public sealed class VirtualStream : VirtualStreamWrapper<MemoryStream>
    {
        public VirtualStream(byte[] buffer, int virtualOrigin) : base(new MemoryStream(buffer))
        {
            CreateVirtualSection(virtualOrigin, (int)Length, 0, true);
        }

        public VirtualStream(int virtualOrigin) :base(new MemoryStream())
        {
            CreateVirtualSection(virtualOrigin, (int)Length, 0, true);
        }
        
        public byte[] ToArray()
        {
            return BaseStream.ToArray();
        }
    }
}