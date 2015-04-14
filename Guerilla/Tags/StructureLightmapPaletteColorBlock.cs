// ReSharper disable All
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
    [LayoutAttribute(Size = 1024, Alignment = 64)]
    public class StructureLightmapPaletteColorBlockBase  : IGuerilla
    {
        internal int fIRSTPaletteColor;
        internal byte[] invalidName_;
        internal  StructureLightmapPaletteColorBlockBase(BinaryReader binaryReader)
        {
            fIRSTPaletteColor = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(1020);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fIRSTPaletteColor);
                binaryWriter.Write(invalidName_, 0, 1020);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
