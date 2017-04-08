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
        public Map cacheStream;

        public CacheWriter(Map stream)
        {
            cacheStream = stream;
        }
    }
}