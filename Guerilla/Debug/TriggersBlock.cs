// ReSharper disable All
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
        public  TriggersBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  TriggersBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            triggerFlags = (TriggerFlags)binaryReader.ReadInt32();
            combinationRule = (CombinationRule)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadOrderCompletionConditionArray(binaryReader);
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
        internal  virtual OrderCompletionCondition[] ReadOrderCompletionConditionArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OrderCompletionCondition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OrderCompletionCondition[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OrderCompletionCondition(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOrderCompletionConditionArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)triggerFlags);
                binaryWriter.Write((Int16)combinationRule);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteOrderCompletionConditionArray(binaryWriter);
            }
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
