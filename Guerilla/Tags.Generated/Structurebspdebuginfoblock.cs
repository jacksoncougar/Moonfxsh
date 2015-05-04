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
    public partial class StructureBspDebugInfoBlock : StructureBspDebugInfoBlockBase
    {
        public StructureBspDebugInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class StructureBspDebugInfoBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal StructureBspClusterDebugInfoBlock[] clusters;
        internal StructureBspFogPlaneDebugInfoBlock[] fogPlanes;
        internal StructureBspFogZoneDebugInfoBlock[] fogZones;
        public override int SerializedSize { get { return 88; } }
        public override int Alignment { get { return 4; } }
        public StructureBspDebugInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(64);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspClusterDebugInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspFogPlaneDebugInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspFogZoneDebugInfoBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            clusters = ReadBlockArrayData<StructureBspClusterDebugInfoBlock>(binaryReader, blamPointers.Dequeue());
            fogPlanes = ReadBlockArrayData<StructureBspFogPlaneDebugInfoBlock>(binaryReader, blamPointers.Dequeue());
            fogZones = ReadBlockArrayData<StructureBspFogZoneDebugInfoBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 64);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterDebugInfoBlock>(binaryWriter, clusters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspFogPlaneDebugInfoBlock>(binaryWriter, fogPlanes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspFogZoneDebugInfoBlock>(binaryWriter, fogZones, nextAddress);
                return nextAddress;
            }
        }
    };
}
