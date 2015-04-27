// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PoweredSeatBlock : PoweredSeatBlockBase
    {
        public  PoweredSeatBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PoweredSeatBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class PoweredSeatBlockBase : GuerillaBlock
    {
        internal float driverPowerupTimeSeconds;
        internal float driverPowerdownTimeSeconds;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PoweredSeatBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            driverPowerupTimeSeconds = binaryReader.ReadSingle();
            driverPowerdownTimeSeconds = binaryReader.ReadSingle();
        }
        public  PoweredSeatBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            driverPowerupTimeSeconds = binaryReader.ReadSingle();
            driverPowerdownTimeSeconds = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
