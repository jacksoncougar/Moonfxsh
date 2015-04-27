// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterVocalizationBlock : CharacterVocalizationBlockBase
    {
        public  CharacterVocalizationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class CharacterVocalizationBlockBase : GuerillaBlock
    {
        /// <summary>
        /// How long does the player look at an AI before the AI responds?
        /// </summary>
        internal float lookCommentTimeS;
        /// <summary>
        /// How long does the player look at the AI before he responds with his 'long look' comment?
        /// </summary>
        internal float lookLongCommentTimeS;
        
        public override int SerializedSize{get { return 8; }}
        
        internal  CharacterVocalizationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            lookCommentTimeS = binaryReader.ReadSingle();
            lookLongCommentTimeS = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(lookCommentTimeS);
                binaryWriter.Write(lookLongCommentTimeS);
                return nextAddress;
            }
        }
    };
}
