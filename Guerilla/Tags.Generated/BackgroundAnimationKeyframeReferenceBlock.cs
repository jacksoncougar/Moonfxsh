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
    public partial class BackgroundAnimationKeyframeReferenceBlock : BackgroundAnimationKeyframeReferenceBlockBase
    {
        public BackgroundAnimationKeyframeReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class BackgroundAnimationKeyframeReferenceBlockBase : GuerillaBlock
    {
        internal int startTransitionIndex;
        internal float alpha;
        internal OpenTK.Vector3 position;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public BackgroundAnimationKeyframeReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            startTransitionIndex = binaryReader.ReadInt32();
            alpha = binaryReader.ReadSingle();
            position = binaryReader.ReadVector3();
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
                binaryWriter.Write(startTransitionIndex);
                binaryWriter.Write(alpha);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}
