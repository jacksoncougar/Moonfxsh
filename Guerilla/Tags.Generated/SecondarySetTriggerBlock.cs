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
    public partial class SecondarySetTriggerBlock : SecondarySetTriggerBlockBase
    {
        public SecondarySetTriggerBlock() : base()
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

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SecondarySetTriggerBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            combinationRule = (CombinationRule) binaryReader.ReadInt16();
            dialogueType =
                (DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType) binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<TriggerReferences>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            triggers = ReadBlockArrayData<TriggerReferences>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) combinationRule);
                binaryWriter.Write((Int16) dialogueType);
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