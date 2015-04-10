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
        public  StructureLightmapPaletteColorBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1024)]
    public class StructureLightmapPaletteColorBlockBase
    {
        internal int fIRSTPaletteColor;
        internal byte[] invalidName_;
        internal  StructureLightmapPaletteColorBlockBase(System.IO.BinaryReader binaryReader)
        {
            fIRSTPaletteColor = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(1020);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fIRSTPaletteColor);
                binaryWriter.Write(invalidName_, 0, 1020);
            }
        }
    };
}
