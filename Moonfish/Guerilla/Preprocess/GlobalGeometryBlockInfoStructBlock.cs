using System.Collections.Generic;

namespace Moonfish.Guerilla.Preprocess
{
    internal class GlobalGeometryBlockInfoStructBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "particle_model_block")]
        [GuerillaPreProcessFieldsMethod(BlockName = "decorator_set_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            fields.RemoveAt(fields.Count - 2);
            return fields;
        }
    }
}