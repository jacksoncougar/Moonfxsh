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
    public partial class AiConversationBlock : AiConversationBlockBase
    {
        public AiConversationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class AiConversationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal byte[] invalidName_;

        /// <summary>
        /// distance the player must enter before the conversation can trigger
        /// </summary>
        internal float triggerDistanceWorldUnits;

        /// <summary>
        /// if the 'involves player' flag is set, when triggered the conversation's participant(s) will run to within this distance of the player
        /// </summary>
        internal float runToPlayerDistWorldUnits;

        internal byte[] invalidName_0;
        internal AiConversationParticipantBlock[] participants;
        internal AiConversationLineBlock[] lines;
        internal GNullBlock[] gNullBlock;

        public override int SerializedSize
        {
            get { return 104; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AiConversationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            triggerDistanceWorldUnits = binaryReader.ReadSingle();
            runToPlayerDistWorldUnits = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(36);
            blamPointers.Enqueue(ReadBlockArrayPointer<AiConversationParticipantBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiConversationLineBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            participants = ReadBlockArrayData<AiConversationParticipantBlock>(binaryReader, blamPointers.Dequeue());
            lines = ReadBlockArrayData<AiConversationLineBlock>(binaryReader, blamPointers.Dequeue());
            gNullBlock = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(triggerDistanceWorldUnits);
                binaryWriter.Write(runToPlayerDistWorldUnits);
                binaryWriter.Write(invalidName_0, 0, 36);
                nextAddress = Guerilla.WriteBlockArray<AiConversationParticipantBlock>(binaryWriter, participants,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiConversationLineBlock>(binaryWriter, lines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            StopIfDeathThisConversationWillBeAbortedIfAnyParticipantDies = 1,
            StopIfDamagedAnActorWillAbortThisConversationIfTheyAreDamaged = 2,
            StopIfVisibleEnemyAnActorWillAbortThisConversationIfTheySeeAnEnemy = 4,
            StopIfAlertedToEnemyAnActorWillAbortThisConversationIfTheySuspectAnEnemy = 8,
            PlayerMustBeVisibleThisConversationCannotTakePlaceUnlessTheParticipantsCanSeeANearbyPlayer = 16,
            StopOtherActionsParticipantsStopDoingWhateverTheyWereDoingInOrderToPerformThisConversation = 32,
            KeepTryingToPlayIfThisConversationFailsInitiallyItWillKeepTestingToSeeWhenItCanPlay = 64,
            PlayerMustBeLookingThisConversationWillNotStartUntilThePlayerIsLookingAtOneOfTheParticipants = 128,
        };
    };
}