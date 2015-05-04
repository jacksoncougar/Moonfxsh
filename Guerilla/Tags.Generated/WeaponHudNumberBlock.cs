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
    public partial class WeaponHudNumberBlock : WeaponHudNumberBlockBase
    {
        public WeaponHudNumberBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 160, Alignment = 4)]
    public class WeaponHudNumberBlockBase : GuerillaBlock
    {
        internal StateAttachedTo stateAttachedTo;
        internal byte[] invalidName_;
        internal CanUseOnMapType canUseOnMapType;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.Point anchorOffset;
        internal float widthScale;
        internal float heightScale;
        internal ScalingFlags scalingFlags;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor;
        internal float flashPeriod;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay;
        internal short numberOfFlashes;
        internal FlashFlags flashFlags;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor;
        internal byte[] invalidName_4;
        internal byte maximumNumberOfDigits;
        internal Flags flags;
        internal byte numberOfFractionalDigits;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal WeaponSpecificFlags weaponSpecificFlags;
        internal byte[] invalidName_7;
        internal byte[] invalidName_8;
        public override int SerializedSize { get { return 160; } }
        public override int Alignment { get { return 4; } }
        public WeaponHudNumberBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            stateAttachedTo = (StateAttachedTo)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            anchorOffset = binaryReader.ReadPoint();
            widthScale = binaryReader.ReadSingle();
            heightScale = binaryReader.ReadSingle();
            scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            invalidName_3 = binaryReader.ReadBytes(20);
            defaultColor = binaryReader.ReadColourA1R1G1B1();
            flashingColor = binaryReader.ReadColourA1R1G1B1();
            flashPeriod = binaryReader.ReadSingle();
            flashDelay = binaryReader.ReadSingle();
            numberOfFlashes = binaryReader.ReadInt16();
            flashFlags = (FlashFlags)binaryReader.ReadInt16();
            flashLength = binaryReader.ReadSingle();
            disabledColor = binaryReader.ReadColourA1R1G1B1();
            invalidName_4 = binaryReader.ReadBytes(4);
            maximumNumberOfDigits = binaryReader.ReadByte();
            flags = (Flags)binaryReader.ReadByte();
            numberOfFractionalDigits = binaryReader.ReadByte();
            invalidName_5 = binaryReader.ReadBytes(1);
            invalidName_6 = binaryReader.ReadBytes(12);
            weaponSpecificFlags = (WeaponSpecificFlags)binaryReader.ReadInt16();
            invalidName_7 = binaryReader.ReadBytes(2);
            invalidName_8 = binaryReader.ReadBytes(36);
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
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_3[4].ReadPointers(binaryReader, blamPointers);
            invalidName_3[5].ReadPointers(binaryReader, blamPointers);
            invalidName_3[6].ReadPointers(binaryReader, blamPointers);
            invalidName_3[7].ReadPointers(binaryReader, blamPointers);
            invalidName_3[8].ReadPointers(binaryReader, blamPointers);
            invalidName_3[9].ReadPointers(binaryReader, blamPointers);
            invalidName_3[10].ReadPointers(binaryReader, blamPointers);
            invalidName_3[11].ReadPointers(binaryReader, blamPointers);
            invalidName_3[12].ReadPointers(binaryReader, blamPointers);
            invalidName_3[13].ReadPointers(binaryReader, blamPointers);
            invalidName_3[14].ReadPointers(binaryReader, blamPointers);
            invalidName_3[15].ReadPointers(binaryReader, blamPointers);
            invalidName_3[16].ReadPointers(binaryReader, blamPointers);
            invalidName_3[17].ReadPointers(binaryReader, blamPointers);
            invalidName_3[18].ReadPointers(binaryReader, blamPointers);
            invalidName_3[19].ReadPointers(binaryReader, blamPointers);
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            invalidName_4[2].ReadPointers(binaryReader, blamPointers);
            invalidName_4[3].ReadPointers(binaryReader, blamPointers);
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_6[0].ReadPointers(binaryReader, blamPointers);
            invalidName_6[1].ReadPointers(binaryReader, blamPointers);
            invalidName_6[2].ReadPointers(binaryReader, blamPointers);
            invalidName_6[3].ReadPointers(binaryReader, blamPointers);
            invalidName_6[4].ReadPointers(binaryReader, blamPointers);
            invalidName_6[5].ReadPointers(binaryReader, blamPointers);
            invalidName_6[6].ReadPointers(binaryReader, blamPointers);
            invalidName_6[7].ReadPointers(binaryReader, blamPointers);
            invalidName_6[8].ReadPointers(binaryReader, blamPointers);
            invalidName_6[9].ReadPointers(binaryReader, blamPointers);
            invalidName_6[10].ReadPointers(binaryReader, blamPointers);
            invalidName_6[11].ReadPointers(binaryReader, blamPointers);
            invalidName_7[0].ReadPointers(binaryReader, blamPointers);
            invalidName_7[1].ReadPointers(binaryReader, blamPointers);
            invalidName_8[0].ReadPointers(binaryReader, blamPointers);
            invalidName_8[1].ReadPointers(binaryReader, blamPointers);
            invalidName_8[2].ReadPointers(binaryReader, blamPointers);
            invalidName_8[3].ReadPointers(binaryReader, blamPointers);
            invalidName_8[4].ReadPointers(binaryReader, blamPointers);
            invalidName_8[5].ReadPointers(binaryReader, blamPointers);
            invalidName_8[6].ReadPointers(binaryReader, blamPointers);
            invalidName_8[7].ReadPointers(binaryReader, blamPointers);
            invalidName_8[8].ReadPointers(binaryReader, blamPointers);
            invalidName_8[9].ReadPointers(binaryReader, blamPointers);
            invalidName_8[10].ReadPointers(binaryReader, blamPointers);
            invalidName_8[11].ReadPointers(binaryReader, blamPointers);
            invalidName_8[12].ReadPointers(binaryReader, blamPointers);
            invalidName_8[13].ReadPointers(binaryReader, blamPointers);
            invalidName_8[14].ReadPointers(binaryReader, blamPointers);
            invalidName_8[15].ReadPointers(binaryReader, blamPointers);
            invalidName_8[16].ReadPointers(binaryReader, blamPointers);
            invalidName_8[17].ReadPointers(binaryReader, blamPointers);
            invalidName_8[18].ReadPointers(binaryReader, blamPointers);
            invalidName_8[19].ReadPointers(binaryReader, blamPointers);
            invalidName_8[20].ReadPointers(binaryReader, blamPointers);
            invalidName_8[21].ReadPointers(binaryReader, blamPointers);
            invalidName_8[22].ReadPointers(binaryReader, blamPointers);
            invalidName_8[23].ReadPointers(binaryReader, blamPointers);
            invalidName_8[24].ReadPointers(binaryReader, blamPointers);
            invalidName_8[25].ReadPointers(binaryReader, blamPointers);
            invalidName_8[26].ReadPointers(binaryReader, blamPointers);
            invalidName_8[27].ReadPointers(binaryReader, blamPointers);
            invalidName_8[28].ReadPointers(binaryReader, blamPointers);
            invalidName_8[29].ReadPointers(binaryReader, blamPointers);
            invalidName_8[30].ReadPointers(binaryReader, blamPointers);
            invalidName_8[31].ReadPointers(binaryReader, blamPointers);
            invalidName_8[32].ReadPointers(binaryReader, blamPointers);
            invalidName_8[33].ReadPointers(binaryReader, blamPointers);
            invalidName_8[34].ReadPointers(binaryReader, blamPointers);
            invalidName_8[35].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)stateAttachedTo);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)canUseOnMapType);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(anchorOffset);
                binaryWriter.Write(widthScale);
                binaryWriter.Write(heightScale);
                binaryWriter.Write((Int16)scalingFlags);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(invalidName_3, 0, 20);
                binaryWriter.Write(defaultColor);
                binaryWriter.Write(flashingColor);
                binaryWriter.Write(flashPeriod);
                binaryWriter.Write(flashDelay);
                binaryWriter.Write(numberOfFlashes);
                binaryWriter.Write((Int16)flashFlags);
                binaryWriter.Write(flashLength);
                binaryWriter.Write(disabledColor);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(maximumNumberOfDigits);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(numberOfFractionalDigits);
                binaryWriter.Write(invalidName_5, 0, 1);
                binaryWriter.Write(invalidName_6, 0, 12);
                binaryWriter.Write((Int16)weaponSpecificFlags);
                binaryWriter.Write(invalidName_7, 0, 2);
                binaryWriter.Write(invalidName_8, 0, 36);
                return nextAddress;
            }
        }
        internal enum StateAttachedTo : short
        {
            InventoryAmmo = 0,
            LoadedAmmo = 1,
            Heat = 2,
            Age = 3,
            SecondaryWeaponInventoryAmmo = 4,
            SecondaryWeaponLoadedAmmo = 5,
            DistanceToTarget = 6,
            ElevationToTarget = 7,
        };
        internal enum CanUseOnMapType : short
        {
            Any = 0,
            Solo = 1,
            Multiplayer = 2,
        };
        [FlagsAttribute]
        internal enum ScalingFlags : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum FlashFlags : short
        {
            ReverseDefaultFlashingColors = 1,
        };
        [FlagsAttribute]
        internal enum Flags : byte
        {
            ShowLeadingZeros = 1,
            OnlyShowWhenZoomed = 2,
            DrawATrailingM = 4,
        };
        [FlagsAttribute]
        internal enum WeaponSpecificFlags : short
        {
            DivideNumberByClipSize = 1,
        };
    };
}
