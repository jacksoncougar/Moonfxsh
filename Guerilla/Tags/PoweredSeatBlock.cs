// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PoweredSeatBlock : PoweredSeatBlockBase
    {
        public  PoweredSeatBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class PoweredSeatBlockBase  : IGuerilla
    {
        internal float driverPowerupTimeSeconds;
        internal float driverPowerdownTimeSeconds;
        internal  PoweredSeatBlockBase(BinaryReader binaryReader)
        {
            driverPowerupTimeSeconds = binaryReader.ReadSingle();
            driverPowerdownTimeSeconds = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(driverPowerupTimeSeconds);
                binaryWriter.Write(driverPowerdownTimeSeconds);
                return nextAddress;
            }
        }
    };
}
