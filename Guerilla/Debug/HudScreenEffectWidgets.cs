// ReSharper disable All
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
        public  HudScreenEffectWidgets(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  HudScreenEffectWidgetsBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            hudWidgetInputsStruct = new HudWidgetInputsStructBlock(binaryReader);
            hudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock(binaryReader);
            anchor = (Anchor)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            bitmap = binaryReader.ReadTagReference();
            fullscreenScreenEffect = binaryReader.ReadTagReference();
            waa = new ScreenEffectBonusStructBlock(binaryReader);
            fullscreenSequenceIndex = binaryReader.ReadByte();
            halfscreenSequenceIndex = binaryReader.ReadByte();
            quarterscreenSequenceIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            fullscreenOffset = binaryReader.ReadPoint();
            halfscreenOffset = binaryReader.ReadPoint();
            quarterscreenOffset = binaryReader.ReadPoint();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                hudWidgetInputsStruct.Write(binaryWriter);
                hudWidgetStateDefinitionStruct.Write(binaryWriter);
                binaryWriter.Write((Int16)anchor);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(fullscreenScreenEffect);
                waa.Write(binaryWriter);
                binaryWriter.Write(fullscreenSequenceIndex);
                binaryWriter.Write(halfscreenSequenceIndex);
                binaryWriter.Write(quarterscreenSequenceIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(fullscreenOffset);
                binaryWriter.Write(halfscreenOffset);
                binaryWriter.Write(quarterscreenOffset);
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
            Unused = 1,
        };
    };
}
