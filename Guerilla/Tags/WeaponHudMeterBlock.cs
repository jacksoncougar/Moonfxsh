// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudMeterBlock : WeaponHudMeterBlockBase
    {
        public  WeaponHudMeterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 165, Alignment = 4)]
    public class WeaponHudMeterBlockBase  : IGuerilla
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
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference meterBitmap;
        internal Moonfish.Tags.RGBColor colorAtMeterMinimum;
        internal Moonfish.Tags.RGBColor colorAtMeterMaximum;
        internal Moonfish.Tags.RGBColor flashColor;
        internal Moonfish.Tags.ColourA1R1G1B1 emptyColor;
        internal Flags flags;
        internal byte minumumMeterValue;
        internal short sequenceIndex;
        internal byte alphaMultiplier;
        internal byte alphaBias;
        /// <summary>
        /// used for non-integral values, i.e. health and shields
        /// </summary>
        internal short valueScale;
        internal float opacity;
        internal float translucency;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor;
        internal GNullBlock[] gNullBlock;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal  WeaponHudMeterBlockBase(BinaryReader binaryReader)
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
            meterBitmap = binaryReader.ReadTagReference();
            colorAtMeterMinimum = binaryReader.ReadRGBColor();
            colorAtMeterMaximum = binaryReader.ReadRGBColor();
            flashColor = binaryReader.ReadRGBColor();
            emptyColor = binaryReader.ReadColourA1R1G1B1();
            flags = (Flags)binaryReader.ReadByte();
            minumumMeterValue = binaryReader.ReadByte();
            sequenceIndex = binaryReader.ReadInt16();
            alphaMultiplier = binaryReader.ReadByte();
            alphaBias = binaryReader.ReadByte();
            valueScale = binaryReader.ReadInt16();
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            disabledColor = binaryReader.ReadColourA1R1G1B1();
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            invalidName_4 = binaryReader.ReadBytes(4);
            invalidName_5 = binaryReader.ReadBytes(40);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                binaryWriter.Write(meterBitmap);
                binaryWriter.Write(colorAtMeterMinimum);
                binaryWriter.Write(colorAtMeterMaximum);
                binaryWriter.Write(flashColor);
                binaryWriter.Write(emptyColor);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(minumumMeterValue);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(alphaMultiplier);
                binaryWriter.Write(alphaBias);
                binaryWriter.Write(valueScale);
                binaryWriter.Write(opacity);
                binaryWriter.Write(translucency);
                binaryWriter.Write(disabledColor);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(invalidName_5, 0, 40);
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
        internal enum Flags : byte
        {
            UseMinMaxForStateChanges = 1,
            InterpolateBetweenMinMaxFlashColorsAsStateChanges = 2,
            InterpolateColorAlongHsvSpace = 4,
            MoreColorsForHsvInterpolation = 8,
            InvertInterpolation = 16,
        };
    };
}
