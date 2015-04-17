﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Preprocess
{
    class GlobalGeometryBlockInfoStructBlock
    {
        [GuerillaPreProcessFieldsMethod(BlockName = "decorator_set_block")]
        protected static IList<MoonfishTagField> GuerillaPreProcessMethod(IList<MoonfishTagField> fields)
        {
            fields.RemoveAt(fields.Count - 2);
            return fields;
        }
    }
}