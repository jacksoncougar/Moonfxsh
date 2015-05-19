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
        public struct StringsInfoStruct
        {
            public int Strings128TableAddress;
            public int StringCount;
            public int StringTableLength;
            public int StringIndexAddress;
            public int StringTableAddress;

            private StringsInfoStruct(Stream sourceStream)
            {
                using (var binaryReader = new BinaryReader(sourceStream, Encoding.Default, true))
                {
                    Strings128TableAddress = binaryReader.ReadInt32();
                    StringCount = binaryReader.ReadInt32();
                    StringTableLength = binaryReader.ReadInt32();
                    StringIndexAddress = binaryReader.ReadInt32();
                    StringTableAddress = binaryReader.ReadInt32();
                }
            }

            public static StringsInfoStruct DeserializeFrom(Stream source)
            {
                return new StringsInfoStruct(source);
            }

            public void SerializeTo(Stream source)
            {
                using (var binaryWriter = new BinaryWriter(source, Encoding.Default, true))
                {
                    binaryWriter.Write(Strings128TableAddress);
					binaryWriter.Write(StringCount);
					binaryWriter.Write(StringTableLength);
                    binaryWriter.Write(StringIndexAddress);
                    binaryWriter.Write(StringTableAddress);
                }
            }
        };
    };
}
