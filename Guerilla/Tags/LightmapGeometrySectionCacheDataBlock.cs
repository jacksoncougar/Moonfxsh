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
    [LayoutAttribute(Size = 68)]
    public class LightmapGeometrySectionCacheDataBlockBase
    {
        internal GlobalGeometrySectionStructBlock geometry;
        internal  LightmapGeometrySectionCacheDataBlockBase(BinaryReader binaryReader)
        {
            this.geometry = new GlobalGeometrySectionStructBlock(binaryReader);
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
    };
}
