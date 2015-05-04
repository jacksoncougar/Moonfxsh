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
    public partial class StructureBspEnvironmentObjectPaletteBlock : StructureBspEnvironmentObjectPaletteBlockBase
    {
        public StructureBspEnvironmentObjectPaletteBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class StructureBspEnvironmentObjectPaletteBlockBase : GuerillaBlock
    {
        [TagReference("scen")]
        internal Moonfish.Tags.TagReference definition;
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference model;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public StructureBspEnvironmentObjectPaletteBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            definition = binaryReader.ReadTagReference();
            model = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(4);
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
                binaryWriter.Write(definition);
                binaryWriter.Write(model);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}
