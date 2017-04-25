using System;
using System.IO;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    partial class GlobalGeometryBlockResourceBlock : IResourceBlock<byte[]>
    {
        private byte[] data;

        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return ResourceDataOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return ResourceDataSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            ResourceDataOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            ResourceDataSize = length;
        }

        public byte[] GetResource(int index = 0)
        {
            return data;
        }

        public void ReadResource(Func<IResourceBlock, int, Stream> @delegate, int index = -1)
        {
            data = new byte[GetResourceLength()];
            @delegate(this, 0).Read(data, 0, data.Length);
        }

        public void WriteResource(Stream output, int index = -1)
        {
            throw new NotImplementedException();
        }
    }
}