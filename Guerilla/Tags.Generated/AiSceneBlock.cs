// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiSceneBlock : AiSceneBlockBase
    {
        public  AiSceneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AiSceneBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal AiSceneTriggerBlock[] triggerConditions;
        internal AiSceneRoleBlock[] roles;
        
        public override int SerializedSize{get { return 24; }}
        
        internal  AiSceneBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt32();
            triggerConditions = Guerilla.ReadBlockArray<AiSceneTriggerBlock>(binaryReader);
            roles = Guerilla.ReadBlockArray<AiSceneRoleBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<AiSceneTriggerBlock>(binaryWriter, triggerConditions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiSceneRoleBlock>(binaryWriter, roles, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            SceneCanPlayMultipleTimes = 1,
            EnableCombatDialogue = 2,
        };
    };
}
