// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspClusterDebugInfoBlock : StructureBspClusterDebugInfoBlockBase
    {
        public  StructureBspClusterDebugInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class StructureBspClusterDebugInfoBlockBase  : IGuerilla
    {
        internal Errors errors;
        internal Warnings warnings;
        internal byte[] invalidName_;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] fogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] visibleFogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] visFogOmissionClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] containingFogZoneIndices;
        internal  StructureBspClusterDebugInfoBlockBase(BinaryReader binaryReader)
        {
            errors = (Errors)binaryReader.ReadInt16();
            warnings = (Warnings)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(28);
            lines = Guerilla.ReadBlockArray<StructureBspDebugInfoRenderLineBlock>(binaryReader);
            fogPlaneIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
            visibleFogPlaneIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
            visFogOmissionClusterIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
            containingFogZoneIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)errors);
                binaryWriter.Write((Int16)warnings);
                binaryWriter.Write(invalidName_, 0, 28);
                Guerilla.WriteBlockArray<StructureBspDebugInfoRenderLineBlock>(binaryWriter, lines, nextAddress);
                Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, fogPlaneIndices, nextAddress);
                Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, visibleFogPlaneIndices, nextAddress);
                Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, visFogOmissionClusterIndices, nextAddress);
                Guerilla.WriteBlockArray<StructureBspDebugInfoIndicesBlock>(binaryWriter, containingFogZoneIndices, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
