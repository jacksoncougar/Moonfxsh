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
    public partial class RenderModelSectionBlock : RenderModelSectionBlockBase
    {
        public RenderModelSectionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class RenderModelSectionBlockBase : GuerillaBlock
    {
        internal GlobalGeometryClassificationEnumDefinition globalGeometryClassificationEnumDefinition;
        internal byte[] invalidName_;
        internal GlobalGeometrySectionInfoStructBlock sectionInfo;
        internal Moonfish.Tags.ShortBlockIndex1 rigidNode;
        internal Flags flags;
        internal RenderModelSectionDataBlock[] sectionData;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public RenderModelSectionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            globalGeometryClassificationEnumDefinition = (GlobalGeometryClassificationEnumDefinition)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            sectionInfo = new GlobalGeometrySectionInfoStructBlock();
            blamPointers.Concat(sectionInfo.ReadFields(binaryReader));
            rigidNode = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderModelSectionDataBlock>(binaryReader));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            sectionInfo.ReadPointers(binaryReader, blamPointers);
            sectionData = ReadBlockArrayData<RenderModelSectionDataBlock>(binaryReader, blamPointers.Dequeue());
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)globalGeometryClassificationEnumDefinition);
                binaryWriter.Write(invalidName_, 0, 2);
                sectionInfo.Write(binaryWriter);
                binaryWriter.Write(rigidNode);
                binaryWriter.Write((Int16)flags);
                nextAddress = Guerilla.WriteBlockArray<RenderModelSectionDataBlock>(binaryWriter, sectionData, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress;
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
