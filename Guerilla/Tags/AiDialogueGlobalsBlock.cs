using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("adlg")]
    public  partial class AiDialogueGlobalsBlock : AiDialogueGlobalsBlockBase
    {
        public  AiDialogueGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class AiDialogueGlobalsBlockBase
    {
        internal VocalizationDefinitionsBlock0[] vocalizations;
        internal VocalizationPatternsBlock[] patterns;
        internal byte[] invalidName_;
        internal DialogueDataBlock[] dialogueData;
        internal InvoluntaryDataBlock[] involuntaryData;
        internal  AiDialogueGlobalsBlockBase(BinaryReader binaryReader)
        {
            this.vocalizations = ReadVocalizationDefinitionsBlock0Array(binaryReader);
            this.patterns = ReadVocalizationPatternsBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.dialogueData = ReadDialogueDataBlockArray(binaryReader);
            this.involuntaryData = ReadInvoluntaryDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual VocalizationDefinitionsBlock0[] ReadVocalizationDefinitionsBlock0Array(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VocalizationDefinitionsBlock0));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VocalizationDefinitionsBlock0[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VocalizationDefinitionsBlock0(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VocalizationPatternsBlock[] ReadVocalizationPatternsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VocalizationPatternsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VocalizationPatternsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VocalizationPatternsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DialogueDataBlock[] ReadDialogueDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DialogueDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DialogueDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DialogueDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual InvoluntaryDataBlock[] ReadInvoluntaryDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InvoluntaryDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InvoluntaryDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InvoluntaryDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
