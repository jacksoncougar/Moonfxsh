using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Preprocess
{
    internal class UserInterfaceScreenWidgetDefinitionBlock
    {
        [GuerillaPreProcessFieldsMethod( BlockName = "user_interface_screen_widget_definition_block" )]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod( IList<MoonfishTagField> fields )
        {
            var mouseDescriptionField = fields[ 30 ];
            var mouseReferenceField = fields[ 31 ];
            fields.Remove( mouseDescriptionField );
            fields.Remove( mouseReferenceField );
            return fields;
        }
    }
}