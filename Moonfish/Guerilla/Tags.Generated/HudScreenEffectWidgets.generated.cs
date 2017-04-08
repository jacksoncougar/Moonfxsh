//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class HudScreenEffectWidgets : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public HudWidgetInputsStructBlock HudWidgetInputsStruct = new HudWidgetInputsStructBlock();
        public HudWidgetStateDefinitionStructBlock HudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock();
        public AnchorEnum Anchor;
        public Flags HudScreenEffectWidgetsFlags;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference Bitmap;
        [Moonfish.Tags.TagReferenceAttribute("egor")]
        public Moonfish.Tags.TagReference FullscreenScreenEffect;
        public ScreenEffectBonusStructBlock Waa = new ScreenEffectBonusStructBlock();
        public byte FullscreenSequenceIndex;
        public byte HalfscreenSequenceIndex;
        public byte QuarterscreenSequenceIndex;
        private byte[] fieldpad = new byte[1];
        public Moonfish.Tags.Point FullscreenOffset;
        public Moonfish.Tags.Point HalfscreenOffset;
        public Moonfish.Tags.Point QuarterscreenOffset;
        public override int SerializedSize
        {
            get
            {
                return 80;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadStringIdent();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.HudWidgetInputsStruct.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.HudWidgetStateDefinitionStruct.ReadFields(binaryReader)));
            this.Anchor = ((AnchorEnum)(binaryReader.ReadInt16()));
            this.HudScreenEffectWidgetsFlags = ((Flags)(binaryReader.ReadInt16()));
            this.Bitmap = binaryReader.ReadTagReference();
            this.FullscreenScreenEffect = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Waa.ReadFields(binaryReader)));
            this.FullscreenSequenceIndex = binaryReader.ReadByte();
            this.HalfscreenSequenceIndex = binaryReader.ReadByte();
            this.QuarterscreenSequenceIndex = binaryReader.ReadByte();
            this.fieldpad = binaryReader.ReadBytes(1);
            this.FullscreenOffset = binaryReader.ReadPoint();
            this.HalfscreenOffset = binaryReader.ReadPoint();
            this.QuarterscreenOffset = binaryReader.ReadPoint();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.HudWidgetInputsStruct.ReadInstances(binaryReader, pointerQueue);
            this.HudWidgetStateDefinitionStruct.ReadInstances(binaryReader, pointerQueue);
            this.Waa.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.HudWidgetInputsStruct.QueueWrites(queueableBinaryWriter);
            this.HudWidgetStateDefinitionStruct.QueueWrites(queueableBinaryWriter);
            this.Waa.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            this.HudWidgetInputsStruct.Write_(queueableBinaryWriter);
            this.HudWidgetStateDefinitionStruct.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.Anchor)));
            queueableBinaryWriter.Write(((short)(this.HudScreenEffectWidgetsFlags)));
            queueableBinaryWriter.Write(this.Bitmap);
            queueableBinaryWriter.Write(this.FullscreenScreenEffect);
            this.Waa.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.FullscreenSequenceIndex);
            queueableBinaryWriter.Write(this.HalfscreenSequenceIndex);
            queueableBinaryWriter.Write(this.QuarterscreenSequenceIndex);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.FullscreenOffset);
            queueableBinaryWriter.Write(this.HalfscreenOffset);
            queueableBinaryWriter.Write(this.QuarterscreenOffset);
        }
        public enum AnchorEnum : short
        {
            HealthAndShield = 0,
            WeaponHud = 1,
            MotionSensor = 2,
            Scoreboard = 3,
            Crosshair = 4,
            LockonTarget = 5,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Unused = 1,
        }
    }
}
