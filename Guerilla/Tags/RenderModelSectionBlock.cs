using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelSectionBlock : RenderModelSectionBlockBase
    {
        public  RenderModelSectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class RenderModelSectionBlockBase
    {
        internal GlobalGeometryClassificationEnumDefinition globalGeometryClassificationEnumDefinition;
        internal byte[] invalidName_;
        internal GlobalGeometrySectionInfoStructBlock sectionInfo;
        internal Moonfish.Tags.ShortBlockIndex1 rigidNode;
        internal Flags flags;
        internal RenderModelSectionDataBlock[] sectionData;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  RenderModelSectionBlockBase(BinaryReader binaryReader)
        {
            this.globalGeometryClassificationEnumDefinition = (GlobalGeometryClassificationEnumDefinition)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            this.rigidNode = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.sectionData = ReadRenderModelSectionDataBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual RenderModelSectionDataBlock[] ReadRenderModelSectionDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelSectionDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelSectionDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelSectionDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum GlobalGeometryClassificationEnumDefinition : short
        
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            GeometryPostprocessed = 1,
        };
    };
}
