using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleModelBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return GeometrySectionInfo.BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return GeometrySectionInfo.BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            GeometrySectionInfo.BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            GeometrySectionInfo.BlockSize = length;
        }
    }
}
