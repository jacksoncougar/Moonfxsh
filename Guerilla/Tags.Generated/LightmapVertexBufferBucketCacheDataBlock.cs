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
    public partial class LightmapVertexBufferBucketCacheDataBlock : LightmapVertexBufferBucketCacheDataBlockBase
    {
        public LightmapVertexBufferBucketCacheDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LightmapVertexBufferBucketCacheDataBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public LightmapVertexBufferBucketCacheDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometrySectionVertexBufferBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            vertexBuffers = ReadBlockArrayData<GlobalGeometrySectionVertexBufferBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryWriter, vertexBuffers, nextAddress);
                return nextAddress;
            }
        }
    };
}
