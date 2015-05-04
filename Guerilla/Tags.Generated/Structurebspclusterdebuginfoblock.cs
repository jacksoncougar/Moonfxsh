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
    public partial class StructureBspClusterDebugInfoBlock : StructureBspClusterDebugInfoBlockBase
    {
        public StructureBspClusterDebugInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class StructureBspClusterDebugInfoBlockBase : GuerillaBlock
    {
        internal Errors errors;
        internal Warnings warnings;
        internal byte[] invalidName_;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] fogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] visibleFogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] visFogOmissionClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] containingFogZoneIndices;

        public override int SerializedSize
        {
            get { return 72; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspClusterDebugInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            errors = (Errors) binaryReader.ReadInt16();
            warnings = (Warnings) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(28);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoRenderLineBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoIndicesBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lines = ReadBlockArrayData<StructureBspDebugInfoRenderLineBlock>(binaryReader, blamPointers.Dequeue());
            fogPlaneIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, blamPointers.Dequeue());
            visibleFogPlaneIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader,
                blamPointers.Dequeue());
            visFogOmissionClusterIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader,
                blamPointers.Dequeue());
            containingFogZoneIndices = ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) errors);
                binaryWriter.Write((Int16) warnings);
                binaryWriter.Write(invalidName_, 0, 28);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoRenderLineBlock>(binaryWriter, lines,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, fogPlaneIndices,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter,
                    visibleFogPlaneIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter,
                    visFogOmissionClusterIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter,
                    containingFogZoneIndices, nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Errors : short
        {
            MultipleFogPlanes = 1,
            FogZoneCollision = 2,
            FogZoneImmersion = 4,
        };

        [FlagsAttribute]
        internal enum Warnings : short
        {
            MultipleVisibleFogPlanes = 1,
            VisibleFogClusterOmission = 2,
            FogPlaneMissedRenderBSP = 4,
        };
    };
}