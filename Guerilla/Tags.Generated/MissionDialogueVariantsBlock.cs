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
    public partial class MissionDialogueVariantsBlock : MissionDialogueVariantsBlockBase
    {
        public MissionDialogueVariantsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MissionDialogueVariantsBlockBase : GuerillaBlock
    {
        /// <summary>
        /// 3-letter designation for the character^
        /// </summary>
        internal Moonfish.Tags.StringIdent variantDesignation;

        [TagReference("snd!")] internal Moonfish.Tags.TagReference sound;
        internal Moonfish.Tags.StringIdent soundEffect;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MissionDialogueVariantsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            variantDesignation = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
            soundEffect = binaryReader.ReadStringID();
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
                binaryWriter.Write(variantDesignation);
                binaryWriter.Write(sound);
                binaryWriter.Write(soundEffect);
                return nextAddress;
            }
        }
    };
}