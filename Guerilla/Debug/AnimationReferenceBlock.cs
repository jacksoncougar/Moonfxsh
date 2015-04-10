// ReSharper disable All
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
        public  AnimationReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            animationPeriodMilliseconds = binaryReader.ReadInt32();
            ReadScreenAnimationKeyframeReferenceBlockArray(binaryReader);
            animationPeriodMilliseconds0 = binaryReader.ReadInt32();
            ReadScreenAnimationKeyframeReferenceBlockArray(binaryReader);
            animationPeriodMilliseconds1 = binaryReader.ReadInt32();
            ambientAnimationLoopingStyle = (AmbientAnimationLoopingStyle)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadScreenAnimationKeyframeReferenceBlockArray(binaryReader);
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
        internal  virtual ScreenAnimationKeyframeReferenceBlock[] ReadScreenAnimationKeyframeReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScreenAnimationKeyframeReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScreenAnimationKeyframeReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScreenAnimationKeyframeReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScreenAnimationKeyframeReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(animationPeriodMilliseconds);
                WriteScreenAnimationKeyframeReferenceBlockArray(binaryWriter);
                binaryWriter.Write(animationPeriodMilliseconds0);
                WriteScreenAnimationKeyframeReferenceBlockArray(binaryWriter);
                binaryWriter.Write(animationPeriodMilliseconds1);
                binaryWriter.Write((Int16)ambientAnimationLoopingStyle);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteScreenAnimationKeyframeReferenceBlockArray(binaryWriter);
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
