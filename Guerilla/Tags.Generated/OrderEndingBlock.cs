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
    public partial class OrderEndingBlock : OrderEndingBlockBase
    {
        public OrderEndingBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class OrderEndingBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 nextOrder;
        internal CombinationRule combinationRule;
        internal float delayTime;

        /// <summary>
        /// when this ending is triggered, launch a dialogue event of the given type
        /// </summary>
        internal DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType dialogueType;

        internal byte[] invalidName_;
        internal TriggerReferences[] triggers;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public OrderEndingBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            nextOrder = binaryReader.ReadShortBlockIndex1();
            combinationRule = (CombinationRule) binaryReader.ReadInt16();
            delayTime = binaryReader.ReadSingle();
            dialogueType =
                (DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(nextOrder);
                binaryWriter.Write((Int16) combinationRule);
                binaryWriter.Write(delayTime);
                binaryWriter.Write((Int16) dialogueType);
                binaryWriter.Write(invalidName_, 0, 2);
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