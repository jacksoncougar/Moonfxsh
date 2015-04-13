using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudTextWidgets : HudTextWidgetsBase
    {
        public  HudTextWidgets(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class HudTextWidgetsBase
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
        internal  HudTextWidgetsBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.hudWidgetInputsStruct = new HudWidgetInputsStructBlock(binaryReader);
            this.hudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock(binaryReader);
            this.anchor = (Anchor)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.shader = binaryReader.ReadTagReference();
            this._string = binaryReader.ReadStringID();
            this.justification = (Justification)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.fullscreenFontIndex = (FullscreenFontIndex)binaryReader.ReadByte();
            this.halfscreenFontIndex = (HalfscreenFontIndex)binaryReader.ReadByte();
            this.quarterscreenFontIndex = (QuarterscreenFontIndex)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(1);
            this.fullscreenScale = binaryReader.ReadSingle();
            this.halfscreenScale = binaryReader.ReadSingle();
            this.quarterscreenScale = binaryReader.ReadSingle();
            this.fullscreenOffset = binaryReader.ReadPoint();
            this.halfscreenOffset = binaryReader.ReadPoint();
            this.quarterscreenOffset = binaryReader.ReadPoint();
            this.effect = ReadHudWidgetEffectBlockArray(binaryReader);
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
        internal  virtual HudWidgetEffectBlock[] ReadHudWidgetEffectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudWidgetEffectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudWidgetEffectBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudWidgetEffectBlock(binaryReader);
                }
            }
            return array;
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
