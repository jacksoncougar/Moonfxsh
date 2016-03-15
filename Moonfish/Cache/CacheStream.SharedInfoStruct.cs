using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Cache
{
    partial class CacheStream
    {
        public struct SharedInfoStruct
        {
            private int Shared0;
            private int Shared1;
            private int Shared2;

            SharedInfoStruct(Stream stream)
            {
                using (var binaryReader = new BinaryReader(stream, Encoding.Default, true))
                {
                    Shared0 = binaryReader.ReadInt32();
                    Shared1 = binaryReader.ReadInt32();
                    Shared2 = binaryReader.ReadInt32();
                }
            }

            public static SharedInfoStruct DeserializeFrom(Stream stream)
            {
				return new SharedInfoStruct(stream);
            }

            public void SerializeTo(Stream stream)
            {
                using (var binaryWriter = new BinaryWriter(stream, Encoding.Default, true))
                {
                    binaryWriter.Write(Shared0);
					binaryWriter.Write(Shared1);
					binaryWriter.Write(Shared2);
                }
            }
        }
    }
}
