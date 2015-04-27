// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureInstancedGeometryRenderInfoStructBlock : StructureInstancedGeometryRenderInfoStructBlockBase
    {
        public  StructureInstancedGeometryRenderInfoStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureInstancedGeometryRenderInfoStructBlock(): base()
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
        
        public override int SerializedSize{get { return 92; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureInstancedGeometryRenderInfoStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            renderData = Guerilla.ReadBlockArray<StructureBspClusterDataBlockNew>(binaryReader);
            indexReorderTable = Guerilla.ReadBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryReader);
        }
        public  StructureInstancedGeometryRenderInfoStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            renderData = Guerilla.ReadBlockArray<StructureBspClusterDataBlockNew>(binaryReader);
            indexReorderTable = Guerilla.ReadBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
