using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitSeatAccelerationStructBlock : UnitSeatAccelerationStructBlockBase
    {
        public UnitSeatAccelerationStructBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 20 )]
    public class UnitSeatAccelerationStructBlockBase
    {
        internal Vector3 accelerationRangeWorldUnitsPerSecondSquared;
        internal float accelActionScaleActionsFail01;
        internal float accelAttachScaleDetachUnit01;
        internal UnitSeatAccelerationStructBlockBase( BinaryReader binaryReader )
        {
            this.accelerationRangeWorldUnitsPerSecondSquared = binaryReader.ReadVector3();
            this.accelActionScaleActionsFail01 = binaryReader.ReadSingle();
            this.accelAttachScaleDetachUnit01 = binaryReader.ReadSingle();
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.Count ];
            if ( blamPointer.Count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
    };
}
