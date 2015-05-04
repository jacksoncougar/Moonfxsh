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
    public partial class SoundPermutationDialogueInfoBlock : SoundPermutationDialogueInfoBlockBase
    {
        public SoundPermutationDialogueInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundPermutationDialogueInfoBlockBase : GuerillaBlock
    {
        internal int mouthDataOffset;
        internal int mouthDataLength;
        internal int lipsyncDataOffset;
        internal int lipsyncDataLength;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundPermutationDialogueInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            mouthDataOffset = binaryReader.ReadInt32();
            mouthDataLength = binaryReader.ReadInt32();
            lipsyncDataOffset = binaryReader.ReadInt32();
            lipsyncDataLength = binaryReader.ReadInt32();
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
                binaryWriter.Write(mouthDataOffset);
                binaryWriter.Write(mouthDataLength);
                binaryWriter.Write(lipsyncDataOffset);
                binaryWriter.Write(lipsyncDataLength);
                return nextAddress;
            }
        }
    };
}