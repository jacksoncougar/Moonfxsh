using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Cache
{
    internal class CacheWriter : BinaryWriter
    {
        public CacheStream cacheStream;

        public CacheWriter( CacheStream stream )
        {
            cacheStream = stream;
        }
    }
}
