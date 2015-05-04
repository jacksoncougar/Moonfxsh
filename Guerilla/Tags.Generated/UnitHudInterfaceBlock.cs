// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public UnitHudInterfaceBlock() : base()
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
        public override int SerializedSize { get { return 1289; } }
        public override int Alignment { get { return 4; } }
        public UnitHudInterfaceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudMultitextureOverlayDefinition>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudMultitextureOverlayDefinition>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudMultitextureOverlayDefinition>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudMultitextureOverlayDefinition>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudMultitextureOverlayDefinition>(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<UnitHudAuxilaryOverlayBlock>(binaryReader));
            invalidName_39 = binaryReader.ReadBytes(16);
            blamPointers.Enqueue(ReadBlockArrayPointer<UnitHudSoundBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UnitHudAuxilaryPanelBlock>(binaryReader));
            newHud = binaryReader.ReadTagReference();
            invalidName_40 = binaryReader.ReadBytes(356);
            invalidName_41 = binaryReader.ReadBytes(48);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[24].ReadPointers(binaryReader, blamPointers);
            invalidName_0[25].ReadPointers(binaryReader, blamPointers);
            invalidName_0[26].ReadPointers(binaryReader, blamPointers);
            invalidName_0[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[28].ReadPointers(binaryReader, blamPointers);
            invalidName_0[29].ReadPointers(binaryReader, blamPointers);
            invalidName_0[30].ReadPointers(binaryReader, blamPointers);
            invalidName_0[31].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
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
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            multitexOverlay = ReadBlockArrayData<GlobalHudMultitextureOverlayDefinition>(binaryReader, blamPointers.Dequeue());
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
            invalidName_5[2].ReadPointers(binaryReader, blamPointers);
            invalidName_5[3].ReadPointers(binaryReader, blamPointers);
            invalidName_6[0].ReadPointers(binaryReader, blamPointers);
            invalidName_6[1].ReadPointers(binaryReader, blamPointers);
            invalidName_7[0].ReadPointers(binaryReader, blamPointers);
            invalidName_7[1].ReadPointers(binaryReader, blamPointers);
            invalidName_7[2].ReadPointers(binaryReader, blamPointers);
            invalidName_7[3].ReadPointers(binaryReader, blamPointers);
            invalidName_7[4].ReadPointers(binaryReader, blamPointers);
            invalidName_7[5].ReadPointers(binaryReader, blamPointers);
            invalidName_7[6].ReadPointers(binaryReader, blamPointers);
            invalidName_7[7].ReadPointers(binaryReader, blamPointers);
            invalidName_7[8].ReadPointers(binaryReader, blamPointers);
            invalidName_7[9].ReadPointers(binaryReader, blamPointers);
            invalidName_7[10].ReadPointers(binaryReader, blamPointers);
            invalidName_7[11].ReadPointers(binaryReader, blamPointers);
            invalidName_7[12].ReadPointers(binaryReader, blamPointers);
            invalidName_7[13].ReadPointers(binaryReader, blamPointers);
            invalidName_7[14].ReadPointers(binaryReader, blamPointers);
            invalidName_7[15].ReadPointers(binaryReader, blamPointers);
            invalidName_7[16].ReadPointers(binaryReader, blamPointers);
            invalidName_7[17].ReadPointers(binaryReader, blamPointers);
            invalidName_7[18].ReadPointers(binaryReader, blamPointers);
            invalidName_7[19].ReadPointers(binaryReader, blamPointers);
            invalidName_8[0].ReadPointers(binaryReader, blamPointers);
            invalidName_8[1].ReadPointers(binaryReader, blamPointers);
            invalidName_8[2].ReadPointers(binaryReader, blamPointers);
            invalidName_8[3].ReadPointers(binaryReader, blamPointers);
            invalidName_9[0].ReadPointers(binaryReader, blamPointers);
            invalidName_9[1].ReadPointers(binaryReader, blamPointers);
            multitexOverlay0 = ReadBlockArrayData<GlobalHudMultitextureOverlayDefinition>(binaryReader, blamPointers.Dequeue());
            invalidName_10[0].ReadPointers(binaryReader, blamPointers);
            invalidName_10[1].ReadPointers(binaryReader, blamPointers);
            invalidName_10[2].ReadPointers(binaryReader, blamPointers);
            invalidName_10[3].ReadPointers(binaryReader, blamPointers);
            invalidName_11[0].ReadPointers(binaryReader, blamPointers);
            invalidName_11[1].ReadPointers(binaryReader, blamPointers);
            invalidName_12[0].ReadPointers(binaryReader, blamPointers);
            invalidName_12[1].ReadPointers(binaryReader, blamPointers);
            invalidName_12[2].ReadPointers(binaryReader, blamPointers);
            invalidName_12[3].ReadPointers(binaryReader, blamPointers);
            invalidName_12[4].ReadPointers(binaryReader, blamPointers);
            invalidName_12[5].ReadPointers(binaryReader, blamPointers);
            invalidName_12[6].ReadPointers(binaryReader, blamPointers);
            invalidName_12[7].ReadPointers(binaryReader, blamPointers);
            invalidName_12[8].ReadPointers(binaryReader, blamPointers);
            invalidName_12[9].ReadPointers(binaryReader, blamPointers);
            invalidName_12[10].ReadPointers(binaryReader, blamPointers);
            invalidName_12[11].ReadPointers(binaryReader, blamPointers);
            invalidName_12[12].ReadPointers(binaryReader, blamPointers);
            invalidName_12[13].ReadPointers(binaryReader, blamPointers);
            invalidName_12[14].ReadPointers(binaryReader, blamPointers);
            invalidName_12[15].ReadPointers(binaryReader, blamPointers);
            invalidName_12[16].ReadPointers(binaryReader, blamPointers);
            invalidName_12[17].ReadPointers(binaryReader, blamPointers);
            invalidName_12[18].ReadPointers(binaryReader, blamPointers);
            invalidName_12[19].ReadPointers(binaryReader, blamPointers);
            gNullBlock = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_13[0].ReadPointers(binaryReader, blamPointers);
            invalidName_13[1].ReadPointers(binaryReader, blamPointers);
            invalidName_13[2].ReadPointers(binaryReader, blamPointers);
            invalidName_13[3].ReadPointers(binaryReader, blamPointers);
            invalidName_14[0].ReadPointers(binaryReader, blamPointers);
            invalidName_14[1].ReadPointers(binaryReader, blamPointers);
            invalidName_14[2].ReadPointers(binaryReader, blamPointers);
            invalidName_14[3].ReadPointers(binaryReader, blamPointers);
            invalidName_14[4].ReadPointers(binaryReader, blamPointers);
            invalidName_14[5].ReadPointers(binaryReader, blamPointers);
            invalidName_14[6].ReadPointers(binaryReader, blamPointers);
            invalidName_14[7].ReadPointers(binaryReader, blamPointers);
            invalidName_14[8].ReadPointers(binaryReader, blamPointers);
            invalidName_14[9].ReadPointers(binaryReader, blamPointers);
            invalidName_14[10].ReadPointers(binaryReader, blamPointers);
            invalidName_14[11].ReadPointers(binaryReader, blamPointers);
            invalidName_14[12].ReadPointers(binaryReader, blamPointers);
            invalidName_14[13].ReadPointers(binaryReader, blamPointers);
            invalidName_14[14].ReadPointers(binaryReader, blamPointers);
            invalidName_14[15].ReadPointers(binaryReader, blamPointers);
            invalidName_15[0].ReadPointers(binaryReader, blamPointers);
            invalidName_15[1].ReadPointers(binaryReader, blamPointers);
            invalidName_16[0].ReadPointers(binaryReader, blamPointers);
            invalidName_16[1].ReadPointers(binaryReader, blamPointers);
            invalidName_16[2].ReadPointers(binaryReader, blamPointers);
            invalidName_16[3].ReadPointers(binaryReader, blamPointers);
            invalidName_16[4].ReadPointers(binaryReader, blamPointers);
            invalidName_16[5].ReadPointers(binaryReader, blamPointers);
            invalidName_16[6].ReadPointers(binaryReader, blamPointers);
            invalidName_16[7].ReadPointers(binaryReader, blamPointers);
            invalidName_16[8].ReadPointers(binaryReader, blamPointers);
            invalidName_16[9].ReadPointers(binaryReader, blamPointers);
            invalidName_16[10].ReadPointers(binaryReader, blamPointers);
            invalidName_16[11].ReadPointers(binaryReader, blamPointers);
            invalidName_16[12].ReadPointers(binaryReader, blamPointers);
            invalidName_16[13].ReadPointers(binaryReader, blamPointers);
            invalidName_16[14].ReadPointers(binaryReader, blamPointers);
            invalidName_16[15].ReadPointers(binaryReader, blamPointers);
            invalidName_16[16].ReadPointers(binaryReader, blamPointers);
            invalidName_16[17].ReadPointers(binaryReader, blamPointers);
            invalidName_16[18].ReadPointers(binaryReader, blamPointers);
            invalidName_16[19].ReadPointers(binaryReader, blamPointers);
            invalidName_17[0].ReadPointers(binaryReader, blamPointers);
            invalidName_17[1].ReadPointers(binaryReader, blamPointers);
            invalidName_17[2].ReadPointers(binaryReader, blamPointers);
            invalidName_17[3].ReadPointers(binaryReader, blamPointers);
            invalidName_18[0].ReadPointers(binaryReader, blamPointers);
            invalidName_18[1].ReadPointers(binaryReader, blamPointers);
            multitexOverlay1 = ReadBlockArrayData<GlobalHudMultitextureOverlayDefinition>(binaryReader, blamPointers.Dequeue());
            invalidName_19[0].ReadPointers(binaryReader, blamPointers);
            invalidName_19[1].ReadPointers(binaryReader, blamPointers);
            invalidName_19[2].ReadPointers(binaryReader, blamPointers);
            invalidName_19[3].ReadPointers(binaryReader, blamPointers);
            invalidName_20[0].ReadPointers(binaryReader, blamPointers);
            invalidName_20[1].ReadPointers(binaryReader, blamPointers);
            invalidName_21[0].ReadPointers(binaryReader, blamPointers);
            invalidName_21[1].ReadPointers(binaryReader, blamPointers);
            invalidName_21[2].ReadPointers(binaryReader, blamPointers);
            invalidName_21[3].ReadPointers(binaryReader, blamPointers);
            invalidName_21[4].ReadPointers(binaryReader, blamPointers);
            invalidName_21[5].ReadPointers(binaryReader, blamPointers);
            invalidName_21[6].ReadPointers(binaryReader, blamPointers);
            invalidName_21[7].ReadPointers(binaryReader, blamPointers);
            invalidName_21[8].ReadPointers(binaryReader, blamPointers);
            invalidName_21[9].ReadPointers(binaryReader, blamPointers);
            invalidName_21[10].ReadPointers(binaryReader, blamPointers);
            invalidName_21[11].ReadPointers(binaryReader, blamPointers);
            invalidName_21[12].ReadPointers(binaryReader, blamPointers);
            invalidName_21[13].ReadPointers(binaryReader, blamPointers);
            invalidName_21[14].ReadPointers(binaryReader, blamPointers);
            invalidName_21[15].ReadPointers(binaryReader, blamPointers);
            invalidName_21[16].ReadPointers(binaryReader, blamPointers);
            invalidName_21[17].ReadPointers(binaryReader, blamPointers);
            invalidName_21[18].ReadPointers(binaryReader, blamPointers);
            invalidName_21[19].ReadPointers(binaryReader, blamPointers);
            gNullBlock0 = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_22[0].ReadPointers(binaryReader, blamPointers);
            invalidName_22[1].ReadPointers(binaryReader, blamPointers);
            invalidName_22[2].ReadPointers(binaryReader, blamPointers);
            invalidName_22[3].ReadPointers(binaryReader, blamPointers);
            invalidName_23[0].ReadPointers(binaryReader, blamPointers);
            invalidName_23[1].ReadPointers(binaryReader, blamPointers);
            invalidName_23[2].ReadPointers(binaryReader, blamPointers);
            invalidName_23[3].ReadPointers(binaryReader, blamPointers);
            invalidName_23[4].ReadPointers(binaryReader, blamPointers);
            invalidName_23[5].ReadPointers(binaryReader, blamPointers);
            invalidName_23[6].ReadPointers(binaryReader, blamPointers);
            invalidName_23[7].ReadPointers(binaryReader, blamPointers);
            invalidName_23[8].ReadPointers(binaryReader, blamPointers);
            invalidName_23[9].ReadPointers(binaryReader, blamPointers);
            invalidName_23[10].ReadPointers(binaryReader, blamPointers);
            invalidName_23[11].ReadPointers(binaryReader, blamPointers);
            invalidName_23[12].ReadPointers(binaryReader, blamPointers);
            invalidName_23[13].ReadPointers(binaryReader, blamPointers);
            invalidName_23[14].ReadPointers(binaryReader, blamPointers);
            invalidName_23[15].ReadPointers(binaryReader, blamPointers);
            invalidName_23[16].ReadPointers(binaryReader, blamPointers);
            invalidName_23[17].ReadPointers(binaryReader, blamPointers);
            invalidName_23[18].ReadPointers(binaryReader, blamPointers);
            invalidName_23[19].ReadPointers(binaryReader, blamPointers);
            invalidName_24[0].ReadPointers(binaryReader, blamPointers);
            invalidName_24[1].ReadPointers(binaryReader, blamPointers);
            invalidName_25[0].ReadPointers(binaryReader, blamPointers);
            invalidName_25[1].ReadPointers(binaryReader, blamPointers);
            invalidName_25[2].ReadPointers(binaryReader, blamPointers);
            invalidName_25[3].ReadPointers(binaryReader, blamPointers);
            invalidName_25[4].ReadPointers(binaryReader, blamPointers);
            invalidName_25[5].ReadPointers(binaryReader, blamPointers);
            invalidName_25[6].ReadPointers(binaryReader, blamPointers);
            invalidName_25[7].ReadPointers(binaryReader, blamPointers);
            invalidName_25[8].ReadPointers(binaryReader, blamPointers);
            invalidName_25[9].ReadPointers(binaryReader, blamPointers);
            invalidName_25[10].ReadPointers(binaryReader, blamPointers);
            invalidName_25[11].ReadPointers(binaryReader, blamPointers);
            invalidName_25[12].ReadPointers(binaryReader, blamPointers);
            invalidName_25[13].ReadPointers(binaryReader, blamPointers);
            invalidName_25[14].ReadPointers(binaryReader, blamPointers);
            invalidName_25[15].ReadPointers(binaryReader, blamPointers);
            invalidName_25[16].ReadPointers(binaryReader, blamPointers);
            invalidName_25[17].ReadPointers(binaryReader, blamPointers);
            invalidName_25[18].ReadPointers(binaryReader, blamPointers);
            invalidName_25[19].ReadPointers(binaryReader, blamPointers);
            invalidName_26[0].ReadPointers(binaryReader, blamPointers);
            invalidName_26[1].ReadPointers(binaryReader, blamPointers);
            invalidName_26[2].ReadPointers(binaryReader, blamPointers);
            invalidName_26[3].ReadPointers(binaryReader, blamPointers);
            invalidName_27[0].ReadPointers(binaryReader, blamPointers);
            invalidName_27[1].ReadPointers(binaryReader, blamPointers);
            multitexOverlay2 = ReadBlockArrayData<GlobalHudMultitextureOverlayDefinition>(binaryReader, blamPointers.Dequeue());
            invalidName_28[0].ReadPointers(binaryReader, blamPointers);
            invalidName_28[1].ReadPointers(binaryReader, blamPointers);
            invalidName_28[2].ReadPointers(binaryReader, blamPointers);
            invalidName_28[3].ReadPointers(binaryReader, blamPointers);
            invalidName_29[0].ReadPointers(binaryReader, blamPointers);
            invalidName_29[1].ReadPointers(binaryReader, blamPointers);
            invalidName_30[0].ReadPointers(binaryReader, blamPointers);
            invalidName_30[1].ReadPointers(binaryReader, blamPointers);
            invalidName_30[2].ReadPointers(binaryReader, blamPointers);
            invalidName_30[3].ReadPointers(binaryReader, blamPointers);
            invalidName_30[4].ReadPointers(binaryReader, blamPointers);
            invalidName_30[5].ReadPointers(binaryReader, blamPointers);
            invalidName_30[6].ReadPointers(binaryReader, blamPointers);
            invalidName_30[7].ReadPointers(binaryReader, blamPointers);
            invalidName_30[8].ReadPointers(binaryReader, blamPointers);
            invalidName_30[9].ReadPointers(binaryReader, blamPointers);
            invalidName_30[10].ReadPointers(binaryReader, blamPointers);
            invalidName_30[11].ReadPointers(binaryReader, blamPointers);
            invalidName_30[12].ReadPointers(binaryReader, blamPointers);
            invalidName_30[13].ReadPointers(binaryReader, blamPointers);
            invalidName_30[14].ReadPointers(binaryReader, blamPointers);
            invalidName_30[15].ReadPointers(binaryReader, blamPointers);
            invalidName_30[16].ReadPointers(binaryReader, blamPointers);
            invalidName_30[17].ReadPointers(binaryReader, blamPointers);
            invalidName_30[18].ReadPointers(binaryReader, blamPointers);
            invalidName_30[19].ReadPointers(binaryReader, blamPointers);
            invalidName_31[0].ReadPointers(binaryReader, blamPointers);
            invalidName_31[1].ReadPointers(binaryReader, blamPointers);
            invalidName_31[2].ReadPointers(binaryReader, blamPointers);
            invalidName_31[3].ReadPointers(binaryReader, blamPointers);
            invalidName_32[0].ReadPointers(binaryReader, blamPointers);
            invalidName_32[1].ReadPointers(binaryReader, blamPointers);
            multitexOverlay3 = ReadBlockArrayData<GlobalHudMultitextureOverlayDefinition>(binaryReader, blamPointers.Dequeue());
            invalidName_33[0].ReadPointers(binaryReader, blamPointers);
            invalidName_33[1].ReadPointers(binaryReader, blamPointers);
            invalidName_33[2].ReadPointers(binaryReader, blamPointers);
            invalidName_33[3].ReadPointers(binaryReader, blamPointers);
            invalidName_34[0].ReadPointers(binaryReader, blamPointers);
            invalidName_34[1].ReadPointers(binaryReader, blamPointers);
            invalidName_34[2].ReadPointers(binaryReader, blamPointers);
            invalidName_34[3].ReadPointers(binaryReader, blamPointers);
            invalidName_34[4].ReadPointers(binaryReader, blamPointers);
            invalidName_34[5].ReadPointers(binaryReader, blamPointers);
            invalidName_34[6].ReadPointers(binaryReader, blamPointers);
            invalidName_34[7].ReadPointers(binaryReader, blamPointers);
            invalidName_34[8].ReadPointers(binaryReader, blamPointers);
            invalidName_34[9].ReadPointers(binaryReader, blamPointers);
            invalidName_34[10].ReadPointers(binaryReader, blamPointers);
            invalidName_34[11].ReadPointers(binaryReader, blamPointers);
            invalidName_34[12].ReadPointers(binaryReader, blamPointers);
            invalidName_34[13].ReadPointers(binaryReader, blamPointers);
            invalidName_34[14].ReadPointers(binaryReader, blamPointers);
            invalidName_34[15].ReadPointers(binaryReader, blamPointers);
            invalidName_34[16].ReadPointers(binaryReader, blamPointers);
            invalidName_34[17].ReadPointers(binaryReader, blamPointers);
            invalidName_34[18].ReadPointers(binaryReader, blamPointers);
            invalidName_34[19].ReadPointers(binaryReader, blamPointers);
            invalidName_34[20].ReadPointers(binaryReader, blamPointers);
            invalidName_34[21].ReadPointers(binaryReader, blamPointers);
            invalidName_34[22].ReadPointers(binaryReader, blamPointers);
            invalidName_34[23].ReadPointers(binaryReader, blamPointers);
            invalidName_34[24].ReadPointers(binaryReader, blamPointers);
            invalidName_34[25].ReadPointers(binaryReader, blamPointers);
            invalidName_34[26].ReadPointers(binaryReader, blamPointers);
            invalidName_34[27].ReadPointers(binaryReader, blamPointers);
            invalidName_34[28].ReadPointers(binaryReader, blamPointers);
            invalidName_34[29].ReadPointers(binaryReader, blamPointers);
            invalidName_34[30].ReadPointers(binaryReader, blamPointers);
            invalidName_34[31].ReadPointers(binaryReader, blamPointers);
            invalidName_35[0].ReadPointers(binaryReader, blamPointers);
            invalidName_35[1].ReadPointers(binaryReader, blamPointers);
            invalidName_36[0].ReadPointers(binaryReader, blamPointers);
            invalidName_36[1].ReadPointers(binaryReader, blamPointers);
            invalidName_36[2].ReadPointers(binaryReader, blamPointers);
            invalidName_36[3].ReadPointers(binaryReader, blamPointers);
            invalidName_36[4].ReadPointers(binaryReader, blamPointers);
            invalidName_36[5].ReadPointers(binaryReader, blamPointers);
            invalidName_36[6].ReadPointers(binaryReader, blamPointers);
            invalidName_36[7].ReadPointers(binaryReader, blamPointers);
            invalidName_36[8].ReadPointers(binaryReader, blamPointers);
            invalidName_36[9].ReadPointers(binaryReader, blamPointers);
            invalidName_36[10].ReadPointers(binaryReader, blamPointers);
            invalidName_36[11].ReadPointers(binaryReader, blamPointers);
            invalidName_36[12].ReadPointers(binaryReader, blamPointers);
            invalidName_36[13].ReadPointers(binaryReader, blamPointers);
            invalidName_36[14].ReadPointers(binaryReader, blamPointers);
            invalidName_36[15].ReadPointers(binaryReader, blamPointers);
            invalidName_36[16].ReadPointers(binaryReader, blamPointers);
            invalidName_36[17].ReadPointers(binaryReader, blamPointers);
            invalidName_36[18].ReadPointers(binaryReader, blamPointers);
            invalidName_36[19].ReadPointers(binaryReader, blamPointers);
            invalidName_37[0].ReadPointers(binaryReader, blamPointers);
            invalidName_37[1].ReadPointers(binaryReader, blamPointers);
            invalidName_38[0].ReadPointers(binaryReader, blamPointers);
            invalidName_38[1].ReadPointers(binaryReader, blamPointers);
            invalidName_38[2].ReadPointers(binaryReader, blamPointers);
            invalidName_38[3].ReadPointers(binaryReader, blamPointers);
            invalidName_38[4].ReadPointers(binaryReader, blamPointers);
            invalidName_38[5].ReadPointers(binaryReader, blamPointers);
            invalidName_38[6].ReadPointers(binaryReader, blamPointers);
            invalidName_38[7].ReadPointers(binaryReader, blamPointers);
            invalidName_38[8].ReadPointers(binaryReader, blamPointers);
            invalidName_38[9].ReadPointers(binaryReader, blamPointers);
            invalidName_38[10].ReadPointers(binaryReader, blamPointers);
            invalidName_38[11].ReadPointers(binaryReader, blamPointers);
            invalidName_38[12].ReadPointers(binaryReader, blamPointers);
            invalidName_38[13].ReadPointers(binaryReader, blamPointers);
            invalidName_38[14].ReadPointers(binaryReader, blamPointers);
            invalidName_38[15].ReadPointers(binaryReader, blamPointers);
            invalidName_38[16].ReadPointers(binaryReader, blamPointers);
            invalidName_38[17].ReadPointers(binaryReader, blamPointers);
            invalidName_38[18].ReadPointers(binaryReader, blamPointers);
            invalidName_38[19].ReadPointers(binaryReader, blamPointers);
            invalidName_38[20].ReadPointers(binaryReader, blamPointers);
            invalidName_38[21].ReadPointers(binaryReader, blamPointers);
            invalidName_38[22].ReadPointers(binaryReader, blamPointers);
            invalidName_38[23].ReadPointers(binaryReader, blamPointers);
            invalidName_38[24].ReadPointers(binaryReader, blamPointers);
            invalidName_38[25].ReadPointers(binaryReader, blamPointers);
            invalidName_38[26].ReadPointers(binaryReader, blamPointers);
            invalidName_38[27].ReadPointers(binaryReader, blamPointers);
            invalidName_38[28].ReadPointers(binaryReader, blamPointers);
            invalidName_38[29].ReadPointers(binaryReader, blamPointers);
            invalidName_38[30].ReadPointers(binaryReader, blamPointers);
            invalidName_38[31].ReadPointers(binaryReader, blamPointers);
            overlays = ReadBlockArrayData<UnitHudAuxilaryOverlayBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_39[0].ReadPointers(binaryReader, blamPointers);
            invalidName_39[1].ReadPointers(binaryReader, blamPointers);
            invalidName_39[2].ReadPointers(binaryReader, blamPointers);
            invalidName_39[3].ReadPointers(binaryReader, blamPointers);
            invalidName_39[4].ReadPointers(binaryReader, blamPointers);
            invalidName_39[5].ReadPointers(binaryReader, blamPointers);
            invalidName_39[6].ReadPointers(binaryReader, blamPointers);
            invalidName_39[7].ReadPointers(binaryReader, blamPointers);
            invalidName_39[8].ReadPointers(binaryReader, blamPointers);
            invalidName_39[9].ReadPointers(binaryReader, blamPointers);
            invalidName_39[10].ReadPointers(binaryReader, blamPointers);
            invalidName_39[11].ReadPointers(binaryReader, blamPointers);
            invalidName_39[12].ReadPointers(binaryReader, blamPointers);
            invalidName_39[13].ReadPointers(binaryReader, blamPointers);
            invalidName_39[14].ReadPointers(binaryReader, blamPointers);
            invalidName_39[15].ReadPointers(binaryReader, blamPointers);
            sounds = ReadBlockArrayData<UnitHudSoundBlock>(binaryReader, blamPointers.Dequeue());
            meters = ReadBlockArrayData<UnitHudAuxilaryPanelBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_40[0].ReadPointers(binaryReader, blamPointers);
            invalidName_40[1].ReadPointers(binaryReader, blamPointers);
            invalidName_40[2].ReadPointers(binaryReader, blamPointers);
            invalidName_40[3].ReadPointers(binaryReader, blamPointers);
            invalidName_40[4].ReadPointers(binaryReader, blamPointers);
            invalidName_40[5].ReadPointers(binaryReader, blamPointers);
            invalidName_40[6].ReadPointers(binaryReader, blamPointers);
            invalidName_40[7].ReadPointers(binaryReader, blamPointers);
            invalidName_40[8].ReadPointers(binaryReader, blamPointers);
            invalidName_40[9].ReadPointers(binaryReader, blamPointers);
            invalidName_40[10].ReadPointers(binaryReader, blamPointers);
            invalidName_40[11].ReadPointers(binaryReader, blamPointers);
            invalidName_40[12].ReadPointers(binaryReader, blamPointers);
            invalidName_40[13].ReadPointers(binaryReader, blamPointers);
            invalidName_40[14].ReadPointers(binaryReader, blamPointers);
            invalidName_40[15].ReadPointers(binaryReader, blamPointers);
            invalidName_40[16].ReadPointers(binaryReader, blamPointers);
            invalidName_40[17].ReadPointers(binaryReader, blamPointers);
            invalidName_40[18].ReadPointers(binaryReader, blamPointers);
            invalidName_40[19].ReadPointers(binaryReader, blamPointers);
            invalidName_40[20].ReadPointers(binaryReader, blamPointers);
            invalidName_40[21].ReadPointers(binaryReader, blamPointers);
            invalidName_40[22].ReadPointers(binaryReader, blamPointers);
            invalidName_40[23].ReadPointers(binaryReader, blamPointers);
            invalidName_40[24].ReadPointers(binaryReader, blamPointers);
            invalidName_40[25].ReadPointers(binaryReader, blamPointers);
            invalidName_40[26].ReadPointers(binaryReader, blamPointers);
            invalidName_40[27].ReadPointers(binaryReader, blamPointers);
            invalidName_40[28].ReadPointers(binaryReader, blamPointers);
            invalidName_40[29].ReadPointers(binaryReader, blamPointers);
            invalidName_40[30].ReadPointers(binaryReader, blamPointers);
            invalidName_40[31].ReadPointers(binaryReader, blamPointers);
            invalidName_40[32].ReadPointers(binaryReader, blamPointers);
            invalidName_40[33].ReadPointers(binaryReader, blamPointers);
            invalidName_40[34].ReadPointers(binaryReader, blamPointers);
            invalidName_40[35].ReadPointers(binaryReader, blamPointers);
            invalidName_40[36].ReadPointers(binaryReader, blamPointers);
            invalidName_40[37].ReadPointers(binaryReader, blamPointers);
            invalidName_40[38].ReadPointers(binaryReader, blamPointers);
            invalidName_40[39].ReadPointers(binaryReader, blamPointers);
            invalidName_40[40].ReadPointers(binaryReader, blamPointers);
            invalidName_40[41].ReadPointers(binaryReader, blamPointers);
            invalidName_40[42].ReadPointers(binaryReader, blamPointers);
            invalidName_40[43].ReadPointers(binaryReader, blamPointers);
            invalidName_40[44].ReadPointers(binaryReader, blamPointers);
            invalidName_40[45].ReadPointers(binaryReader, blamPointers);
            invalidName_40[46].ReadPointers(binaryReader, blamPointers);
            invalidName_40[47].ReadPointers(binaryReader, blamPointers);
            invalidName_40[48].ReadPointers(binaryReader, blamPointers);
            invalidName_40[49].ReadPointers(binaryReader, blamPointers);
            invalidName_40[50].ReadPointers(binaryReader, blamPointers);
            invalidName_40[51].ReadPointers(binaryReader, blamPointers);
            invalidName_40[52].ReadPointers(binaryReader, blamPointers);
            invalidName_40[53].ReadPointers(binaryReader, blamPointers);
            invalidName_40[54].ReadPointers(binaryReader, blamPointers);
            invalidName_40[55].ReadPointers(binaryReader, blamPointers);
            invalidName_40[56].ReadPointers(binaryReader, blamPointers);
            invalidName_40[57].ReadPointers(binaryReader, blamPointers);
            invalidName_40[58].ReadPointers(binaryReader, blamPointers);
            invalidName_40[59].ReadPointers(binaryReader, blamPointers);
            invalidName_40[60].ReadPointers(binaryReader, blamPointers);
            invalidName_40[61].ReadPointers(binaryReader, blamPointers);
            invalidName_40[62].ReadPointers(binaryReader, blamPointers);
            invalidName_40[63].ReadPointers(binaryReader, blamPointers);
            invalidName_40[64].ReadPointers(binaryReader, blamPointers);
            invalidName_40[65].ReadPointers(binaryReader, blamPointers);
            invalidName_40[66].ReadPointers(binaryReader, blamPointers);
            invalidName_40[67].ReadPointers(binaryReader, blamPointers);
            invalidName_40[68].ReadPointers(binaryReader, blamPointers);
            invalidName_40[69].ReadPointers(binaryReader, blamPointers);
            invalidName_40[70].ReadPointers(binaryReader, blamPointers);
            invalidName_40[71].ReadPointers(binaryReader, blamPointers);
            invalidName_40[72].ReadPointers(binaryReader, blamPointers);
            invalidName_40[73].ReadPointers(binaryReader, blamPointers);
            invalidName_40[74].ReadPointers(binaryReader, blamPointers);
            invalidName_40[75].ReadPointers(binaryReader, blamPointers);
            invalidName_40[76].ReadPointers(binaryReader, blamPointers);
            invalidName_40[77].ReadPointers(binaryReader, blamPointers);
            invalidName_40[78].ReadPointers(binaryReader, blamPointers);
            invalidName_40[79].ReadPointers(binaryReader, blamPointers);
            invalidName_40[80].ReadPointers(binaryReader, blamPointers);
            invalidName_40[81].ReadPointers(binaryReader, blamPointers);
            invalidName_40[82].ReadPointers(binaryReader, blamPointers);
            invalidName_40[83].ReadPointers(binaryReader, blamPointers);
            invalidName_40[84].ReadPointers(binaryReader, blamPointers);
            invalidName_40[85].ReadPointers(binaryReader, blamPointers);
            invalidName_40[86].ReadPointers(binaryReader, blamPointers);
            invalidName_40[87].ReadPointers(binaryReader, blamPointers);
            invalidName_40[88].ReadPointers(binaryReader, blamPointers);
            invalidName_40[89].ReadPointers(binaryReader, blamPointers);
            invalidName_40[90].ReadPointers(binaryReader, blamPointers);
            invalidName_40[91].ReadPointers(binaryReader, blamPointers);
            invalidName_40[92].ReadPointers(binaryReader, blamPointers);
            invalidName_40[93].ReadPointers(binaryReader, blamPointers);
            invalidName_40[94].ReadPointers(binaryReader, blamPointers);
            invalidName_40[95].ReadPointers(binaryReader, blamPointers);
            invalidName_40[96].ReadPointers(binaryReader, blamPointers);
            invalidName_40[97].ReadPointers(binaryReader, blamPointers);
            invalidName_40[98].ReadPointers(binaryReader, blamPointers);
            invalidName_40[99].ReadPointers(binaryReader, blamPointers);
            invalidName_40[100].ReadPointers(binaryReader, blamPointers);
            invalidName_40[101].ReadPointers(binaryReader, blamPointers);
            invalidName_40[102].ReadPointers(binaryReader, blamPointers);
            invalidName_40[103].ReadPointers(binaryReader, blamPointers);
            invalidName_40[104].ReadPointers(binaryReader, blamPointers);
            invalidName_40[105].ReadPointers(binaryReader, blamPointers);
            invalidName_40[106].ReadPointers(binaryReader, blamPointers);
            invalidName_40[107].ReadPointers(binaryReader, blamPointers);
            invalidName_40[108].ReadPointers(binaryReader, blamPointers);
            invalidName_40[109].ReadPointers(binaryReader, blamPointers);
            invalidName_40[110].ReadPointers(binaryReader, blamPointers);
            invalidName_40[111].ReadPointers(binaryReader, blamPointers);
            invalidName_40[112].ReadPointers(binaryReader, blamPointers);
            invalidName_40[113].ReadPointers(binaryReader, blamPointers);
            invalidName_40[114].ReadPointers(binaryReader, blamPointers);
            invalidName_40[115].ReadPointers(binaryReader, blamPointers);
            invalidName_40[116].ReadPointers(binaryReader, blamPointers);
            invalidName_40[117].ReadPointers(binaryReader, blamPointers);
            invalidName_40[118].ReadPointers(binaryReader, blamPointers);
            invalidName_40[119].ReadPointers(binaryReader, blamPointers);
            invalidName_40[120].ReadPointers(binaryReader, blamPointers);
            invalidName_40[121].ReadPointers(binaryReader, blamPointers);
            invalidName_40[122].ReadPointers(binaryReader, blamPointers);
            invalidName_40[123].ReadPointers(binaryReader, blamPointers);
            invalidName_40[124].ReadPointers(binaryReader, blamPointers);
            invalidName_40[125].ReadPointers(binaryReader, blamPointers);
            invalidName_40[126].ReadPointers(binaryReader, blamPointers);
            invalidName_40[127].ReadPointers(binaryReader, blamPointers);
            invalidName_40[128].ReadPointers(binaryReader, blamPointers);
            invalidName_40[129].ReadPointers(binaryReader, blamPointers);
            invalidName_40[130].ReadPointers(binaryReader, blamPointers);
            invalidName_40[131].ReadPointers(binaryReader, blamPointers);
            invalidName_40[132].ReadPointers(binaryReader, blamPointers);
            invalidName_40[133].ReadPointers(binaryReader, blamPointers);
            invalidName_40[134].ReadPointers(binaryReader, blamPointers);
            invalidName_40[135].ReadPointers(binaryReader, blamPointers);
            invalidName_40[136].ReadPointers(binaryReader, blamPointers);
            invalidName_40[137].ReadPointers(binaryReader, blamPointers);
            invalidName_40[138].ReadPointers(binaryReader, blamPointers);
            invalidName_40[139].ReadPointers(binaryReader, blamPointers);
            invalidName_40[140].ReadPointers(binaryReader, blamPointers);
            invalidName_40[141].ReadPointers(binaryReader, blamPointers);
            invalidName_40[142].ReadPointers(binaryReader, blamPointers);
            invalidName_40[143].ReadPointers(binaryReader, blamPointers);
            invalidName_40[144].ReadPointers(binaryReader, blamPointers);
            invalidName_40[145].ReadPointers(binaryReader, blamPointers);
            invalidName_40[146].ReadPointers(binaryReader, blamPointers);
            invalidName_40[147].ReadPointers(binaryReader, blamPointers);
            invalidName_40[148].ReadPointers(binaryReader, blamPointers);
            invalidName_40[149].ReadPointers(binaryReader, blamPointers);
            invalidName_40[150].ReadPointers(binaryReader, blamPointers);
            invalidName_40[151].ReadPointers(binaryReader, blamPointers);
            invalidName_40[152].ReadPointers(binaryReader, blamPointers);
            invalidName_40[153].ReadPointers(binaryReader, blamPointers);
            invalidName_40[154].ReadPointers(binaryReader, blamPointers);
            invalidName_40[155].ReadPointers(binaryReader, blamPointers);
            invalidName_40[156].ReadPointers(binaryReader, blamPointers);
            invalidName_40[157].ReadPointers(binaryReader, blamPointers);
            invalidName_40[158].ReadPointers(binaryReader, blamPointers);
            invalidName_40[159].ReadPointers(binaryReader, blamPointers);
            invalidName_40[160].ReadPointers(binaryReader, blamPointers);
            invalidName_40[161].ReadPointers(binaryReader, blamPointers);
            invalidName_40[162].ReadPointers(binaryReader, blamPointers);
            invalidName_40[163].ReadPointers(binaryReader, blamPointers);
            invalidName_40[164].ReadPointers(binaryReader, blamPointers);
            invalidName_40[165].ReadPointers(binaryReader, blamPointers);
            invalidName_40[166].ReadPointers(binaryReader, blamPointers);
            invalidName_40[167].ReadPointers(binaryReader, blamPointers);
            invalidName_40[168].ReadPointers(binaryReader, blamPointers);
            invalidName_40[169].ReadPointers(binaryReader, blamPointers);
            invalidName_40[170].ReadPointers(binaryReader, blamPointers);
            invalidName_40[171].ReadPointers(binaryReader, blamPointers);
            invalidName_40[172].ReadPointers(binaryReader, blamPointers);
            invalidName_40[173].ReadPointers(binaryReader, blamPointers);
            invalidName_40[174].ReadPointers(binaryReader, blamPointers);
            invalidName_40[175].ReadPointers(binaryReader, blamPointers);
            invalidName_40[176].ReadPointers(binaryReader, blamPointers);
            invalidName_40[177].ReadPointers(binaryReader, blamPointers);
            invalidName_40[178].ReadPointers(binaryReader, blamPointers);
            invalidName_40[179].ReadPointers(binaryReader, blamPointers);
            invalidName_40[180].ReadPointers(binaryReader, blamPointers);
            invalidName_40[181].ReadPointers(binaryReader, blamPointers);
            invalidName_40[182].ReadPointers(binaryReader, blamPointers);
            invalidName_40[183].ReadPointers(binaryReader, blamPointers);
            invalidName_40[184].ReadPointers(binaryReader, blamPointers);
            invalidName_40[185].ReadPointers(binaryReader, blamPointers);
            invalidName_40[186].ReadPointers(binaryReader, blamPointers);
            invalidName_40[187].ReadPointers(binaryReader, blamPointers);
            invalidName_40[188].ReadPointers(binaryReader, blamPointers);
            invalidName_40[189].ReadPointers(binaryReader, blamPointers);
            invalidName_40[190].ReadPointers(binaryReader, blamPointers);
            invalidName_40[191].ReadPointers(binaryReader, blamPointers);
            invalidName_40[192].ReadPointers(binaryReader, blamPointers);
            invalidName_40[193].ReadPointers(binaryReader, blamPointers);
            invalidName_40[194].ReadPointers(binaryReader, blamPointers);
            invalidName_40[195].ReadPointers(binaryReader, blamPointers);
            invalidName_40[196].ReadPointers(binaryReader, blamPointers);
            invalidName_40[197].ReadPointers(binaryReader, blamPointers);
            invalidName_40[198].ReadPointers(binaryReader, blamPointers);
            invalidName_40[199].ReadPointers(binaryReader, blamPointers);
            invalidName_40[200].ReadPointers(binaryReader, blamPointers);
            invalidName_40[201].ReadPointers(binaryReader, blamPointers);
            invalidName_40[202].ReadPointers(binaryReader, blamPointers);
            invalidName_40[203].ReadPointers(binaryReader, blamPointers);
            invalidName_40[204].ReadPointers(binaryReader, blamPointers);
            invalidName_40[205].ReadPointers(binaryReader, blamPointers);
            invalidName_40[206].ReadPointers(binaryReader, blamPointers);
            invalidName_40[207].ReadPointers(binaryReader, blamPointers);
            invalidName_40[208].ReadPointers(binaryReader, blamPointers);
            invalidName_40[209].ReadPointers(binaryReader, blamPointers);
            invalidName_40[210].ReadPointers(binaryReader, blamPointers);
            invalidName_40[211].ReadPointers(binaryReader, blamPointers);
            invalidName_40[212].ReadPointers(binaryReader, blamPointers);
            invalidName_40[213].ReadPointers(binaryReader, blamPointers);
            invalidName_40[214].ReadPointers(binaryReader, blamPointers);
            invalidName_40[215].ReadPointers(binaryReader, blamPointers);
            invalidName_40[216].ReadPointers(binaryReader, blamPointers);
            invalidName_40[217].ReadPointers(binaryReader, blamPointers);
            invalidName_40[218].ReadPointers(binaryReader, blamPointers);
            invalidName_40[219].ReadPointers(binaryReader, blamPointers);
            invalidName_40[220].ReadPointers(binaryReader, blamPointers);
            invalidName_40[221].ReadPointers(binaryReader, blamPointers);
            invalidName_40[222].ReadPointers(binaryReader, blamPointers);
            invalidName_40[223].ReadPointers(binaryReader, blamPointers);
            invalidName_40[224].ReadPointers(binaryReader, blamPointers);
            invalidName_40[225].ReadPointers(binaryReader, blamPointers);
            invalidName_40[226].ReadPointers(binaryReader, blamPointers);
            invalidName_40[227].ReadPointers(binaryReader, blamPointers);
            invalidName_40[228].ReadPointers(binaryReader, blamPointers);
            invalidName_40[229].ReadPointers(binaryReader, blamPointers);
            invalidName_40[230].ReadPointers(binaryReader, blamPointers);
            invalidName_40[231].ReadPointers(binaryReader, blamPointers);
            invalidName_40[232].ReadPointers(binaryReader, blamPointers);
            invalidName_40[233].ReadPointers(binaryReader, blamPointers);
            invalidName_40[234].ReadPointers(binaryReader, blamPointers);
            invalidName_40[235].ReadPointers(binaryReader, blamPointers);
            invalidName_40[236].ReadPointers(binaryReader, blamPointers);
            invalidName_40[237].ReadPointers(binaryReader, blamPointers);
            invalidName_40[238].ReadPointers(binaryReader, blamPointers);
            invalidName_40[239].ReadPointers(binaryReader, blamPointers);
            invalidName_40[240].ReadPointers(binaryReader, blamPointers);
            invalidName_40[241].ReadPointers(binaryReader, blamPointers);
            invalidName_40[242].ReadPointers(binaryReader, blamPointers);
            invalidName_40[243].ReadPointers(binaryReader, blamPointers);
            invalidName_40[244].ReadPointers(binaryReader, blamPointers);
            invalidName_40[245].ReadPointers(binaryReader, blamPointers);
            invalidName_40[246].ReadPointers(binaryReader, blamPointers);
            invalidName_40[247].ReadPointers(binaryReader, blamPointers);
            invalidName_40[248].ReadPointers(binaryReader, blamPointers);
            invalidName_40[249].ReadPointers(binaryReader, blamPointers);
            invalidName_40[250].ReadPointers(binaryReader, blamPointers);
            invalidName_40[251].ReadPointers(binaryReader, blamPointers);
            invalidName_40[252].ReadPointers(binaryReader, blamPointers);
            invalidName_40[253].ReadPointers(binaryReader, blamPointers);
            invalidName_40[254].ReadPointers(binaryReader, blamPointers);
            invalidName_40[255].ReadPointers(binaryReader, blamPointers);
            invalidName_40[256].ReadPointers(binaryReader, blamPointers);
            invalidName_40[257].ReadPointers(binaryReader, blamPointers);
            invalidName_40[258].ReadPointers(binaryReader, blamPointers);
            invalidName_40[259].ReadPointers(binaryReader, blamPointers);
            invalidName_40[260].ReadPointers(binaryReader, blamPointers);
            invalidName_40[261].ReadPointers(binaryReader, blamPointers);
            invalidName_40[262].ReadPointers(binaryReader, blamPointers);
            invalidName_40[263].ReadPointers(binaryReader, blamPointers);
            invalidName_40[264].ReadPointers(binaryReader, blamPointers);
            invalidName_40[265].ReadPointers(binaryReader, blamPointers);
            invalidName_40[266].ReadPointers(binaryReader, blamPointers);
            invalidName_40[267].ReadPointers(binaryReader, blamPointers);
            invalidName_40[268].ReadPointers(binaryReader, blamPointers);
            invalidName_40[269].ReadPointers(binaryReader, blamPointers);
            invalidName_40[270].ReadPointers(binaryReader, blamPointers);
            invalidName_40[271].ReadPointers(binaryReader, blamPointers);
            invalidName_40[272].ReadPointers(binaryReader, blamPointers);
            invalidName_40[273].ReadPointers(binaryReader, blamPointers);
            invalidName_40[274].ReadPointers(binaryReader, blamPointers);
            invalidName_40[275].ReadPointers(binaryReader, blamPointers);
            invalidName_40[276].ReadPointers(binaryReader, blamPointers);
            invalidName_40[277].ReadPointers(binaryReader, blamPointers);
            invalidName_40[278].ReadPointers(binaryReader, blamPointers);
            invalidName_40[279].ReadPointers(binaryReader, blamPointers);
            invalidName_40[280].ReadPointers(binaryReader, blamPointers);
            invalidName_40[281].ReadPointers(binaryReader, blamPointers);
            invalidName_40[282].ReadPointers(binaryReader, blamPointers);
            invalidName_40[283].ReadPointers(binaryReader, blamPointers);
            invalidName_40[284].ReadPointers(binaryReader, blamPointers);
            invalidName_40[285].ReadPointers(binaryReader, blamPointers);
            invalidName_40[286].ReadPointers(binaryReader, blamPointers);
            invalidName_40[287].ReadPointers(binaryReader, blamPointers);
            invalidName_40[288].ReadPointers(binaryReader, blamPointers);
            invalidName_40[289].ReadPointers(binaryReader, blamPointers);
            invalidName_40[290].ReadPointers(binaryReader, blamPointers);
            invalidName_40[291].ReadPointers(binaryReader, blamPointers);
            invalidName_40[292].ReadPointers(binaryReader, blamPointers);
            invalidName_40[293].ReadPointers(binaryReader, blamPointers);
            invalidName_40[294].ReadPointers(binaryReader, blamPointers);
            invalidName_40[295].ReadPointers(binaryReader, blamPointers);
            invalidName_40[296].ReadPointers(binaryReader, blamPointers);
            invalidName_40[297].ReadPointers(binaryReader, blamPointers);
            invalidName_40[298].ReadPointers(binaryReader, blamPointers);
            invalidName_40[299].ReadPointers(binaryReader, blamPointers);
            invalidName_40[300].ReadPointers(binaryReader, blamPointers);
            invalidName_40[301].ReadPointers(binaryReader, blamPointers);
            invalidName_40[302].ReadPointers(binaryReader, blamPointers);
            invalidName_40[303].ReadPointers(binaryReader, blamPointers);
            invalidName_40[304].ReadPointers(binaryReader, blamPointers);
            invalidName_40[305].ReadPointers(binaryReader, blamPointers);
            invalidName_40[306].ReadPointers(binaryReader, blamPointers);
            invalidName_40[307].ReadPointers(binaryReader, blamPointers);
            invalidName_40[308].ReadPointers(binaryReader, blamPointers);
            invalidName_40[309].ReadPointers(binaryReader, blamPointers);
            invalidName_40[310].ReadPointers(binaryReader, blamPointers);
            invalidName_40[311].ReadPointers(binaryReader, blamPointers);
            invalidName_40[312].ReadPointers(binaryReader, blamPointers);
            invalidName_40[313].ReadPointers(binaryReader, blamPointers);
            invalidName_40[314].ReadPointers(binaryReader, blamPointers);
            invalidName_40[315].ReadPointers(binaryReader, blamPointers);
            invalidName_40[316].ReadPointers(binaryReader, blamPointers);
            invalidName_40[317].ReadPointers(binaryReader, blamPointers);
            invalidName_40[318].ReadPointers(binaryReader, blamPointers);
            invalidName_40[319].ReadPointers(binaryReader, blamPointers);
            invalidName_40[320].ReadPointers(binaryReader, blamPointers);
            invalidName_40[321].ReadPointers(binaryReader, blamPointers);
            invalidName_40[322].ReadPointers(binaryReader, blamPointers);
            invalidName_40[323].ReadPointers(binaryReader, blamPointers);
            invalidName_40[324].ReadPointers(binaryReader, blamPointers);
            invalidName_40[325].ReadPointers(binaryReader, blamPointers);
            invalidName_40[326].ReadPointers(binaryReader, blamPointers);
            invalidName_40[327].ReadPointers(binaryReader, blamPointers);
            invalidName_40[328].ReadPointers(binaryReader, blamPointers);
            invalidName_40[329].ReadPointers(binaryReader, blamPointers);
            invalidName_40[330].ReadPointers(binaryReader, blamPointers);
            invalidName_40[331].ReadPointers(binaryReader, blamPointers);
            invalidName_40[332].ReadPointers(binaryReader, blamPointers);
            invalidName_40[333].ReadPointers(binaryReader, blamPointers);
            invalidName_40[334].ReadPointers(binaryReader, blamPointers);
            invalidName_40[335].ReadPointers(binaryReader, blamPointers);
            invalidName_40[336].ReadPointers(binaryReader, blamPointers);
            invalidName_40[337].ReadPointers(binaryReader, blamPointers);
            invalidName_40[338].ReadPointers(binaryReader, blamPointers);
            invalidName_40[339].ReadPointers(binaryReader, blamPointers);
            invalidName_40[340].ReadPointers(binaryReader, blamPointers);
            invalidName_40[341].ReadPointers(binaryReader, blamPointers);
            invalidName_40[342].ReadPointers(binaryReader, blamPointers);
            invalidName_40[343].ReadPointers(binaryReader, blamPointers);
            invalidName_40[344].ReadPointers(binaryReader, blamPointers);
            invalidName_40[345].ReadPointers(binaryReader, blamPointers);
            invalidName_40[346].ReadPointers(binaryReader, blamPointers);
            invalidName_40[347].ReadPointers(binaryReader, blamPointers);
            invalidName_40[348].ReadPointers(binaryReader, blamPointers);
            invalidName_40[349].ReadPointers(binaryReader, blamPointers);
            invalidName_40[350].ReadPointers(binaryReader, blamPointers);
            invalidName_40[351].ReadPointers(binaryReader, blamPointers);
            invalidName_40[352].ReadPointers(binaryReader, blamPointers);
            invalidName_40[353].ReadPointers(binaryReader, blamPointers);
            invalidName_40[354].ReadPointers(binaryReader, blamPointers);
            invalidName_40[355].ReadPointers(binaryReader, blamPointers);
            invalidName_41[0].ReadPointers(binaryReader, blamPointers);
            invalidName_41[1].ReadPointers(binaryReader, blamPointers);
            invalidName_41[2].ReadPointers(binaryReader, blamPointers);
            invalidName_41[3].ReadPointers(binaryReader, blamPointers);
            invalidName_41[4].ReadPointers(binaryReader, blamPointers);
            invalidName_41[5].ReadPointers(binaryReader, blamPointers);
            invalidName_41[6].ReadPointers(binaryReader, blamPointers);
            invalidName_41[7].ReadPointers(binaryReader, blamPointers);
            invalidName_41[8].ReadPointers(binaryReader, blamPointers);
            invalidName_41[9].ReadPointers(binaryReader, blamPointers);
            invalidName_41[10].ReadPointers(binaryReader, blamPointers);
            invalidName_41[11].ReadPointers(binaryReader, blamPointers);
            invalidName_41[12].ReadPointers(binaryReader, blamPointers);
            invalidName_41[13].ReadPointers(binaryReader, blamPointers);
            invalidName_41[14].ReadPointers(binaryReader, blamPointers);
            invalidName_41[15].ReadPointers(binaryReader, blamPointers);
            invalidName_41[16].ReadPointers(binaryReader, blamPointers);
            invalidName_41[17].ReadPointers(binaryReader, blamPointers);
            invalidName_41[18].ReadPointers(binaryReader, blamPointers);
            invalidName_41[19].ReadPointers(binaryReader, blamPointers);
            invalidName_41[20].ReadPointers(binaryReader, blamPointers);
            invalidName_41[21].ReadPointers(binaryReader, blamPointers);
            invalidName_41[22].ReadPointers(binaryReader, blamPointers);
            invalidName_41[23].ReadPointers(binaryReader, blamPointers);
            invalidName_41[24].ReadPointers(binaryReader, blamPointers);
            invalidName_41[25].ReadPointers(binaryReader, blamPointers);
            invalidName_41[26].ReadPointers(binaryReader, blamPointers);
            invalidName_41[27].ReadPointers(binaryReader, blamPointers);
            invalidName_41[28].ReadPointers(binaryReader, blamPointers);
            invalidName_41[29].ReadPointers(binaryReader, blamPointers);
            invalidName_41[30].ReadPointers(binaryReader, blamPointers);
            invalidName_41[31].ReadPointers(binaryReader, blamPointers);
            invalidName_41[32].ReadPointers(binaryReader, blamPointers);
            invalidName_41[33].ReadPointers(binaryReader, blamPointers);
            invalidName_41[34].ReadPointers(binaryReader, blamPointers);
            invalidName_41[35].ReadPointers(binaryReader, blamPointers);
            invalidName_41[36].ReadPointers(binaryReader, blamPointers);
            invalidName_41[37].ReadPointers(binaryReader, blamPointers);
            invalidName_41[38].ReadPointers(binaryReader, blamPointers);
            invalidName_41[39].ReadPointers(binaryReader, blamPointers);
            invalidName_41[40].ReadPointers(binaryReader, blamPointers);
            invalidName_41[41].ReadPointers(binaryReader, blamPointers);
            invalidName_41[42].ReadPointers(binaryReader, blamPointers);
            invalidName_41[43].ReadPointers(binaryReader, blamPointers);
            invalidName_41[44].ReadPointers(binaryReader, blamPointers);
            invalidName_41[45].ReadPointers(binaryReader, blamPointers);
            invalidName_41[46].ReadPointers(binaryReader, blamPointers);
            invalidName_41[47].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
