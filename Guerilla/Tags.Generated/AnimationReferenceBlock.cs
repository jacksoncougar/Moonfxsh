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
    public partial class AnimationReferenceBlock : AnimationReferenceBlockBase
    {
        public AnimationReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class AnimationReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal int animationPeriodMilliseconds;
        internal ScreenAnimationKeyframeReferenceBlock[] keyframes;
        internal int animationPeriodMilliseconds0;
        internal ScreenAnimationKeyframeReferenceBlock[] keyframes0;
        internal int animationPeriodMilliseconds1;
        internal AmbientAnimationLoopingStyle ambientAnimationLoopingStyle;
        internal byte[] invalidName_;
        internal ScreenAnimationKeyframeReferenceBlock[] keyframes1;

        public override int SerializedSize
        {
            get { return 44; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AnimationReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            animationPeriodMilliseconds = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScreenAnimationKeyframeReferenceBlock>(binaryReader));
            animationPeriodMilliseconds0 = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScreenAnimationKeyframeReferenceBlock>(binaryReader));
            animationPeriodMilliseconds1 = binaryReader.ReadInt32();
            ambientAnimationLoopingStyle = (AmbientAnimationLoopingStyle) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<ScreenAnimationKeyframeReferenceBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            keyframes = ReadBlockArrayData<ScreenAnimationKeyframeReferenceBlock>(binaryReader, blamPointers.Dequeue());
            keyframes0 = ReadBlockArrayData<ScreenAnimationKeyframeReferenceBlock>(binaryReader, blamPointers.Dequeue());
            keyframes1 = ReadBlockArrayData<ScreenAnimationKeyframeReferenceBlock>(binaryReader, blamPointers.Dequeue());
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
                binaryWriter.Write(animationPeriodMilliseconds0);
                nextAddress = Guerilla.WriteBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryWriter, keyframes0,
                    nextAddress);
                binaryWriter.Write(animationPeriodMilliseconds1);
                binaryWriter.Write((Int16) ambientAnimationLoopingStyle);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<ScreenAnimationKeyframeReferenceBlock>(binaryWriter, keyframes1,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
        };

        internal enum AmbientAnimationLoopingStyle : short
        {
            NONE = 0,
            ReverseLoop = 1,
            Loop = 2,
            DontLoop = 3,
        };
    };
}