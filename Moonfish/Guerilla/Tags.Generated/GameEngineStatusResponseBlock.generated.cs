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
    
    public partial class GameEngineStatusResponseBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags GameEngineStatusResponseFlags;
        private byte[] fieldpad = new byte[2];
        public StateEnum State;
        private byte[] fieldpad0 = new byte[2];
        public Moonfish.Tags.StringIdent FfaMessage;
        public Moonfish.Tags.StringIdent TeamMessage;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference;
        private byte[] fieldpad1 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 28;
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
            this.GameEngineStatusResponseFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.State = ((StateEnum)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.FfaMessage = binaryReader.ReadStringIdent();
            this.TeamMessage = binaryReader.ReadStringIdent();
            this.TagReference = binaryReader.ReadTagReference();
            this.fieldpad1 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.GameEngineStatusResponseFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((short)(this.State)));
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.FfaMessage);
            queueableBinaryWriter.Write(this.TeamMessage);
            queueableBinaryWriter.Write(this.TagReference);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Unused = 1,
        }
        public enum StateEnum : short
        {
            WaitingForSpaceToClear = 0,
            Observing = 1,
            RespawningSoon = 2,
            SittingOut = 3,
            OutOfLives = 4,
            Playingwinning = 5,
            Playingtied = 6,
            Playinglosing = 7,
            GameOverwon = 8,
            GameOvertied = 9,
            GameOverlost = 10,
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
            LimitedLivesLeftmultiple = 22,
            LimitedLivesLeftsingle = 23,
            LimitedLivesLeftfinal = 24,
            PlayingwinningUnlimited = 25,
            PlayingtiedUnlimited = 26,
            PlayinglosingUnlimited = 27,
        }
    }
}
