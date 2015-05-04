// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitSeatAccelerationStructBlock : UnitSeatAccelerationStructBlockBase
    {
        public UnitSeatAccelerationStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class UnitSeatAccelerationStructBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 accelerationRangeWorldUnitsPerSecondSquared;
        internal float accelActionScaleActionsFail01;
        internal float accelAttachScaleDetachUnit01;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public UnitSeatAccelerationStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            accelerationRangeWorldUnitsPerSecondSquared = binaryReader.ReadVector3();
            accelActionScaleActionsFail01 = binaryReader.ReadSingle();
            accelAttachScaleDetachUnit01 = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(accelerationRangeWorldUnitsPerSecondSquared);
                binaryWriter.Write(accelActionScaleActionsFail01);
                binaryWriter.Write(accelAttachScaleDetachUnit01);
                return nextAddress;
            }
        }
    };
}
