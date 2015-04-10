using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationAimingScreenStructBlock : AnimationAimingScreenStructBlockBase
    {
        public  AnimationAimingScreenStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class AnimationAimingScreenStructBlockBase
    {
        internal float rightYawPerFrame;
        internal float leftYawPerFrame;
        internal short rightFrameCount;
        internal short leftFrameCount;
        internal float downPitchPerFrame;
        internal float upPitchPerFrame;
        internal short downPitchFrameCount;
        internal short upPitchFrameCount;
        internal  AnimationAimingScreenStructBlockBase(BinaryReader binaryReader)
        {
            this.rightYawPerFrame = binaryReader.ReadSingle();
            this.leftYawPerFrame = binaryReader.ReadSingle();
            this.rightFrameCount = binaryReader.ReadInt16();
            this.leftFrameCount = binaryReader.ReadInt16();
            this.downPitchPerFrame = binaryReader.ReadSingle();
            this.upPitchPerFrame = binaryReader.ReadSingle();
            this.downPitchFrameCount = binaryReader.ReadInt16();
            this.upPitchFrameCount = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
