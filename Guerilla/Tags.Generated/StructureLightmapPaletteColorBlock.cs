// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapPaletteColorBlock : StructureLightmapPaletteColorBlockBase
    {
        public  StructureLightmapPaletteColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureLightmapPaletteColorBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 1024, Alignment = 64)]
    public class StructureLightmapPaletteColorBlockBase : GuerillaBlock
    {
        internal int fIRSTPaletteColor;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 1024; }}
        
        
        public override int Alignment{get { return 64; }}
        
        public  StructureLightmapPaletteColorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            fIRSTPaletteColor = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(1020);
        }
        public  StructureLightmapPaletteColorBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fIRSTPaletteColor);
                binaryWriter.Write(invalidName_, 0, 1020);
                return nextAddress;
            }
        }
    };
}
