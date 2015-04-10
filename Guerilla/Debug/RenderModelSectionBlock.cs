// ReSharper disable All
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
        public  RenderModelSectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RenderModelSectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            globalGeometryClassificationEnumDefinition = (GlobalGeometryClassificationEnumDefinition)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            rigidNode = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            ReadRenderModelSectionDataBlockArray(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual RenderModelSectionDataBlock[] ReadRenderModelSectionDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelSectionDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelSectionDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelSectionDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelSectionDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)globalGeometryClassificationEnumDefinition);
                binaryWriter.Write(invalidName_, 0, 2);
                sectionInfo.Write(binaryWriter);
                binaryWriter.Write(rigidNode);
                binaryWriter.Write((Int16)flags);
                WriteRenderModelSectionDataBlockArray(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
            }
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
