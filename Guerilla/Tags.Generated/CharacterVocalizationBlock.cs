// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterVocalizationBlock : CharacterVocalizationBlockBase
    {
        public CharacterVocalizationBlock() : base()
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

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterVocalizationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            lookCommentTimeS = binaryReader.ReadSingle();
            lookLongCommentTimeS = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(lookCommentTimeS);
                binaryWriter.Write(lookLongCommentTimeS);
                return nextAddress;
            }
        }
    };
}