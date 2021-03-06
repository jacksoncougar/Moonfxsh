﻿using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish.Model
{
    [GuerillaType(MoonfishFieldType.FieldRealBounds)]
    [GuerillaType(MoonfishFieldType.FieldAngleBounds)]
    public struct Range
    {
        public readonly float Min;
        public readonly float Max;

        public Range(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public override string ToString()
        {
            return $"{Min}, {Max}";
        }

        public float Length => Max - Min;
    }
}