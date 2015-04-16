using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    class matg
    {
        [GuerillaPreProcessMethod(BlockName = "globals_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {

        }
        [GuerillaPreProcessFieldsMethod(BlockName = "globals_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var field = new MoonfishTagField( MoonfishFieldType.FieldBlock, "Sounds" );
            field.AssignDefinition( new MoonfishTagDefinition( "Sound References", new List<MoonfishTagField>
            {
                new MoonfishTagField( MoonfishFieldType.FieldTagReference, "Sound*" )
            } ) );
            fields[ 8 ] = field;
            return fields;
        }
    }
}

