using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    public partial class MoonfishXboxAnimationRawBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            BlockSize = length;
        }
    }
}
