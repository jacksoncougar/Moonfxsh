// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationAimingScreenStructBlock : AnimationAimingScreenStructBlockBase
    {
        public  AnimationAimingScreenStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationAimingScreenStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class AnimationAimingScreenStructBlockBase : GuerillaBlock
    {
        internal float rightYawPerFrame;
        internal float leftYawPerFrame;
        internal short rightFrameCount;
        internal short leftFrameCount;
        internal float downPitchPerFrame;
        internal float upPitchPerFrame;
        internal short downPitchFrameCount;
        internal short upPitchFrameCount;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationAimingScreenStructBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public  AnimationAimingScreenStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
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
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
