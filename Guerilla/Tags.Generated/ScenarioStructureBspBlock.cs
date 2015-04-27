// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

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
        public  ScenarioStructureBspBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioStructureBspBlock(): base()
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
        
        public override int SerializedSize{get { return 572; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioStructureBspBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            importInfo = Guerilla.ReadBlockArray<GlobalTagImportInfoBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            collisionMaterials = Guerilla.ReadBlockArray<StructureCollisionMaterialsBlock>(binaryReader);
            collisionBSP = Guerilla.ReadBlockArray<GlobalCollisionBspBlock>(binaryReader);
            vehicleFloorWorldUnits = binaryReader.ReadSingle();
            vehicleCeilingWorldUnits = binaryReader.ReadSingle();
            uNUSEDNodes = Guerilla.ReadBlockArray<UNUSEDStructureBspNodeBlock>(binaryReader);
            leaves = Guerilla.ReadBlockArray<StructureBspLeafBlock>(binaryReader);
            worldBoundsX = binaryReader.ReadRange();
            worldBoundsY = binaryReader.ReadRange();
            worldBoundsZ = binaryReader.ReadRange();
            surfaceReferences = Guerilla.ReadBlockArray<StructureBspSurfaceReferenceBlock>(binaryReader);
            clusterData = Guerilla.ReadData(binaryReader);
            clusterPortals = Guerilla.ReadBlockArray<StructureBspClusterPortalBlock>(binaryReader);
            fogPlanes = Guerilla.ReadBlockArray<StructureBspFogPlaneBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(24);
            weatherPalette = Guerilla.ReadBlockArray<StructureBspWeatherPaletteBlock>(binaryReader);
            weatherPolyhedra = Guerilla.ReadBlockArray<StructureBspWeatherPolyhedronBlock>(binaryReader);
            detailObjects = Guerilla.ReadBlockArray<StructureBspDetailObjectDataBlock>(binaryReader);
            clusters = Guerilla.ReadBlockArray<StructureBspClusterBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<GlobalGeometryMaterialBlock>(binaryReader);
            skyOwnerCluster = Guerilla.ReadBlockArray<StructureBspSkyOwnerClusterBlock>(binaryReader);
            conveyorSurfaces = Guerilla.ReadBlockArray<StructureBspConveyorSurfaceBlock>(binaryReader);
            breakableSurfaces = Guerilla.ReadBlockArray<StructureBspBreakableSurfaceBlock>(binaryReader);
            pathfindingData = Guerilla.ReadBlockArray<PathfindingDataBlock>(binaryReader);
            pathfindingEdges = Guerilla.ReadBlockArray<StructureBspPathfindingEdgesBlock>(binaryReader);
            backgroundSoundPalette = Guerilla.ReadBlockArray<StructureBspBackgroundSoundPaletteBlock>(binaryReader);
            soundEnvironmentPalette = Guerilla.ReadBlockArray<StructureBspSoundEnvironmentPaletteBlock>(binaryReader);
            soundPASData = Guerilla.ReadData(binaryReader);
            markers = Guerilla.ReadBlockArray<StructureBspMarkerBlock>(binaryReader);
            runtimeDecals = Guerilla.ReadBlockArray<StructureBspRuntimeDecalBlock>(binaryReader);
            environmentObjectPalette = Guerilla.ReadBlockArray<StructureBspEnvironmentObjectPaletteBlock>(binaryReader);
            environmentObjects = Guerilla.ReadBlockArray<StructureBspEnvironmentObjectBlock>(binaryReader);
            lightmaps = Guerilla.ReadBlockArray<StructureBspLightmapDataBlock>(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(4);
            leafMapLeaves = Guerilla.ReadBlockArray<GlobalMapLeafBlock>(binaryReader);
            leafMapConnections = Guerilla.ReadBlockArray<GlobalLeafConnectionBlock>(binaryReader);
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>(binaryReader);
            precomputedLighting = Guerilla.ReadBlockArray<StructureBspPrecomputedLightingBlock>(binaryReader);
            instancedGeometriesDefinitions = Guerilla.ReadBlockArray<StructureBspInstancedGeometryDefinitionBlock>(binaryReader);
            instancedGeometryInstances = Guerilla.ReadBlockArray<StructureBspInstancedGeometryInstancesBlock>(binaryReader);
            ambienceSoundClusters = Guerilla.ReadBlockArray<StructureBspSoundClusterBlock>(binaryReader);
            reverbSoundClusters = Guerilla.ReadBlockArray<StructureBspSoundClusterBlock>(binaryReader);
            transparentPlanes = Guerilla.ReadBlockArray<TransparentPlanesBlock>(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(96);
            vehicleSpericalLimitRadius = binaryReader.ReadSingle();
            vehicleSpericalLimitCenter = binaryReader.ReadVector3();
            debugInfo = Guerilla.ReadBlockArray<StructureBspDebugInfoBlock>(binaryReader);
            decorators = binaryReader.ReadTagReference();
            structurePhysics = new GlobalStructurePhysicsStructBlock(binaryReader);
            waterDefinitions = Guerilla.ReadBlockArray<GlobalWaterDefinitionsBlock>(binaryReader);
            portalDeviceMapping = Guerilla.ReadBlockArray<StructurePortalDeviceMappingBlock>(binaryReader);
            audibility = Guerilla.ReadBlockArray<StructureBspAudibilityBlock>(binaryReader);
            objectFakeLightprobes = Guerilla.ReadBlockArray<StructureBspFakeLightprobesBlock>(binaryReader);
            decorators0 = Guerilla.ReadBlockArray<DecoratorPlacementDefinitionBlock>(binaryReader);
        }
        public  ScenarioStructureBspBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
