// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudTextWidgets : HudTextWidgetsBase
    {
        public  HudTextWidgets(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class HudTextWidgetsBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal HudWidgetInputsStructBlock hudWidgetInputsStruct;
        internal HudWidgetStateDefinitionStructBlock hudWidgetStateDefinitionStruct;
        internal Anchor anchor;
        internal Flags flags;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal Moonfish.Tags.StringID _string;
        internal Justification justification;
        internal byte[] invalidName_;
        internal FullscreenFontIndex fullscreenFontIndex;
        internal HalfscreenFontIndex halfscreenFontIndex;
        internal QuarterscreenFontIndex quarterscreenFontIndex;
        internal byte[] invalidName_0;
        internal float fullscreenScale;
        internal float halfscreenScale;
        internal float quarterscreenScale;
        internal Moonfish.Tags.Point fullscreenOffset;
        internal Moonfish.Tags.Point halfscreenOffset;
        internal Moonfish.Tags.Point quarterscreenOffset;
        internal HudWidgetEffectBlock[] effect;
        
        public override int SerializedSize{get { return 84; }}
        
        internal  HudTextWidgetsBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            hudWidgetInputsStruct = new HudWidgetInputsStructBlock(binaryReader);
            hudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock(binaryReader);
            anchor = (Anchor)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            shader = binaryReader.ReadTagReference();
            _string = binaryReader.ReadStringID();
            justification = (Justification)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            fullscreenFontIndex = (FullscreenFontIndex)binaryReader.ReadByte();
            halfscreenFontIndex = (HalfscreenFontIndex)binaryReader.ReadByte();
            quarterscreenFontIndex = (QuarterscreenFontIndex)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(1);
            fullscreenScale = binaryReader.ReadSingle();
            halfscreenScale = binaryReader.ReadSingle();
            quarterscreenScale = binaryReader.ReadSingle();
            fullscreenOffset = binaryReader.ReadPoint();
            halfscreenOffset = binaryReader.ReadPoint();
            quarterscreenOffset = binaryReader.ReadPoint();
            effect = Guerilla.ReadBlockArray<HudWidgetEffectBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                hudWidgetInputsStruct.Write(binaryWriter);
                hudWidgetStateDefinitionStruct.Write(binaryWriter);
                binaryWriter.Write((Int16)anchor);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(shader);
                binaryWriter.Write(_string);
                binaryWriter.Write((Int16)justification);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Byte)fullscreenFontIndex);
                binaryWriter.Write((Byte)halfscreenFontIndex);
                binaryWriter.Write((Byte)quarterscreenFontIndex);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(fullscreenScale);
                binaryWriter.Write(halfscreenScale);
                binaryWriter.Write(quarterscreenScale);
                binaryWriter.Write(fullscreenOffset);
                binaryWriter.Write(halfscreenOffset);
                binaryWriter.Write(quarterscreenOffset);
                nextAddress = Guerilla.WriteBlockArray<HudWidgetEffectBlock>(binaryWriter, effect, nextAddress);
                return nextAddress;
            }
        }
        internal enum Anchor : short
        {
            HealthAndShield = 0,
            WeaponHud = 1,
            MotionSensor = 2,
            Scoreboard = 3,
            Crosshair = 4,
            LockOnTarget = 5,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            StringIsANumber = 1,
            Force2DigitNumber = 2,
            Force3DigitNumber = 4,
            TalkingPlayerHack = 8,
        };
        internal enum Justification : short
        {
            Left = 0,
            Center = 1,
            Right = 2,
        };
        internal enum FullscreenFontIndex : byte
        {
            Defualt = 0,
            NumberFont = 1,
        };
        internal enum HalfscreenFontIndex : byte
        {
            Defualt = 0,
            NumberFont = 1,
        };
        internal enum QuarterscreenFontIndex : byte
        {
            Defualt = 0,
            NumberFont = 1,
        };
    };
}
