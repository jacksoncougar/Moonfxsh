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
    public partial class LightmapInstanceBucketReferenceBlock : LightmapInstanceBucketReferenceBlockBase
    {
        public LightmapInstanceBucketReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LightmapInstanceBucketReferenceBlockBase : GuerillaBlock
    {
        internal short flags;
        internal short bucketIndex;
        internal LightmapInstanceBucketSectionOffsetBlock[] sectionOffsets;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public LightmapInstanceBucketReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = binaryReader.ReadInt16();
            bucketIndex = binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapInstanceBucketSectionOffsetBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sectionOffsets = ReadBlockArrayData<LightmapInstanceBucketSectionOffsetBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flags);
                binaryWriter.Write(bucketIndex);
                nextAddress = Guerilla.WriteBlockArray<LightmapInstanceBucketSectionOffsetBlock>(binaryWriter, sectionOffsets, nextAddress);
                return nextAddress;
            }
        }
    };
}
