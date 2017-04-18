using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    /// <summary>
    /// Exposes accessors for resource data pointers in implementing class.
    /// </summary>
    public interface IResourceBlock
    {
        [UsedImplicitly]
        ResourcePointer GetResourcePointer(int index = 0);
        [UsedImplicitly]
        int GetResourceLength(int index = 0);
        void SetResourcePointer(ResourcePointer pointer, int index = 0);
        [UsedImplicitly]
        void SetResourceLength(int length, int index = 0);
    }

    public interface IResourceBlock<out T> : IResourceBlock
    {
        /// <summary>
        /// Returns the resource object contained by this block if it is loaded.
        /// </summary>
        /// <param name="index">resource index</param>
        /// <returns></returns>
        T GetResource(int index = 0);

        /// <summary>
        /// Loads this resource block from the given delegate return value.
        /// </summary>
        /// <remarks>
        /// Internally the implementation will call the delegate passing itself 
        /// and the resource index as arguments. When the delegate returns it is 
        /// expected to contain a null stream or a stream containing the resource 
        /// data at the given index.
        /// </remarks>
        /// <param name="delegate"></param>
        void ReadResource(Func<IResourceBlock, int, Stream> @delegate);

        void WriteResource(Stream output);
    }

    public static class ResourceBlock
    {
        public static void WriteResource<T>(this IResourceBlock block, Stream output, T resource)
            where T : GuerillaBlock
        {
            var startAddress = output.Position;
            long endAddress;
            long length;

            using (var writer = new BinaryWriter(output))
            {
                writer.Write(resource);
            }

            endAddress = output.Position;
            length = endAddress - startAddress;

            block.SetResourceLength((int) length);
            block.SetResourcePointer((int) startAddress);
        }
    }

    public interface IResourceContainer<out T> : IEnumerable<IResourceBlock<T>>
    {
    }
}