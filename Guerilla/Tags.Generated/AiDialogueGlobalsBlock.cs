// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Adlg = (TagClass)"adlg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("adlg")]
    public partial class AiDialogueGlobalsBlock : AiDialogueGlobalsBlockBase
    {
        public AiDialogueGlobalsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class AiDialogueGlobalsBlockBase : GuerillaBlock
    {
        internal VocalizationDefinitionsBlock0[] vocalizations;
        internal VocalizationPatternsBlock[] patterns;
        internal byte[] invalidName_;
        internal DialogueDataBlock[] dialogueData;
        internal InvoluntaryDataBlock[] involuntaryData;
        public override int SerializedSize { get { return 44; } }
        public override int Alignment { get { return 4; } }
        public AiDialogueGlobalsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VocalizationDefinitionsBlock0>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VocalizationPatternsBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(12);
            blamPointers.Enqueue(ReadBlockArrayPointer<DialogueDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<InvoluntaryDataBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            vocalizations = ReadBlockArrayData<VocalizationDefinitionsBlock0>(binaryReader, blamPointers.Dequeue());
            patterns = ReadBlockArrayData<VocalizationPatternsBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            dialogueData = ReadBlockArrayData<DialogueDataBlock>(binaryReader, blamPointers.Dequeue());
            involuntaryData = ReadBlockArrayData<InvoluntaryDataBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<VocalizationDefinitionsBlock0>(binaryWriter, vocalizations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VocalizationPatternsBlock>(binaryWriter, patterns, nextAddress);
                binaryWriter.Write(invalidName_, 0, 12);
                nextAddress = Guerilla.WriteBlockArray<DialogueDataBlock>(binaryWriter, dialogueData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<InvoluntaryDataBlock>(binaryWriter, involuntaryData, nextAddress);
                return nextAddress;
            }
        }
    };
}
