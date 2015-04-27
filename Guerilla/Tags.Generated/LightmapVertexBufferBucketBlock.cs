// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapVertexBufferBucketBlock : LightmapVertexBufferBucketBlockBase
    {
        public  LightmapVertexBufferBucketBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapVertexBufferBucketBlock(): base()
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
        
        public override int SerializedSize{get { return 56; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapVertexBufferBucketBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            rawVertices = Guerilla.ReadBlockArray<LightmapBucketRawVertexBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            cacheData = Guerilla.ReadBlockArray<LightmapVertexBufferBucketCacheDataBlock>(binaryReader);
        }
        public  LightmapVertexBufferBucketBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
