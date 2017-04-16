using System.IO;

namespace Moonfish
{
    public sealed class VirtualStream : VirtualStreamWrapper<MemoryStream>
    {
        public VirtualStream(byte[] buffer, int virtualOrigin) : base(new MemoryStream(buffer))
        {
            Initialize(virtualOrigin);
        }
        
        public VirtualStream(int virtualOrigin) :base(new MemoryStream())
        {
            Initialize(virtualOrigin);
        }

        private void Initialize(int virtualOrigin)
        {
            CreateVirtualSection(virtualOrigin, (int) Length, 0, true);
        }

        private VirtualStream(MemoryStream stream, int virtualOrigin) : base(stream)
        {
            Initialize(virtualOrigin);
        }

        public static VirtualStream CreateFromFile(string filename, int virtualOrigin)
        {
            return new VirtualStream(new MemoryStream(File.ReadAllBytes(filename)), virtualOrigin);
        }

        public byte[] ToArray()
        {
            return BaseStream.ToArray();
        }
    }
}