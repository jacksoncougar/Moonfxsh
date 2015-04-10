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
    [LayoutAttribute(Size = 12)]
    public class AiSceneTriggerBlockBase
    {
        internal CombinationRule combinationRule;
        internal byte[] invalidName_;
        internal TriggerReferences[] triggers;
        internal  AiSceneTriggerBlockBase(BinaryReader binaryReader)
        {
            this.combinationRule = (CombinationRule)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.triggers = ReadTriggerReferencesArray(binaryReader);
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
        internal  virtual TriggerReferences[] ReadTriggerReferencesArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TriggerReferences));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TriggerReferences[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TriggerReferences(binaryReader);
                }
            }
            return array;
        }
        internal enum CombinationRule : short
        
        {
            OR = 0,
            AND = 1,
        };
    };
}
