// ReSharper disable All
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
        public  CharacterVocalizationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterVocalizationBlockBase(System.IO.BinaryReader binaryReader)
        {
            lookCommentTimeS = binaryReader.ReadSingle();
            lookLongCommentTimeS = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(lookCommentTimeS);
                binaryWriter.Write(lookLongCommentTimeS);
            }
        }
    };
}
