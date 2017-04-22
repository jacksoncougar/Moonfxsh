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
    [TagBlockOriginalNameAttribute("game_engine_general_event_block")]
    public partial class GameEngineGeneralEventBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags GameEngineGeneralEventFlags;
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
        public SoundFlags GameEngineGeneralEventSoundFlags;
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
            this.GameEngineGeneralEventFlags = ((Flags)(binaryReader.ReadInt16()));
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
            this.GameEngineGeneralEventSoundFlags = ((SoundFlags)(binaryReader.ReadInt16()));
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
            queueableBinaryWriter.Write(((short)(this.GameEngineGeneralEventFlags)));
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
            queueableBinaryWriter.Write(((short)(this.GameEngineGeneralEventSoundFlags)));
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
            Kill = 0,
            Suicide = 1,
            KillTeammate = 2,
            Victory = 3,
            TeamVictory = 4,
            Unused1 = 5,
            Unused2 = 6,
            _1MinToWin = 7,
            Team1MinToWin = 8,
            _30SecsToWin = 9,
            Team30SecsToWin = 10,
            PlayerQuit = 11,
            PlayerJoined = 12,
            KilledByUnknown = 13,
            _30MinutesLeft = 14,
            _15MinutesLeft = 15,
            _5MinutesLeft = 16,
            _1MinuteLeft = 17,
            TimeExpired = 18,
            GameOver = 19,
            RespawnTick = 20,
            LastRespawnTick = 21,
            TeleporterUsed = 22,
            PlayerChangedTeam = 23,
            PlayerRejoined = 24,
            GainedLead = 25,
            GainedTeamLead = 26,
            LostLead = 27,
            LostTeamLead = 28,
            TiedLeader = 29,
            TiedTeamLeader = 30,
            RoundOver = 31,
            _30SecondsLeft = 32,
            _10SecondsLeft = 33,
            Killfalling = 34,
            Killcollision = 35,
            Killmelee = 36,
            SuddenDeath = 37,
            PlayerBootedPlayer = 38,
            KillflagCarrier = 39,
            KillbombCarrier = 40,
            KillstickyGrenade = 41,
            Killsniper = 42,
            KillstMelee = 43,
            BoardedVehicle = 44,
            StartTeamNoti = 45,
            Telefrag = 46,
            _10SecsToWin = 47,
            Team10SecsToWin = 48,
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
