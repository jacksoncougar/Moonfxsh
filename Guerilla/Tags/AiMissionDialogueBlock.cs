using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mdlg")]
    public  partial class AiMissionDialogueBlock : AiMissionDialogueBlockBase
    {
        public  AiMissionDialogueBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class AiMissionDialogueBlockBase
    {
        internal MissionDialogueLinesBlock[] lines;
        internal  AiMissionDialogueBlockBase(BinaryReader binaryReader)
        {
            this.lines = ReadMissionDialogueLinesBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual MissionDialogueLinesBlock[] ReadMissionDialogueLinesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MissionDialogueLinesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MissionDialogueLinesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MissionDialogueLinesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}