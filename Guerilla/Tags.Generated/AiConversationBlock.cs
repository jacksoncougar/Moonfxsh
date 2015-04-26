// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiConversationBlock : AiConversationBlockBase
    {
        public AiConversationBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 104, Alignment = 4 )]
    public class AiConversationBlockBase : IGuerilla
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

        internal AiConversationBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadString32( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            triggerDistanceWorldUnits = binaryReader.ReadSingle( );
            runToPlayerDistWorldUnits = binaryReader.ReadSingle( );
            invalidName_0 = binaryReader.ReadBytes( 36 );
            participants = Guerilla.ReadBlockArray<AiConversationParticipantBlock>( binaryReader );
            lines = Guerilla.ReadBlockArray<AiConversationLineBlock>( binaryReader );
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( triggerDistanceWorldUnits );
                binaryWriter.Write( runToPlayerDistWorldUnits );
                binaryWriter.Write( invalidName_0, 0, 36 );
                nextAddress = Guerilla.WriteBlockArray<AiConversationParticipantBlock>( binaryWriter, participants,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<AiConversationLineBlock>( binaryWriter, lines, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>( binaryWriter, gNullBlock, nextAddress );
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