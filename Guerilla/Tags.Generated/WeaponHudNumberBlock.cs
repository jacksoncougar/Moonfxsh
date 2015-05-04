// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponHudNumberBlock : WeaponHudNumberBlockBase
    {
        public  WeaponHudNumberBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponHudNumberBlock(): base()
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
        
        public override int SerializedSize{get { return 160; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponHudNumberBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
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
        }
        public  WeaponHudNumberBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
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
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
