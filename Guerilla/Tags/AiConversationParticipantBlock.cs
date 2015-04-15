// ReSharper disable All
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
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class AiConversationParticipantBlockBase  : IGuerilla
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
            invalidName_ = binaryReader.ReadBytes(8);
            useThisObject = binaryReader.ReadShortBlockIndex1();
            setNewName = binaryReader.ReadShortBlockIndex1();
            invalidName_0 = binaryReader.ReadBytes(12);
            invalidName_1 = binaryReader.ReadBytes(12);
            encounterName = binaryReader.ReadString32();
            invalidName_2 = binaryReader.ReadBytes(4);
            invalidName_3 = binaryReader.ReadBytes(12);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(useThisObject);
                binaryWriter.Write(setNewName);
                binaryWriter.Write(invalidName_0, 0, 12);
                binaryWriter.Write(invalidName_1, 0, 12);
                binaryWriter.Write(encounterName);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(invalidName_3, 0, 12);
                return nextAddress;
            }
        }
    };
}
