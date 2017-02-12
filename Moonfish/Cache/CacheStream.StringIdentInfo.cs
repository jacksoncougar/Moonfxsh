using System.IO;
using System.Text;

namespace Moonfish.Cache
{
    partial class CacheStream
    {

        /// <summary>
        /// A struct containing an address and byte-length to a resource in halo 2 vista
        /// </summary>
        public struct UnknownInfoStruct
        {
            public readonly int Address;
            public readonly int Length;

            private UnknownInfoStruct(Stream sourceStream)
            {
                using (var binaryReader = new BinaryReader(sourceStream, Encoding.Default, true))
                {
                    Address = binaryReader.ReadInt32();
                    Length = binaryReader.ReadInt32();
                }
            }

            public static UnknownInfoStruct DeserializeFrom(Stream source)
            {
                return new UnknownInfoStruct(source);
            }

            public void SerializeTo(Stream source)
            {
                using (var binaryWriter = new BinaryWriter(source, Encoding.Default, true))
                {
                    binaryWriter.Write(Address);
                    binaryWriter.Write(Length);

                }
            }
        }
    }
}