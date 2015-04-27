// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CheatPowerupsBlock : CheatPowerupsBlockBase
    {
        public  CheatPowerupsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CheatPowerupsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class CheatPowerupsBlockBase : GuerillaBlock
    {
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference powerup;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CheatPowerupsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            powerup = binaryReader.ReadTagReference();
        }
        public  CheatPowerupsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            powerup = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(powerup);
                return nextAddress;
            }
        }
    };
}
