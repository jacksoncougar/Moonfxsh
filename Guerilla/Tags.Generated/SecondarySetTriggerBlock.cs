// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SecondarySetTriggerBlock : SecondarySetTriggerBlockBase
    {
        public  SecondarySetTriggerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SecondarySetTriggerBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SecondarySetTriggerBlockBase : GuerillaBlock
    {
        internal CombinationRule combinationRule;
        /// <summary>
        /// when this ending is triggered, launch a dialogue event of the given type
        /// </summary>
        internal DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType dialogueType;
        internal TriggerReferences[] triggers;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SecondarySetTriggerBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            combinationRule = (CombinationRule)binaryReader.ReadInt16();
            dialogueType = (DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType)binaryReader.ReadInt16();
            triggers = Guerilla.ReadBlockArray<TriggerReferences>(binaryReader);
        }
        public  SecondarySetTriggerBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            combinationRule = (CombinationRule)binaryReader.ReadInt16();
            dialogueType = (DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType)binaryReader.ReadInt16();
            triggers = Guerilla.ReadBlockArray<TriggerReferences>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)combinationRule);
                binaryWriter.Write((Int16)dialogueType);
                nextAddress = Guerilla.WriteBlockArray<TriggerReferences>(binaryWriter, triggers, nextAddress);
                return nextAddress;
            }
        }
        internal enum CombinationRule : short
        {
            OR = 0,
            AND = 1,
        };
        internal enum DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType : short
        {
            None = 0,
            Advance = 1,
            Charge = 2,
            FallBack = 3,
            Retreat = 4,
            Moveone = 5,
            Arrival = 6,
            EnterVehicle = 7,
            ExitVehicle = 8,
            FollowPlayer = 9,
            LeavePlayer = 10,
            Support = 11,
        };
    };
}
