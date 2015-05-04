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
    public partial class StructureBspFogPlaneDebugInfoBlock : StructureBspFogPlaneDebugInfoBlockBase
    {
        public StructureBspFogPlaneDebugInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class StructureBspFogPlaneDebugInfoBlockBase : GuerillaBlock
    {
        internal int fogZoneIndex;
        internal byte[] invalidName_;
        internal int connectedPlaneDesignator;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] intersectedClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] infExtentClusterIndices;
        public override int SerializedSize { get { return 56; } }
        public override int Alignment { get { return 4; } }
        public StructureBspFogPlaneDebugInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            fogZoneIndex = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(24);
            connectedPlaneDesignator = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoRenderLineBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lines = ReadBlockArrayData<StructureBspDebugInfoRenderLineBlock>(binaryReader, blamPointers.Dequeue());
            intersectedClusterIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, blamPointers.Dequeue());
            infExtentClusterIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fogZoneIndex);
                binaryWriter.Write(invalidName_, 0, 24);
                binaryWriter.Write(connectedPlaneDesignator);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoRenderLineBlock>(binaryWriter, lines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, intersectedClusterIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, infExtentClusterIndices, nextAddress);
                return nextAddress;
            }
        }
    };
}
