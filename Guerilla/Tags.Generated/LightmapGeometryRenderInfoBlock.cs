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
    public partial class LightmapGeometryRenderInfoBlock : LightmapGeometryRenderInfoBlockBase
    {
        public LightmapGeometryRenderInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class LightmapGeometryRenderInfoBlockBase : GuerillaBlock
    {
        internal short bitmapIndex;
        internal byte paletteIndex;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public LightmapGeometryRenderInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmapIndex = binaryReader.ReadInt16();
            paletteIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(paletteIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                return nextAddress;
            }
        }
    };
}
