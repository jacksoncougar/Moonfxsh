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
    public partial class StructureBspFogZoneDebugInfoBlock : StructureBspFogZoneDebugInfoBlockBase
    {
        public StructureBspFogZoneDebugInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class StructureBspFogZoneDebugInfoBlockBase : GuerillaBlock
    {
        internal int mediaIndexScenarioFogPlane;
        internal int baseFogPlaneIndex;
        internal byte[] invalidName_;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] immersedClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] boundingFogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] collisionFogPlaneIndices;
        public override int SerializedSize { get { return 64; } }
        public override int Alignment { get { return 4; } }
        public StructureBspFogZoneDebugInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            mediaIndexScenarioFogPlane = binaryReader.ReadInt32();
            baseFogPlaneIndex = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(24);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoRenderLineBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            lines = ReadBlockArrayData<StructureBspDebugInfoRenderLineBlock>(binaryReader, blamPointers.Dequeue());
            immersedClusterIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, blamPointers.Dequeue());
            boundingFogPlaneIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, blamPointers.Dequeue());
            collisionFogPlaneIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(mediaIndexScenarioFogPlane);
                binaryWriter.Write(baseFogPlaneIndex);
                binaryWriter.Write(invalidName_, 0, 24);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoRenderLineBlock>(binaryWriter, lines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, immersedClusterIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, boundingFogPlaneIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, collisionFogPlaneIndices, nextAddress);
                return nextAddress;
            }
        }
    };
}
