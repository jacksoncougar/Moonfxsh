using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorCacheBlockBlock : IResourceBlock
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
    }
}

namespace Moonfish.Tags
{
    public partial class DecoratorCacheBlockBlock
    {
        [GuerillaPreProcessMethod(BlockName = "decorator_cache_block_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            var field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
            field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
        }
    }
}
