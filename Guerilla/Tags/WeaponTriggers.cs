using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponTriggers : WeaponTriggersBase
    {
        public  WeaponTriggers(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class WeaponTriggersBase
    {
        internal Flags flags;
        internal Input input;
        internal Behavior behavior;
        internal Moonfish.Tags.ShortBlockIndex1 primaryBarrel;
        internal Moonfish.Tags.ShortBlockIndex1 secondaryBarrel;
        internal Prediction prediction;
        internal byte[] invalidName_;
        internal WeaponTriggerAutofireStructBlock autofire;
        internal WeaponTriggerChargingStructBlock charging;
        internal  WeaponTriggersBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.input = (Input)binaryReader.ReadInt16();
            this.behavior = (Behavior)binaryReader.ReadInt16();
            this.primaryBarrel = binaryReader.ReadShortBlockIndex1();
            this.secondaryBarrel = binaryReader.ReadShortBlockIndex1();
            this.prediction = (Prediction)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.autofire = new WeaponTriggerAutofireStructBlock(binaryReader);
            this.charging = new WeaponTriggerChargingStructBlock(binaryReader);
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            AutofireSingleActionOnly = 1,
        };
        internal enum Input : short
        
        {
            RightTrigger = 0,
            LeftTrigger = 1,
            MeleeAttack = 2,
        };
        internal enum Behavior : short
        
        {
            Spew = 0,
            Latch = 1,
            LatchAutofire = 2,
            Charge = 3,
            LatchZoom = 4,
            LatchRocketlauncher = 5,
        };
        internal enum Prediction : short
        
        {
            None = 0,
            Spew = 1,
            Charge = 2,
        };
    };
}
