using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudCrosshairItemBlock : WeaponHudCrosshairItemBlockBase
    {
        public  WeaponHudCrosshairItemBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 108)]
    public class WeaponHudCrosshairItemBlockBase
    {
        internal Moonfish.Tags.Point anchorOffset;
        internal float widthScale;
        internal float heightScale;
        internal ScalingFlags scalingFlags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
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
        internal byte[] invalidName_1;
        internal short frameRate;
        internal short sequenceIndex;
        internal Flags flags;
        internal byte[] invalidName_2;
        internal  WeaponHudCrosshairItemBlockBase(BinaryReader binaryReader)
        {
            this.anchorOffset = binaryReader.ReadPoint();
            this.widthScale = binaryReader.ReadSingle();
            this.heightScale = binaryReader.ReadSingle();
            this.scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(20);
            this.defaultColor = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod = binaryReader.ReadSingle();
            this.flashDelay = binaryReader.ReadSingle();
            this.numberOfFlashes = binaryReader.ReadInt16();
            this.flashFlags = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength = binaryReader.ReadSingle();
            this.disabledColor = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.frameRate = binaryReader.ReadInt16();
            this.sequenceIndex = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_2 = binaryReader.ReadBytes(32);
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
        internal enum Flags : int
        
        {
            FlashesWhenActive = 1,
            NotASprite = 2,
            ShowOnlyWhenZoomed = 4,
            ShowSniperData = 8,
            HideAreaOutsideReticle = 16,
            OneZoomLevel = 32,
            DontShowWhenZoomed = 64,
        };
    };
}
