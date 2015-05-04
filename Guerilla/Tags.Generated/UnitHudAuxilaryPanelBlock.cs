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
    public partial class UnitHudAuxilaryPanelBlock : UnitHudAuxilaryPanelBlockBase
    {
        public UnitHudAuxilaryPanelBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 297, Alignment = 4)]
    public class UnitHudAuxilaryPanelBlockBase : GuerillaBlock
    {
        internal Type type;
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
        internal Moonfish.Tags.TagReference meterBitmap;
        internal Moonfish.Tags.ColourR1G1B1 colorAtMeterMinimum;
        internal Moonfish.Tags.ColourR1G1B1 colorAtMeterMaximum;
        internal Moonfish.Tags.ColourR1G1B1 flashColor;
        internal Moonfish.Tags.ColourA1R1G1B1 emptyColor;
        internal Flags flags;
        internal byte minumumMeterValue;
        internal short sequenceIndex0;
        internal byte alphaMultiplier;
        internal byte alphaBias;
        /// <summary>
        /// used for non-integral values, i.e. health and shields
        /// </summary>
        internal short valueScale;
        internal float opacity;
        internal float translucency;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor0;
        internal GNullBlock[] gNullBlock;
        internal byte[] invalidName_8;
        internal float minimumFractionCutoff;
        internal Flags flags0;
        internal byte[] invalidName_9;
        internal byte[] invalidName_10;
        public override int SerializedSize { get { return 297; } }
        public override int Alignment { get { return 4; } }
        public UnitHudAuxilaryPanelBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(16);
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
            meterBitmap = binaryReader.ReadTagReference();
            colorAtMeterMinimum = binaryReader.ReadColourR1G1B1();
            colorAtMeterMaximum = binaryReader.ReadColourR1G1B1();
            flashColor = binaryReader.ReadColourR1G1B1();
            emptyColor = binaryReader.ReadColourA1R1G1B1();
            flags = (Flags)binaryReader.ReadByte();
            minumumMeterValue = binaryReader.ReadByte();
            sequenceIndex0 = binaryReader.ReadInt16();
            alphaMultiplier = binaryReader.ReadByte();
            alphaBias = binaryReader.ReadByte();
            valueScale = binaryReader.ReadInt16();
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            disabledColor0 = binaryReader.ReadColourA1R1G1B1();
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            invalidName_8 = binaryReader.ReadBytes(4);
            minimumFractionCutoff = binaryReader.ReadSingle();
            flags0 = (Flags)binaryReader.ReadByte();
            invalidName_9 = binaryReader.ReadBytes(24);
            invalidName_10 = binaryReader.ReadBytes(64);
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
            gNullBlock = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_8[0].ReadPointers(binaryReader, blamPointers);
            invalidName_8[1].ReadPointers(binaryReader, blamPointers);
            invalidName_8[2].ReadPointers(binaryReader, blamPointers);
            invalidName_8[3].ReadPointers(binaryReader, blamPointers);
            invalidName_9[0].ReadPointers(binaryReader, blamPointers);
            invalidName_9[1].ReadPointers(binaryReader, blamPointers);
            invalidName_9[2].ReadPointers(binaryReader, blamPointers);
            invalidName_9[3].ReadPointers(binaryReader, blamPointers);
            invalidName_9[4].ReadPointers(binaryReader, blamPointers);
            invalidName_9[5].ReadPointers(binaryReader, blamPointers);
            invalidName_9[6].ReadPointers(binaryReader, blamPointers);
            invalidName_9[7].ReadPointers(binaryReader, blamPointers);
            invalidName_9[8].ReadPointers(binaryReader, blamPointers);
            invalidName_9[9].ReadPointers(binaryReader, blamPointers);
            invalidName_9[10].ReadPointers(binaryReader, blamPointers);
            invalidName_9[11].ReadPointers(binaryReader, blamPointers);
            invalidName_9[12].ReadPointers(binaryReader, blamPointers);
            invalidName_9[13].ReadPointers(binaryReader, blamPointers);
            invalidName_9[14].ReadPointers(binaryReader, blamPointers);
            invalidName_9[15].ReadPointers(binaryReader, blamPointers);
            invalidName_9[16].ReadPointers(binaryReader, blamPointers);
            invalidName_9[17].ReadPointers(binaryReader, blamPointers);
            invalidName_9[18].ReadPointers(binaryReader, blamPointers);
            invalidName_9[19].ReadPointers(binaryReader, blamPointers);
            invalidName_9[20].ReadPointers(binaryReader, blamPointers);
            invalidName_9[21].ReadPointers(binaryReader, blamPointers);
            invalidName_9[22].ReadPointers(binaryReader, blamPointers);
            invalidName_9[23].ReadPointers(binaryReader, blamPointers);
            invalidName_10[0].ReadPointers(binaryReader, blamPointers);
            invalidName_10[1].ReadPointers(binaryReader, blamPointers);
            invalidName_10[2].ReadPointers(binaryReader, blamPointers);
            invalidName_10[3].ReadPointers(binaryReader, blamPointers);
            invalidName_10[4].ReadPointers(binaryReader, blamPointers);
            invalidName_10[5].ReadPointers(binaryReader, blamPointers);
            invalidName_10[6].ReadPointers(binaryReader, blamPointers);
            invalidName_10[7].ReadPointers(binaryReader, blamPointers);
            invalidName_10[8].ReadPointers(binaryReader, blamPointers);
            invalidName_10[9].ReadPointers(binaryReader, blamPointers);
            invalidName_10[10].ReadPointers(binaryReader, blamPointers);
            invalidName_10[11].ReadPointers(binaryReader, blamPointers);
            invalidName_10[12].ReadPointers(binaryReader, blamPointers);
            invalidName_10[13].ReadPointers(binaryReader, blamPointers);
            invalidName_10[14].ReadPointers(binaryReader, blamPointers);
            invalidName_10[15].ReadPointers(binaryReader, blamPointers);
            invalidName_10[16].ReadPointers(binaryReader, blamPointers);
            invalidName_10[17].ReadPointers(binaryReader, blamPointers);
            invalidName_10[18].ReadPointers(binaryReader, blamPointers);
            invalidName_10[19].ReadPointers(binaryReader, blamPointers);
            invalidName_10[20].ReadPointers(binaryReader, blamPointers);
            invalidName_10[21].ReadPointers(binaryReader, blamPointers);
            invalidName_10[22].ReadPointers(binaryReader, blamPointers);
            invalidName_10[23].ReadPointers(binaryReader, blamPointers);
            invalidName_10[24].ReadPointers(binaryReader, blamPointers);
            invalidName_10[25].ReadPointers(binaryReader, blamPointers);
            invalidName_10[26].ReadPointers(binaryReader, blamPointers);
            invalidName_10[27].ReadPointers(binaryReader, blamPointers);
            invalidName_10[28].ReadPointers(binaryReader, blamPointers);
            invalidName_10[29].ReadPointers(binaryReader, blamPointers);
            invalidName_10[30].ReadPointers(binaryReader, blamPointers);
            invalidName_10[31].ReadPointers(binaryReader, blamPointers);
            invalidName_10[32].ReadPointers(binaryReader, blamPointers);
            invalidName_10[33].ReadPointers(binaryReader, blamPointers);
            invalidName_10[34].ReadPointers(binaryReader, blamPointers);
            invalidName_10[35].ReadPointers(binaryReader, blamPointers);
            invalidName_10[36].ReadPointers(binaryReader, blamPointers);
            invalidName_10[37].ReadPointers(binaryReader, blamPointers);
            invalidName_10[38].ReadPointers(binaryReader, blamPointers);
            invalidName_10[39].ReadPointers(binaryReader, blamPointers);
            invalidName_10[40].ReadPointers(binaryReader, blamPointers);
            invalidName_10[41].ReadPointers(binaryReader, blamPointers);
            invalidName_10[42].ReadPointers(binaryReader, blamPointers);
            invalidName_10[43].ReadPointers(binaryReader, blamPointers);
            invalidName_10[44].ReadPointers(binaryReader, blamPointers);
            invalidName_10[45].ReadPointers(binaryReader, blamPointers);
            invalidName_10[46].ReadPointers(binaryReader, blamPointers);
            invalidName_10[47].ReadPointers(binaryReader, blamPointers);
            invalidName_10[48].ReadPointers(binaryReader, blamPointers);
            invalidName_10[49].ReadPointers(binaryReader, blamPointers);
            invalidName_10[50].ReadPointers(binaryReader, blamPointers);
            invalidName_10[51].ReadPointers(binaryReader, blamPointers);
            invalidName_10[52].ReadPointers(binaryReader, blamPointers);
            invalidName_10[53].ReadPointers(binaryReader, blamPointers);
            invalidName_10[54].ReadPointers(binaryReader, blamPointers);
            invalidName_10[55].ReadPointers(binaryReader, blamPointers);
            invalidName_10[56].ReadPointers(binaryReader, blamPointers);
            invalidName_10[57].ReadPointers(binaryReader, blamPointers);
            invalidName_10[58].ReadPointers(binaryReader, blamPointers);
            invalidName_10[59].ReadPointers(binaryReader, blamPointers);
            invalidName_10[60].ReadPointers(binaryReader, blamPointers);
            invalidName_10[61].ReadPointers(binaryReader, blamPointers);
            invalidName_10[62].ReadPointers(binaryReader, blamPointers);
            invalidName_10[63].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 16);
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
                binaryWriter.Write(meterBitmap);
                binaryWriter.Write(colorAtMeterMinimum);
                binaryWriter.Write(colorAtMeterMaximum);
                binaryWriter.Write(flashColor);
                binaryWriter.Write(emptyColor);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(minumumMeterValue);
                binaryWriter.Write(sequenceIndex0);
                binaryWriter.Write(alphaMultiplier);
                binaryWriter.Write(alphaBias);
                binaryWriter.Write(valueScale);
                binaryWriter.Write(opacity);
                binaryWriter.Write(translucency);
                binaryWriter.Write(disabledColor0);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                binaryWriter.Write(invalidName_8, 0, 4);
                binaryWriter.Write(minimumFractionCutoff);
                binaryWriter.Write((Byte)flags0);
                binaryWriter.Write(invalidName_9, 0, 24);
                binaryWriter.Write(invalidName_10, 0, 64);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            IntegratedLight = 0,
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
        internal enum Flags : byte
        {
            UseMinMaxForStateChanges = 1,
            InterpolateBetweenMinMaxFlashColorsAsStateChanges = 2,
            InterpolateColorAlongHsvSpace = 4,
            MoreColorsForHsvInterpolation = 8,
            InvertInterpolation = 16,
        };
        [FlagsAttribute]
        internal enum Flags0 : int
        {
            ShowOnlyWhenActive = 1,
            FlashOnceIfActivatedWhileDisabled = 2,
        };
    };
}
