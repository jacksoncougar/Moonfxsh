// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudScreenEffectWidgets : HudScreenEffectWidgetsBase
    {
        public HudScreenEffectWidgets() : base()
        {
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class HudScreenEffectWidgetsBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
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
        public override int SerializedSize { get { return 80; } }
        public override int Alignment { get { return 4; } }
        public HudScreenEffectWidgetsBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            hudWidgetInputsStruct = new HudWidgetInputsStructBlock();
            blamPointers.Concat(hudWidgetInputsStruct.ReadFields(binaryReader));
            hudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock();
            blamPointers.Concat(hudWidgetStateDefinitionStruct.ReadFields(binaryReader));
            anchor = (Anchor)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            bitmap = binaryReader.ReadTagReference();
            fullscreenScreenEffect = binaryReader.ReadTagReference();
            waa = new ScreenEffectBonusStructBlock();
            blamPointers.Concat(waa.ReadFields(binaryReader));
            fullscreenSequenceIndex = binaryReader.ReadByte();
            halfscreenSequenceIndex = binaryReader.ReadByte();
            quarterscreenSequenceIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            fullscreenOffset = binaryReader.ReadPoint();
            halfscreenOffset = binaryReader.ReadPoint();
            quarterscreenOffset = binaryReader.ReadPoint();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            hudWidgetInputsStruct.ReadPointers(binaryReader, blamPointers);
            hudWidgetStateDefinitionStruct.ReadPointers(binaryReader, blamPointers);
            waa.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
            Unused = 1,
        };
    };
}
