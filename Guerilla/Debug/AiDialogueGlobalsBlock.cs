// ReSharper disable All
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
        public  AiDialogueGlobalsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AiDialogueGlobalsBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadVocalizationDefinitionsBlock0Array(binaryReader);
            ReadVocalizationPatternsBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(12);
            ReadDialogueDataBlockArray(binaryReader);
            ReadInvoluntaryDataBlockArray(binaryReader);
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
        internal  virtual VocalizationDefinitionsBlock0[] ReadVocalizationDefinitionsBlock0Array(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VocalizationDefinitionsBlock0));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VocalizationDefinitionsBlock0[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VocalizationDefinitionsBlock0(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VocalizationPatternsBlock[] ReadVocalizationPatternsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VocalizationPatternsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VocalizationPatternsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VocalizationPatternsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DialogueDataBlock[] ReadDialogueDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DialogueDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DialogueDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DialogueDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual InvoluntaryDataBlock[] ReadInvoluntaryDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InvoluntaryDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InvoluntaryDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InvoluntaryDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVocalizationDefinitionsBlock0Array(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVocalizationPatternsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDialogueDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteInvoluntaryDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteVocalizationDefinitionsBlock0Array(binaryWriter);
                WriteVocalizationPatternsBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 12);
                WriteDialogueDataBlockArray(binaryWriter);
                WriteInvoluntaryDataBlockArray(binaryWriter);
            }
        }
    };
}
