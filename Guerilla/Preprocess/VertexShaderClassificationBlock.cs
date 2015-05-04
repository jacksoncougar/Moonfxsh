using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    internal class VertexShaderClassificationBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "vertex_shader_classification_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var compiledShaderDataField = fields[1];
            var definition = compiledShaderDataField.Definition as MoonfishTagDataDefinition;
            if (definition != null)
                definition.DataElementSize = 2;

            fields.Insert(fields.Count - 1, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 8));
            return fields;
        }
    }
}