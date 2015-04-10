// ReSharper disable All
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
        public  StructureInstancedGeometryRenderInfoStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureInstancedGeometryRenderInfoStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            ReadStructureBspClusterDataBlockNewArray(binaryReader);
            ReadGlobalGeometrySectionStripIndexBlockArray(binaryReader);
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
        internal  virtual StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalGeometrySectionStripIndexBlock[] ReadGlobalGeometrySectionStripIndexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterDataBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometrySectionStripIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                sectionInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                WriteStructureBspClusterDataBlockNewArray(binaryWriter);
                WriteGlobalGeometrySectionStripIndexBlockArray(binaryWriter);
            }
        }
    };
}
