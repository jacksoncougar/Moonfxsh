// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiScenarioMissionDialogueBlock : AiScenarioMissionDialogueBlockBase
    {
        public  AiScenarioMissionDialogueBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiScenarioMissionDialogueBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AiScenarioMissionDialogueBlockBase : GuerillaBlock
    {
        [TagReference("mdlg")]
        internal Moonfish.Tags.TagReference missionDialogue;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiScenarioMissionDialogueBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            missionDialogue = binaryReader.ReadTagReference();
        }
        public  AiScenarioMissionDialogueBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(missionDialogue);
                return nextAddress;
            }
        }
    };
}
