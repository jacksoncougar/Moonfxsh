using System.Collections.Generic;

namespace Moonfish.Guerilla.Preprocess
{
    internal class DecoratorPermutationsBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "decorator_permutations_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            fields.Insert(10, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            fields.Insert(9, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            return fields;
        }
    }
}