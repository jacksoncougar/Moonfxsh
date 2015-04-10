using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudScreenEffectWidgets : HudScreenEffectWidgetsBase
    {
        public  HudScreenEffectWidgets(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class HudScreenEffectWidgetsBase
    {
        internal Moonfish.Tags.StringID name;
        internal HudWidgetInputsStructBlock hudWidgetInputsStruct;
        internal HudWidgetStateDefinitionStructBlock hudWidgetStateDefinitionStruct;
        internal Anchor anchor;
        internal Flags flags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference fullscreenScreenEffect;
        internal ScreenEffectBonusStructBlock waa;
        internal byte fullscreenSequenceIndex;
        internal byte halfscreenSequenceIndex;
        internal byte quarterscreenSequenceIndex;
        internal byte[] invalidName_;
        internal Moonfish.Tags.Point fullscreenOffset;
        internal Moonfish.Tags.Point halfscreenOffset;
        internal Moonfish.Tags.Point quarterscreenOffset;
        internal  HudScreenEffectWidgetsBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.hudWidgetInputsStruct = new HudWidgetInputsStructBlock(binaryReader);
            this.hudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock(binaryReader);
            this.anchor = (Anchor)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.bitmap = binaryReader.ReadTagReference();
            this.fullscreenScreenEffect = binaryReader.ReadTagReference();
            this.waa = new ScreenEffectBonusStructBlock(binaryReader);
            this.fullscreenSequenceIndex = binaryReader.ReadByte();
            this.halfscreenSequenceIndex = binaryReader.ReadByte();
            this.quarterscreenSequenceIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.fullscreenOffset = binaryReader.ReadPoint();
            this.halfscreenOffset = binaryReader.ReadPoint();
            this.quarterscreenOffset = binaryReader.ReadPoint();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
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
            Unused = 1,
        };
    };
}
