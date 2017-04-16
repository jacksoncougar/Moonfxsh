using System.IO;
using System.Text;
using Moonfish.Tags;

namespace Moonfish
{
    public struct StructureAllocationHeader
    {
        public int BlockLength;
        public int StructureBspAddress;
        public int LightmapAddress;
        public TagClass FourCC;
        public const int SizeInBytes = 16;

        public void SerializeTo(Stream stream)
        {
            using (
                var binaryWriter = new BinaryWriter(stream, Encoding.Default,
                    true))
            {
                binaryWriter.Write(BlockLength);
                binaryWriter.Write(StructureBspAddress);
                binaryWriter.Write(LightmapAddress);
                binaryWriter.Write(FourCC);
            }
        }
    }
}