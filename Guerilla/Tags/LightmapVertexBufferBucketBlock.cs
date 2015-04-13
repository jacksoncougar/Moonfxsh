using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapVertexBufferBucketBlock : LightmapVertexBufferBucketBlockBase
    {
        public  LightmapVertexBufferBucketBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class LightmapVertexBufferBucketBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal LightmapBucketRawVertexBlock[] rawVertices;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapVertexBufferBucketCacheDataBlock[] cacheData;
        internal  LightmapVertexBufferBucketBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.rawVertices = ReadLightmapBucketRawVertexBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.cacheData = ReadLightmapVertexBufferBucketCacheDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual LightmapBucketRawVertexBlock[] ReadLightmapBucketRawVertexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapBucketRawVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapBucketRawVertexBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapBucketRawVertexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapVertexBufferBucketCacheDataBlock[] ReadLightmapVertexBufferBucketCacheDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapVertexBufferBucketCacheDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapVertexBufferBucketCacheDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapVertexBufferBucketCacheDataBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            IncidentDirection = 1,
            Color = 2,
        };
    };
}
