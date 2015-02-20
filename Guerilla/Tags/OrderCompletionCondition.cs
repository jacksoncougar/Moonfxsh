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
    [LayoutAttribute(Size = 56)]
    public class OrderCompletionConditionBase
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
            this.ruleType = (RuleType)binaryReader.ReadInt16();
            this.squad = binaryReader.ReadShortBlockIndex1();
            this.squadGroup = binaryReader.ReadShortBlockIndex1();
            this.a = binaryReader.ReadInt16();
            this.x = binaryReader.ReadSingle();
            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.exitConditionScript = binaryReader.ReadString32();
            this.invalidName_0 = binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.flags = (Flags)binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
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
