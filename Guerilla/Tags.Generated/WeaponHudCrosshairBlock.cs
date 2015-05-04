// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponHudCrosshairBlock : WeaponHudCrosshairBlockBase
    {
        public WeaponHudCrosshairBlock() : base()
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
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public WeaponHudCrosshairBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            crosshairType = (CrosshairType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            crosshairBitmap = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponHudCrosshairItemBlock>(binaryReader));
            invalidName_2 = binaryReader.ReadBytes(40);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            crosshairOverlays = ReadBlockArrayData<WeaponHudCrosshairItemBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_2[20].ReadPointers(binaryReader, blamPointers);
            invalidName_2[21].ReadPointers(binaryReader, blamPointers);
            invalidName_2[22].ReadPointers(binaryReader, blamPointers);
            invalidName_2[23].ReadPointers(binaryReader, blamPointers);
            invalidName_2[24].ReadPointers(binaryReader, blamPointers);
            invalidName_2[25].ReadPointers(binaryReader, blamPointers);
            invalidName_2[26].ReadPointers(binaryReader, blamPointers);
            invalidName_2[27].ReadPointers(binaryReader, blamPointers);
            invalidName_2[28].ReadPointers(binaryReader, blamPointers);
            invalidName_2[29].ReadPointers(binaryReader, blamPointers);
            invalidName_2[30].ReadPointers(binaryReader, blamPointers);
            invalidName_2[31].ReadPointers(binaryReader, blamPointers);
            invalidName_2[32].ReadPointers(binaryReader, blamPointers);
            invalidName_2[33].ReadPointers(binaryReader, blamPointers);
            invalidName_2[34].ReadPointers(binaryReader, blamPointers);
            invalidName_2[35].ReadPointers(binaryReader, blamPointers);
            invalidName_2[36].ReadPointers(binaryReader, blamPointers);
            invalidName_2[37].ReadPointers(binaryReader, blamPointers);
            invalidName_2[38].ReadPointers(binaryReader, blamPointers);
            invalidName_2[39].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
