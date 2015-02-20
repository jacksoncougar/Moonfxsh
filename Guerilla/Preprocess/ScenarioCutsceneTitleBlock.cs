using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Preprocess
{
    partial class ScenarioCutsceneTitleBlock
    {
        [GuerillaPreProcessMethod( BlockName = "scenario_cutscene_title_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            fields.Insert( fields.Count, new tag_field( ) { type = field_type._field_pad, Name = "padding", definition = 2 } );
        }
    }
}
