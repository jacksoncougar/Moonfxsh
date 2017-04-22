using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Moonfish.Guerilla.Tags
{
    public partial class BitmapBlock : IResourceContainer<byte[]>
    {
        IEnumerator<IResourceBlock<byte[]>> IEnumerable<IResourceBlock<byte[]>>.GetEnumerator()
        {
            return Bitmaps.Cast<IResourceBlock<byte[]>>().GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Bitmaps.GetEnumerator();
        }
    }
}