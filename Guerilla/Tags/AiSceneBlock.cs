using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiSceneBlock : AiSceneBlockBase
    {
        public  AiSceneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class AiSceneBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal AiSceneTriggerBlock[] triggerConditions;
        internal AiSceneRoleBlock[] roles;
        internal  AiSceneBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.triggerConditions = ReadAiSceneTriggerBlockArray(binaryReader);
            this.roles = ReadAiSceneRoleBlockArray(binaryReader);
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
        internal  virtual AiSceneTriggerBlock[] ReadAiSceneTriggerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiSceneTriggerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiSceneTriggerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiSceneTriggerBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiSceneRoleBlock[] ReadAiSceneRoleBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiSceneRoleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiSceneRoleBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiSceneRoleBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            SceneCanPlayMultipleTimes = 1,
            EnableCombatDialogue = 2,
        };
    };
}
