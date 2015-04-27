// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

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
        public  AiDialogueGlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiDialogueGlobalsBlock(): base()
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
        
        public override int SerializedSize{get { return 44; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiDialogueGlobalsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vocalizations = Guerilla.ReadBlockArray<VocalizationDefinitionsBlock0>(binaryReader);
            patterns = Guerilla.ReadBlockArray<VocalizationPatternsBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(12);
            dialogueData = Guerilla.ReadBlockArray<DialogueDataBlock>(binaryReader);
            involuntaryData = Guerilla.ReadBlockArray<InvoluntaryDataBlock>(binaryReader);
        }
        public  AiDialogueGlobalsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
