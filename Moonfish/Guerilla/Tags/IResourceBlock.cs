using System.Collections;
using System.Collections.Generic;
using System.IO;
using Moonfish.Cache;

namespace Moonfish.Guerilla.Tags
{
    public interface IResourceBlock
    {
        ResourcePointer GetResourcePointer(int index = 0);
        int GetResourceLength(int index = 0);

        void SetResourcePointer(ResourcePointer pointer, int index = 0);
        void SetResourceLength(int length, int index = 0);
    }
    public static class ResourceBlockExtensions

{

    public static byte[] GetResourceData(this IResourceBlock resourceInfoBlock, int index = 0)
    {
        Stream resourceStream;
        var resourcePointer = resourceInfoBlock.GetResourcePointer(index);
        var resourceLength = resourceInfoBlock.GetResourceLength(index);

        if (!Halo2.TryGettingResourceStream(resourcePointer, out resourceStream))
            return null;

        resourceStream.Position = resourcePointer.Address;
        var buffer = new byte[resourceLength];
        resourceStream.Read(buffer, 0, resourceLength);
        return buffer;
    }
}

    public struct ResourceReference
    {
        public ResourceReference(int address, int length)
        {
            Address = address;
            Length = length;
        }
        public int Address;
        public int Length;
    }
}