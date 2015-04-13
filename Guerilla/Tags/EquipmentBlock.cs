// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass EqipClass = (TagClass)"eqip";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("eqip")]
    public  partial class EquipmentBlock : EquipmentBlockBase
    {
        public  EquipmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class EquipmentBlockBase : ItemBlock
    {
        internal PowerupType powerupType;
        internal GrenadeType grenadeType;
        internal float powerupTimeSeconds;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference pickupSound;
        internal  EquipmentBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            powerupType = (PowerupType)binaryReader.ReadInt16();
            grenadeType = (GrenadeType)binaryReader.ReadInt16();
            powerupTimeSeconds = binaryReader.ReadSingle();
            pickupSound = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)powerupType);
                binaryWriter.Write((Int16)grenadeType);
                binaryWriter.Write(powerupTimeSeconds);
                binaryWriter.Write(pickupSound);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
