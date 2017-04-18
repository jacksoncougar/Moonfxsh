using System.Collections.Generic;

namespace Moonfish.Guerilla.Tags
{
    public interface IResourceContainer<out T> : IEnumerable<IResourceBlock<T>>
    {
    }
}