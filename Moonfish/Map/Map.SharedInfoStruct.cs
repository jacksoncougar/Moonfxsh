using System.IO;
using System.Text;

namespace Moonfish
{
    partial class Map
    {
        public struct SharedInfoStruct
        {
            private readonly int shared0;
            private readonly int shared1;
            private readonly int shared2;

            private SharedInfoStruct(Stream stream)
            {
                using (
                    var binaryReader = new BinaryReader(stream, Encoding.Default,
                        true))
                {
                    shared0 = binaryReader.ReadInt32();
                    shared1 = binaryReader.ReadInt32();
                    shared2 = binaryReader.ReadInt32();
                }
            }

            public static SharedInfoStruct DeserializeFrom(Stream stream)
            {
                return new SharedInfoStruct(stream);
            }

            public void SerializeTo(Stream stream)
            {
                using (
                    var binaryWriter = new BinaryWriter(stream, Encoding.Default,
                        true))
                {
                    binaryWriter.Write(shared0);
                    binaryWriter.Write(shared1);
                    binaryWriter.Write(shared2);
                }
            }
        }
    }
}