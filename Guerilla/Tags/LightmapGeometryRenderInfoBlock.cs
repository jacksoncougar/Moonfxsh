using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapGeometryRenderInfoBlock : LightmapGeometryRenderInfoBlockBase
    {
        public  LightmapGeometryRenderInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class LightmapGeometryRenderInfoBlockBase
    {
        internal short bitmapIndex;
        internal byte paletteIndex;
        internal byte[] invalidName_;
        internal  LightmapGeometryRenderInfoBlockBase(BinaryReader binaryReader)
        {
            this.bitmapIndex = binaryReader.ReadInt16();
            this.paletteIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
