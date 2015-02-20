using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("eqip")]
    public  partial class EquipmentBlock : EquipmentBlockBase
    {
        public  EquipmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class EquipmentBlockBase : ItemBlock
    {
        internal PowerupType powerupType;
        internal GrenadeType grenadeType;
        internal float powerupTimeSeconds;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference pickupSound;
        internal  EquipmentBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.powerupType = (PowerupType)binaryReader.ReadInt16();
            this.grenadeType = (GrenadeType)binaryReader.ReadInt16();
            this.powerupTimeSeconds = binaryReader.ReadSingle();
            this.pickupSound = binaryReader.ReadTagReference();
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
        internal enum PowerupType : short
        {
            None = 0,
            DoubleSpeed = 1,
            OverShield = 2,
            ActiveCamouflage = 3,
            FullSpectrumVision = 4,
            Health = 5,
            Grenade = 6,
        };
        internal enum GrenadeType : short
        {
            HumanFragmentation = 0,
            CovenantPlasma = 1,
        };
    };
}
