using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Remapping
{
    partial class ModelVariantRegionBlockBase
    {
        [GuerillaPreProcessMethod( BlockName = "model_variant_region_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            ( (enum_definition)fields[5].Definition ).Options = new List<string>( new[]{ 
            "no sorting",
            "minus5#Closest",
            "minus4",
            "minus3",
            "minus2",
            "minus1",
            "no bias#Same as model",
            "plus1",
            "plus2",
            "plus3",
            "plus4",
            "plus5#Farthest",
            } );
        }
    }
}
