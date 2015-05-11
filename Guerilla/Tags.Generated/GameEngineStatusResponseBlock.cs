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
    public partial class GameEngineStatusResponseBlock : GameEngineStatusResponseBlockBase
    {
        public GameEngineStatusResponseBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class GameEngineStatusResponseBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal State state;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringIdent ffaMessage;
        internal Moonfish.Tags.StringIdent teamMessage;
        [TagReference("null")] internal Moonfish.Tags.TagReference invalidName_1;
        internal byte[] invalidName_2;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GameEngineStatusResponseBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            state = (State) binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            ffaMessage = binaryReader.ReadStringID();
            teamMessage = binaryReader.ReadStringID();
            invalidName_1 = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadBytes(4);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16) state);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(ffaMessage);
                binaryWriter.Write(teamMessage);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2, 0, 4);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            Unused = 1,
        };

        internal enum State : short
        {
            WaitingForSpaceToClear = 0,
            Observing = 1,
            RespawningSoon = 2,
            SittingOut = 3,
            OutOfLives = 4,
            PlayingWinning = 5,
            PlayingTied = 6,
            PlayingLosing = 7,
            GameOverWon = 8,
            GameOverTied = 9,
            GameOverLost = 10,
            YouHaveFlag = 11,
            EnemyHasFlag = 12,
            FlagNotHome = 13,
            CarryingOddball = 14,
            YouAreJuggy = 15,
            YouControlHill = 16,
            SwitchingSidesSoon = 17,
            PlayerRecentlyStarted = 18,
            YouHaveBomb = 19,
            FlagContested = 20,
            BombContested = 21,
            LimitedLivesLeftMultiple = 22,
            LimitedLivesLeftSingle = 23,
            LimitedLivesLeftFinal = 24,
            PlayingWinningUnlimited = 25,
            PlayingTiedUnlimited = 26,
            PlayingLosingUnlimited = 27,
        };
    };
}