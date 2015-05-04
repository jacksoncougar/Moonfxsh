using System.Collections.Generic;
using System.IO;

namespace Moonfish.Guerilla.Preprocess
{
    internal class ScenarioBlock
    {
        [GuerillaPreProcessMethod(BlockName = "scenario_block")]
        protected static void GuerillaPreProcessMethod(BinaryReader binaryReader, IList<tag_field> fields)
        {
            //fields.Insert( fields.Count, new tag_field( ) { type = field_type._field_pad, Name = "padding", definition = 2 } );
        }
    }
}