using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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