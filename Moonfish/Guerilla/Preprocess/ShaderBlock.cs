using System.Collections.Generic;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var postProcessBlockField = fields[17];
            fields.Remove(postProcessBlockField);
            return fields;
        }
    }
}