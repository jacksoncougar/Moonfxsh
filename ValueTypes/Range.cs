using Moonfish.Guerilla;
using Moonfish.Tags;

namespace Moonfish.Model
{
    [GuerillaType( MoonfishFieldType.FieldRealBounds )]
    [GuerillaType( MoonfishFieldType.FieldAngleBounds )]
    public struct Range
    {
        public readonly float Min;
        public readonly float Max;

        public Range( float min, float max )
        {
            this.Min = min;
            this.Max = max;
        }

        public override string ToString( )
        {
            return string.Format( "{{{0}:{1}}}", Min, Max );
        }

        public float Length { get { return Max - Min; } }
    }
}
