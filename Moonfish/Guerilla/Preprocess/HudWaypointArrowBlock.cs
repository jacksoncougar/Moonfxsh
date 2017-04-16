using System.Collections.Generic;

namespace Moonfish.Guerilla.Preprocess
{
    internal class HudWaypointArrowBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "hud_waypoint_arrow_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            if (fields[2].Type == MoonfishFieldType.FieldRgbColor)
                fields.Insert(3, new MoonfishTagField(MoonfishFieldType.FieldPad, "", 1));
            return fields;
        }
    }
}