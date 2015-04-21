// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiConversationLineBlock : AiConversationLineBlockBase
    {
        public AiConversationLineBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 76, Alignment = 4 )]
    public class AiConversationLineBlockBase : IGuerilla
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 participant;
        internal Addressee addressee;

        /// <summary>
        /// this field is only used if the addressee type is 'participant'
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 addresseeParticipant;

        internal byte[] invalidName_;
        internal float lineDelayTime;
        internal byte[] invalidName_0;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference variant1;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference variant2;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference variant3;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference variant4;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference variant5;
        [TagReference( "snd!" )] internal Moonfish.Tags.TagReference variant6;

        internal AiConversationLineBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt16( );
            participant = binaryReader.ReadShortBlockIndex1( );
            addressee = ( Addressee ) binaryReader.ReadInt16( );
            addresseeParticipant = binaryReader.ReadShortBlockIndex1( );
            invalidName_ = binaryReader.ReadBytes( 4 );
            lineDelayTime = binaryReader.ReadSingle( );
            invalidName_0 = binaryReader.ReadBytes( 12 );
            variant1 = binaryReader.ReadTagReference( );
            variant2 = binaryReader.ReadTagReference( );
            variant3 = binaryReader.ReadTagReference( );
            variant4 = binaryReader.ReadTagReference( );
            variant5 = binaryReader.ReadTagReference( );
            variant6 = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( participant );
                binaryWriter.Write( ( Int16 ) addressee );
                binaryWriter.Write( addresseeParticipant );
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( lineDelayTime );
                binaryWriter.Write( invalidName_0, 0, 12 );
                binaryWriter.Write( variant1 );
                binaryWriter.Write( variant2 );
                binaryWriter.Write( variant3 );
                binaryWriter.Write( variant4 );
                binaryWriter.Write( variant5 );
                binaryWriter.Write( variant6 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            AddresseeLookAtSpeaker = 1,
            EveryoneLookAtSpeaker = 2,
            EveryoneLookAtAddressee = 4,
            WaitAfterUntilToldToAdvance = 8,
            WaitUntilSpeakerNearby = 16,
            WaitUntilEveryoneNearby = 32,
        };

        internal enum Addressee : short
        {
            None = 0,
            Player = 1,
            Participant = 2,
        };
    };
}