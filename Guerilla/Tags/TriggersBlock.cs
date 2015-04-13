using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TriggersBlock : TriggersBlockBase
    {
        public  TriggersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class TriggersBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal TriggerFlags triggerFlags;
        internal CombinationRule combinationRule;
        internal byte[] invalidName_;
        internal OrderCompletionCondition[] conditions;
        internal  TriggersBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.triggerFlags = (TriggerFlags)binaryReader.ReadInt32();
            this.combinationRule = (CombinationRule)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.conditions = ReadOrderCompletionConditionArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual OrderCompletionCondition[] ReadOrderCompletionConditionArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OrderCompletionCondition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OrderCompletionCondition[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OrderCompletionCondition(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum TriggerFlags : int
        
        {
            LatchONWhenTriggered = 1,
        };
        internal enum CombinationRule : short
        
        {
            OR = 0,
            AND = 1,
        };
    };
}
