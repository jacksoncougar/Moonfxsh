using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    /// <summary>Exposes accessors for resource data pointers in implementing class.</summary>
    public interface IResourceBlock
    {
        /// <summary>
        /// Gets the resource pointer for the resource at the given index.
        /// </summary>
        /// <param name="index">The index of the resource.</param>
        /// <returns>The resource pointer.</returns>
        ResourcePointer GetResourcePointer(int index = 0);

        /// <summary>
        /// Gets the length of the resource stream at the given index.
        /// </summary>
        /// <param name="index">The index of the resource.</param>
        /// <returns>The length of the resource stream.</returns>
        int GetResourceLength(int index = 0);

        /// <summary>
        /// Sets the resource pointer for the resource at the given index.
        /// </summary>
        /// <param name="pointer">The value to set to the internal resource pointer.</param>
        /// <param name="index">The index of the resource.</param>
        void SetResourcePointer(ResourcePointer pointer, int index = 0);

        /// <summary>
        /// Sets the length of the resource stream for the resource at the given index.
        /// </summary>
        /// <param name="length">The value to set as the length for the resource stream.</param>
        /// <param name="index">The index of the resource.</param>
        void SetResourceLength(int length, int index = 0);
    }

    /// <summary>
    /// Exposes setter and getter for internal resource description blocks.
    /// </summary>
    /// <typeparam name="T">The type of the resource descriptor</typeparam>
    /// <remarks>The resource description block describes internal structures of a resource stream.</remarks>
    public interface IResourceDescriptor<T>
    {
        /// <summary>
        /// Gets the resource descriptors.
        /// </summary>
        /// <returns>Returns an array of <see cref="T"/> resource descriptors.</returns>
        T[] GetDescriptors();

        /// <summary>
        /// Sets the resource descriptors.
        /// </summary>
        /// <param name="descriptors">The objects to set as the resource descriptors.</param>
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
        ///     contain a stream containing the resource data at the given index.
        /// </remarks>
        /// <param name="delegate"></param>
        /// <param name="index"></param>
        void ReadResource(Func<IResourceBlock, int, Stream> @delegate, int index = -1);

        /// <summary>
        /// Writes the resource to the given stream.
        /// </summary>
        /// <param name="output">The stream to write the resource to.</param>
        /// <param name="index"></param>
        void WriteResource(Stream output, int index = -1);
    }
}