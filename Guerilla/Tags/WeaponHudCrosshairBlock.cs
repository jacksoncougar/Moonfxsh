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
        public  WeaponHudCrosshairBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  WeaponHudCrosshairBlockBase(BinaryReader binaryReader)
        {
            this.crosshairType = (CrosshairType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(28);
            this.crosshairBitmap = binaryReader.ReadTagReference();
            this.crosshairOverlays = ReadWeaponHudCrosshairItemBlockArray(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(40);
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
        internal  virtual WeaponHudCrosshairItemBlock[] ReadWeaponHudCrosshairItemBlockArray(BinaryReader binaryReader)
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
