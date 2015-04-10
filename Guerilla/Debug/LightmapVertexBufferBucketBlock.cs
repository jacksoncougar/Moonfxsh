// ReSharper disable All
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
        public  LightmapVertexBufferBucketBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  LightmapVertexBufferBucketBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadLightmapBucketRawVertexBlockArray(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            ReadLightmapVertexBufferBucketCacheDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual LightmapBucketRawVertexBlock[] ReadLightmapBucketRawVertexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapBucketRawVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapBucketRawVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapBucketRawVertexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightmapVertexBufferBucketCacheDataBlock[] ReadLightmapVertexBufferBucketCacheDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapVertexBufferBucketCacheDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapVertexBufferBucketCacheDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapVertexBufferBucketCacheDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapBucketRawVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapVertexBufferBucketCacheDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteLightmapBucketRawVertexBlockArray(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                WriteLightmapVertexBufferBucketCacheDataBlockArray(binaryWriter);
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
