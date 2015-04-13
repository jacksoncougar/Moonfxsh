using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitHudAuxilaryPanelBlock : UnitHudAuxilaryPanelBlockBase
    {
        public  UnitHudAuxilaryPanelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 297)]
    public class UnitHudAuxilaryPanelBlockBase
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
        internal  UnitHudAuxilaryPanelBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(16);
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
            this.meterBitmap = binaryReader.ReadTagReference();
            this.colorAtMeterMinimum = binaryReader.ReadRGBColor();
            this.colorAtMeterMaximum = binaryReader.ReadRGBColor();
            this.flashColor = binaryReader.ReadRGBColor();
            this.emptyColor = binaryReader.ReadColourA1R1G1B1();
            this.flags = (Flags)binaryReader.ReadByte();
            this.minumumMeterValue = binaryReader.ReadByte();
            this.sequenceIndex0 = binaryReader.ReadInt16();
            this.alphaMultiplier = binaryReader.ReadByte();
            this.alphaBias = binaryReader.ReadByte();
            this.valueScale = binaryReader.ReadInt16();
            this.opacity = binaryReader.ReadSingle();
            this.translucency = binaryReader.ReadSingle();
            this.disabledColor0 = binaryReader.ReadColourA1R1G1B1();
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.invalidName_8 = binaryReader.ReadBytes(4);
            this.minimumFractionCutoff = binaryReader.ReadSingle();
            this.flags0 = (Flags)binaryReader.ReadByte();
            this.invalidName_9 = binaryReader.ReadBytes(24);
            this.invalidName_10 = binaryReader.ReadBytes(64);
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
