using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla;

namespace Moonfish.Guerilla.Tags
{
}

namespace Moonfish.Tags
{
    public partial class DecoratorCacheBlockBlock
    {
        [GuerillaPreProcessMethod(BlockName = "decorator_cache_block_block")]
        protected static void GuerillaPreProcessMethod(BlamBinaryReader blamBinaryReader, IList<tag_field> fields)
        {
            var field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
            field = fields.Last(x => x.type != field_type._field_terminator);
            fields.Remove(field);
        }
    }
}
