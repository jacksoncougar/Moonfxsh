using System.IO;

namespace Moonfish.Cache
{
    internal class CacheWriter : BinaryWriter
    {
        public CacheStream cacheStream;

        public CacheWriter(CacheStream stream)
        {
            cacheStream = stream;
        }
    }
}