using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    internal class PixelShaderFragmentBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "pixel_shader_fragment_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            fields.Insert(fields.Count - 2, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            return fields;
        }
    }
}