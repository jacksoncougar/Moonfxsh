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
        T GetResource(int index = 0);

        void LoadResource(Func<IResourceBlock, int, Stream> @delegate);
    }

    public interface IResourceContainer<out T> : IEnumerable<IResourceBlock<T>>
    {
    }
}