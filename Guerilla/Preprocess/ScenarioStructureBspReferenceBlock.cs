using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    internal class ScenarioStructureBspReferenceBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "scenario_structure_bsp_reference_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var blockInfoStruct = new MoonfishTagField(MoonfishFieldType.FieldStruct, "StructureBlockInfo");
            blockInfoStruct.AssignDefinition(
                new MoonfishTagStruct(new MoonfishTagDefinition("MoonfishGlobalStructureBlockInfoStructBlock", new[]
                {
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Offset"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Length"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "Block Address"),
                    new MoonfishTagField(MoonfishFieldType.FieldLongInteger, "")
                })));
            fields.RemoveAt(0);
            fields.Insert(0, blockInfoStruct);

            return fields;
        }
    }
}
