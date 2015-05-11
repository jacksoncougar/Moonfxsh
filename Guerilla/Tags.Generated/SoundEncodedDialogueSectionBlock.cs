// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEncodedDialogueSectionBlock : SoundEncodedDialogueSectionBlockBase
    {
        public SoundEncodedDialogueSectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundEncodedDialogueSectionBlockBase : GuerillaBlock
    {
        internal byte[] encodedData;
        internal SoundPermutationDialogueInfoBlock[] soundDialogueInfo;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundEncodedDialogueSectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundPermutationDialogueInfoBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            encodedData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            soundDialogueInfo = ReadBlockArrayData<SoundPermutationDialogueInfoBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, encodedData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundPermutationDialogueInfoBlock>(binaryWriter,
                    soundDialogueInfo, nextAddress);
                return nextAddress;
            }
        }
    };
}