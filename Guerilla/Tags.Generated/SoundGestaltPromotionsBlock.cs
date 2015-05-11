// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPromotionsBlock : SoundGestaltPromotionsBlockBase
    {
        public SoundGestaltPromotionsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundGestaltPromotionsBlockBase : GuerillaBlock
    {
        internal SoundPromotionRuleBlock[] soundPromotionRules;
        internal SoundPromotionRuntimeTimerBlock[] soundPromotionRuntimeTimers;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundGestaltPromotionsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundPromotionRuleBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundPromotionRuntimeTimerBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(12);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            soundPromotionRules = ReadBlockArrayData<SoundPromotionRuleBlock>(binaryReader, blamPointers.Dequeue());
            soundPromotionRuntimeTimers = ReadBlockArrayData<SoundPromotionRuntimeTimerBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundPromotionRuleBlock>(binaryWriter, soundPromotionRules,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundPromotionRuntimeTimerBlock>(binaryWriter,
                    soundPromotionRuntimeTimers, nextAddress);
                binaryWriter.Write(invalidName_, 0, 12);
                return nextAddress;
            }
        }
    };
}