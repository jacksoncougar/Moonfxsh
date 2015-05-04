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
    public partial class LightmapVertexBufferBucketBlock : LightmapVertexBufferBucketBlockBase
    {
        public LightmapVertexBufferBucketBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class LightmapVertexBufferBucketBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal LightmapBucketRawVertexBlock[] rawVertices;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapVertexBufferBucketCacheDataBlock[] cacheData;
        public override int SerializedSize { get { return 56; } }
        public override int Alignment { get { return 4; } }
        public LightmapVertexBufferBucketBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapBucketRawVertexBlock>(binaryReader));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightmapVertexBufferBucketCacheDataBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            rawVertices = ReadBlockArrayData<LightmapBucketRawVertexBlock>(binaryReader, blamPointers.Dequeue());
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
            cacheData = ReadBlockArrayData<LightmapVertexBufferBucketCacheDataBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<LightmapBucketRawVertexBlock>(binaryWriter, rawVertices, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<LightmapVertexBufferBucketCacheDataBlock>(binaryWriter, cacheData, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            IncidentDirection = 1,
            Color = 2,
        };
    };
}
