// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CheatPowerupsBlock : CheatPowerupsBlockBase
    {
        public  CheatPowerupsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class CheatPowerupsBlockBase  : IGuerilla
    {
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference powerup;
        internal  CheatPowerupsBlockBase(BinaryReader binaryReader)
        {
            powerup = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(powerup);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
