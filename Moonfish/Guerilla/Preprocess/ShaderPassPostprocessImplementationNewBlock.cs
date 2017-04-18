using System.Collections.Generic;
using System.IO;

namespace Moonfish.Guerilla.Preprocess
{
    public partial class ShaderPassPostprocessImplementationNewBlock
    {
        [GuerillaPreProcessMethod(BlockName = "shader_pass_postprocess_implementation_new_block")]
        protected static void GuerillaPreProcessMethod(BlamBinaryReader blamBinaryReader, IList<tag_field> fields)
        {
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);
            fields.RemoveAt(fields.Count - 2);
        }
    }
}