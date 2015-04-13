using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiConversationBlock : AiConversationBlockBase
    {
        public AiConversationBlock(BinaryReader binaryReader)
            : base(binaryReader)
        {

        }
    };
    [LayoutAttribute(Size = 104)]
    public class AiConversationBlockBase
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
        internal AiConversationBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.triggerDistanceWorldUnits = binaryReader.ReadSingle();
            this.runToPlayerDistWorldUnits = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(36);
            this.participants = ReadAiConversationParticipantBlockArray(binaryReader);
            this.lines = ReadAiConversationLineBlockArray(binaryReader);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
        }

        internal virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if (blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal virtual AiConversationParticipantBlock[] ReadAiConversationParticipantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiConversationParticipantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiConversationParticipantBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiConversationParticipantBlock(binaryReader);
                }
            }
            return array;
        }

        public void Write(BinaryWriter binaryWriter, int nextAddress)
        {
            using (binaryWriter.BaseStream.Pin()) { 
                binaryWriter.Write(name);
                binaryWriter.Write((short)flags);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(triggerDistanceWorldUnits);
                binaryWriter.Write(runToPlayerDistWorldUnits);
                binaryWriter.Write(invalidName_0);
            }

        }

        internal virtual AiConversationParticipantBlock[] WriteAiConversationParticipantBlockArray(BinaryWriter binaryWriter, int nextAddress)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiConversationParticipantBlock));
            var count = participants.Length;
            var blamPointer = new BlamPointer(count, nextAddress, elementSize);

            binaryWriter.Write(count);
            binaryWriter.Write(nextAddress);

            var array = new AiConversationParticipantBlock[blamPointer.elementCount];
            using (binaryWriter.BaseStream.Pin())
            {
                for (var i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryWriter.BaseStream.Position = blamPointer[i];
                    //participants[i].Write(binaryWriter);
                }
            }
            return array;
        }

        internal virtual AiConversationLineBlock[] ReadAiConversationLineBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiConversationLineBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiConversationLineBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiConversationLineBlock(binaryReader);
                }
            }
            return array;
        }
        internal virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
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
