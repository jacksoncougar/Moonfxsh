// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiScenarioMissionDialogueBlock : AiScenarioMissionDialogueBlockBase
    {
        public  AiScenarioMissionDialogueBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AiScenarioMissionDialogueBlockBase  : IGuerilla
    {
        [TagReference("mdlg")]
        internal Moonfish.Tags.TagReference missionDialogue;
        internal  AiScenarioMissionDialogueBlockBase(BinaryReader binaryReader)
        {
            missionDialogue = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(missionDialogue);
                return nextAddress;
            }
        }
    };
}
