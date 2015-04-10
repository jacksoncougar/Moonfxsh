using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterVocalizationBlock : CharacterVocalizationBlockBase
    {
        public  CharacterVocalizationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class CharacterVocalizationBlockBase
    {
        /// <summary>
        /// How long does the player look at an AI before the AI responds?
        /// </summary>
        internal float lookCommentTimeS;
        /// <summary>
        /// How long does the player look at the AI before he responds with his 'long look' comment?
        /// </summary>
        internal float lookLongCommentTimeS;
        internal  CharacterVocalizationBlockBase(BinaryReader binaryReader)
        {
            this.lookCommentTimeS = binaryReader.ReadSingle();
            this.lookLongCommentTimeS = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
