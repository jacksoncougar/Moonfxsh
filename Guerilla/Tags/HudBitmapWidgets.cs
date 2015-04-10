using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudBitmapWidgets : HudBitmapWidgetsBase
    {
        public  HudBitmapWidgets(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 100)]
    public class HudBitmapWidgetsBase
    {
        internal Moonfish.Tags.StringID name;
        internal HudWidgetInputsStructBlock hudWidgetInputsStruct;
        internal HudWidgetStateDefinitionStructBlock hudWidgetStateDefinitionStruct;
        internal Anchor anchor;
        internal Flags flags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal byte fullscreenSequenceIndex;
        internal byte halfscreenSequenceIndex;
        internal byte quarterscreenSequenceIndex;
        internal byte[] invalidName_;
        internal Moonfish.Tags.Point fullscreenOffset;
        internal Moonfish.Tags.Point halfscreenOffset;
        internal Moonfish.Tags.Point quarterscreenOffset;
        internal OpenTK.Vector2 fullscreenRegistrationPoint;
        internal OpenTK.Vector2 halfscreenRegistrationPoint;
        internal OpenTK.Vector2 quarterscreenRegistrationPoint;
        internal HudWidgetEffectBlock[] effect;
        internal SpecialHudType specialHudType;
        internal byte[] invalidName_0;
        internal  HudBitmapWidgetsBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.hudWidgetInputsStruct = new HudWidgetInputsStructBlock(binaryReader);
            this.hudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock(binaryReader);
            this.anchor = (Anchor)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.bitmap = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            this.fullscreenSequenceIndex = binaryReader.ReadByte();
            this.halfscreenSequenceIndex = binaryReader.ReadByte();
            this.quarterscreenSequenceIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.fullscreenOffset = binaryReader.ReadPoint();
            this.halfscreenOffset = binaryReader.ReadPoint();
            this.quarterscreenOffset = binaryReader.ReadPoint();
            this.fullscreenRegistrationPoint = binaryReader.ReadVector2();
            this.halfscreenRegistrationPoint = binaryReader.ReadVector2();
            this.quarterscreenRegistrationPoint = binaryReader.ReadVector2();
            this.effect = ReadHudWidgetEffectBlockArray(binaryReader);
            this.specialHudType = (SpecialHudType)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
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
        internal  virtual HudWidgetEffectBlock[] ReadHudWidgetEffectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudWidgetEffectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudWidgetEffectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
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
            FlipHorizontally = 1,
            FlipVertically = 2,
            ScopeMirrorHorizontally = 4,
            ScopeMirrorVertically = 8,
            ScopeStretch = 16,
        };
        internal enum SpecialHudType : short
        
        {
            Unspecial = 0,
            SBPlayerEmblem = 1,
            SBOtherPlayerEmblem = 2,
            SBPlayerScoreMeter = 3,
            SBOtherPlayerScoreMeter = 4,
            UnitShieldMeter = 5,
            MotionSensor = 6,
            TerritoryMeter = 7,
        };
    };
}
