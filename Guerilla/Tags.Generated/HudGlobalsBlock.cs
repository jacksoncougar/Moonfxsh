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
        public static readonly TagClass Hudg = (TagClass)"hudg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hudg")]
    public partial class HudGlobalsBlock : HudGlobalsBlockBase
    {
        public HudGlobalsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 1160, Alignment = 4)]
    public class HudGlobalsBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 1160; } }
        public override int Alignment { get { return 4; } }
        public HudGlobalsBlockBase() : base()
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
            obsolete1 = binaryReader.ReadTagReference();
            obsolete2 = binaryReader.ReadTagReference();
            upTime = binaryReader.ReadSingle();
            fadeTime = binaryReader.ReadSingle();
            iconColor = binaryReader.ReadVector4();
            textColor = binaryReader.ReadVector4();
            textSpacing = binaryReader.ReadSingle();
            itemMessageText = binaryReader.ReadTagReference();
            iconBitmap = binaryReader.ReadTagReference();
            alternateIconText = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<HudButtonIconBlock>(binaryReader));
            defaultColor = binaryReader.ReadColourA1R1G1B1();
            flashingColor = binaryReader.ReadColourA1R1G1B1();
            flashPeriod = binaryReader.ReadSingle();
            flashDelay = binaryReader.ReadSingle();
            numberOfFlashes = binaryReader.ReadInt16();
            flashFlags = (FlashFlags)binaryReader.ReadInt16();
            flashLength = binaryReader.ReadSingle();
            disabledColor = binaryReader.ReadColourA1R1G1B1();
            invalidName_3 = binaryReader.ReadBytes(4);
            hudMessages = binaryReader.ReadTagReference();
            defaultColor0 = binaryReader.ReadColourA1R1G1B1();
            flashingColor0 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod0 = binaryReader.ReadSingle();
            flashDelay0 = binaryReader.ReadSingle();
            numberOfFlashes0 = binaryReader.ReadInt16();
            flashFlags0 = (FlashFlags)binaryReader.ReadInt16();
            flashLength0 = binaryReader.ReadSingle();
            disabledColor0 = binaryReader.ReadColourA1R1G1B1();
            uptimeTicks = binaryReader.ReadInt16();
            fadeTicks = binaryReader.ReadInt16();
            topOffset = binaryReader.ReadSingle();
            bottomOffset = binaryReader.ReadSingle();
            leftOffset = binaryReader.ReadSingle();
            rightOffset = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(32);
            arrowBitmap = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<HudWaypointArrowBlock>(binaryReader));
            invalidName_5 = binaryReader.ReadBytes(80);
            hudScaleInMultiplayer = binaryReader.ReadSingle();
            invalidName_6 = binaryReader.ReadBytes(256);
            invalidName_7 = binaryReader.ReadBytes(16);
            motionSensorRange = binaryReader.ReadSingle();
            motionSensorVelocitySensitivity = binaryReader.ReadSingle();
            motionSensorScaleDONTTOUCHEVER = binaryReader.ReadSingle();
            defaultChapterTitleBounds = binaryReader.ReadVector2();
            invalidName_8 = binaryReader.ReadBytes(44);
            topOffset0 = binaryReader.ReadInt16();
            bottomOffset0 = binaryReader.ReadInt16();
            leftOffset0 = binaryReader.ReadInt16();
            rightOffset0 = binaryReader.ReadInt16();
            invalidName_9 = binaryReader.ReadBytes(32);
            indicatorBitmap = binaryReader.ReadTagReference();
            sequenceIndex = binaryReader.ReadInt16();
            multiplayerSequenceIndex = binaryReader.ReadInt16();
            color = binaryReader.ReadColourA1R1G1B1();
            invalidName_10 = binaryReader.ReadBytes(16);
            defaultColor1 = binaryReader.ReadColourA1R1G1B1();
            flashingColor1 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod1 = binaryReader.ReadSingle();
            flashDelay1 = binaryReader.ReadSingle();
            numberOfFlashes1 = binaryReader.ReadInt16();
            flashFlags1 = (FlashFlags)binaryReader.ReadInt16();
            flashLength1 = binaryReader.ReadSingle();
            disabledColor1 = binaryReader.ReadColourA1R1G1B1();
            invalidName_11 = binaryReader.ReadBytes(4);
            defaultColor2 = binaryReader.ReadColourA1R1G1B1();
            flashingColor2 = binaryReader.ReadColourA1R1G1B1();
            flashPeriod2 = binaryReader.ReadSingle();
            flashDelay2 = binaryReader.ReadSingle();
            numberOfFlashes2 = binaryReader.ReadInt16();
            flashFlags2 = (FlashFlags)binaryReader.ReadInt16();
            flashLength2 = binaryReader.ReadSingle();
            disabledColor2 = binaryReader.ReadColourA1R1G1B1();
            invalidName_12 = binaryReader.ReadBytes(4);
            invalidName_13 = binaryReader.ReadBytes(40);
            carnageReportBitmap = binaryReader.ReadTagReference();
            loadingBeginText = binaryReader.ReadInt16();
            loadingEndText = binaryReader.ReadInt16();
            checkpointBeginText = binaryReader.ReadInt16();
            checkpointEndText = binaryReader.ReadInt16();
            checkpointSound = binaryReader.ReadTagReference();
            invalidName_14 = binaryReader.ReadBytes(96);
            newGlobals = new GlobalNewHudGlobalsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(newGlobals.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            buttonIcons = ReadBlockArrayData<HudButtonIconBlock>(binaryReader, blamPointers.Dequeue());
            waypointArrows = ReadBlockArrayData<HudWaypointArrowBlock>(binaryReader, blamPointers.Dequeue());
            newGlobals.ReadPointers(binaryReader, blamPointers);
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
                binaryWriter.Write(obsolete1);
                binaryWriter.Write(obsolete2);
                binaryWriter.Write(upTime);
                binaryWriter.Write(fadeTime);
                binaryWriter.Write(iconColor);
                binaryWriter.Write(textColor);
                binaryWriter.Write(textSpacing);
                binaryWriter.Write(itemMessageText);
                binaryWriter.Write(iconBitmap);
                binaryWriter.Write(alternateIconText);
                nextAddress = Guerilla.WriteBlockArray<HudButtonIconBlock>(binaryWriter, buttonIcons, nextAddress);
                binaryWriter.Write(defaultColor);
                binaryWriter.Write(flashingColor);
                binaryWriter.Write(flashPeriod);
                binaryWriter.Write(flashDelay);
                binaryWriter.Write(numberOfFlashes);
                binaryWriter.Write((Int16)flashFlags);
                binaryWriter.Write(flashLength);
                binaryWriter.Write(disabledColor);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(hudMessages);
                binaryWriter.Write(defaultColor0);
                binaryWriter.Write(flashingColor0);
                binaryWriter.Write(flashPeriod0);
                binaryWriter.Write(flashDelay0);
                binaryWriter.Write(numberOfFlashes0);
                binaryWriter.Write((Int16)flashFlags0);
                binaryWriter.Write(flashLength0);
                binaryWriter.Write(disabledColor0);
                binaryWriter.Write(uptimeTicks);
                binaryWriter.Write(fadeTicks);
                binaryWriter.Write(topOffset);
                binaryWriter.Write(bottomOffset);
                binaryWriter.Write(leftOffset);
                binaryWriter.Write(rightOffset);
                binaryWriter.Write(invalidName_4, 0, 32);
                binaryWriter.Write(arrowBitmap);
                nextAddress = Guerilla.WriteBlockArray<HudWaypointArrowBlock>(binaryWriter, waypointArrows, nextAddress);
                binaryWriter.Write(invalidName_5, 0, 80);
                binaryWriter.Write(hudScaleInMultiplayer);
                binaryWriter.Write(invalidName_6, 0, 256);
                binaryWriter.Write(invalidName_7, 0, 16);
                binaryWriter.Write(motionSensorRange);
                binaryWriter.Write(motionSensorVelocitySensitivity);
                binaryWriter.Write(motionSensorScaleDONTTOUCHEVER);
                binaryWriter.Write(defaultChapterTitleBounds);
                binaryWriter.Write(invalidName_8, 0, 44);
                binaryWriter.Write(topOffset0);
                binaryWriter.Write(bottomOffset0);
                binaryWriter.Write(leftOffset0);
                binaryWriter.Write(rightOffset0);
                binaryWriter.Write(invalidName_9, 0, 32);
                binaryWriter.Write(indicatorBitmap);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(multiplayerSequenceIndex);
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_10, 0, 16);
                binaryWriter.Write(defaultColor1);
                binaryWriter.Write(flashingColor1);
                binaryWriter.Write(flashPeriod1);
                binaryWriter.Write(flashDelay1);
                binaryWriter.Write(numberOfFlashes1);
                binaryWriter.Write((Int16)flashFlags1);
                binaryWriter.Write(flashLength1);
                binaryWriter.Write(disabledColor1);
                binaryWriter.Write(invalidName_11, 0, 4);
                binaryWriter.Write(defaultColor2);
                binaryWriter.Write(flashingColor2);
                binaryWriter.Write(flashPeriod2);
                binaryWriter.Write(flashDelay2);
                binaryWriter.Write(numberOfFlashes2);
                binaryWriter.Write((Int16)flashFlags2);
                binaryWriter.Write(flashLength2);
                binaryWriter.Write(disabledColor2);
                binaryWriter.Write(invalidName_12, 0, 4);
                binaryWriter.Write(invalidName_13, 0, 40);
                binaryWriter.Write(carnageReportBitmap);
                binaryWriter.Write(loadingBeginText);
                binaryWriter.Write(loadingEndText);
                binaryWriter.Write(checkpointBeginText);
                binaryWriter.Write(checkpointEndText);
                binaryWriter.Write(checkpointSound);
                binaryWriter.Write(invalidName_14, 0, 96);
                newGlobals.Write(binaryWriter);
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
