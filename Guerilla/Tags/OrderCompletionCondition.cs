// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class OrderCompletionCondition : OrderCompletionConditionBase
    {
        public  OrderCompletionCondition(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class OrderCompletionConditionBase  : IGuerilla
    {
        internal RuleType ruleType;
        internal Moonfish.Tags.ShortBlockIndex1 squad;
        internal Moonfish.Tags.ShortBlockIndex1 squadGroup;
        internal short a;
        internal float x;
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal byte[] invalidName_;
        internal Moonfish.Tags.String32 exitConditionScript;
        internal short invalidName_0;
        internal byte[] invalidName_1;
        internal Flags flags;
        internal  OrderCompletionConditionBase(BinaryReader binaryReader)
        {
            ruleType = (RuleType)binaryReader.ReadInt16();
            squad = binaryReader.ReadShortBlockIndex1();
            squadGroup = binaryReader.ReadShortBlockIndex1();
            a = binaryReader.ReadInt16();
            x = binaryReader.ReadSingle();
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            exitConditionScript = binaryReader.ReadString32();
            invalidName_0 = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)ruleType);
                binaryWriter.Write(squad);
                binaryWriter.Write(squadGroup);
                binaryWriter.Write(a);
                binaryWriter.Write(x);
                binaryWriter.Write(triggerVolume);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(exitConditionScript);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write((Int32)flags);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum RuleType : short
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
        };
        [FlagsAttribute]
        internal enum Flags : int
        {
            NOT = 1,
        };
    };
}
