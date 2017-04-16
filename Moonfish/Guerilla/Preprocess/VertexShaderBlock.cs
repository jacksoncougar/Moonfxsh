using System.Collections.Generic;

namespace Moonfish.Guerilla.Preprocess
{
    internal class VertexShaderBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "vertex_shader_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var outputSwizzlesField = fields[3];
            fields.Remove(outputSwizzlesField);
            return fields;
        }
    }
}