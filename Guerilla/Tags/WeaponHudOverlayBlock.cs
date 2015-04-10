using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudOverlayBlock : WeaponHudOverlayBlockBase
    {
        public  WeaponHudOverlayBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 136)]
    public class WeaponHudOverlayBlockBase
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
        internal byte[] invalidName_2;
        internal short sequenceIndex;
        internal Type type;
        internal Flags flags;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal  WeaponHudOverlayBlockBase(BinaryReader binaryReader)
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
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.sequenceIndex = binaryReader.ReadInt16();
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_3 = binaryReader.ReadBytes(16);
            this.invalidName_4 = binaryReader.ReadBytes(40);
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
        internal enum Type : short
        
        {
            ShowOnFlashing = 1,
            ShowOnEmpty = 2,
            ShowOnReloadOverheating = 4,
            ShowOnDefault = 8,
            ShowAlways = 16,
        };
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            FlashesWhenActive = 1,
        };
    };
}
