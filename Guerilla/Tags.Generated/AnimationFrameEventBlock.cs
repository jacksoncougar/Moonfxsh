// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationFrameEventBlock : AnimationFrameEventBlockBase
    {
        public AnimationFrameEventBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AnimationFrameEventBlockBase : GuerillaBlock
    {
        internal Type type;
        internal short frame;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AnimationFrameEventBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type) binaryReader.ReadInt16();
            frame = binaryReader.ReadInt16();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) type);
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