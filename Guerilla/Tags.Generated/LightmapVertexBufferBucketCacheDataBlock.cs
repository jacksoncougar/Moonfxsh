// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapVertexBufferBucketCacheDataBlock : LightmapVertexBufferBucketCacheDataBlockBase
    {
        public  LightmapVertexBufferBucketCacheDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapVertexBufferBucketCacheDataBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LightmapVertexBufferBucketCacheDataBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionVertexBufferBlock[] vertexBuffers;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapVertexBufferBucketCacheDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vertexBuffers = Guerilla.ReadBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryReader);
        }
        public  LightmapVertexBufferBucketCacheDataBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            vertexBuffers = Guerilla.ReadBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionVertexBufferBlock>(binaryWriter, vertexBuffers, nextAddress);
                return nextAddress;
            }
        }
    };
}
