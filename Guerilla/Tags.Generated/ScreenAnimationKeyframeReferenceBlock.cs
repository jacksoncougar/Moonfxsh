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
    public partial class ScreenAnimationKeyframeReferenceBlock : ScreenAnimationKeyframeReferenceBlockBase
    {
        public ScreenAnimationKeyframeReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ScreenAnimationKeyframeReferenceBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal float alpha;
        internal OpenTK.Vector3 position;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public ScreenAnimationKeyframeReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
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
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(alpha);
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}
