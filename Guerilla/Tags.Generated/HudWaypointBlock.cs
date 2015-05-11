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
    public partial class HudWaypointBlock : HudWaypointBlockBase
    {
        public HudWaypointBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class HudWaypointBlockBase : GuerillaBlock
    {
        [TagReference("bitm")] internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")] internal Moonfish.Tags.TagReference shader;
        internal short onscreenSequenceIndex;
        internal short occludedSequenceIndex;
        internal short offscreenSequenceIndex;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public HudWaypointBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            onscreenSequenceIndex = binaryReader.ReadInt16();
            occludedSequenceIndex = binaryReader.ReadInt16();
            offscreenSequenceIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(bitmap);
                binaryWriter.Write(shader);
                binaryWriter.Write(onscreenSequenceIndex);
                binaryWriter.Write(occludedSequenceIndex);
                binaryWriter.Write(offscreenSequenceIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}