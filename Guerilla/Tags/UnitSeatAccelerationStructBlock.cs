// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitSeatAccelerationStructBlock : UnitSeatAccelerationStructBlockBase
    {
        public UnitSeatAccelerationStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class UnitSeatAccelerationStructBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 accelerationRangeWorldUnitsPerSecondSquared;
        internal float accelActionScaleActionsFail01;
        internal float accelAttachScaleDetachUnit01;

        internal UnitSeatAccelerationStructBlockBase( BinaryReader binaryReader )
        {
            accelerationRangeWorldUnitsPerSecondSquared = binaryReader.ReadVector3( );
            accelActionScaleActionsFail01 = binaryReader.ReadSingle( );
            accelAttachScaleDetachUnit01 = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( accelerationRangeWorldUnitsPerSecondSquared );
                binaryWriter.Write( accelActionScaleActionsFail01 );
                binaryWriter.Write( accelAttachScaleDetachUnit01 );
                return nextAddress;
            }
        }
    };
}