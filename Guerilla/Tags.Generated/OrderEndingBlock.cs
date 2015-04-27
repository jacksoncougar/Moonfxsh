// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OrderEndingBlock : OrderEndingBlockBase
    {
        public OrderEndingBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
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

        internal OrderEndingBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            nextOrder = binaryReader.ReadShortBlockIndex1( );
            combinationRule = ( CombinationRule ) binaryReader.ReadInt16( );
            delayTime = binaryReader.ReadSingle( );
            dialogueType =
                ( DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            triggers = Guerilla.ReadBlockArray<TriggerReferences>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( nextOrder );
                binaryWriter.Write( ( Int16 ) combinationRule );
                binaryWriter.Write( delayTime );
                binaryWriter.Write( ( Int16 ) dialogueType );
                binaryWriter.Write( invalidName_, 0, 2 );
                nextAddress = Guerilla.WriteBlockArray<TriggerReferences>( binaryWriter, triggers, nextAddress );
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