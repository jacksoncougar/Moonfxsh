using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    partial class BitmapDataBlock : IResourceBlock<byte[]>
    {
        private byte[] data0;
        private byte[] data1;
        private byte[] data2;

        /// <summary>
        /// Gets the resource pointer for the resource at the given index.
        /// </summary>
        /// <param name="index">The index of the resource.</param>
        /// <returns>
        /// The resource pointer.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
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

        /// <summary>
        /// Gets the length of the resource stream at the given index.
        /// </summary>
        /// <param name="index">The index of the resource.</param>
        /// <returns>
        /// The length of the resource stream.
        /// </returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
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

        /// <summary>
        /// Sets the resource pointer for the resource at the given index.
        /// </summary>
        /// <param name="pointer">The value to set to the internal resource pointer.</param>
        /// <param name="index">The index of the resource.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
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

        /// <summary>
        /// Sets the length of the resource stream for the resource at the given index.
        /// </summary>
        /// <param name="length">The value to set as the length for the resource stream.</param>
        /// <param name="index">The index of the resource.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
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

        /// <summary>
        /// Returns the resource object contained by this block if it is loaded.
        /// </summary>
        /// <param name="index">resource index</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index</exception>
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

        /// <summary>
        /// Loads this resource block from the given delegate return value.
        /// </summary>
        /// <param name="delegate"></param>
        /// <param name="index"></param>
        /// <remarks>
        /// Internally the implementation will call the delegate passing itself and the
        /// resource index as arguments. When the delegate returns it is expected to
        /// contain a stream containing the resource data at the given index.
        /// </remarks>
        public void ReadResource(Func<IResourceBlock, int, Stream> @delegate, int index = -1)
        {
            switch (index)
            {
                case -1:
                    data0 = new byte[GetResourceLength(0)];
                    @delegate(this, 0).Read(data0, 0, data0.Length);
                    data1 = new byte[GetResourceLength(1)];
                    @delegate(this, 1).Read(data1, 0, data1.Length);
                    data2 = new byte[GetResourceLength(2)];
                    @delegate(this, 2).Read(data2, 0, data2.Length);
                    break;
                case 0:
                    data0 = new byte[GetResourceLength(0)];
                    @delegate(this, 0).Read(data0, 0, data0.Length);
                    break;

                case 1:
                    data1 = new byte[GetResourceLength(1)];
                    @delegate(this, 1).Read(data1, 1, data1.Length);
                    break;

                case 2:
                    data2 = new byte[GetResourceLength(2)];
                    @delegate(this, 2).Read(data2, 2, data2.Length);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        /// <summary>
        /// Writes the resource to the given stream.
        /// </summary>
        /// <param name="output">The stream to write the resource to.</param>
        /// <param name="index"></param>
        public void WriteResource(Stream output, int index = -1)
        {
            switch (index)
            {
                case -1:
                    ResourceLinker.WriteResourceBytes(this, output, 0);
                    ResourceLinker.WriteResourceBytes(this, output, 1);
                    ResourceLinker.WriteResourceBytes(this, output, 2);
                    break;
                case 0:
                    ResourceLinker.WriteResourceBytes(this, output, 0);
                    break;

                case 1:
                    ResourceLinker.WriteResourceBytes(this, output, 1);
                    break;

                case 2:
                    ResourceLinker.WriteResourceBytes(this, output, 2);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}