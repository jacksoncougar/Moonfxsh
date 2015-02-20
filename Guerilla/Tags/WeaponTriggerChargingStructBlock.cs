using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponTriggerChargingStructBlock : WeaponTriggerChargingStructBlockBase
    {
        public  WeaponTriggerChargingStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class WeaponTriggerChargingStructBlockBase
    {
        /// <summary>
        /// the amount of time it takes for this trigger to become fully charged
        /// </summary>
        internal float chargingTimeSeconds;
        /// <summary>
        /// the amount of time this trigger can be charged before becoming overcharged
        /// </summary>
        internal float chargedTimeSeconds;
        internal OverchargedAction overchargedAction;
        internal byte[] invalidName_;
        /// <summary>
        /// the amount of illumination given off when the weapon is fully charged
        /// </summary>
        internal float chargedIllumination01;
        /// <summary>
        /// length of time the weapon will spew (fire continuously) while discharging
        /// </summary>
        internal float spewTimeSeconds;
        /// <summary>
        /// the chargingEffect is created once when the trigger begins to charge
        /// </summary>
        [TagReference("null")]
        internal Moonfish.Tags.TagReference chargingEffect;
        /// <summary>
        /// the charging effect is created once when the trigger begins to charge
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference chargingDamageEffect;
        internal  WeaponTriggerChargingStructBlockBase(BinaryReader binaryReader)
        {
            this.chargingTimeSeconds = binaryReader.ReadSingle();
            this.chargedTimeSeconds = binaryReader.ReadSingle();
            this.overchargedAction = (OverchargedAction)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.chargedIllumination01 = binaryReader.ReadSingle();
            this.spewTimeSeconds = binaryReader.ReadSingle();
            this.chargingEffect = binaryReader.ReadTagReference();
            this.chargingDamageEffect = binaryReader.ReadTagReference();
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
        internal enum OverchargedAction : short
        
        {
            None = 0,
            Explode = 1,
            Discharge = 2,
        };
    };
}
