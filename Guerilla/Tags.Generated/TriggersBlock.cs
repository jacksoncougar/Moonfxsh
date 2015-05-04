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
    public partial class TriggersBlock : TriggersBlockBase
    {
        public TriggersBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class TriggersBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal TriggerFlags triggerFlags;
        internal CombinationRule combinationRule;
        internal byte[] invalidName_;
        internal OrderCompletionCondition[] conditions;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 4; } }
        public TriggersBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            triggerFlags = (TriggerFlags)binaryReader.ReadInt32();
            combinationRule = (CombinationRule)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<OrderCompletionCondition>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            conditions = ReadBlockArrayData<OrderCompletionCondition>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)triggerFlags);
                binaryWriter.Write((Int16)combinationRule);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<OrderCompletionCondition>(binaryWriter, conditions, nextAddress);
                return nextAddress;
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
