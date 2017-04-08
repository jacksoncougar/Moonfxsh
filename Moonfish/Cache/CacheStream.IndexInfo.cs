using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Cache
{
    public partial class Map
    {
        public struct IndexInfoStruct
        {
            public int IndexOffset;
            public int IndexLength;
            public int MetaAllocationLength;
            public int TotalAllocationLength;

            private IndexInfoStruct(Stream stream)
            {
                using (var binaryReader = new BinaryReader(stream, Encoding.Default, true))
                {
                    IndexOffset = binaryReader.ReadInt32();
                    IndexLength = binaryReader.ReadInt32();
                    MetaAllocationLength = binaryReader.ReadInt32();
                    TotalAllocationLength = binaryReader.ReadInt32();
                }
            }

            public static IndexInfoStruct DeserializeFrom(Stream stream)
            {
                return new IndexInfoStruct(stream);
            }

            public void SerializeTo(Stream stream)
            {
                using (var binaryWriter = new BinaryWriter(stream, Encoding.Default, true))
                {
                    binaryWriter.Write(IndexOffset);
                    binaryWriter.Write(IndexLength);
                    binaryWriter.Write(MetaAllocationLength);
                    binaryWriter.Write(TotalAllocationLength);
                }
            }
        }
    }
}
