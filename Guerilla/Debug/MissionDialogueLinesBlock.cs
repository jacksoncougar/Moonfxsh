// ReSharper disable All
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
        public  MissionDialogueLinesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class MissionDialogueLinesBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal MissionDialogueVariantsBlock[] variants;
        internal Moonfish.Tags.StringID defaultSoundEffect;
        internal  MissionDialogueLinesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            ReadMissionDialogueVariantsBlockArray(binaryReader);
            defaultSoundEffect = binaryReader.ReadStringID();
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
        internal  virtual MissionDialogueVariantsBlock[] ReadMissionDialogueVariantsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MissionDialogueVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MissionDialogueVariantsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MissionDialogueVariantsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMissionDialogueVariantsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                WriteMissionDialogueVariantsBlockArray(binaryWriter);
                binaryWriter.Write(defaultSoundEffect);
            }
        }
    };
}
