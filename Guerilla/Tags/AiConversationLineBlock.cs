using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiConversationLineBlock : AiConversationLineBlockBase
    {
        public  AiConversationLineBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class AiConversationLineBlockBase
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
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference variant1;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference variant2;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference variant3;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference variant4;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference variant5;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference variant6;
        internal  AiConversationLineBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.participant = binaryReader.ReadShortBlockIndex1();
            this.addressee = (Addressee)binaryReader.ReadInt16();
            this.addresseeParticipant = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.lineDelayTime = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(12);
            this.variant1 = binaryReader.ReadTagReference();
            this.variant2 = binaryReader.ReadTagReference();
            this.variant3 = binaryReader.ReadTagReference();
            this.variant4 = binaryReader.ReadTagReference();
            this.variant5 = binaryReader.ReadTagReference();
            this.variant6 = binaryReader.ReadTagReference();
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
