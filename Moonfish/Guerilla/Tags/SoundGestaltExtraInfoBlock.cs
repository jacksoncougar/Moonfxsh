using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltExtraInfoBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return GeometryBlockInfo.BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return GeometryBlockInfo.BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            GeometryBlockInfo.BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            GeometryBlockInfo.BlockSize = length;
        }

        public void LoadResourceData()
        {
            throw new NotImplementedException();
        }
    }
}
