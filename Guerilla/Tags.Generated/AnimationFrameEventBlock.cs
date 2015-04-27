// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationFrameEventBlock : AnimationFrameEventBlockBase
    {
        public  AnimationFrameEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationFrameEventBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AnimationFrameEventBlockBase : GuerillaBlock
    {
        internal Type type;
        internal short frame;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationFrameEventBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            frame = binaryReader.ReadInt16();
        }
        public  AnimationFrameEventBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            frame = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(frame);
                return nextAddress;
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
