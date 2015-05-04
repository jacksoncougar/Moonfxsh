// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiSceneBlock : AiSceneBlockBase
    {
        public AiSceneBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AiSceneBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Flags flags;
        internal AiSceneTriggerBlock[] triggerConditions;
        internal AiSceneRoleBlock[] roles;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public AiSceneBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<AiSceneTriggerBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiSceneRoleBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            triggerConditions = ReadBlockArrayData<AiSceneTriggerBlock>(binaryReader, blamPointers.Dequeue());
            roles = ReadBlockArrayData<AiSceneRoleBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
