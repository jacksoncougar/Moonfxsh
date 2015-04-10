using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudNumberBlock : WeaponHudNumberBlockBase
    {
        public  WeaponHudNumberBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 160)]
    public class WeaponHudNumberBlockBase
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
        internal  WeaponHudNumberBlockBase(BinaryReader binaryReader)
        {
            this.stateAttachedTo = (StateAttachedTo)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(28);
            this.anchorOffset = binaryReader.ReadPoint();
            this.widthScale = binaryReader.ReadSingle();
            this.heightScale = binaryReader.ReadSingle();
            this.scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.invalidName_3 = binaryReader.ReadBytes(20);
            this.defaultColor = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod = binaryReader.ReadSingle();
            this.flashDelay = binaryReader.ReadSingle();
            this.numberOfFlashes = binaryReader.ReadInt16();
            this.flashFlags = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength = binaryReader.ReadSingle();
            this.disabledColor = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.maximumNumberOfDigits = binaryReader.ReadByte();
            this.flags = (Flags)binaryReader.ReadByte();
            this.numberOfFractionalDigits = binaryReader.ReadByte();
            this.invalidName_5 = binaryReader.ReadBytes(1);
            this.invalidName_6 = binaryReader.ReadBytes(12);
            this.weaponSpecificFlags = (WeaponSpecificFlags)binaryReader.ReadInt16();
            this.invalidName_7 = binaryReader.ReadBytes(2);
            this.invalidName_8 = binaryReader.ReadBytes(36);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
