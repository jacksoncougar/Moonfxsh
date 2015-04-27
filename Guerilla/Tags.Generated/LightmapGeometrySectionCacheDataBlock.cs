// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapGeometrySectionCacheDataBlock : LightmapGeometrySectionCacheDataBlockBase
    {
        public  LightmapGeometrySectionCacheDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapGeometrySectionCacheDataBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class LightmapGeometrySectionCacheDataBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionStructBlock geometry;
        
        public override int SerializedSize{get { return 68; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapGeometrySectionCacheDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            geometry = new GlobalGeometrySectionStructBlock(binaryReader);
        }
        public  LightmapGeometrySectionCacheDataBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometry.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
