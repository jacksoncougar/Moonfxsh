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
        public  LightmapGeometrySectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class LightmapGeometrySectionBlockBase
    {
        internal GlobalGeometrySectionInfoStructBlock geometryInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapGeometrySectionCacheDataBlock[] cacheData;
        internal  LightmapGeometrySectionBlockBase(BinaryReader binaryReader)
        {
            this.geometryInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.cacheData = ReadLightmapGeometrySectionCacheDataBlockArray(binaryReader);
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
        internal  virtual LightmapGeometrySectionCacheDataBlock[] ReadLightmapGeometrySectionCacheDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapGeometrySectionCacheDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapGeometrySectionCacheDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapGeometrySectionCacheDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
