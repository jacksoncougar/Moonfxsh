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
    public partial class StructureBspLeafBlock : StructureBspLeafBlockBase
    {
        public StructureBspLeafBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class StructureBspLeafBlockBase : GuerillaBlock
    {
        internal short cluster;
        internal short surfaceReferenceCount;
        internal int firstSurfaceReferenceIndex;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public StructureBspLeafBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            cluster = binaryReader.ReadInt16();
            surfaceReferenceCount = binaryReader.ReadInt16();
            firstSurfaceReferenceIndex = binaryReader.ReadInt32();
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
                binaryWriter.Write(cluster);
                binaryWriter.Write(surfaceReferenceCount);
                binaryWriter.Write(firstSurfaceReferenceIndex);
                return nextAddress;
            }
        }
    };
}
