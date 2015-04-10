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
    [LayoutAttribute(Size = 8)]
    public class PoweredSeatBlockBase
    {
        internal float driverPowerupTimeSeconds;
        internal float driverPowerdownTimeSeconds;
        internal  PoweredSeatBlockBase(BinaryReader binaryReader)
        {
            this.driverPowerupTimeSeconds = binaryReader.ReadSingle();
            this.driverPowerdownTimeSeconds = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
