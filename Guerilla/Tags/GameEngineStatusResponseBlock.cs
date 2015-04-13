using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GameEngineStatusResponseBlock : GameEngineStatusResponseBlockBase
    {
        public  GameEngineStatusResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class GameEngineStatusResponseBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal State state;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringID ffaMessage;
        internal Moonfish.Tags.StringID teamMessage;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_1;
        internal byte[] invalidName_2;
        internal  GameEngineStatusResponseBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.state = (State)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.ffaMessage = binaryReader.ReadStringID();
            this.teamMessage = binaryReader.ReadStringID();
            this.invalidName_1 = binaryReader.ReadTagReference();
            this.invalidName_2 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
