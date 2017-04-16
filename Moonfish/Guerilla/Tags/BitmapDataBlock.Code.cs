using System;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    [UsedImplicitly]
    partial class BitmapDataBlock : IResourceBlock
    {
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
                default: throw new ArgumentOutOfRangeException(nameof(index));
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
                default: throw new ArgumentOutOfRangeException(nameof(index));
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
                default: throw new ArgumentOutOfRangeException(nameof(index));
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
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void LoadResourceData()
        {
            throw new NotImplementedException();
        }
    }
}