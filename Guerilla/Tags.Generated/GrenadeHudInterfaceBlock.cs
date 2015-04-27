// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Grhi = (TagClass)"grhi";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("grhi")]
    public partial class GrenadeHudInterfaceBlock : GrenadeHudInterfaceBlockBase
    {
        public  GrenadeHudInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GrenadeHudInterfaceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 464, Alignment = 4)]
    public class GrenadeHudInterfaceBlockBase : GuerillaBlock
    {
        internal Anchor anchor;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.Point anchorOffset;
        internal float widthScale;
        internal float heightScale;
        internal ScalingFlags scalingFlags;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceBitmap;
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
        internal byte[] invalidName_3;
        internal short sequenceIndex;
        internal byte[] invalidName_4;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay;
        internal byte[] invalidName_5;
        internal Moonfish.Tags.Point anchorOffset0;
        internal float widthScale0;
        internal float heightScale0;
        internal ScalingFlags scalingFlags0;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceBitmap0;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor0;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor0;
        internal float flashPeriod0;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay0;
        internal short numberOfFlashes0;
        internal FlashFlags flashFlags0;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength0;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor0;
        internal byte[] invalidName_8;
        internal short sequenceIndex0;
        internal byte[] invalidName_9;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay0;
        internal byte[] invalidName_10;
        internal Moonfish.Tags.Point anchorOffset1;
        internal float widthScale1;
        internal float heightScale1;
        internal ScalingFlags scalingFlags1;
        internal byte[] invalidName_11;
        internal byte[] invalidName_12;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor1;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor1;
        internal float flashPeriod1;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay1;
        internal short numberOfFlashes1;
        internal FlashFlags flashFlags1;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength1;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor1;
        internal byte[] invalidName_13;
        internal byte maximumNumberOfDigits;
        internal Flags flags;
        internal byte numberOfFractionalDigits;
        internal byte[] invalidName_14;
        internal byte[] invalidName_15;
        internal short flashCutoff;
        internal byte[] invalidName_16;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference overlayBitmap;
        internal GrenadeHudOverlayBlock[] overlays;
        internal GrenadeHudSoundBlock[] warningSounds;
        internal byte[] invalidName_17;
        /// <summary>
        /// sequenceIndex1 into the global hud icon bitmap
        /// </summary>
        internal short sequenceIndex1;
        /// <summary>
        /// extra spacing beyond bitmap width for text alignment
        /// </summary>
        internal short widthOffset;
        internal Moonfish.Tags.Point offsetFromReferenceCorner;
        internal Moonfish.Tags.ColourA1R1G1B1 overrideIconColor;
        internal byte frameRate030;
        internal Flags flags0;
        internal short textIndex;
        internal byte[] invalidName_18;
        
        public override int SerializedSize{get { return 464; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GrenadeHudInterfaceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            anchor = (Anchor)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(32);
            anchorOffset = binaryReader.ReadPoint();
            widthScale = binaryReader.ReadSingle();
            heightScale = binaryReader.ReadSingle();
            scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(20);
            interfaceBitmap = binaryReader.ReadTagReference();
            defaultColor = binaryReader.ReadColourA1R1G1B1();
            flashingColor = binaryReader.ReadColourA1R1G1B1();
            flashPeriod = binaryReader.ReadSingle();
            flashDelay = binaryReader.ReadSingle();
            numberOfFlashes = binaryReader.ReadInt16();
            flashFlags = (FlashFlags)binaryReader.ReadInt16();
            flashLength = binaryReader.ReadSingle();
            disabledColor = binaryReader.ReadColourA1R1G1B1();
            invalidName_3 = binaryReader.ReadBytes(4);
            sequenceIndex = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(2);
            multitexOverlay = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_5 = binaryReader.ReadBytes(4);
            anchorOffset0 = binaryReader.ReadPoint();
            widthScale0 = binaryReader.ReadSingle();
            heightScale0 = binaryReader.ReadSingle();
            scalingFlags0 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_6 = binaryReader.ReadBytes(2);
            invalidName_7 = binaryReader.ReadBytes(20);
            interfaceBitmap0 = binaryReader.ReadTagReference();
            defaultColor0 = binaryReader.ReadColourA1R1G1B1();
            flashingColor0 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod0 = binaryReader.ReadSingle();
            flashDelay0 = binaryReader.ReadSingle();
            numberOfFlashes0 = binaryReader.ReadInt16();
            flashFlags0 = (FlashFlags)binaryReader.ReadInt16();
            flashLength0 = binaryReader.ReadSingle();
            disabledColor0 = binaryReader.ReadColourA1R1G1B1();
            invalidName_8 = binaryReader.ReadBytes(4);
            sequenceIndex0 = binaryReader.ReadInt16();
            invalidName_9 = binaryReader.ReadBytes(2);
            multitexOverlay0 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_10 = binaryReader.ReadBytes(4);
            anchorOffset1 = binaryReader.ReadPoint();
            widthScale1 = binaryReader.ReadSingle();
            heightScale1 = binaryReader.ReadSingle();
            scalingFlags1 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_11 = binaryReader.ReadBytes(2);
            invalidName_12 = binaryReader.ReadBytes(20);
            defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod1 = binaryReader.ReadSingle();
            flashDelay1 = binaryReader.ReadSingle();
            numberOfFlashes1 = binaryReader.ReadInt16();
            flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            flashLength1 = binaryReader.ReadSingle();
            disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            invalidName_13 = binaryReader.ReadBytes(4);
            maximumNumberOfDigits = binaryReader.ReadByte();
            flags = (Flags)binaryReader.ReadByte();
            numberOfFractionalDigits = binaryReader.ReadByte();
            invalidName_14 = binaryReader.ReadBytes(1);
            invalidName_15 = binaryReader.ReadBytes(12);
            flashCutoff = binaryReader.ReadInt16();
            invalidName_16 = binaryReader.ReadBytes(2);
            overlayBitmap = binaryReader.ReadTagReference();
            overlays = Guerilla.ReadBlockArray<GrenadeHudOverlayBlock>(binaryReader);
            warningSounds = Guerilla.ReadBlockArray<GrenadeHudSoundBlock>(binaryReader);
            invalidName_17 = binaryReader.ReadBytes(68);
            sequenceIndex1 = binaryReader.ReadInt16();
            widthOffset = binaryReader.ReadInt16();
            offsetFromReferenceCorner = binaryReader.ReadPoint();
            overrideIconColor = binaryReader.ReadColourA1R1G1B1();
            frameRate030 = binaryReader.ReadByte();
            flags0 = (Flags)binaryReader.ReadByte();
            textIndex = binaryReader.ReadInt16();
            invalidName_18 = binaryReader.ReadBytes(48);
        }
        public  GrenadeHudInterfaceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)anchor);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write(anchorOffset);
                binaryWriter.Write(widthScale);
                binaryWriter.Write(heightScale);
                binaryWriter.Write((Int16)scalingFlags);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 20);
                binaryWriter.Write(interfaceBitmap);
                binaryWriter.Write(defaultColor);
                binaryWriter.Write(flashingColor);
                binaryWriter.Write(flashPeriod);
                binaryWriter.Write(flashDelay);
                binaryWriter.Write(numberOfFlashes);
                binaryWriter.Write((Int16)flashFlags);
                binaryWriter.Write(flashLength);
                binaryWriter.Write(disabledColor);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(invalidName_4, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryWriter, multitexOverlay, nextAddress);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(anchorOffset0);
                binaryWriter.Write(widthScale0);
                binaryWriter.Write(heightScale0);
                binaryWriter.Write((Int16)scalingFlags0);
                binaryWriter.Write(invalidName_6, 0, 2);
                binaryWriter.Write(invalidName_7, 0, 20);
                binaryWriter.Write(interfaceBitmap0);
                binaryWriter.Write(defaultColor0);
                binaryWriter.Write(flashingColor0);
                binaryWriter.Write(flashPeriod0);
                binaryWriter.Write(flashDelay0);
                binaryWriter.Write(numberOfFlashes0);
                binaryWriter.Write((Int16)flashFlags0);
                binaryWriter.Write(flashLength0);
                binaryWriter.Write(disabledColor0);
                binaryWriter.Write(invalidName_8, 0, 4);
                binaryWriter.Write(sequenceIndex0);
                binaryWriter.Write(invalidName_9, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryWriter, multitexOverlay0, nextAddress);
                binaryWriter.Write(invalidName_10, 0, 4);
                binaryWriter.Write(anchorOffset1);
                binaryWriter.Write(widthScale1);
                binaryWriter.Write(heightScale1);
                binaryWriter.Write((Int16)scalingFlags1);
                binaryWriter.Write(invalidName_11, 0, 2);
                binaryWriter.Write(invalidName_12, 0, 20);
                binaryWriter.Write(defaultColor1);
                binaryWriter.Write(flashingColor1);
                binaryWriter.Write(flashPeriod1);
                binaryWriter.Write(flashDelay1);
                binaryWriter.Write(numberOfFlashes1);
                binaryWriter.Write((Int16)flashFlags1);
                binaryWriter.Write(flashLength1);
                binaryWriter.Write(disabledColor1);
                binaryWriter.Write(invalidName_13, 0, 4);
                binaryWriter.Write(maximumNumberOfDigits);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(numberOfFractionalDigits);
                binaryWriter.Write(invalidName_14, 0, 1);
                binaryWriter.Write(invalidName_15, 0, 12);
                binaryWriter.Write(flashCutoff);
                binaryWriter.Write(invalidName_16, 0, 2);
                binaryWriter.Write(overlayBitmap);
                nextAddress = Guerilla.WriteBlockArray<GrenadeHudOverlayBlock>(binaryWriter, overlays, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GrenadeHudSoundBlock>(binaryWriter, warningSounds, nextAddress);
                binaryWriter.Write(invalidName_17, 0, 68);
                binaryWriter.Write(sequenceIndex1);
                binaryWriter.Write(widthOffset);
                binaryWriter.Write(offsetFromReferenceCorner);
                binaryWriter.Write(overrideIconColor);
                binaryWriter.Write(frameRate030);
                binaryWriter.Write((Byte)flags0);
                binaryWriter.Write(textIndex);
                binaryWriter.Write(invalidName_18, 0, 48);
                return nextAddress;
            }
        }
        internal enum Anchor : short
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3,
            Center = 4,
            Crosshair = 5,
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
        internal enum ScalingFlags0 : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum FlashFlags0 : short
        {
            ReverseDefaultFlashingColors = 1,
        };
        [FlagsAttribute]
        internal enum ScalingFlags1 : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum FlashFlags1 : short
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
        internal enum Flags0 : byte
        {
            UseTextFromStringListInstead = 1,
            OverrideDefaultColor = 2,
            WidthOffsetIsAbsoluteIconWidth = 4,
        };
    };
}
