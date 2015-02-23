using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    public partial class ShaderPassPostprocessImplementationNewBlock
    {
        [GuerillaPreProcessMethod(BlockName = "shader_pass_postprocess_implementation_new_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);
        }
    }
}
