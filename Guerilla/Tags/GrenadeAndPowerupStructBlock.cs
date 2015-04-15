// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GrenadeAndPowerupStructBlock : GrenadeAndPowerupStructBlockBase
    {
        public  GrenadeAndPowerupStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class GrenadeAndPowerupStructBlockBase  : IGuerilla
    {
        internal GrenadeBlock[] grenades;
        internal PowerupBlock[] powerups;
        internal  GrenadeAndPowerupStructBlockBase(BinaryReader binaryReader)
        {
            grenades = Guerilla.ReadBlockArray<GrenadeBlock>(binaryReader);
            powerups = Guerilla.ReadBlockArray<PowerupBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GrenadeBlock>(binaryWriter, grenades, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PowerupBlock>(binaryWriter, powerups, nextAddress);
                return nextAddress;
            }
        }
    };
}
