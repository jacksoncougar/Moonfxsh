// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GameEngineGeneralEventBlock : GameEngineGeneralEventBlockBase
    {
        public GameEngineGeneralEventBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 168, Alignment = 4)]
    public class GameEngineGeneralEventBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Event _event;
        internal Audience audience;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.StringIdent displayString;
        internal RequiredField requiredField;
        internal ExcludedAudience excludedAudience;
        internal Moonfish.Tags.StringIdent primaryString;
        internal int primaryStringDurationSeconds;
        internal Moonfish.Tags.StringIdent pluralDisplayString;
        internal byte[] invalidName_2;
        internal float soundDelayAnnouncerOnly;
        internal SoundFlags soundFlags;
        internal byte[] invalidName_3;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference sound;
        internal SoundResponseExtraSoundsStructBlock extraSounds;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal SoundResponseDefinitionBlock[] soundPermutations;

        public override int SerializedSize
        {
            get { return 168; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GameEngineGeneralEventBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            _event = (Event) binaryReader.ReadInt16();
            audience = (Audience) binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
            displayString = binaryReader.ReadStringID();
            requiredField = (RequiredField) binaryReader.ReadInt16();
            excludedAudience = (ExcludedAudience) binaryReader.ReadInt16();
            primaryString = binaryReader.ReadStringID();
            primaryStringDurationSeconds = binaryReader.ReadInt32();
            pluralDisplayString = binaryReader.ReadStringID();
            invalidName_2 = binaryReader.ReadBytes(28);
            soundDelayAnnouncerOnly = binaryReader.ReadSingle();
            soundFlags = (SoundFlags) binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            sound = binaryReader.ReadTagReference();
            extraSounds = new SoundResponseExtraSoundsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(extraSounds.ReadFields(binaryReader)));
            invalidName_4 = binaryReader.ReadBytes(4);
            invalidName_5 = binaryReader.ReadBytes(16);
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundResponseDefinitionBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            extraSounds.ReadPointers(binaryReader, blamPointers);
            soundPermutations = ReadBlockArrayData<SoundResponseDefinitionBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16) _event);
                binaryWriter.Write((Int16) audience);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(displayString);
                binaryWriter.Write((Int16) requiredField);
                binaryWriter.Write((Int16) excludedAudience);
                binaryWriter.Write(primaryString);
                binaryWriter.Write(primaryStringDurationSeconds);
                binaryWriter.Write(pluralDisplayString);
                binaryWriter.Write(invalidName_2, 0, 28);
                binaryWriter.Write(soundDelayAnnouncerOnly);
                binaryWriter.Write((Int16) soundFlags);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(sound);
                extraSounds.Write(binaryWriter);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(invalidName_5, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<SoundResponseDefinitionBlock>(binaryWriter, soundPermutations,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            QuantityMessage = 1,
        };

        internal enum Event : short
        {
            Kill = 0,
            Suicide = 1,
            KillTeammate = 2,
            Victory = 3,
            TeamVictory = 4,
            Unused1 = 5,
            Unused2 = 6,
            InvalidName1MinToWin = 7,
            Team1MinToWin = 8,
            InvalidName30SecsToWin = 9,
            Team30SecsToWin = 10,
            PlayerQuit = 11,
            PlayerJoined = 12,
            KilledByUnknown = 13,
            InvalidName30MinutesLeft = 14,
            InvalidName15MinutesLeft = 15,
            InvalidName5MinutesLeft = 16,
            InvalidName1MinuteLeft = 17,
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
            InvalidName30SecondsLeft = 32,
            InvalidName10SecondsLeft = 33,
            KillFalling = 34,
            KillCollision = 35,
            KillMelee = 36,
            SuddenDeath = 37,
            PlayerBootedPlayer = 38,
            KillFlagCarrier = 39,
            KillBombCarrier = 40,
            KillStickyGrenade = 41,
            KillSniper = 42,
            KillStMelee = 43,
            BoardedVehicle = 44,
            StartTeamNoti = 45,
            Telefrag = 46,
            InvalidName10SecsToWin = 47,
            Team10SecsToWin = 48,
        };

        internal enum Audience : short
        {
            CausePlayer = 0,
            CauseTeam = 1,
            EffectPlayer = 2,
            EffectTeam = 3,
            All = 4,
        };

        internal enum RequiredField : short
        {
            NONE = 0,
            CausePlayer = 1,
            CauseTeam = 2,
            EffectPlayer = 3,
            EffectTeam = 4,
        };

        internal enum ExcludedAudience : short
        {
            NONE = 0,
            CausePlayer = 1,
            CauseTeam = 2,
            EffectPlayer = 3,
            EffectTeam = 4,
        };

        [FlagsAttribute]
        internal enum SoundFlags : short
        {
            AnnouncerSound = 1,
        };
    };
}