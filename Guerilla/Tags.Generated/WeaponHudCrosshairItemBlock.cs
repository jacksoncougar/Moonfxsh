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
    public partial class WeaponHudCrosshairItemBlock : WeaponHudCrosshairItemBlockBase
    {
        public WeaponHudCrosshairItemBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class WeaponHudCrosshairItemBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 108; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public WeaponHudCrosshairItemBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            anchorOffset = binaryReader.ReadPoint();
            widthScale = binaryReader.ReadSingle();
            heightScale = binaryReader.ReadSingle();
            scalingFlags = (ScalingFlags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(20);
            defaultColor = binaryReader.ReadColourA1R1G1B1();
            flashingColor = binaryReader.ReadColourA1R1G1B1();
            flashPeriod = binaryReader.ReadSingle();
            flashDelay = binaryReader.ReadSingle();
            numberOfFlashes = binaryReader.ReadInt16();
            flashFlags = (FlashFlags) binaryReader.ReadInt16();
            flashLength = binaryReader.ReadSingle();
            disabledColor = binaryReader.ReadColourA1R1G1B1();
            invalidName_1 = binaryReader.ReadBytes(4);
            frameRate = binaryReader.ReadInt16();
            sequenceIndex = binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt32();
            invalidName_2 = binaryReader.ReadBytes(32);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(anchorOffset);
                binaryWriter.Write(widthScale);
                binaryWriter.Write(heightScale);
                binaryWriter.Write((Int16) scalingFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 20);
                binaryWriter.Write(defaultColor);
                binaryWriter.Write(flashingColor);
                binaryWriter.Write(flashPeriod);
                binaryWriter.Write(flashDelay);
                binaryWriter.Write(numberOfFlashes);
                binaryWriter.Write((Int16) flashFlags);
                binaryWriter.Write(flashLength);
                binaryWriter.Write(disabledColor);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(frameRate);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(invalidName_2, 0, 32);
                return nextAddress;
            }
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