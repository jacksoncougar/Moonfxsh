using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiConversationParticipantBlock : AiConversationParticipantBlockBase
    {
        public  AiConversationParticipantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class AiConversationParticipantBlockBase
    {
        internal byte[] invalidName_;
        /// <summary>
        /// if a unit with this name exists, we try to pick them to start the conversation
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 useThisObject;
        /// <summary>
        /// once we pick a unit, we name it this
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 setNewName;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.String32 encounterName;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal  AiConversationParticipantBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(8);
            this.useThisObject = binaryReader.ReadShortBlockIndex1();
            this.setNewName = binaryReader.ReadShortBlockIndex1();
            this.invalidName_0 = binaryReader.ReadBytes(12);
            this.invalidName_1 = binaryReader.ReadBytes(12);
            this.encounterName = binaryReader.ReadString32();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.invalidName_3 = binaryReader.ReadBytes(12);
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
    };
}
