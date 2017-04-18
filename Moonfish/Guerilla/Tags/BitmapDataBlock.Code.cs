using System;
using System.IO;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    [UsedImplicitly]
    partial class BitmapDataBlock : IResourceBlock<byte[]>
    {
        private byte[] data0;
        private byte[] data1;
        private byte[] data2;

        public ResourcePointer GetResourcePointer(int index = 0)
        {
            switch (index)
            {
                case 0:
                    return LOD1TextureDataOffset;
                case 1:
                    return LOD2TextureDataOffset;
                case 2:
                    return LOD3TextureDataOffset;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public int GetResourceLength(int index = 0)
        {
            switch (index)
            {
                case 0:
                    return LOD1TextureDataLength;
                case 1:
                    return LOD2TextureDataLength;
                case 2:
                    return LOD3TextureDataLength;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            switch (index)
            {
                case 0:
                    LOD1TextureDataOffset = pointer;
                    break;
                case 1:
                    LOD2TextureDataOffset = pointer;
                    break;
                case 2:
                    LOD3TextureDataOffset = pointer;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void SetResourceLength(int length, int index = 0)
        {
            switch (index)
            {
                case 0:
                    LOD1TextureDataLength = length;
                    break;
                case 1:
                    LOD2TextureDataLength = length;
                    break;
                case 2:
                    LOD3TextureDataLength = length;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public byte[] GetResource(int index = 0)
        {
            switch (index)
            {
                case 0:
                    return data0;
                case 1:
                    return data1;
                case 2:
                    return data2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void ReadResource(Func<IResourceBlock, int, Stream> @delegate)
        {
            data0 = new byte[GetResourceLength()];
            @delegate(this, 0).Read(data0, 0, data0.Length);
            data1 = new byte[GetResourceLength(1)];
            @delegate(this, 1).Read(data1, 0, data1.Length);
            data2 = new byte[GetResourceLength(2)];
            @delegate(this, 2).Read(data2, 0, data2.Length);
        }

        public void WriteResource(Stream output)
        {
            throw new NotImplementedException();
        }
    }
}