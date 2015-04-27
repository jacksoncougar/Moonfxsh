// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapGeometrySectionBlock : LightmapGeometrySectionBlockBase
    {
        public  LightmapGeometrySectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapGeometrySectionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class LightmapGeometrySectionBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionInfoStructBlock geometryInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal LightmapGeometrySectionCacheDataBlock[] cacheData;
        
        public override int SerializedSize{get { return 84; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapGeometrySectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            geometryInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            cacheData = Guerilla.ReadBlockArray<LightmapGeometrySectionCacheDataBlock>(binaryReader);
        }
        public  LightmapGeometrySectionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            geometryInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            cacheData = Guerilla.ReadBlockArray<LightmapGeometrySectionCacheDataBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometryInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<LightmapGeometrySectionCacheDataBlock>(binaryWriter, cacheData, nextAddress);
                return nextAddress;
            }
        }
    };
}
