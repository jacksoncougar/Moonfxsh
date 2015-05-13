using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    partial class BitmapDataBlock : IResourceBlock
    {
        public byte[] bitmapLOD1Bytes;
        public byte[] bitmapLOD2Bytes;
        public byte[] bitmapLOD3Bytes;

        public void LoadRawResources()
        {
            ReadResourceData(out bitmapLOD1Bytes, LOD1TextureDataLength, LOD1TextureDataOffset);
            ReadResourceData(out bitmapLOD2Bytes, LOD2TextureDataLength, LOD2TextureDataOffset);
            ReadResourceData(out bitmapLOD3Bytes, LOD3TextureDataLength, LOD3TextureDataOffset);
        }

        public byte[] GetRawResourceBytes()
        {
            using (
                var stream =
                    new MemoryStream(bitmapLOD1Bytes.Length + bitmapLOD2Bytes.Length + bitmapLOD3Bytes.Length))
            {
                var offset = 0;
                stream.Write(bitmapLOD1Bytes, offset, bitmapLOD1Bytes.Length);
                offset += bitmapLOD1Bytes.Length;
                stream.Write(bitmapLOD2Bytes, offset, bitmapLOD2Bytes.Length);
                offset += bitmapLOD2Bytes.Length;
                stream.Write(bitmapLOD3Bytes, offset, bitmapLOD3Bytes.Length);
                return stream.GetBuffer();
            }
        }

        private void ReadResourceData(out byte[] data, int dataLength, int dataAddress)
        {
            Stream resource;
            if (Halo2.TryGettingResourceStream(dataAddress, out resource))
            {
                var pointer = (ResourcePointer) dataAddress;
                resource.Seek(pointer.Address, SeekOrigin.Begin);
                bitmapLOD1Bytes = new byte[dataLength];
                resource.Read(bitmapLOD1Bytes, 0, dataLength);
            }
            data = new byte[0];
        }
    }
}