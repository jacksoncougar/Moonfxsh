using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MissionDialogueLinesBlock : MissionDialogueLinesBlockBase
    {
        public  MissionDialogueLinesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class MissionDialogueLinesBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal MissionDialogueVariantsBlock[] variants;
        internal Moonfish.Tags.StringID defaultSoundEffect;
        internal  MissionDialogueLinesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.variants = ReadMissionDialogueVariantsBlockArray(binaryReader);
            this.defaultSoundEffect = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual MissionDialogueVariantsBlock[] ReadMissionDialogueVariantsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MissionDialogueVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MissionDialogueVariantsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MissionDialogueVariantsBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
