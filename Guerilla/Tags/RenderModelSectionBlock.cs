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
        public  RenderModelSectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class RenderModelSectionBlockBase  : IGuerilla
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
            globalGeometryClassificationEnumDefinition = (GlobalGeometryClassificationEnumDefinition)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            rigidNode = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            sectionData = Guerilla.ReadBlockArray<RenderModelSectionDataBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)globalGeometryClassificationEnumDefinition);
                binaryWriter.Write(invalidName_, 0, 2);
                sectionInfo.Write(binaryWriter);
                binaryWriter.Write(rigidNode);
                binaryWriter.Write((Int16)flags);
                nextAddress = Guerilla.WriteBlockArray<RenderModelSectionDataBlock>(binaryWriter, sectionData, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
