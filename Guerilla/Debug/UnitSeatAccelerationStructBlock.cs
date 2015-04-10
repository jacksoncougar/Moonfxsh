// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitSeatAccelerationStructBlock : UnitSeatAccelerationStructBlockBase
    {
        public  UnitSeatAccelerationStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class UnitSeatAccelerationStructBlockBase
    {
        internal OpenTK.Vector3 accelerationRangeWorldUnitsPerSecondSquared;
        internal float accelActionScaleActionsFail01;
        internal float accelAttachScaleDetachUnit01;
        internal  UnitSeatAccelerationStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            accelerationRangeWorldUnitsPerSecondSquared = binaryReader.ReadVector3();
            accelActionScaleActionsFail01 = binaryReader.ReadSingle();
            accelAttachScaleDetachUnit01 = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(accelerationRangeWorldUnitsPerSecondSquared);
                binaryWriter.Write(accelActionScaleActionsFail01);
                binaryWriter.Write(accelAttachScaleDetachUnit01);
            }
        }
    };
}
