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
        public static readonly TagClass Mdlg = (TagClass)"mdlg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mdlg")]
    public partial class AiMissionDialogueBlock : AiMissionDialogueBlockBase
    {
        public  AiMissionDialogueBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiMissionDialogueBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AiMissionDialogueBlockBase : GuerillaBlock
    {
        internal MissionDialogueLinesBlock[] lines;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiMissionDialogueBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            lines = Guerilla.ReadBlockArray<MissionDialogueLinesBlock>(binaryReader);
        }
        public  AiMissionDialogueBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            lines = Guerilla.ReadBlockArray<MissionDialogueLinesBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MissionDialogueLinesBlock>(binaryWriter, lines, nextAddress);
                return nextAddress;
            }
        }
    };
}
