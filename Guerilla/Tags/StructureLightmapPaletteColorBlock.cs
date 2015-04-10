using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureLightmapPaletteColorBlock : StructureLightmapPaletteColorBlockBase
    {
        public  StructureLightmapPaletteColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1024)]
    public class StructureLightmapPaletteColorBlockBase
    {
        internal int fIRSTPaletteColor;
        internal byte[] invalidName_;
        internal  StructureLightmapPaletteColorBlockBase(BinaryReader binaryReader)
        {
            this.fIRSTPaletteColor = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(1020);
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