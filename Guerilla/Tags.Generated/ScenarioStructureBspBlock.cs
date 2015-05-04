// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Sbsp = (TagClass)"sbsp";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sbsp")]
    public partial class ScenarioStructureBspBlock : ScenarioStructureBspBlockBase
    {
        public ScenarioStructureBspBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 572, Alignment = 4)]
    public class ScenarioStructureBspBlockBase : GuerillaBlock
    {
        internal GlobalTagImportInfoBlock[] importInfo;
        internal byte[] invalidName_;
        internal StructureCollisionMaterialsBlock[] collisionMaterials;
        internal GlobalCollisionBspBlock[] collisionBSP;
        /// <summary>
        /// Height below which vehicles get pushed up by an unstoppable force.
        /// </summary>
        internal float vehicleFloorWorldUnits;
        /// <summary>
        /// Height above which vehicles get pushed down by an unstoppable force.
        /// </summary>
        internal float vehicleCeilingWorldUnits;
        internal UNUSEDStructureBspNodeBlock[] uNUSEDNodes;
        internal StructureBspLeafBlock[] leaves;
        internal Moonfish.Model.Range worldBoundsX;
        internal Moonfish.Model.Range worldBoundsY;
        internal Moonfish.Model.Range worldBoundsZ;
        internal StructureBspSurfaceReferenceBlock[] surfaceReferences;
        internal byte[] clusterData;
        internal StructureBspClusterPortalBlock[] clusterPortals;
        internal StructureBspFogPlaneBlock[] fogPlanes;
        internal byte[] invalidName_0;
        internal StructureBspWeatherPaletteBlock[] weatherPalette;
        internal StructureBspWeatherPolyhedronBlock[] weatherPolyhedra;
        internal StructureBspDetailObjectDataBlock[] detailObjects;
        internal StructureBspClusterBlock[] clusters;
        internal GlobalGeometryMaterialBlock[] materials;
        internal StructureBspSkyOwnerClusterBlock[] skyOwnerCluster;
        internal StructureBspConveyorSurfaceBlock[] conveyorSurfaces;
        internal StructureBspBreakableSurfaceBlock[] breakableSurfaces;
        internal PathfindingDataBlock[] pathfindingData;
        internal StructureBspPathfindingEdgesBlock[] pathfindingEdges;
        internal StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
        internal StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
        internal byte[] soundPASData;
        internal StructureBspMarkerBlock[] markers;
        internal StructureBspRuntimeDecalBlock[] runtimeDecals;
        internal StructureBspEnvironmentObjectPaletteBlock[] environmentObjectPalette;
        internal StructureBspEnvironmentObjectBlock[] environmentObjects;
        internal StructureBspLightmapDataBlock[] lightmaps;
        internal byte[] invalidName_1;
        internal GlobalMapLeafBlock[] leafMapLeaves;
        internal GlobalLeafConnectionBlock[] leafMapConnections;
        internal GlobalErrorReportCategoriesBlock[] errors;
        internal StructureBspPrecomputedLightingBlock[] precomputedLighting;
        internal StructureBspInstancedGeometryDefinitionBlock[] instancedGeometriesDefinitions;
        internal StructureBspInstancedGeometryInstancesBlock[] instancedGeometryInstances;
        internal StructureBspSoundClusterBlock[] ambienceSoundClusters;
        internal StructureBspSoundClusterBlock[] reverbSoundClusters;
        internal TransparentPlanesBlock[] transparentPlanes;
        internal byte[] invalidName_2;
        /// <summary>
        /// Distances this far and longer from limit origin will pull you back in.
        /// </summary>
        internal float vehicleSpericalLimitRadius;
        /// <summary>
        /// Center of space in which vehicle can move.
        /// </summary>
        internal OpenTK.Vector3 vehicleSpericalLimitCenter;
        internal StructureBspDebugInfoBlock[] debugInfo;
        [TagReference("DECP")]
        internal Moonfish.Tags.TagReference decorators;
        internal GlobalStructurePhysicsStructBlock structurePhysics;
        internal GlobalWaterDefinitionsBlock[] waterDefinitions;
        internal StructurePortalDeviceMappingBlock[] portalDeviceMapping;
        internal StructureBspAudibilityBlock[] audibility;
        internal StructureBspFakeLightprobesBlock[] objectFakeLightprobes;
        internal DecoratorPlacementDefinitionBlock[] decorators0;
        public override int SerializedSize { get { return 572; } }
        public override int Alignment { get { return 4; } }
        public ScenarioStructureBspBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalTagImportInfoBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureCollisionMaterialsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalCollisionBspBlock>(binaryReader));
            vehicleFloorWorldUnits = binaryReader.ReadSingle();
            vehicleCeilingWorldUnits = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<UNUSEDStructureBspNodeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspLeafBlock>(binaryReader));
            worldBoundsX = binaryReader.ReadRange();
            worldBoundsY = binaryReader.ReadRange();
            worldBoundsZ = binaryReader.ReadRange();
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSurfaceReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspClusterPortalBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspFogPlaneBlock>(binaryReader));
            invalidName_0 = binaryReader.ReadBytes(24);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspWeatherPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspWeatherPolyhedronBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDetailObjectDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspClusterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryMaterialBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSkyOwnerClusterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspConveyorSurfaceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspBreakableSurfaceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PathfindingDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspPathfindingEdgesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspBackgroundSoundPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSoundEnvironmentPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspMarkerBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspRuntimeDecalBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspEnvironmentObjectPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspEnvironmentObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspLightmapDataBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalMapLeafBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalLeafConnectionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalErrorReportCategoriesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspPrecomputedLightingBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspInstancedGeometryDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspInstancedGeometryInstancesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSoundClusterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSoundClusterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TransparentPlanesBlock>(binaryReader));
            invalidName_2 = binaryReader.ReadBytes(96);
            vehicleSpericalLimitRadius = binaryReader.ReadSingle();
            vehicleSpericalLimitCenter = binaryReader.ReadVector3();
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspDebugInfoBlock>(binaryReader));
            decorators = binaryReader.ReadTagReference();
            structurePhysics = new GlobalStructurePhysicsStructBlock();
            blamPointers.Concat(structurePhysics.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalWaterDefinitionsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructurePortalDeviceMappingBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspAudibilityBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspFakeLightprobesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorPlacementDefinitionBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            importInfo = ReadBlockArrayData<GlobalTagImportInfoBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            collisionMaterials = ReadBlockArrayData<StructureCollisionMaterialsBlock>(binaryReader, blamPointers.Dequeue());
            collisionBSP = ReadBlockArrayData<GlobalCollisionBspBlock>(binaryReader, blamPointers.Dequeue());
            uNUSEDNodes = ReadBlockArrayData<UNUSEDStructureBspNodeBlock>(binaryReader, blamPointers.Dequeue());
            leaves = ReadBlockArrayData<StructureBspLeafBlock>(binaryReader, blamPointers.Dequeue());
            surfaceReferences = ReadBlockArrayData<StructureBspSurfaceReferenceBlock>(binaryReader, blamPointers.Dequeue());
            clusterData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            clusterPortals = ReadBlockArrayData<StructureBspClusterPortalBlock>(binaryReader, blamPointers.Dequeue());
            fogPlanes = ReadBlockArrayData<StructureBspFogPlaneBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            weatherPalette = ReadBlockArrayData<StructureBspWeatherPaletteBlock>(binaryReader, blamPointers.Dequeue());
            weatherPolyhedra = ReadBlockArrayData<StructureBspWeatherPolyhedronBlock>(binaryReader, blamPointers.Dequeue());
            detailObjects = ReadBlockArrayData<StructureBspDetailObjectDataBlock>(binaryReader, blamPointers.Dequeue());
            clusters = ReadBlockArrayData<StructureBspClusterBlock>(binaryReader, blamPointers.Dequeue());
            materials = ReadBlockArrayData<GlobalGeometryMaterialBlock>(binaryReader, blamPointers.Dequeue());
            skyOwnerCluster = ReadBlockArrayData<StructureBspSkyOwnerClusterBlock>(binaryReader, blamPointers.Dequeue());
            conveyorSurfaces = ReadBlockArrayData<StructureBspConveyorSurfaceBlock>(binaryReader, blamPointers.Dequeue());
            breakableSurfaces = ReadBlockArrayData<StructureBspBreakableSurfaceBlock>(binaryReader, blamPointers.Dequeue());
            pathfindingData = ReadBlockArrayData<PathfindingDataBlock>(binaryReader, blamPointers.Dequeue());
            pathfindingEdges = ReadBlockArrayData<StructureBspPathfindingEdgesBlock>(binaryReader, blamPointers.Dequeue());
            backgroundSoundPalette = ReadBlockArrayData<StructureBspBackgroundSoundPaletteBlock>(binaryReader, blamPointers.Dequeue());
            soundEnvironmentPalette = ReadBlockArrayData<StructureBspSoundEnvironmentPaletteBlock>(binaryReader, blamPointers.Dequeue());
            soundPASData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            markers = ReadBlockArrayData<StructureBspMarkerBlock>(binaryReader, blamPointers.Dequeue());
            runtimeDecals = ReadBlockArrayData<StructureBspRuntimeDecalBlock>(binaryReader, blamPointers.Dequeue());
            environmentObjectPalette = ReadBlockArrayData<StructureBspEnvironmentObjectPaletteBlock>(binaryReader, blamPointers.Dequeue());
            environmentObjects = ReadBlockArrayData<StructureBspEnvironmentObjectBlock>(binaryReader, blamPointers.Dequeue());
            lightmaps = ReadBlockArrayData<StructureBspLightmapDataBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            leafMapLeaves = ReadBlockArrayData<GlobalMapLeafBlock>(binaryReader, blamPointers.Dequeue());
            leafMapConnections = ReadBlockArrayData<GlobalLeafConnectionBlock>(binaryReader, blamPointers.Dequeue());
            errors = ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, blamPointers.Dequeue());
            precomputedLighting = ReadBlockArrayData<StructureBspPrecomputedLightingBlock>(binaryReader, blamPointers.Dequeue());
            instancedGeometriesDefinitions = ReadBlockArrayData<StructureBspInstancedGeometryDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            instancedGeometryInstances = ReadBlockArrayData<StructureBspInstancedGeometryInstancesBlock>(binaryReader, blamPointers.Dequeue());
            ambienceSoundClusters = ReadBlockArrayData<StructureBspSoundClusterBlock>(binaryReader, blamPointers.Dequeue());
            reverbSoundClusters = ReadBlockArrayData<StructureBspSoundClusterBlock>(binaryReader, blamPointers.Dequeue());
            transparentPlanes = ReadBlockArrayData<TransparentPlanesBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_2[20].ReadPointers(binaryReader, blamPointers);
            invalidName_2[21].ReadPointers(binaryReader, blamPointers);
            invalidName_2[22].ReadPointers(binaryReader, blamPointers);
            invalidName_2[23].ReadPointers(binaryReader, blamPointers);
            invalidName_2[24].ReadPointers(binaryReader, blamPointers);
            invalidName_2[25].ReadPointers(binaryReader, blamPointers);
            invalidName_2[26].ReadPointers(binaryReader, blamPointers);
            invalidName_2[27].ReadPointers(binaryReader, blamPointers);
            invalidName_2[28].ReadPointers(binaryReader, blamPointers);
            invalidName_2[29].ReadPointers(binaryReader, blamPointers);
            invalidName_2[30].ReadPointers(binaryReader, blamPointers);
            invalidName_2[31].ReadPointers(binaryReader, blamPointers);
            invalidName_2[32].ReadPointers(binaryReader, blamPointers);
            invalidName_2[33].ReadPointers(binaryReader, blamPointers);
            invalidName_2[34].ReadPointers(binaryReader, blamPointers);
            invalidName_2[35].ReadPointers(binaryReader, blamPointers);
            invalidName_2[36].ReadPointers(binaryReader, blamPointers);
            invalidName_2[37].ReadPointers(binaryReader, blamPointers);
            invalidName_2[38].ReadPointers(binaryReader, blamPointers);
            invalidName_2[39].ReadPointers(binaryReader, blamPointers);
            invalidName_2[40].ReadPointers(binaryReader, blamPointers);
            invalidName_2[41].ReadPointers(binaryReader, blamPointers);
            invalidName_2[42].ReadPointers(binaryReader, blamPointers);
            invalidName_2[43].ReadPointers(binaryReader, blamPointers);
            invalidName_2[44].ReadPointers(binaryReader, blamPointers);
            invalidName_2[45].ReadPointers(binaryReader, blamPointers);
            invalidName_2[46].ReadPointers(binaryReader, blamPointers);
            invalidName_2[47].ReadPointers(binaryReader, blamPointers);
            invalidName_2[48].ReadPointers(binaryReader, blamPointers);
            invalidName_2[49].ReadPointers(binaryReader, blamPointers);
            invalidName_2[50].ReadPointers(binaryReader, blamPointers);
            invalidName_2[51].ReadPointers(binaryReader, blamPointers);
            invalidName_2[52].ReadPointers(binaryReader, blamPointers);
            invalidName_2[53].ReadPointers(binaryReader, blamPointers);
            invalidName_2[54].ReadPointers(binaryReader, blamPointers);
            invalidName_2[55].ReadPointers(binaryReader, blamPointers);
            invalidName_2[56].ReadPointers(binaryReader, blamPointers);
            invalidName_2[57].ReadPointers(binaryReader, blamPointers);
            invalidName_2[58].ReadPointers(binaryReader, blamPointers);
            invalidName_2[59].ReadPointers(binaryReader, blamPointers);
            invalidName_2[60].ReadPointers(binaryReader, blamPointers);
            invalidName_2[61].ReadPointers(binaryReader, blamPointers);
            invalidName_2[62].ReadPointers(binaryReader, blamPointers);
            invalidName_2[63].ReadPointers(binaryReader, blamPointers);
            invalidName_2[64].ReadPointers(binaryReader, blamPointers);
            invalidName_2[65].ReadPointers(binaryReader, blamPointers);
            invalidName_2[66].ReadPointers(binaryReader, blamPointers);
            invalidName_2[67].ReadPointers(binaryReader, blamPointers);
            invalidName_2[68].ReadPointers(binaryReader, blamPointers);
            invalidName_2[69].ReadPointers(binaryReader, blamPointers);
            invalidName_2[70].ReadPointers(binaryReader, blamPointers);
            invalidName_2[71].ReadPointers(binaryReader, blamPointers);
            invalidName_2[72].ReadPointers(binaryReader, blamPointers);
            invalidName_2[73].ReadPointers(binaryReader, blamPointers);
            invalidName_2[74].ReadPointers(binaryReader, blamPointers);
            invalidName_2[75].ReadPointers(binaryReader, blamPointers);
            invalidName_2[76].ReadPointers(binaryReader, blamPointers);
            invalidName_2[77].ReadPointers(binaryReader, blamPointers);
            invalidName_2[78].ReadPointers(binaryReader, blamPointers);
            invalidName_2[79].ReadPointers(binaryReader, blamPointers);
            invalidName_2[80].ReadPointers(binaryReader, blamPointers);
            invalidName_2[81].ReadPointers(binaryReader, blamPointers);
            invalidName_2[82].ReadPointers(binaryReader, blamPointers);
            invalidName_2[83].ReadPointers(binaryReader, blamPointers);
            invalidName_2[84].ReadPointers(binaryReader, blamPointers);
            invalidName_2[85].ReadPointers(binaryReader, blamPointers);
            invalidName_2[86].ReadPointers(binaryReader, blamPointers);
            invalidName_2[87].ReadPointers(binaryReader, blamPointers);
            invalidName_2[88].ReadPointers(binaryReader, blamPointers);
            invalidName_2[89].ReadPointers(binaryReader, blamPointers);
            invalidName_2[90].ReadPointers(binaryReader, blamPointers);
            invalidName_2[91].ReadPointers(binaryReader, blamPointers);
            invalidName_2[92].ReadPointers(binaryReader, blamPointers);
            invalidName_2[93].ReadPointers(binaryReader, blamPointers);
            invalidName_2[94].ReadPointers(binaryReader, blamPointers);
            invalidName_2[95].ReadPointers(binaryReader, blamPointers);
            debugInfo = ReadBlockArrayData<StructureBspDebugInfoBlock>(binaryReader, blamPointers.Dequeue());
            structurePhysics.ReadPointers(binaryReader, blamPointers);
            waterDefinitions = ReadBlockArrayData<GlobalWaterDefinitionsBlock>(binaryReader, blamPointers.Dequeue());
            portalDeviceMapping = ReadBlockArrayData<StructurePortalDeviceMappingBlock>(binaryReader, blamPointers.Dequeue());
            audibility = ReadBlockArrayData<StructureBspAudibilityBlock>(binaryReader, blamPointers.Dequeue());
            objectFakeLightprobes = ReadBlockArrayData<StructureBspFakeLightprobesBlock>(binaryReader, blamPointers.Dequeue());
            decorators0 = ReadBlockArrayData<DecoratorPlacementDefinitionBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalTagImportInfoBlock>(binaryWriter, importInfo, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<StructureCollisionMaterialsBlock>(binaryWriter, collisionMaterials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalCollisionBspBlock>(binaryWriter, collisionBSP, nextAddress);
                binaryWriter.Write(vehicleFloorWorldUnits);
                binaryWriter.Write(vehicleCeilingWorldUnits);
                nextAddress = Guerilla.WriteBlockArray<UNUSEDStructureBspNodeBlock>(binaryWriter, uNUSEDNodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspLeafBlock>(binaryWriter, leaves, nextAddress);
                binaryWriter.Write(worldBoundsX);
                binaryWriter.Write(worldBoundsY);
                binaryWriter.Write(worldBoundsZ);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSurfaceReferenceBlock>(binaryWriter, surfaceReferences, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, clusterData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterPortalBlock>(binaryWriter, clusterPortals, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspFogPlaneBlock>(binaryWriter, fogPlanes, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 24);
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPaletteBlock>(binaryWriter, weatherPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPolyhedronBlock>(binaryWriter, weatherPolyhedra, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDetailObjectDataBlock>(binaryWriter, detailObjects, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterBlock>(binaryWriter, clusters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryMaterialBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSkyOwnerClusterBlock>(binaryWriter, skyOwnerCluster, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspConveyorSurfaceBlock>(binaryWriter, conveyorSurfaces, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspBreakableSurfaceBlock>(binaryWriter, breakableSurfaces, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PathfindingDataBlock>(binaryWriter, pathfindingData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspPathfindingEdgesBlock>(binaryWriter, pathfindingEdges, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspBackgroundSoundPaletteBlock>(binaryWriter, backgroundSoundPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSoundEnvironmentPaletteBlock>(binaryWriter, soundEnvironmentPalette, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, soundPASData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspMarkerBlock>(binaryWriter, markers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspRuntimeDecalBlock>(binaryWriter, runtimeDecals, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspEnvironmentObjectPaletteBlock>(binaryWriter, environmentObjectPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspEnvironmentObjectBlock>(binaryWriter, environmentObjects, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspLightmapDataBlock>(binaryWriter, lightmaps, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<GlobalMapLeafBlock>(binaryWriter, leafMapLeaves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalLeafConnectionBlock>(binaryWriter, leafMapConnections, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalErrorReportCategoriesBlock>(binaryWriter, errors, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspPrecomputedLightingBlock>(binaryWriter, precomputedLighting, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspInstancedGeometryDefinitionBlock>(binaryWriter, instancedGeometriesDefinitions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspInstancedGeometryInstancesBlock>(binaryWriter, instancedGeometryInstances, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSoundClusterBlock>(binaryWriter, ambienceSoundClusters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSoundClusterBlock>(binaryWriter, reverbSoundClusters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TransparentPlanesBlock>(binaryWriter, transparentPlanes, nextAddress);
                binaryWriter.Write(invalidName_2, 0, 96);
                binaryWriter.Write(vehicleSpericalLimitRadius);
                binaryWriter.Write(vehicleSpericalLimitCenter);
                nextAddress = Guerilla.WriteBlockArray<StructureBspDebugInfoBlock>(binaryWriter, debugInfo, nextAddress);
                binaryWriter.Write(decorators);
                structurePhysics.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<GlobalWaterDefinitionsBlock>(binaryWriter, waterDefinitions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructurePortalDeviceMappingBlock>(binaryWriter, portalDeviceMapping, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspAudibilityBlock>(binaryWriter, audibility, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspFakeLightprobesBlock>(binaryWriter, objectFakeLightprobes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorPlacementDefinitionBlock>(binaryWriter, decorators0, nextAddress);
                return nextAddress;
            }
        }
    };
}
