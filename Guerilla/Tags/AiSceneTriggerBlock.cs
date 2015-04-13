// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiSceneTriggerBlock : AiSceneTriggerBlockBase
    {
        public  AiSceneTriggerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class AiSceneTriggerBlockBase  : IGuerilla
    {
        internal CombinationRule combinationRule;
        internal byte[] invalidName_;
        internal TriggerReferences[] triggers;
        internal  AiSceneTriggerBlockBase(BinaryReader binaryReader)
        {
            combinationRule = (CombinationRule)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            triggers = Guerilla.ReadBlockArray<TriggerReferences>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)combinationRule);
                binaryWriter.Write(invalidName_, 0, 2);
                Guerilla.WriteBlockArray<TriggerReferences>(binaryWriter, triggers, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum CombinationRule : short
        {
            OR = 0,
            AND = 1,
        };
    };
}
