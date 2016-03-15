using System.Collections.Generic;

namespace Moonfish.Guerilla.Preprocess
{
    public class MaterialsBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "materials_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            return fields;
        }
    }
}
