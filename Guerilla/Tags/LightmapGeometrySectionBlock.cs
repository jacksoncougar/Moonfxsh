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
        public  LightmapGeometrySectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class LightmapGeometrySectionBlockBase  : IGuerilla
    {
        internal GlobalGeometrySectionInfoStructBlock geometryInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapGeometrySectionCacheDataBlock[] cacheData;
        internal  LightmapGeometrySectionBlockBase(BinaryReader binaryReader)
        {
            geometryInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            cacheData = Guerilla.ReadBlockArray<LightmapGeometrySectionCacheDataBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometryInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionCacheDataBlock>(binaryWriter, cacheData, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
