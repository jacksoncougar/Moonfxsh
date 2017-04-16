using System.IO;

namespace Moonfish
{
    internal class CacheWriter : BinaryWriter
    {
        public Map CacheStream;

        public CacheWriter(Map stream)
        {
            CacheStream = stream;
        }
    }
}