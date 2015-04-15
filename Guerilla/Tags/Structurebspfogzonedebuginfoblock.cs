// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspFogZoneDebugInfoBlock : StructureBspFogZoneDebugInfoBlockBase
    {
        public  StructureBspFogZoneDebugInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class StructureBspFogZoneDebugInfoBlockBase  : IGuerilla
    {
        internal int mediaIndexScenarioFogPlane;
        internal int baseFogPlaneIndex;
        internal byte[] invalidName_;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] immersedClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] boundingFogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] collisionFogPlaneIndices;
        internal  StructureBspFogZoneDebugInfoBlockBase(BinaryReader binaryReader)
        {
            mediaIndexScenarioFogPlane = binaryReader.ReadInt32();
            baseFogPlaneIndex = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(24);
            lines = Guerilla.ReadBlockArray<StructureBspDebugInfoRenderLineBlock>(binaryReader);
            immersedClusterIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
            boundingFogPlaneIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
            collisionFogPlaneIndices = Guerilla.ReadBlockArray<StructureBspDebugInfoIndicesBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
