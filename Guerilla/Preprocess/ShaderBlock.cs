using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    class ShaderBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "shader_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var postProcessBlockField = fields[ 17 ];
            fields.Remove( postProcessBlockField );
            return fields;
        }
    }
}
