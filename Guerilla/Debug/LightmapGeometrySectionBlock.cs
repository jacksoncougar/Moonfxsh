// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapGeometrySectionBlock : LightmapGeometrySectionBlockBase
    {
        public  LightmapGeometrySectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class LightmapGeometrySectionBlockBase
    {
        internal GlobalGeometrySectionInfoStructBlock geometryInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapGeometrySectionCacheDataBlock[] cacheData;
        internal  LightmapGeometrySectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            geometryInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            ReadLightmapGeometrySectionCacheDataBlockArray(binaryReader);
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
        internal  virtual LightmapGeometrySectionCacheDataBlock[] ReadLightmapGeometrySectionCacheDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapGeometrySectionCacheDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapGeometrySectionCacheDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapGeometrySectionCacheDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapGeometrySectionCacheDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometryInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                WriteLightmapGeometrySectionCacheDataBlockArray(binaryWriter);
            }
        }
    };
}
