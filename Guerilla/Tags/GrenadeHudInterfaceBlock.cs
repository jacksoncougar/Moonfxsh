using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("grhi")]
    public  partial class GrenadeHudInterfaceBlock : GrenadeHudInterfaceBlockBase
    {
        public  GrenadeHudInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 464)]
    public class GrenadeHudInterfaceBlockBase
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
        internal  GrenadeHudInterfaceBlockBase(BinaryReader binaryReader)
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
            this.defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod1 = binaryReader.ReadSingle();
            this.flashDelay1 = binaryReader.ReadSingle();
            this.numberOfFlashes1 = binaryReader.ReadInt16();
            this.flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength1 = binaryReader.ReadSingle();
            this.disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_13 = binaryReader.ReadBytes(4);
            this.maximumNumberOfDigits = binaryReader.ReadByte();
            this.flags = (Flags)binaryReader.ReadByte();
            this.numberOfFractionalDigits = binaryReader.ReadByte();
            this.invalidName_14 = binaryReader.ReadBytes(1);
            this.invalidName_15 = binaryReader.ReadBytes(12);
            this.flashCutoff = binaryReader.ReadInt16();
            this.invalidName_16 = binaryReader.ReadBytes(2);
            this.overlayBitmap = binaryReader.ReadTagReference();
            this.overlays = ReadGrenadeHudOverlayBlockArray(binaryReader);
            this.warningSounds = ReadGrenadeHudSoundBlockArray(binaryReader);
            this.invalidName_17 = binaryReader.ReadBytes(68);
            this.sequenceIndex1 = binaryReader.ReadInt16();
            this.widthOffset = binaryReader.ReadInt16();
            this.offsetFromReferenceCorner = binaryReader.ReadPoint();
            this.overrideIconColor = binaryReader.ReadColourA1R1G1B1();
            this.frameRate030 = binaryReader.ReadByte();
            this.flags0 = (Flags)binaryReader.ReadByte();
            this.textIndex = binaryReader.ReadInt16();
            this.invalidName_18 = binaryReader.ReadBytes(48);
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
        internal  virtual GrenadeHudOverlayBlock[] ReadGrenadeHudOverlayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GrenadeHudOverlayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GrenadeHudOverlayBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GrenadeHudOverlayBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GrenadeHudSoundBlock[] ReadGrenadeHudSoundBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GrenadeHudSoundBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GrenadeHudSoundBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GrenadeHudSoundBlock(binaryReader);
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
