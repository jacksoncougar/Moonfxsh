// ReSharper disable All
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
        public  WeaponTriggers(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  WeaponTriggersBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            input = (Input)binaryReader.ReadInt16();
            behavior = (Behavior)binaryReader.ReadInt16();
            primaryBarrel = binaryReader.ReadShortBlockIndex1();
            secondaryBarrel = binaryReader.ReadShortBlockIndex1();
            prediction = (Prediction)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            autofire = new WeaponTriggerAutofireStructBlock(binaryReader);
            charging = new WeaponTriggerChargingStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)input);
                binaryWriter.Write((Int16)behavior);
                binaryWriter.Write(primaryBarrel);
                binaryWriter.Write(secondaryBarrel);
                binaryWriter.Write((Int16)prediction);
                binaryWriter.Write(invalidName_, 0, 2);
                autofire.Write(binaryWriter);
                charging.Write(binaryWriter);
            }
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
