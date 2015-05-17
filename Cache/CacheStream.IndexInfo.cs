using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Cache
{
    public partial class CacheStream
    {
        public struct IndexInfoStruct
        {
            public int IndexOffset;
            public int IndexLength;
            public int MetaAllocationLength;
            public int TotalAllocationLength;

            public IndexInfoStruct(BinaryReader binaryReader)
            {
                IndexOffset = binaryReader.ReadInt32();
                IndexLength = binaryReader.ReadInt32();
                MetaAllocationLength = binaryReader.ReadInt32();
                TotalAllocationLength = binaryReader.ReadInt32();
            }
        }
    }
}
