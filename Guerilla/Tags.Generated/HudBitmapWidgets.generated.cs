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
    
    public partial class HudBitmapWidgets : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public HudWidgetInputsStructBlock HudWidgetInputsStruct = new HudWidgetInputsStructBlock();
        public HudWidgetStateDefinitionStructBlock HudWidgetStateDefinitionStruct = new HudWidgetStateDefinitionStructBlock();
        public AnchorEnum Anchor;
        public Flags HudBitmapWidgetsFlags;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference Bitmap;
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference Shader;
        public byte FullscreenSequenceIndex;
        public byte HalfscreenSequenceIndex;
        public byte QuarterscreenSequenceIndex;
        private byte[] fieldpad = new byte[1];
        public Moonfish.Tags.Point FullscreenOffset;
        public Moonfish.Tags.Point HalfscreenOffset;
        public Moonfish.Tags.Point QuarterscreenOffset;
        public OpenTK.Vector2 FullscreenRegistrationPoint;
        public OpenTK.Vector2 HalfscreenRegistrationPoint;
        public OpenTK.Vector2 QuarterscreenRegistrationPoint;
        public HudWidgetEffectBlock[] Effect = new HudWidgetEffectBlock[0];
        public SpecialHudTypeEnum SpecialHudType;
        private byte[] fieldpad0 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 100;
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
            this.Name = binaryReader.ReadStringID();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.HudWidgetInputsStruct.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.HudWidgetStateDefinitionStruct.ReadFields(binaryReader)));
            this.Anchor = ((AnchorEnum)(binaryReader.ReadInt16()));
            this.HudBitmapWidgetsFlags = ((Flags)(binaryReader.ReadInt16()));
            this.Bitmap = binaryReader.ReadTagReference();
            this.Shader = binaryReader.ReadTagReference();
            this.FullscreenSequenceIndex = binaryReader.ReadByte();
            this.HalfscreenSequenceIndex = binaryReader.ReadByte();
            this.QuarterscreenSequenceIndex = binaryReader.ReadByte();
            this.fieldpad = binaryReader.ReadBytes(1);
            this.FullscreenOffset = binaryReader.ReadPoint();
            this.HalfscreenOffset = binaryReader.ReadPoint();
            this.QuarterscreenOffset = binaryReader.ReadPoint();
            this.FullscreenRegistrationPoint = binaryReader.ReadVector2();
            this.HalfscreenRegistrationPoint = binaryReader.ReadVector2();
            this.QuarterscreenRegistrationPoint = binaryReader.ReadVector2();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(104));
            this.SpecialHudType = ((SpecialHudTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.HudWidgetInputsStruct.ReadInstances(binaryReader, pointerQueue);
            this.HudWidgetStateDefinitionStruct.ReadInstances(binaryReader, pointerQueue);
            this.Effect = base.ReadBlockArrayData<HudWidgetEffectBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.HudWidgetInputsStruct.QueueWrites(queueableBinaryWriter);
            this.HudWidgetStateDefinitionStruct.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Effect);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            this.HudWidgetInputsStruct.Write_(queueableBinaryWriter);
            this.HudWidgetStateDefinitionStruct.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.Anchor)));
            queueableBinaryWriter.Write(((short)(this.HudBitmapWidgetsFlags)));
            queueableBinaryWriter.Write(this.Bitmap);
            queueableBinaryWriter.Write(this.Shader);
            queueableBinaryWriter.Write(this.FullscreenSequenceIndex);
            queueableBinaryWriter.Write(this.HalfscreenSequenceIndex);
            queueableBinaryWriter.Write(this.QuarterscreenSequenceIndex);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.FullscreenOffset);
            queueableBinaryWriter.Write(this.HalfscreenOffset);
            queueableBinaryWriter.Write(this.QuarterscreenOffset);
            queueableBinaryWriter.Write(this.FullscreenRegistrationPoint);
            queueableBinaryWriter.Write(this.HalfscreenRegistrationPoint);
            queueableBinaryWriter.Write(this.QuarterscreenRegistrationPoint);
            queueableBinaryWriter.WritePointer(this.Effect);
            queueableBinaryWriter.Write(((short)(this.SpecialHudType)));
            queueableBinaryWriter.Write(this.fieldpad0);
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
            FlipHorizontally = 1,
            FlipVertically = 2,
            scopeMirrorHorizontally = 4,
            scopeMirrorVertically = 8,
            scopeStretch = 16,
        }
        public enum SpecialHudTypeEnum : short
        {
            Unspecial = 0,
            SbPlayerEmblem = 1,
            SbOtherPlayerEmblem = 2,
            SbPlayerScoreMeter = 3,
            SbOtherPlayerScoreMeter = 4,
            UnitShieldMeter = 5,
            MotionSensor = 6,
            TerritoryMeter = 7,
        }
    }
}