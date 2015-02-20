using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Preprocess
{
    class ScenarioBlock
    {
        [GuerillaPreProcessMethod( BlockName = "scenario_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            //fields.Insert( fields.Count, new tag_field( ) { type = field_type._field_pad, Name = "padding", definition = 2 } );
        }
    }
}
