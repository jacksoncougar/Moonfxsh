// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureLightmapPaletteColorBlock : StructureLightmapPaletteColorBlockBase
    {
        public StructureLightmapPaletteColorBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 1024, Alignment = 64)]
    public class StructureLightmapPaletteColorBlockBase : GuerillaBlock
    {
        internal int fIRSTPaletteColor;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 1024; } }
        public override int Alignment { get { return 64; } }
        public StructureLightmapPaletteColorBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            fIRSTPaletteColor = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(1020);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fIRSTPaletteColor);
                binaryWriter.Write(invalidName_, 0, 1020);
                return nextAddress;
            }
        }
    };
}
