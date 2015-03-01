using System.Collections.Generic;
using System.IO;

namespace Moonfish.Guerilla.Preprocess
{
    partial class ShaderPostprocessBitmapNewBlockBase
    {
        [GuerillaPreProcessMethod( BlockName = "shader_postprocess_bitmap_new_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            var field = fields[ 0 ];
            field.type = field_type._field_moonfish_ident;
            fields[ 0 ] = field;
        }
    }
}
