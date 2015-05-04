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
    public partial class StructureInstancedGeometryRenderInfoStructBlock : StructureInstancedGeometryRenderInfoStructBlockBase
    {
        public StructureInstancedGeometryRenderInfoStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class StructureInstancedGeometryRenderInfoStructBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionInfoStructBlock sectionInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal StructureBspClusterDataBlockNew[] renderData;
        internal GlobalGeometrySectionStripIndexBlock[] indexReorderTable;
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public StructureInstancedGeometryRenderInfoStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sectionInfo = new GlobalGeometrySectionInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(sectionInfo.ReadFields(binaryReader)));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspClusterDataBlockNew>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometrySectionStripIndexBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sectionInfo.ReadPointers(binaryReader, blamPointers);
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
            renderData = ReadBlockArrayData<StructureBspClusterDataBlockNew>(binaryReader, blamPointers.Dequeue());
            indexReorderTable = ReadBlockArrayData<GlobalGeometrySectionStripIndexBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                sectionInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterDataBlockNew>(binaryWriter, renderData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryWriter, indexReorderTable, nextAddress);
                return nextAddress;
            }
        }
    };
}
