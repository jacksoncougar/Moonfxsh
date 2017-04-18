using System;
using System.IO;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    /// <summary>Exposes accessors for resource data pointers in implementing class.</summary>
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

    public interface IResourceDescriptor<T>
    {
        T[] GetDescriptors();
        void SetDescriptors(T[] descriptors);
    }
    
    public interface IResourceBlock<out T> : IResourceBlock
    {
        /// <summary>Returns the resource object contained by this block if it is loaded.</summary>
        /// <param name="index">resource index</param>
        /// <returns></returns>
        T GetResource(int index = 0);

        /// <summary>Loads this resource block from the given delegate return value.</summary>
        /// <remarks>
        ///     Internally the implementation will call the delegate passing itself and the
        ///     resource index as arguments. When the delegate returns it is expected to
        ///     contain a null stream or a stream containing the resource data at the given
        ///     index.
        /// </remarks>
        /// <param name="delegate"></param>
        void ReadResource(Func<IResourceBlock, int, Stream> @delegate);

        void WriteResource(Stream output);
    }
}