using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Preprocess
{
    internal class SoundBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "sound_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            var soundField = new MoonfishTagField(MoonfishFieldType.FieldPad, "Sound Fields");
            soundField.AssignCount(20);
            fields = new[] {soundField, new MoonfishTagField(MoonfishFieldType.FieldTerminator, ""),};
            return fields;
        }
    }
}