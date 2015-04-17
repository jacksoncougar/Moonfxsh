using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    internal class ModelAnimationGraphBlockBase
    {
        [GuerillaPreProcessFieldsMethod( BlockName = "model_animation_graph_block" )]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod( IList<MoonfishTagField> fields )
        {
            var unknownBlock = new MoonfishTagField( MoonfishFieldType.FieldBlock, "Xbox Unknown Animation Block" );
            unknownBlock.AssignDefinition( new MoonfishTagDefinition( "Moonfish Xbox Animation Unknown Block",
                new List<MoonfishTagField>
                {
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown1" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown2" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown3" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown4" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown5" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown6" )
                } ) );

            var rawBlock = new MoonfishTagField( MoonfishFieldType.FieldBlock, "Xbox Unknown Animation Block" );
            rawBlock.AssignDefinition( new MoonfishTagDefinition( "Moonfish Xbox Animation Raw Block",
                new List<MoonfishTagField>
                {
                    new MoonfishTagField( MoonfishFieldType.FieldMoonfishIdent, "Owner Tag" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Block Size" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Block Length" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown" ),
                    new MoonfishTagField( MoonfishFieldType.FieldLongInteger, "Unknown1" ),
                } ) );

            fields.Insert( fields.Count - 1, rawBlock );
            fields.Insert( fields.Count - 1, unknownBlock );
            return fields;
        }
    }
}