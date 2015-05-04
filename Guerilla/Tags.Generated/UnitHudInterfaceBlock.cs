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
        public static readonly TagClass Unhi = (TagClass)"unhi";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("unhi")]
    public partial class UnitHudInterfaceBlock : UnitHudInterfaceBlockBase
    {
        public  UnitHudInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitHudInterfaceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 1289, Alignment = 4)]
    public class UnitHudInterfaceBlockBase : GuerillaBlock
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
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference meterBitmap;
        internal Moonfish.Tags.ColourR1G1B1 colorAtMeterMinimum;
        internal Moonfish.Tags.ColourR1G1B1 colorAtMeterMaximum;
        internal Moonfish.Tags.ColourR1G1B1 flashColor;
        internal Moonfish.Tags.ColourA1R1G1B1 emptyColor;
        internal Flags flags;
        internal byte minumumMeterValue;
        internal short sequenceIndex1;
        internal byte alphaMultiplier;
        internal byte alphaBias;
        /// <summary>
        /// used for non-integral values, i.e. health and shields
        /// </summary>
        internal short valueScale;
        internal float opacity;
        internal float translucency;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor1;
        internal GNullBlock[] gNullBlock;
        internal byte[] invalidName_13;
        internal Moonfish.Tags.ColourR1G1B1 overchargeMinimumColor;
        internal Moonfish.Tags.ColourR1G1B1 overchargeMaximumColor;
        internal Moonfish.Tags.ColourR1G1B1 overchargeFlashColor;
        internal Moonfish.Tags.ColourR1G1B1 overchargeEmptyColor;
        internal byte[] invalidName_14;
        internal Moonfish.Tags.Point anchorOffset2;
        internal float widthScale2;
        internal float heightScale2;
        internal ScalingFlags scalingFlags2;
        internal byte[] invalidName_15;
        internal byte[] invalidName_16;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceBitmap1;
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
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor2;
        internal byte[] invalidName_17;
        internal short sequenceIndex2;
        internal byte[] invalidName_18;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay1;
        internal byte[] invalidName_19;
        internal Moonfish.Tags.Point anchorOffset3;
        internal float widthScale3;
        internal float heightScale3;
        internal ScalingFlags scalingFlags3;
        internal byte[] invalidName_20;
        internal byte[] invalidName_21;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference meterBitmap0;
        internal Moonfish.Tags.ColourR1G1B1 colorAtMeterMinimum0;
        internal Moonfish.Tags.ColourR1G1B1 colorAtMeterMaximum0;
        internal Moonfish.Tags.ColourR1G1B1 flashColor0;
        internal Moonfish.Tags.ColourA1R1G1B1 emptyColor0;
        internal Flags flags0;
        internal byte minumumMeterValue0;
        internal short sequenceIndex3;
        internal byte alphaMultiplier0;
        internal byte alphaBias0;
        /// <summary>
        /// used for non-integral values, i.e. health and shields
        /// </summary>
        internal short valueScale0;
        internal float opacity0;
        internal float translucency0;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor3;
        internal GNullBlock[] gNullBlock0;
        internal byte[] invalidName_22;
        internal Moonfish.Tags.ColourR1G1B1 mediumHealthLeftColor;
        internal float maxColorHealthFractionCutoff;
        internal float minColorHealthFractionCutoff;
        internal byte[] invalidName_23;
        internal Moonfish.Tags.Point anchorOffset4;
        internal float widthScale4;
        internal float heightScale4;
        internal ScalingFlags scalingFlags4;
        internal byte[] invalidName_24;
        internal byte[] invalidName_25;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceBitmap2;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor2;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor2;
        internal float flashPeriod2;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay2;
        internal short numberOfFlashes2;
        internal FlashFlags flashFlags2;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength2;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor4;
        internal byte[] invalidName_26;
        internal short sequenceIndex4;
        internal byte[] invalidName_27;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay2;
        internal byte[] invalidName_28;
        internal Moonfish.Tags.Point anchorOffset5;
        internal float widthScale5;
        internal float heightScale5;
        internal ScalingFlags scalingFlags5;
        internal byte[] invalidName_29;
        internal byte[] invalidName_30;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference interfaceBitmap3;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor3;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor3;
        internal float flashPeriod3;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay3;
        internal short numberOfFlashes3;
        internal FlashFlags flashFlags3;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength3;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor5;
        internal byte[] invalidName_31;
        internal short sequenceIndex5;
        internal byte[] invalidName_32;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay3;
        internal byte[] invalidName_33;
        internal byte[] invalidName_34;
        internal Moonfish.Tags.Point anchorOffset6;
        internal float widthScale6;
        internal float heightScale6;
        internal ScalingFlags scalingFlags6;
        internal byte[] invalidName_35;
        internal byte[] invalidName_36;
        internal Anchor anchor0;
        internal byte[] invalidName_37;
        internal byte[] invalidName_38;
        internal UnitHudAuxilaryOverlayBlock[] overlays;
        internal byte[] invalidName_39;
        internal UnitHudSoundBlock[] sounds;
        internal UnitHudAuxilaryPanelBlock[] meters;
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference newHud;
        internal byte[] invalidName_40;
        internal byte[] invalidName_41;
        
        public override int SerializedSize{get { return 1289; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitHudInterfaceBlockBase(BinaryReader binaryReader): base(binaryReader)
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
            meterBitmap = binaryReader.ReadTagReference();
            colorAtMeterMinimum = binaryReader.ReadColourR1G1B1();
            colorAtMeterMaximum = binaryReader.ReadColourR1G1B1();
            flashColor = binaryReader.ReadColourR1G1B1();
            emptyColor = binaryReader.ReadColourA1R1G1B1();
            flags = (Flags)binaryReader.ReadByte();
            minumumMeterValue = binaryReader.ReadByte();
            sequenceIndex1 = binaryReader.ReadInt16();
            alphaMultiplier = binaryReader.ReadByte();
            alphaBias = binaryReader.ReadByte();
            valueScale = binaryReader.ReadInt16();
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            invalidName_13 = binaryReader.ReadBytes(4);
            overchargeMinimumColor = binaryReader.ReadColourR1G1B1();
            overchargeMaximumColor = binaryReader.ReadColourR1G1B1();
            overchargeFlashColor = binaryReader.ReadColourR1G1B1();
            overchargeEmptyColor = binaryReader.ReadColourR1G1B1();
            invalidName_14 = binaryReader.ReadBytes(16);
            anchorOffset2 = binaryReader.ReadPoint();
            widthScale2 = binaryReader.ReadSingle();
            heightScale2 = binaryReader.ReadSingle();
            scalingFlags2 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_15 = binaryReader.ReadBytes(2);
            invalidName_16 = binaryReader.ReadBytes(20);
            interfaceBitmap1 = binaryReader.ReadTagReference();
            defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod1 = binaryReader.ReadSingle();
            flashDelay1 = binaryReader.ReadSingle();
            numberOfFlashes1 = binaryReader.ReadInt16();
            flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            flashLength1 = binaryReader.ReadSingle();
            disabledColor2 = binaryReader.ReadColourA1R1G1B1();
            invalidName_17 = binaryReader.ReadBytes(4);
            sequenceIndex2 = binaryReader.ReadInt16();
            invalidName_18 = binaryReader.ReadBytes(2);
            multitexOverlay1 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_19 = binaryReader.ReadBytes(4);
            anchorOffset3 = binaryReader.ReadPoint();
            widthScale3 = binaryReader.ReadSingle();
            heightScale3 = binaryReader.ReadSingle();
            scalingFlags3 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_20 = binaryReader.ReadBytes(2);
            invalidName_21 = binaryReader.ReadBytes(20);
            meterBitmap0 = binaryReader.ReadTagReference();
            colorAtMeterMinimum0 = binaryReader.ReadColourR1G1B1();
            colorAtMeterMaximum0 = binaryReader.ReadColourR1G1B1();
            flashColor0 = binaryReader.ReadColourR1G1B1();
            emptyColor0 = binaryReader.ReadColourA1R1G1B1();
            flags0 = (Flags)binaryReader.ReadByte();
            minumumMeterValue0 = binaryReader.ReadByte();
            sequenceIndex3 = binaryReader.ReadInt16();
            alphaMultiplier0 = binaryReader.ReadByte();
            alphaBias0 = binaryReader.ReadByte();
            valueScale0 = binaryReader.ReadInt16();
            opacity0 = binaryReader.ReadSingle();
            translucency0 = binaryReader.ReadSingle();
            disabledColor3 = binaryReader.ReadColourA1R1G1B1();
            gNullBlock0 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            invalidName_22 = binaryReader.ReadBytes(4);
            mediumHealthLeftColor = binaryReader.ReadColourR1G1B1();
            maxColorHealthFractionCutoff = binaryReader.ReadSingle();
            minColorHealthFractionCutoff = binaryReader.ReadSingle();
            invalidName_23 = binaryReader.ReadBytes(20);
            anchorOffset4 = binaryReader.ReadPoint();
            widthScale4 = binaryReader.ReadSingle();
            heightScale4 = binaryReader.ReadSingle();
            scalingFlags4 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_24 = binaryReader.ReadBytes(2);
            invalidName_25 = binaryReader.ReadBytes(20);
            interfaceBitmap2 = binaryReader.ReadTagReference();
            defaultColor2 = binaryReader.ReadColourA1R1G1B1();
            flashingColor2 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod2 = binaryReader.ReadSingle();
            flashDelay2 = binaryReader.ReadSingle();
            numberOfFlashes2 = binaryReader.ReadInt16();
            flashFlags2 = (FlashFlags)binaryReader.ReadInt16();
            flashLength2 = binaryReader.ReadSingle();
            disabledColor4 = binaryReader.ReadColourA1R1G1B1();
            invalidName_26 = binaryReader.ReadBytes(4);
            sequenceIndex4 = binaryReader.ReadInt16();
            invalidName_27 = binaryReader.ReadBytes(2);
            multitexOverlay2 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_28 = binaryReader.ReadBytes(4);
            anchorOffset5 = binaryReader.ReadPoint();
            widthScale5 = binaryReader.ReadSingle();
            heightScale5 = binaryReader.ReadSingle();
            scalingFlags5 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_29 = binaryReader.ReadBytes(2);
            invalidName_30 = binaryReader.ReadBytes(20);
            interfaceBitmap3 = binaryReader.ReadTagReference();
            defaultColor3 = binaryReader.ReadColourA1R1G1B1();
            flashingColor3 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod3 = binaryReader.ReadSingle();
            flashDelay3 = binaryReader.ReadSingle();
            numberOfFlashes3 = binaryReader.ReadInt16();
            flashFlags3 = (FlashFlags)binaryReader.ReadInt16();
            flashLength3 = binaryReader.ReadSingle();
            disabledColor5 = binaryReader.ReadColourA1R1G1B1();
            invalidName_31 = binaryReader.ReadBytes(4);
            sequenceIndex5 = binaryReader.ReadInt16();
            invalidName_32 = binaryReader.ReadBytes(2);
            multitexOverlay3 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_33 = binaryReader.ReadBytes(4);
            invalidName_34 = binaryReader.ReadBytes(32);
            anchorOffset6 = binaryReader.ReadPoint();
            widthScale6 = binaryReader.ReadSingle();
            heightScale6 = binaryReader.ReadSingle();
            scalingFlags6 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_35 = binaryReader.ReadBytes(2);
            invalidName_36 = binaryReader.ReadBytes(20);
            anchor0 = (Anchor)binaryReader.ReadInt16();
            invalidName_37 = binaryReader.ReadBytes(2);
            invalidName_38 = binaryReader.ReadBytes(32);
            overlays = Guerilla.ReadBlockArray<UnitHudAuxilaryOverlayBlock>(binaryReader);
            invalidName_39 = binaryReader.ReadBytes(16);
            sounds = Guerilla.ReadBlockArray<UnitHudSoundBlock>(binaryReader);
            meters = Guerilla.ReadBlockArray<UnitHudAuxilaryPanelBlock>(binaryReader);
            newHud = binaryReader.ReadTagReference();
            invalidName_40 = binaryReader.ReadBytes(356);
            invalidName_41 = binaryReader.ReadBytes(48);
        }
        public  UnitHudInterfaceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
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
            meterBitmap = binaryReader.ReadTagReference();
            colorAtMeterMinimum = binaryReader.ReadColourR1G1B1();
            colorAtMeterMaximum = binaryReader.ReadColourR1G1B1();
            flashColor = binaryReader.ReadColourR1G1B1();
            emptyColor = binaryReader.ReadColourA1R1G1B1();
            flags = (Flags)binaryReader.ReadByte();
            minumumMeterValue = binaryReader.ReadByte();
            sequenceIndex1 = binaryReader.ReadInt16();
            alphaMultiplier = binaryReader.ReadByte();
            alphaBias = binaryReader.ReadByte();
            valueScale = binaryReader.ReadInt16();
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            invalidName_13 = binaryReader.ReadBytes(4);
            overchargeMinimumColor = binaryReader.ReadColourR1G1B1();
            overchargeMaximumColor = binaryReader.ReadColourR1G1B1();
            overchargeFlashColor = binaryReader.ReadColourR1G1B1();
            overchargeEmptyColor = binaryReader.ReadColourR1G1B1();
            invalidName_14 = binaryReader.ReadBytes(16);
            anchorOffset2 = binaryReader.ReadPoint();
            widthScale2 = binaryReader.ReadSingle();
            heightScale2 = binaryReader.ReadSingle();
            scalingFlags2 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_15 = binaryReader.ReadBytes(2);
            invalidName_16 = binaryReader.ReadBytes(20);
            interfaceBitmap1 = binaryReader.ReadTagReference();
            defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod1 = binaryReader.ReadSingle();
            flashDelay1 = binaryReader.ReadSingle();
            numberOfFlashes1 = binaryReader.ReadInt16();
            flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            flashLength1 = binaryReader.ReadSingle();
            disabledColor2 = binaryReader.ReadColourA1R1G1B1();
            invalidName_17 = binaryReader.ReadBytes(4);
            sequenceIndex2 = binaryReader.ReadInt16();
            invalidName_18 = binaryReader.ReadBytes(2);
            multitexOverlay1 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_19 = binaryReader.ReadBytes(4);
            anchorOffset3 = binaryReader.ReadPoint();
            widthScale3 = binaryReader.ReadSingle();
            heightScale3 = binaryReader.ReadSingle();
            scalingFlags3 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_20 = binaryReader.ReadBytes(2);
            invalidName_21 = binaryReader.ReadBytes(20);
            meterBitmap0 = binaryReader.ReadTagReference();
            colorAtMeterMinimum0 = binaryReader.ReadColourR1G1B1();
            colorAtMeterMaximum0 = binaryReader.ReadColourR1G1B1();
            flashColor0 = binaryReader.ReadColourR1G1B1();
            emptyColor0 = binaryReader.ReadColourA1R1G1B1();
            flags0 = (Flags)binaryReader.ReadByte();
            minumumMeterValue0 = binaryReader.ReadByte();
            sequenceIndex3 = binaryReader.ReadInt16();
            alphaMultiplier0 = binaryReader.ReadByte();
            alphaBias0 = binaryReader.ReadByte();
            valueScale0 = binaryReader.ReadInt16();
            opacity0 = binaryReader.ReadSingle();
            translucency0 = binaryReader.ReadSingle();
            disabledColor3 = binaryReader.ReadColourA1R1G1B1();
            gNullBlock0 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            invalidName_22 = binaryReader.ReadBytes(4);
            mediumHealthLeftColor = binaryReader.ReadColourR1G1B1();
            maxColorHealthFractionCutoff = binaryReader.ReadSingle();
            minColorHealthFractionCutoff = binaryReader.ReadSingle();
            invalidName_23 = binaryReader.ReadBytes(20);
            anchorOffset4 = binaryReader.ReadPoint();
            widthScale4 = binaryReader.ReadSingle();
            heightScale4 = binaryReader.ReadSingle();
            scalingFlags4 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_24 = binaryReader.ReadBytes(2);
            invalidName_25 = binaryReader.ReadBytes(20);
            interfaceBitmap2 = binaryReader.ReadTagReference();
            defaultColor2 = binaryReader.ReadColourA1R1G1B1();
            flashingColor2 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod2 = binaryReader.ReadSingle();
            flashDelay2 = binaryReader.ReadSingle();
            numberOfFlashes2 = binaryReader.ReadInt16();
            flashFlags2 = (FlashFlags)binaryReader.ReadInt16();
            flashLength2 = binaryReader.ReadSingle();
            disabledColor4 = binaryReader.ReadColourA1R1G1B1();
            invalidName_26 = binaryReader.ReadBytes(4);
            sequenceIndex4 = binaryReader.ReadInt16();
            invalidName_27 = binaryReader.ReadBytes(2);
            multitexOverlay2 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_28 = binaryReader.ReadBytes(4);
            anchorOffset5 = binaryReader.ReadPoint();
            widthScale5 = binaryReader.ReadSingle();
            heightScale5 = binaryReader.ReadSingle();
            scalingFlags5 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_29 = binaryReader.ReadBytes(2);
            invalidName_30 = binaryReader.ReadBytes(20);
            interfaceBitmap3 = binaryReader.ReadTagReference();
            defaultColor3 = binaryReader.ReadColourA1R1G1B1();
            flashingColor3 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod3 = binaryReader.ReadSingle();
            flashDelay3 = binaryReader.ReadSingle();
            numberOfFlashes3 = binaryReader.ReadInt16();
            flashFlags3 = (FlashFlags)binaryReader.ReadInt16();
            flashLength3 = binaryReader.ReadSingle();
            disabledColor5 = binaryReader.ReadColourA1R1G1B1();
            invalidName_31 = binaryReader.ReadBytes(4);
            sequenceIndex5 = binaryReader.ReadInt16();
            invalidName_32 = binaryReader.ReadBytes(2);
            multitexOverlay3 = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_33 = binaryReader.ReadBytes(4);
            invalidName_34 = binaryReader.ReadBytes(32);
            anchorOffset6 = binaryReader.ReadPoint();
            widthScale6 = binaryReader.ReadSingle();
            heightScale6 = binaryReader.ReadSingle();
            scalingFlags6 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_35 = binaryReader.ReadBytes(2);
            invalidName_36 = binaryReader.ReadBytes(20);
            anchor0 = (Anchor)binaryReader.ReadInt16();
            invalidName_37 = binaryReader.ReadBytes(2);
            invalidName_38 = binaryReader.ReadBytes(32);
            overlays = Guerilla.ReadBlockArray<UnitHudAuxilaryOverlayBlock>(binaryReader);
            invalidName_39 = binaryReader.ReadBytes(16);
            sounds = Guerilla.ReadBlockArray<UnitHudSoundBlock>(binaryReader);
            meters = Guerilla.ReadBlockArray<UnitHudAuxilaryPanelBlock>(binaryReader);
            newHud = binaryReader.ReadTagReference();
            invalidName_40 = binaryReader.ReadBytes(356);
            invalidName_41 = binaryReader.ReadBytes(48);
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
                binaryWriter.Write(meterBitmap);
                binaryWriter.Write(colorAtMeterMinimum);
                binaryWriter.Write(colorAtMeterMaximum);
                binaryWriter.Write(flashColor);
                binaryWriter.Write(emptyColor);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(minumumMeterValue);
                binaryWriter.Write(sequenceIndex1);
                binaryWriter.Write(alphaMultiplier);
                binaryWriter.Write(alphaBias);
                binaryWriter.Write(valueScale);
                binaryWriter.Write(opacity);
                binaryWriter.Write(translucency);
                binaryWriter.Write(disabledColor1);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                binaryWriter.Write(invalidName_13, 0, 4);
                binaryWriter.Write(overchargeMinimumColor);
                binaryWriter.Write(overchargeMaximumColor);
                binaryWriter.Write(overchargeFlashColor);
                binaryWriter.Write(overchargeEmptyColor);
                binaryWriter.Write(invalidName_14, 0, 16);
                binaryWriter.Write(anchorOffset2);
                binaryWriter.Write(widthScale2);
                binaryWriter.Write(heightScale2);
                binaryWriter.Write((Int16)scalingFlags2);
                binaryWriter.Write(invalidName_15, 0, 2);
                binaryWriter.Write(invalidName_16, 0, 20);
                binaryWriter.Write(interfaceBitmap1);
                binaryWriter.Write(defaultColor1);
                binaryWriter.Write(flashingColor1);
                binaryWriter.Write(flashPeriod1);
                binaryWriter.Write(flashDelay1);
                binaryWriter.Write(numberOfFlashes1);
                binaryWriter.Write((Int16)flashFlags1);
                binaryWriter.Write(flashLength1);
                binaryWriter.Write(disabledColor2);
                binaryWriter.Write(invalidName_17, 0, 4);
                binaryWriter.Write(sequenceIndex2);
                binaryWriter.Write(invalidName_18, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryWriter, multitexOverlay1, nextAddress);
                binaryWriter.Write(invalidName_19, 0, 4);
                binaryWriter.Write(anchorOffset3);
                binaryWriter.Write(widthScale3);
                binaryWriter.Write(heightScale3);
                binaryWriter.Write((Int16)scalingFlags3);
                binaryWriter.Write(invalidName_20, 0, 2);
                binaryWriter.Write(invalidName_21, 0, 20);
                binaryWriter.Write(meterBitmap0);
                binaryWriter.Write(colorAtMeterMinimum0);
                binaryWriter.Write(colorAtMeterMaximum0);
                binaryWriter.Write(flashColor0);
                binaryWriter.Write(emptyColor0);
                binaryWriter.Write((Byte)flags0);
                binaryWriter.Write(minumumMeterValue0);
                binaryWriter.Write(sequenceIndex3);
                binaryWriter.Write(alphaMultiplier0);
                binaryWriter.Write(alphaBias0);
                binaryWriter.Write(valueScale0);
                binaryWriter.Write(opacity0);
                binaryWriter.Write(translucency0);
                binaryWriter.Write(disabledColor3);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock0, nextAddress);
                binaryWriter.Write(invalidName_22, 0, 4);
                binaryWriter.Write(mediumHealthLeftColor);
                binaryWriter.Write(maxColorHealthFractionCutoff);
                binaryWriter.Write(minColorHealthFractionCutoff);
                binaryWriter.Write(invalidName_23, 0, 20);
                binaryWriter.Write(anchorOffset4);
                binaryWriter.Write(widthScale4);
                binaryWriter.Write(heightScale4);
                binaryWriter.Write((Int16)scalingFlags4);
                binaryWriter.Write(invalidName_24, 0, 2);
                binaryWriter.Write(invalidName_25, 0, 20);
                binaryWriter.Write(interfaceBitmap2);
                binaryWriter.Write(defaultColor2);
                binaryWriter.Write(flashingColor2);
                binaryWriter.Write(flashPeriod2);
                binaryWriter.Write(flashDelay2);
                binaryWriter.Write(numberOfFlashes2);
                binaryWriter.Write((Int16)flashFlags2);
                binaryWriter.Write(flashLength2);
                binaryWriter.Write(disabledColor4);
                binaryWriter.Write(invalidName_26, 0, 4);
                binaryWriter.Write(sequenceIndex4);
                binaryWriter.Write(invalidName_27, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryWriter, multitexOverlay2, nextAddress);
                binaryWriter.Write(invalidName_28, 0, 4);
                binaryWriter.Write(anchorOffset5);
                binaryWriter.Write(widthScale5);
                binaryWriter.Write(heightScale5);
                binaryWriter.Write((Int16)scalingFlags5);
                binaryWriter.Write(invalidName_29, 0, 2);
                binaryWriter.Write(invalidName_30, 0, 20);
                binaryWriter.Write(interfaceBitmap3);
                binaryWriter.Write(defaultColor3);
                binaryWriter.Write(flashingColor3);
                binaryWriter.Write(flashPeriod3);
                binaryWriter.Write(flashDelay3);
                binaryWriter.Write(numberOfFlashes3);
                binaryWriter.Write((Int16)flashFlags3);
                binaryWriter.Write(flashLength3);
                binaryWriter.Write(disabledColor5);
                binaryWriter.Write(invalidName_31, 0, 4);
                binaryWriter.Write(sequenceIndex5);
                binaryWriter.Write(invalidName_32, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryWriter, multitexOverlay3, nextAddress);
                binaryWriter.Write(invalidName_33, 0, 4);
                binaryWriter.Write(invalidName_34, 0, 32);
                binaryWriter.Write(anchorOffset6);
                binaryWriter.Write(widthScale6);
                binaryWriter.Write(heightScale6);
                binaryWriter.Write((Int16)scalingFlags6);
                binaryWriter.Write(invalidName_35, 0, 2);
                binaryWriter.Write(invalidName_36, 0, 20);
                binaryWriter.Write((Int16)anchor0);
                binaryWriter.Write(invalidName_37, 0, 2);
                binaryWriter.Write(invalidName_38, 0, 32);
                nextAddress = Guerilla.WriteBlockArray<UnitHudAuxilaryOverlayBlock>(binaryWriter, overlays, nextAddress);
                binaryWriter.Write(invalidName_39, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<UnitHudSoundBlock>(binaryWriter, sounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UnitHudAuxilaryPanelBlock>(binaryWriter, meters, nextAddress);
                binaryWriter.Write(newHud);
                binaryWriter.Write(invalidName_40, 0, 356);
                binaryWriter.Write(invalidName_41, 0, 48);
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
        internal enum Flags : byte
        {
            UseMinMaxForStateChanges = 1,
            InterpolateBetweenMinMaxFlashColorsAsStateChanges = 2,
            InterpolateColorAlongHsvSpace = 4,
            MoreColorsForHsvInterpolation = 8,
            InvertInterpolation = 16,
        };
        [FlagsAttribute]
        internal enum ScalingFlags2 : short
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
        internal enum ScalingFlags3 : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum Flags0 : byte
        {
            UseMinMaxForStateChanges = 1,
            InterpolateBetweenMinMaxFlashColorsAsStateChanges = 2,
            InterpolateColorAlongHsvSpace = 4,
            MoreColorsForHsvInterpolation = 8,
            InvertInterpolation = 16,
        };
        [FlagsAttribute]
        internal enum ScalingFlags4 : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum FlashFlags2 : short
        {
            ReverseDefaultFlashingColors = 1,
        };
        [FlagsAttribute]
        internal enum ScalingFlags5 : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum FlashFlags3 : short
        {
            ReverseDefaultFlashingColors = 1,
        };
        [FlagsAttribute]
        internal enum ScalingFlags6 : short
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        internal enum Anchor0 : short
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3,
            Center = 4,
            Crosshair = 5,
        };
    };
}
