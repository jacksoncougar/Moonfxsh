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
    public partial class SingleAnimationReferenceBlock : SingleAnimationReferenceBlockBase
    {
        public SingleAnimationReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SingleAnimationReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal int animationPeriodMilliseconds;
        internal ScreenAnimationKeyframeReferenceBlock[] keyframes;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SingleAnimationReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            animationPeriodMilliseconds = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScreenAnimationKeyframeReferenceBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            keyframes = ReadBlockArrayData<ScreenAnimationKeyframeReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(animationPeriodMilliseconds);
                nextAddress = Guerilla.WriteBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryWriter, keyframes,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };
    };
}