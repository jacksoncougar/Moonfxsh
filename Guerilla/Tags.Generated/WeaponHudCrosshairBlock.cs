// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponHudCrosshairBlock : WeaponHudCrosshairBlockBase
    {
        public  WeaponHudCrosshairBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponHudCrosshairBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class WeaponHudCrosshairBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 92; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponHudCrosshairBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            crosshairType = (CrosshairType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            crosshairBitmap = binaryReader.ReadTagReference();
            crosshairOverlays = Guerilla.ReadBlockArray<WeaponHudCrosshairItemBlock>(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(40);
        }
        public  WeaponHudCrosshairBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            crosshairType = (CrosshairType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            crosshairBitmap = binaryReader.ReadTagReference();
            crosshairOverlays = Guerilla.ReadBlockArray<WeaponHudCrosshairItemBlock>(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(40);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)crosshairType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)canUseOnMapType);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(crosshairBitmap);
                nextAddress = Guerilla.WriteBlockArray<WeaponHudCrosshairItemBlock>(binaryWriter, crosshairOverlays, nextAddress);
                binaryWriter.Write(invalidName_2, 0, 40);
                return nextAddress;
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
