// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapGeometrySectionCacheDataBlock : LightmapGeometrySectionCacheDataBlockBase
    {
        public  LightmapGeometrySectionCacheDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class LightmapGeometrySectionCacheDataBlockBase  : IGuerilla
    {
        internal GlobalGeometrySectionStructBlock geometry;
        internal  LightmapGeometrySectionCacheDataBlockBase(BinaryReader binaryReader)
        {
            geometry = new GlobalGeometrySectionStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometry.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
