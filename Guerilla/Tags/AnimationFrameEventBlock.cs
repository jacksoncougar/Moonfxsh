// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationFrameEventBlock : AnimationFrameEventBlockBase
    {
        public  AnimationFrameEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AnimationFrameEventBlockBase  : IGuerilla
    {
        internal Type type;
        internal short frame;
        internal  AnimationFrameEventBlockBase(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            frame = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(frame);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum Type : short
        {
            PrimaryKeyframe = 0,
            SecondaryKeyframe = 1,
            LeftFoot = 2,
            RightFoot = 3,
            AllowInterruption = 4,
            TransitionA = 5,
            TransitionB = 6,
            TransitionC = 7,
            TransitionD = 8,
            BothFeetShuffle = 9,
            BodyImpact = 10,
        };
    };
}
