using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public struct StructureAllocationHeader
    {
        public int BlockLength;
        public int StructureBSPAddress;
        public int LightmapAddress;
        public TagClass FourCC;
        public const int SizeInBytes = 16;

        public void SerializeTo(Stream stream)
        {
            using (var binaryWriter = new BinaryWriter(stream, Encoding.Default, true))
            {
                binaryWriter.Write(BlockLength);
                binaryWriter.Write(StructureBSPAddress);
                binaryWriter.Write(LightmapAddress);
                binaryWriter.Write(FourCC);
            }
        }
    }
}
