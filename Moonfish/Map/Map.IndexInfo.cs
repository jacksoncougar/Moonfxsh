using System.IO;
using System.Text;
using Moonfish.Guerilla;

namespace Moonfish
{
    public sealed partial class Map
    {
        public struct IndexInfoStruct
        {
            /// <summary>
            ///     Offset to start of Index from beginning of file.
            /// </summary>
            public int IndexOffset;

            /// <summary>
            ///     Length of Index.
            /// </summary>
            public int IndexLength;

            /// <summary>
            ///     Length of primary meta data allocation.
            /// </summary>
            /// <remarks>
            ///     This is typically the length from the end of the index data to the end of the file.
            /// </remarks>
            public int MetaAllocationLength;

            /// <summary>
            ///     IndexLength + MetaAllocationLength (I think).
            /// </summary>
            public int TotalAllocationLength;

            private IndexInfoStruct(Stream stream)
            {
                using (
                    var binaryReader = new BlamBinaryReader(stream, Encoding.Default,
                        true))
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
                using (
                    var binaryWriter = new BinaryWriter(stream, Encoding.Default,
                        true))
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