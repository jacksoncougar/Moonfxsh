// ReSharper disable All
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
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AnimationAimingScreenStructBlockBase  : IGuerilla
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
            rightYawPerFrame = binaryReader.ReadSingle();
            leftYawPerFrame = binaryReader.ReadSingle();
            rightFrameCount = binaryReader.ReadInt16();
            leftFrameCount = binaryReader.ReadInt16();
            downPitchPerFrame = binaryReader.ReadSingle();
            upPitchPerFrame = binaryReader.ReadSingle();
            downPitchFrameCount = binaryReader.ReadInt16();
            upPitchFrameCount = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rightYawPerFrame);
                binaryWriter.Write(leftYawPerFrame);
                binaryWriter.Write(rightFrameCount);
                binaryWriter.Write(leftFrameCount);
                binaryWriter.Write(downPitchPerFrame);
                binaryWriter.Write(upPitchPerFrame);
                binaryWriter.Write(downPitchFrameCount);
                binaryWriter.Write(upPitchFrameCount);
                return nextAddress;
            }
        }
    };
}
