using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureInstancedGeometryRenderInfoStructBlock : StructureInstancedGeometryRenderInfoStructBlockBase
    {
        public  StructureInstancedGeometryRenderInfoStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class StructureInstancedGeometryRenderInfoStructBlockBase
    {
        internal GlobalGeometrySectionInfoStructBlock sectionInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal StructureBspClusterDataBlockNew[] renderData;
        internal GlobalGeometrySectionStripIndexBlock[] indexReorderTable;
        internal  StructureInstancedGeometryRenderInfoStructBlockBase(BinaryReader binaryReader)
        {
            this.sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.renderData = ReadStructureBspClusterDataBlockNewArray(binaryReader);
            this.indexReorderTable = ReadGlobalGeometrySectionStripIndexBlockArray(binaryReader);
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
        internal  virtual StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterDataBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterDataBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterDataBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometrySectionStripIndexBlock[] ReadGlobalGeometrySectionStripIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
