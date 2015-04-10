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
    [LayoutAttribute(Size = 4)]
    public class AnimationFrameEventBlockBase
    {
        internal Type type;
        internal short frame;
        internal  AnimationFrameEventBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.frame = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
