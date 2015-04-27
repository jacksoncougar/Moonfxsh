// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitHudAuxilaryPanelBlock : UnitHudAuxilaryPanelBlockBase
    {
        public  UnitHudAuxilaryPanelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitHudAuxilaryPanelBlock(): base()
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
        internal Moonfish.Tags.RGBColor colorAtMeterMinimum;
        internal Moonfish.Tags.RGBColor colorAtMeterMaximum;
        internal Moonfish.Tags.RGBColor flashColor;
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
        
        public override int SerializedSize{get { return 297; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitHudAuxilaryPanelBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
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
            multitexOverlay = Guerilla.ReadBlockArray<GlobalHudMultitextureOverlayDefinition>(binaryReader);
            invalidName_5 = binaryReader.ReadBytes(4);
            anchorOffset0 = binaryReader.ReadPoint();
            widthScale0 = binaryReader.ReadSingle();
            heightScale0 = binaryReader.ReadSingle();
            scalingFlags0 = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_6 = binaryReader.ReadBytes(2);
            invalidName_7 = binaryReader.ReadBytes(20);
            meterBitmap = binaryReader.ReadTagReference();
            colorAtMeterMinimum = binaryReader.ReadRGBColor();
            colorAtMeterMaximum = binaryReader.ReadRGBColor();
            flashColor = binaryReader.ReadRGBColor();
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
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            invalidName_8 = binaryReader.ReadBytes(4);
            minimumFractionCutoff = binaryReader.ReadSingle();
            flags0 = (Flags)binaryReader.ReadByte();
            invalidName_9 = binaryReader.ReadBytes(24);
            invalidName_10 = binaryReader.ReadBytes(64);
        }
        public  UnitHudAuxilaryPanelBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
