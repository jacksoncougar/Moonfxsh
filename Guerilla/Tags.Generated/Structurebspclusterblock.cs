// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspClusterBlock : StructureBspClusterBlockBase
    {
        public  StructureBspClusterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspClusterBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 176, Alignment = 4)]
    public class StructureBspClusterBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionInfoStructBlock sectionInfo;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal StructureBspClusterDataBlockNew[] clusterData;
        internal Moonfish.Model.Range boundsX;
        internal Moonfish.Model.Range boundsY;
        internal Moonfish.Model.Range boundsZ;
        internal byte scenarioSkyIndex;
        internal byte mediaIndex;
        internal byte scenarioVisibleSkyIndex;
        internal byte scenarioAtmosphericFogIndex;
        internal byte planarFogDesignator;
        internal byte visibleFogPlaneIndex;
        internal Moonfish.Tags.ShortBlockIndex1 backgroundSound;
        internal Moonfish.Tags.ShortBlockIndex1 soundEnvironment;
        internal Moonfish.Tags.ShortBlockIndex1 weather;
        internal short transitionStructureBSP;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Flags flags;
        internal byte[] invalidName_1;
        internal PredictedResourceBlock[] predictedResources;
        internal StructureBspClusterPortalIndexBlock[] portals;
        internal int checksumFromStructure;
        internal StructureBspClusterInstancedGeometryIndexBlock[] instancedGeometryIndices;
        internal GlobalGeometrySectionStripIndexBlock[] indexReorderTable;
        internal byte[] collisionMoppCode;
        
        public override int SerializedSize{get { return 176; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspClusterBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            clusterData = Guerilla.ReadBlockArray<StructureBspClusterDataBlockNew>(binaryReader);
            boundsX = binaryReader.ReadRange();
            boundsY = binaryReader.ReadRange();
            boundsZ = binaryReader.ReadRange();
            scenarioSkyIndex = binaryReader.ReadByte();
            mediaIndex = binaryReader.ReadByte();
            scenarioVisibleSkyIndex = binaryReader.ReadByte();
            scenarioAtmosphericFogIndex = binaryReader.ReadByte();
            planarFogDesignator = binaryReader.ReadByte();
            visibleFogPlaneIndex = binaryReader.ReadByte();
            backgroundSound = binaryReader.ReadShortBlockIndex1();
            soundEnvironment = binaryReader.ReadShortBlockIndex1();
            weather = binaryReader.ReadShortBlockIndex1();
            transitionStructureBSP = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            portals = Guerilla.ReadBlockArray<StructureBspClusterPortalIndexBlock>(binaryReader);
            checksumFromStructure = binaryReader.ReadInt32();
            instancedGeometryIndices = Guerilla.ReadBlockArray<StructureBspClusterInstancedGeometryIndexBlock>(binaryReader);
            indexReorderTable = Guerilla.ReadBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryReader);
            collisionMoppCode = Guerilla.ReadData(binaryReader);
        }
        public  StructureBspClusterBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            clusterData = Guerilla.ReadBlockArray<StructureBspClusterDataBlockNew>(binaryReader);
            boundsX = binaryReader.ReadRange();
            boundsY = binaryReader.ReadRange();
            boundsZ = binaryReader.ReadRange();
            scenarioSkyIndex = binaryReader.ReadByte();
            mediaIndex = binaryReader.ReadByte();
            scenarioVisibleSkyIndex = binaryReader.ReadByte();
            scenarioAtmosphericFogIndex = binaryReader.ReadByte();
            planarFogDesignator = binaryReader.ReadByte();
            visibleFogPlaneIndex = binaryReader.ReadByte();
            backgroundSound = binaryReader.ReadShortBlockIndex1();
            soundEnvironment = binaryReader.ReadShortBlockIndex1();
            weather = binaryReader.ReadShortBlockIndex1();
            transitionStructureBSP = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            portals = Guerilla.ReadBlockArray<StructureBspClusterPortalIndexBlock>(binaryReader);
            checksumFromStructure = binaryReader.ReadInt32();
            instancedGeometryIndices = Guerilla.ReadBlockArray<StructureBspClusterInstancedGeometryIndexBlock>(binaryReader);
            indexReorderTable = Guerilla.ReadBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryReader);
            collisionMoppCode = Guerilla.ReadData(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                sectionInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterDataBlockNew>(binaryWriter, clusterData, nextAddress);
                binaryWriter.Write(boundsX);
                binaryWriter.Write(boundsY);
                binaryWriter.Write(boundsZ);
                binaryWriter.Write(scenarioSkyIndex);
                binaryWriter.Write(mediaIndex);
                binaryWriter.Write(scenarioVisibleSkyIndex);
                binaryWriter.Write(scenarioAtmosphericFogIndex);
                binaryWriter.Write(planarFogDesignator);
                binaryWriter.Write(visibleFogPlaneIndex);
                binaryWriter.Write(backgroundSound);
                binaryWriter.Write(soundEnvironment);
                binaryWriter.Write(weather);
                binaryWriter.Write(transitionStructureBSP);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_1, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<PredictedResourceBlock>(binaryWriter, predictedResources, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterPortalIndexBlock>(binaryWriter, portals, nextAddress);
                binaryWriter.Write(checksumFromStructure);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterInstancedGeometryIndexBlock>(binaryWriter, instancedGeometryIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometrySectionStripIndexBlock>(binaryWriter, indexReorderTable, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, collisionMoppCode, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            OneWayPortal = 1,
            DoorPortal = 2,
            PostprocessedGeometry = 4,
            IsTheSky = 8,
        };
    };
}
