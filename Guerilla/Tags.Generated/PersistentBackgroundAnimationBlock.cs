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
    public partial class PersistentBackgroundAnimationBlock : PersistentBackgroundAnimationBlockBase
    {
        public PersistentBackgroundAnimationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PersistentBackgroundAnimationBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal int animationPeriodMilliseconds;
        internal BackgroundAnimationKeyframeReferenceBlock[] interpolatedKeyframes;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PersistentBackgroundAnimationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            animationPeriodMilliseconds = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<BackgroundAnimationKeyframeReferenceBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            interpolatedKeyframes = ReadBlockArrayData<BackgroundAnimationKeyframeReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(animationPeriodMilliseconds);
                nextAddress = Guerilla.WriteBlockArray<BackgroundAnimationKeyframeReferenceBlock>(binaryWriter,
                    interpolatedKeyframes, nextAddress);
                return nextAddress;
            }
        }
    };
}