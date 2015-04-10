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
        public  AnimationAimingScreenStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationAimingScreenStructBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
            }
        }
    };
}
