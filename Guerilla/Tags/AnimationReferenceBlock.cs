using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationReferenceBlock : AnimationReferenceBlockBase
    {
        public  AnimationReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class AnimationReferenceBlockBase
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
        internal  AnimationReferenceBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.animationPeriodMilliseconds = binaryReader.ReadInt32();
            this.keyframes = ReadScreenAnimationKeyframeReferenceBlockArray(binaryReader);
            this.animationPeriodMilliseconds0 = binaryReader.ReadInt32();
            this.keyframes0 = ReadScreenAnimationKeyframeReferenceBlockArray(binaryReader);
            this.animationPeriodMilliseconds1 = binaryReader.ReadInt32();
            this.ambientAnimationLoopingStyle = (AmbientAnimationLoopingStyle)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.keyframes1 = ReadScreenAnimationKeyframeReferenceBlockArray(binaryReader);
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
        internal  virtual ScreenAnimationKeyframeReferenceBlock[] ReadScreenAnimationKeyframeReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScreenAnimationKeyframeReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScreenAnimationKeyframeReferenceBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScreenAnimationKeyframeReferenceBlock(binaryReader);
                }
            }
            return array;
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
