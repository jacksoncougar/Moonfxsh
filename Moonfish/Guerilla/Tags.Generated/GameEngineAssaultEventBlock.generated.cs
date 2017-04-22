//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("game_engine_assault_event_block")]
    public partial class GameEngineAssaultEventBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags GameEngineAssaultEventFlags;
        private byte[] fieldpad = new byte[2];
        public EventEnum Event;
        public AudienceEnum Audience;
        private byte[] fieldpad0 = new byte[2];
        private byte[] fieldpad1 = new byte[2];
        public Moonfish.Tags.StringIdent DisplayString;
        public RequiredFieldEnum RequiredField;
        public ExcludedAudienceEnum ExcludedAudience;
        public Moonfish.Tags.StringIdent PrimaryString;
        public int PrimaryStringDuration;
        public Moonfish.Tags.StringIdent PluralDisplayString;
        private byte[] fieldpad2 = new byte[28];
        public float SoundDelay;
        public SoundFlags GameEngineAssaultEventSoundFlags;
        private byte[] fieldpad3 = new byte[2];
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference Sound;
        public SoundResponseExtraSoundsStructBlock ExtraSounds = new SoundResponseExtraSoundsStructBlock();
        private byte[] fieldpad4 = new byte[4];
        private byte[] fieldpad5 = new byte[16];
        public SoundResponseDefinitionBlock[] SoundPermutations = new SoundResponseDefinitionBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 168;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.GameEngineAssaultEventFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.Event = ((EventEnum)(binaryReader.ReadInt16()));
            this.Audience = ((AudienceEnum)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.fieldpad1 = binaryReader.ReadBytes(2);
            this.DisplayString = binaryReader.ReadStringIdent();
            this.RequiredField = ((RequiredFieldEnum)(binaryReader.ReadInt16()));
            this.ExcludedAudience = ((ExcludedAudienceEnum)(binaryReader.ReadInt16()));
            this.PrimaryString = binaryReader.ReadStringIdent();
            this.PrimaryStringDuration = binaryReader.ReadInt32();
            this.PluralDisplayString = binaryReader.ReadStringIdent();
            this.fieldpad2 = binaryReader.ReadBytes(28);
            this.SoundDelay = binaryReader.ReadSingle();
            this.GameEngineAssaultEventSoundFlags = ((SoundFlags)(binaryReader.ReadInt16()));
            this.fieldpad3 = binaryReader.ReadBytes(2);
            this.Sound = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ExtraSounds.ReadFields(binaryReader)));
            this.fieldpad4 = binaryReader.ReadBytes(4);
            this.fieldpad5 = binaryReader.ReadBytes(16);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(80));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ExtraSounds.ReadInstances(binaryReader, pointerQueue);
            this.SoundPermutations = base.ReadBlockArrayData<SoundResponseDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.ExtraSounds.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.SoundPermutations);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.GameEngineAssaultEventFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((short)(this.Event)));
            queueableBinaryWriter.Write(((short)(this.Audience)));
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.DisplayString);
            queueableBinaryWriter.Write(((short)(this.RequiredField)));
            queueableBinaryWriter.Write(((short)(this.ExcludedAudience)));
            queueableBinaryWriter.Write(this.PrimaryString);
            queueableBinaryWriter.Write(this.PrimaryStringDuration);
            queueableBinaryWriter.Write(this.PluralDisplayString);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.Write(this.SoundDelay);
            queueableBinaryWriter.Write(((short)(this.GameEngineAssaultEventSoundFlags)));
            queueableBinaryWriter.Write(this.fieldpad3);
            queueableBinaryWriter.Write(this.Sound);
            this.ExtraSounds.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad4);
            queueableBinaryWriter.Write(this.fieldpad5);
            queueableBinaryWriter.WritePointer(this.SoundPermutations);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            QuantityMessage = 1,
        }
        public enum EventEnum : short
        {
            GameStart = 0,
            BombTaken = 1,
            BombDropped = 2,
            BombReturnedByPlayer = 3,
            BombReturnedByTimeout = 4,
            BombCaptured = 5,
            BombNewDefensiveTeam = 6,
            BombReturnFaliure = 7,
            SideSwitchTick = 8,
            SideSwitchFinalTick = 9,
            SideSwitch30Seconds = 10,
            SideSwitch10Seconds = 11,
            BombReturnedByDefusing = 12,
            BombPlacedOnEnemyPost = 13,
            BombArmingStarted = 14,
            BombArmingCompleted = 15,
            BombContested = 16,
        }
        public enum AudienceEnum : short
        {
            CausePlayer = 0,
            CauseTeam = 1,
            EffectPlayer = 2,
            EffectTeam = 3,
            All = 4,
        }
        public enum RequiredFieldEnum : short
        {
            NONE = 0,
            CausePlayer = 1,
            CauseTeam = 2,
            EffectPlayer = 3,
            EffectTeam = 4,
        }
        public enum ExcludedAudienceEnum : short
        {
            NONE = 0,
            CausePlayer = 1,
            CauseTeam = 2,
            EffectPlayer = 3,
            EffectTeam = 4,
        }
        [System.FlagsAttribute()]
        public enum SoundFlags : short
        {
            None = 0,
            AnnouncerSound = 1,
        }
    }
}
