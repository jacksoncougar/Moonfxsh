using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("unhi")]
    public  partial class UnitHudInterfaceBlock : UnitHudInterfaceBlockBase
    {
        public  UnitHudInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1289)]
    public class UnitHudInterfaceBlockBase
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
        internal Moonfish.Tags.RGBColor colorAtMeterMinimum;
        internal Moonfish.Tags.RGBColor colorAtMeterMaximum;
        internal Moonfish.Tags.RGBColor flashColor;
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
        internal Moonfish.Tags.RGBColor overchargeMinimumColor;
        internal Moonfish.Tags.RGBColor overchargeMaximumColor;
        internal Moonfish.Tags.RGBColor overchargeFlashColor;
        internal Moonfish.Tags.RGBColor overchargeEmptyColor;
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
        internal Moonfish.Tags.RGBColor colorAtMeterMinimum0;
        internal Moonfish.Tags.RGBColor colorAtMeterMaximum0;
        internal Moonfish.Tags.RGBColor flashColor0;
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
        internal Moonfish.Tags.RGBColor mediumHealthLeftColor;
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
        internal  UnitHudInterfaceBlockBase(BinaryReader binaryReader)
        {
            this.anchor = (Anchor)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(32);
            this.anchorOffset = binaryReader.ReadPoint();
            this.widthScale = binaryReader.ReadSingle();
            this.heightScale = binaryReader.ReadSingle();
            this.scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(20);
            this.interfaceBitmap = binaryReader.ReadTagReference();
            this.defaultColor = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod = binaryReader.ReadSingle();
            this.flashDelay = binaryReader.ReadSingle();
            this.numberOfFlashes = binaryReader.ReadInt16();
            this.flashFlags = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength = binaryReader.ReadSingle();
            this.disabledColor = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.sequenceIndex = binaryReader.ReadInt16();
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.multitexOverlay = ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.anchorOffset0 = binaryReader.ReadPoint();
            this.widthScale0 = binaryReader.ReadSingle();
            this.heightScale0 = binaryReader.ReadSingle();
            this.scalingFlags0 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_6 = binaryReader.ReadBytes(2);
            this.invalidName_7 = binaryReader.ReadBytes(20);
            this.interfaceBitmap0 = binaryReader.ReadTagReference();
            this.defaultColor0 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor0 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod0 = binaryReader.ReadSingle();
            this.flashDelay0 = binaryReader.ReadSingle();
            this.numberOfFlashes0 = binaryReader.ReadInt16();
            this.flashFlags0 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength0 = binaryReader.ReadSingle();
            this.disabledColor0 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_8 = binaryReader.ReadBytes(4);
            this.sequenceIndex0 = binaryReader.ReadInt16();
            this.invalidName_9 = binaryReader.ReadBytes(2);
            this.multitexOverlay0 = ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            this.invalidName_10 = binaryReader.ReadBytes(4);
            this.anchorOffset1 = binaryReader.ReadPoint();
            this.widthScale1 = binaryReader.ReadSingle();
            this.heightScale1 = binaryReader.ReadSingle();
            this.scalingFlags1 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_11 = binaryReader.ReadBytes(2);
            this.invalidName_12 = binaryReader.ReadBytes(20);
            this.meterBitmap = binaryReader.ReadTagReference();
            this.colorAtMeterMinimum = binaryReader.ReadRGBColor();
            this.colorAtMeterMaximum = binaryReader.ReadRGBColor();
            this.flashColor = binaryReader.ReadRGBColor();
            this.emptyColor = binaryReader.ReadColourA1R1G1B1();
            this.flags = (Flags)binaryReader.ReadByte();
            this.minumumMeterValue = binaryReader.ReadByte();
            this.sequenceIndex1 = binaryReader.ReadInt16();
            this.alphaMultiplier = binaryReader.ReadByte();
            this.alphaBias = binaryReader.ReadByte();
            this.valueScale = binaryReader.ReadInt16();
            this.opacity = binaryReader.ReadSingle();
            this.translucency = binaryReader.ReadSingle();
            this.disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.invalidName_13 = binaryReader.ReadBytes(4);
            this.overchargeMinimumColor = binaryReader.ReadRGBColor();
            this.overchargeMaximumColor = binaryReader.ReadRGBColor();
            this.overchargeFlashColor = binaryReader.ReadRGBColor();
            this.overchargeEmptyColor = binaryReader.ReadRGBColor();
            this.invalidName_14 = binaryReader.ReadBytes(16);
            this.anchorOffset2 = binaryReader.ReadPoint();
            this.widthScale2 = binaryReader.ReadSingle();
            this.heightScale2 = binaryReader.ReadSingle();
            this.scalingFlags2 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_15 = binaryReader.ReadBytes(2);
            this.invalidName_16 = binaryReader.ReadBytes(20);
            this.interfaceBitmap1 = binaryReader.ReadTagReference();
            this.defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod1 = binaryReader.ReadSingle();
            this.flashDelay1 = binaryReader.ReadSingle();
            this.numberOfFlashes1 = binaryReader.ReadInt16();
            this.flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength1 = binaryReader.ReadSingle();
            this.disabledColor2 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_17 = binaryReader.ReadBytes(4);
            this.sequenceIndex2 = binaryReader.ReadInt16();
            this.invalidName_18 = binaryReader.ReadBytes(2);
            this.multitexOverlay1 = ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            this.invalidName_19 = binaryReader.ReadBytes(4);
            this.anchorOffset3 = binaryReader.ReadPoint();
            this.widthScale3 = binaryReader.ReadSingle();
            this.heightScale3 = binaryReader.ReadSingle();
            this.scalingFlags3 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_20 = binaryReader.ReadBytes(2);
            this.invalidName_21 = binaryReader.ReadBytes(20);
            this.meterBitmap0 = binaryReader.ReadTagReference();
            this.colorAtMeterMinimum0 = binaryReader.ReadRGBColor();
            this.colorAtMeterMaximum0 = binaryReader.ReadRGBColor();
            this.flashColor0 = binaryReader.ReadRGBColor();
            this.emptyColor0 = binaryReader.ReadColourA1R1G1B1();
            this.flags0 = (Flags)binaryReader.ReadByte();
            this.minumumMeterValue0 = binaryReader.ReadByte();
            this.sequenceIndex3 = binaryReader.ReadInt16();
            this.alphaMultiplier0 = binaryReader.ReadByte();
            this.alphaBias0 = binaryReader.ReadByte();
            this.valueScale0 = binaryReader.ReadInt16();
            this.opacity0 = binaryReader.ReadSingle();
            this.translucency0 = binaryReader.ReadSingle();
            this.disabledColor3 = binaryReader.ReadColourA1R1G1B1();
            this.gNullBlock0 = ReadGNullBlockArray(binaryReader);
            this.invalidName_22 = binaryReader.ReadBytes(4);
            this.mediumHealthLeftColor = binaryReader.ReadRGBColor();
            this.maxColorHealthFractionCutoff = binaryReader.ReadSingle();
            this.minColorHealthFractionCutoff = binaryReader.ReadSingle();
            this.invalidName_23 = binaryReader.ReadBytes(20);
            this.anchorOffset4 = binaryReader.ReadPoint();
            this.widthScale4 = binaryReader.ReadSingle();
            this.heightScale4 = binaryReader.ReadSingle();
            this.scalingFlags4 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_24 = binaryReader.ReadBytes(2);
            this.invalidName_25 = binaryReader.ReadBytes(20);
            this.interfaceBitmap2 = binaryReader.ReadTagReference();
            this.defaultColor2 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor2 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod2 = binaryReader.ReadSingle();
            this.flashDelay2 = binaryReader.ReadSingle();
            this.numberOfFlashes2 = binaryReader.ReadInt16();
            this.flashFlags2 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength2 = binaryReader.ReadSingle();
            this.disabledColor4 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_26 = binaryReader.ReadBytes(4);
            this.sequenceIndex4 = binaryReader.ReadInt16();
            this.invalidName_27 = binaryReader.ReadBytes(2);
            this.multitexOverlay2 = ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            this.invalidName_28 = binaryReader.ReadBytes(4);
            this.anchorOffset5 = binaryReader.ReadPoint();
            this.widthScale5 = binaryReader.ReadSingle();
            this.heightScale5 = binaryReader.ReadSingle();
            this.scalingFlags5 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_29 = binaryReader.ReadBytes(2);
            this.invalidName_30 = binaryReader.ReadBytes(20);
            this.interfaceBitmap3 = binaryReader.ReadTagReference();
            this.defaultColor3 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor3 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod3 = binaryReader.ReadSingle();
            this.flashDelay3 = binaryReader.ReadSingle();
            this.numberOfFlashes3 = binaryReader.ReadInt16();
            this.flashFlags3 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength3 = binaryReader.ReadSingle();
            this.disabledColor5 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_31 = binaryReader.ReadBytes(4);
            this.sequenceIndex5 = binaryReader.ReadInt16();
            this.invalidName_32 = binaryReader.ReadBytes(2);
            this.multitexOverlay3 = ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            this.invalidName_33 = binaryReader.ReadBytes(4);
            this.invalidName_34 = binaryReader.ReadBytes(32);
            this.anchorOffset6 = binaryReader.ReadPoint();
            this.widthScale6 = binaryReader.ReadSingle();
            this.heightScale6 = binaryReader.ReadSingle();
            this.scalingFlags6 = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_35 = binaryReader.ReadBytes(2);
            this.invalidName_36 = binaryReader.ReadBytes(20);
            this.anchor0 = (Anchor)binaryReader.ReadInt16();
            this.invalidName_37 = binaryReader.ReadBytes(2);
            this.invalidName_38 = binaryReader.ReadBytes(32);
            this.overlays = ReadUnitHudAuxilaryOverlayBlockArray(binaryReader);
            this.invalidName_39 = binaryReader.ReadBytes(16);
            this.sounds = ReadUnitHudSoundBlockArray(binaryReader);
            this.meters = ReadUnitHudAuxilaryPanelBlockArray(binaryReader);
            this.newHud = binaryReader.ReadTagReference();
            this.invalidName_40 = binaryReader.ReadBytes(356);
            this.invalidName_41 = binaryReader.ReadBytes(48);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual GlobalHudMultitextureOverlayDefinition[] ReadGlobalHudMultitextureOverlayDefinitionArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalHudMultitextureOverlayDefinition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalHudMultitextureOverlayDefinition[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalHudMultitextureOverlayDefinition(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UnitHudAuxilaryOverlayBlock[] ReadUnitHudAuxilaryOverlayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitHudAuxilaryOverlayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitHudAuxilaryOverlayBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitHudAuxilaryOverlayBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UnitHudSoundBlock[] ReadUnitHudSoundBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitHudSoundBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitHudSoundBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitHudSoundBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UnitHudAuxilaryPanelBlock[] ReadUnitHudAuxilaryPanelBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UnitHudAuxilaryPanelBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UnitHudAuxilaryPanelBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UnitHudAuxilaryPanelBlock(binaryReader);
                }
            }
            return array;
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
