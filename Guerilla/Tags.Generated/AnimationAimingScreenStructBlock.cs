// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationAimingScreenStructBlock : AnimationAimingScreenStructBlockBase
    {
        public AnimationAimingScreenStructBlock() : base()
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
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public AnimationAimingScreenStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            rightYawPerFrame = binaryReader.ReadSingle();
            leftYawPerFrame = binaryReader.ReadSingle();
            rightFrameCount = binaryReader.ReadInt16();
            leftFrameCount = binaryReader.ReadInt16();
            downPitchPerFrame = binaryReader.ReadSingle();
            upPitchPerFrame = binaryReader.ReadSingle();
            downPitchFrameCount = binaryReader.ReadInt16();
            upPitchFrameCount = binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
