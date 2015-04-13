using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hudg")]
    public  partial class HudGlobalsBlock : HudGlobalsBlockBase
    {
        public  HudGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1160)]
    public class HudGlobalsBlockBase
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
        internal Moonfish.Tags.TagReference obsolete1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference obsolete2;
        internal float upTime;
        internal float fadeTime;
        internal OpenTK.Vector4 iconColor;
        internal OpenTK.Vector4 textColor;
        internal float textSpacing;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference itemMessageText;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference iconBitmap;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference alternateIconText;
        internal HudButtonIconBlock[] buttonIcons;
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
        [TagReference("hmt ")]
        internal Moonfish.Tags.TagReference hudMessages;
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
        internal short uptimeTicks;
        internal short fadeTicks;
        internal float topOffset;
        internal float bottomOffset;
        internal float leftOffset;
        internal float rightOffset;
        internal byte[] invalidName_4;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference arrowBitmap;
        internal HudWaypointArrowBlock[] waypointArrows;
        internal byte[] invalidName_5;
        internal float hudScaleInMultiplayer;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal float motionSensorRange;
        /// <summary>
        /// how fast something moves to show up on the motion sensor
        /// </summary>
        internal float motionSensorVelocitySensitivity;
        internal float motionSensorScaleDONTTOUCHEVER;
        internal OpenTK.Vector2 defaultChapterTitleBounds;
        internal byte[] invalidName_8;
        internal short topOffset0;
        internal short bottomOffset0;
        internal short leftOffset0;
        internal short rightOffset0;
        internal byte[] invalidName_9;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference indicatorBitmap;
        internal short sequenceIndex;
        internal short multiplayerSequenceIndex;
        internal Moonfish.Tags.ColourA1R1G1B1 color;
        internal byte[] invalidName_10;
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
        internal byte[] invalidName_11;
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
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor2;
        internal byte[] invalidName_12;
        internal byte[] invalidName_13;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference carnageReportBitmap;
        internal short loadingBeginText;
        internal short loadingEndText;
        internal short checkpointBeginText;
        internal short checkpointEndText;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference checkpointSound;
        internal byte[] invalidName_14;
        internal GlobalNewHudGlobalsStructBlock newGlobals;
        internal  HudGlobalsBlockBase(BinaryReader binaryReader)
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
            this.obsolete1 = binaryReader.ReadTagReference();
            this.obsolete2 = binaryReader.ReadTagReference();
            this.upTime = binaryReader.ReadSingle();
            this.fadeTime = binaryReader.ReadSingle();
            this.iconColor = binaryReader.ReadVector4();
            this.textColor = binaryReader.ReadVector4();
            this.textSpacing = binaryReader.ReadSingle();
            this.itemMessageText = binaryReader.ReadTagReference();
            this.iconBitmap = binaryReader.ReadTagReference();
            this.alternateIconText = binaryReader.ReadTagReference();
            this.buttonIcons = ReadHudButtonIconBlockArray(binaryReader);
            this.defaultColor = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod = binaryReader.ReadSingle();
            this.flashDelay = binaryReader.ReadSingle();
            this.numberOfFlashes = binaryReader.ReadInt16();
            this.flashFlags = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength = binaryReader.ReadSingle();
            this.disabledColor = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.hudMessages = binaryReader.ReadTagReference();
            this.defaultColor0 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor0 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod0 = binaryReader.ReadSingle();
            this.flashDelay0 = binaryReader.ReadSingle();
            this.numberOfFlashes0 = binaryReader.ReadInt16();
            this.flashFlags0 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength0 = binaryReader.ReadSingle();
            this.disabledColor0 = binaryReader.ReadColourA1R1G1B1();
            this.uptimeTicks = binaryReader.ReadInt16();
            this.fadeTicks = binaryReader.ReadInt16();
            this.topOffset = binaryReader.ReadSingle();
            this.bottomOffset = binaryReader.ReadSingle();
            this.leftOffset = binaryReader.ReadSingle();
            this.rightOffset = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(32);
            this.arrowBitmap = binaryReader.ReadTagReference();
            this.waypointArrows = ReadHudWaypointArrowBlockArray(binaryReader);
            this.invalidName_5 = binaryReader.ReadBytes(80);
            this.hudScaleInMultiplayer = binaryReader.ReadSingle();
            this.invalidName_6 = binaryReader.ReadBytes(256);
            this.invalidName_7 = binaryReader.ReadBytes(16);
            this.motionSensorRange = binaryReader.ReadSingle();
            this.motionSensorVelocitySensitivity = binaryReader.ReadSingle();
            this.motionSensorScaleDONTTOUCHEVER = binaryReader.ReadSingle();
            this.defaultChapterTitleBounds = binaryReader.ReadVector2();
            this.invalidName_8 = binaryReader.ReadBytes(44);
            this.topOffset0 = binaryReader.ReadInt16();
            this.bottomOffset0 = binaryReader.ReadInt16();
            this.leftOffset0 = binaryReader.ReadInt16();
            this.rightOffset0 = binaryReader.ReadInt16();
            this.invalidName_9 = binaryReader.ReadBytes(32);
            this.indicatorBitmap = binaryReader.ReadTagReference();
            this.sequenceIndex = binaryReader.ReadInt16();
            this.multiplayerSequenceIndex = binaryReader.ReadInt16();
            this.color = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_10 = binaryReader.ReadBytes(16);
            this.defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod1 = binaryReader.ReadSingle();
            this.flashDelay1 = binaryReader.ReadSingle();
            this.numberOfFlashes1 = binaryReader.ReadInt16();
            this.flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength1 = binaryReader.ReadSingle();
            this.disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_11 = binaryReader.ReadBytes(4);
            this.defaultColor2 = binaryReader.ReadColourA1R1G1B1();
            this.flashingColor2 = binaryReader.ReadColourA1R1G1B1();
            this.flashPeriod2 = binaryReader.ReadSingle();
            this.flashDelay2 = binaryReader.ReadSingle();
            this.numberOfFlashes2 = binaryReader.ReadInt16();
            this.flashFlags2 = (FlashFlags)binaryReader.ReadInt16();
            this.flashLength2 = binaryReader.ReadSingle();
            this.disabledColor2 = binaryReader.ReadColourA1R1G1B1();
            this.invalidName_12 = binaryReader.ReadBytes(4);
            this.invalidName_13 = binaryReader.ReadBytes(40);
            this.carnageReportBitmap = binaryReader.ReadTagReference();
            this.loadingBeginText = binaryReader.ReadInt16();
            this.loadingEndText = binaryReader.ReadInt16();
            this.checkpointBeginText = binaryReader.ReadInt16();
            this.checkpointEndText = binaryReader.ReadInt16();
            this.checkpointSound = binaryReader.ReadTagReference();
            this.invalidName_14 = binaryReader.ReadBytes(96);
            this.newGlobals = new GlobalNewHudGlobalsStructBlock(binaryReader);
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
        internal  virtual HudButtonIconBlock[] ReadHudButtonIconBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudButtonIconBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudButtonIconBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudButtonIconBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudWaypointArrowBlock[] ReadHudWaypointArrowBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudWaypointArrowBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudWaypointArrowBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudWaypointArrowBlock(binaryReader);
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
        internal enum FlashFlags0 : short
        
        {
            ReverseDefaultFlashingColors = 1,
        };
        [FlagsAttribute]
        internal enum FlashFlags1 : short
        
        {
            ReverseDefaultFlashingColors = 1,
        };
        [FlagsAttribute]
        internal enum FlashFlags2 : short
        
        {
            ReverseDefaultFlashingColors = 1,
        };
    };
}
