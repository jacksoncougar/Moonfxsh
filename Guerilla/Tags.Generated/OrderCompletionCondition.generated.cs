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
    
    public partial class OrderCompletionCondition : GuerillaBlock, IWriteQueueable
    {
        public RuleTypeEnum RuleType;
        public Moonfish.Tags.ShortBlockIndex1 Squad;
        public Moonfish.Tags.ShortBlockIndex1 SquadGroup;
        public short A;
        public float X;
        public Moonfish.Tags.ShortBlockIndex1 TriggerVolume;
        private byte[] fieldpad = new byte[2];
        public Moonfish.Tags.String32 ExitConditionScript;
        public short FieldShortInteger;
        private byte[] fieldpad0 = new byte[2];
        public Flags OrderCompletionConditionFlags;
        public override int SerializedSize
        {
            get
            {
                return 56;
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
            this.RuleType = ((RuleTypeEnum)(binaryReader.ReadInt16()));
            this.Squad = binaryReader.ReadShortBlockIndex1();
            this.SquadGroup = binaryReader.ReadShortBlockIndex1();
            this.A = binaryReader.ReadInt16();
            this.X = binaryReader.ReadSingle();
            this.TriggerVolume = binaryReader.ReadShortBlockIndex1();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ExitConditionScript = binaryReader.ReadString32();
            this.FieldShortInteger = binaryReader.ReadInt16();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.OrderCompletionConditionFlags = ((Flags)(binaryReader.ReadInt32()));
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
            queueableBinaryWriter.Write(((short)(this.RuleType)));
            queueableBinaryWriter.Write(this.Squad);
            queueableBinaryWriter.Write(this.SquadGroup);
            queueableBinaryWriter.Write(this.A);
            queueableBinaryWriter.Write(this.X);
            queueableBinaryWriter.Write(this.TriggerVolume);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.ExitConditionScript);
            queueableBinaryWriter.Write(this.FieldShortInteger);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(((int)(this.OrderCompletionConditionFlags)));
        }
        public enum RuleTypeEnum : short
        {
            AOrGreaterAlive = 0,
            AOrFewerAlive = 1,
            XOrGreaterStrength = 2,
            XOrLessStrength = 3,
            IfEnemySighted = 4,
            AfterATicks = 5,
            IfAlertedBySquadA = 6,
            ScriptRefTRUE = 7,
            ScriptRefFALSE = 8,
            IfPlayerInTriggerVolume = 9,
            IfALLPlayersInTriggerVolume = 10,
            CombatStatusAOrMore = 11,
            CombatStatusAOrLess = 12,
            Arrived = 13,
            InVehicle = 14,
            SightedPlayer = 15,
            AOrGreaterFighting = 16,
            AOrFewerFighting = 17,
            PlayerWithinXWorldUnits = 18,
            PlayerShotMoreThanXSecondsAgo = 19,
            GameSafeToSave = 20,
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            NOT = 1,
        }
    }
}
