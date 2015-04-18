using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Preprocess
{
    internal class matg
    {
        [GuerillaPreProcessMethod( BlockName = "globals_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
        }

        [GuerillaPreProcessFieldsMethod( BlockName = "globals_block" )]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod( IList<MoonfishTagField> fields )
        {
            var field = new MoonfishTagField( MoonfishFieldType.FieldBlock, "Sounds" );
            var soundTagReferenceField = new MoonfishTagField( MoonfishFieldType.FieldTagReference, "Sound*" );
            soundTagReferenceField.AssignDefinition( new MoonfishTagReferenceDefinition( TagClass.Snd ) );
            field.AssignDefinition( new MoonfishTagDefinition( "Moonfish Sound References Block",
                new List<MoonfishTagField>
                {
                    soundTagReferenceField
                } ) );
            var t = fields[ 8 ].Definition.CalculateSizeOfFieldSet( );
            fields[ 8 ] = field;
            return fields;
        }
    }
}