// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudCrosshairBlock : WeaponHudCrosshairBlockBase
    {
        public  WeaponHudCrosshairBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class WeaponHudCrosshairBlockBase
    {
        internal CrosshairType crosshairType;
        internal byte[] invalidName_;
        internal CanUseOnMapType canUseOnMapType;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference crosshairBitmap;
        internal WeaponHudCrosshairItemBlock[] crosshairOverlays;
        internal byte[] invalidName_2;
        internal  WeaponHudCrosshairBlockBase(System.IO.BinaryReader binaryReader)
        {
            crosshairType = (CrosshairType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            crosshairBitmap = binaryReader.ReadTagReference();
            ReadWeaponHudCrosshairItemBlockArray(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(40);
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
        internal  virtual WeaponHudCrosshairItemBlock[] ReadWeaponHudCrosshairItemBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudCrosshairItemBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudCrosshairItemBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudCrosshairItemBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudCrosshairItemBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)crosshairType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)canUseOnMapType);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(crosshairBitmap);
                WriteWeaponHudCrosshairItemBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_2, 0, 40);
            }
        }
        internal enum CrosshairType : short
        
        {
            Aim = 0,
            Zoom = 1,
            Charge = 2,
            ShouldReload = 3,
            FlashHeat = 4,
            FlashInventoryAmmo = 5,
            FlashBattery = 6,
            ReloadOverheat = 7,
            FlashWhenFiringAndNoAmmo = 8,
            FlashWhenThrowingAndNoGrenade = 9,
            LowAmmoAndNoneLeftToReload = 10,
            ShouldReloadSecondaryTrigger = 11,
            FlashSecondaryInventoryAmmo = 12,
            FlashSecondaryReload = 13,
            FlashWhenFiringSecondaryTriggerWithNoAmmo = 14,
            LowSecondaryAmmoAndNoneLeftToReload = 15,
            PrimaryTriggerReady = 16,
            SecondaryTriggerReady = 17,
            FlashWhenFiringWithDepletedBattery = 18,
        };
        internal enum CanUseOnMapType : short
        
        {
            Any = 0,
            Solo = 1,
            Multiplayer = 2,
        };
    };
}
