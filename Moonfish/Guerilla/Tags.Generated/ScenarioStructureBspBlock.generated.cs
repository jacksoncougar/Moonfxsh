//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagClassAttribute("sbsp")]
    [TagBlockOriginalNameAttribute("scenario_structure_bsp_block")]
    public partial class ScenarioStructureBspBlock : GuerillaBlock, IWriteQueueable
    {
        public GlobalTagImportInfoBlock[] ImportInfo = new GlobalTagImportInfoBlock[0];
        private byte[] fieldpad = new byte[4];
        public StructureCollisionMaterialsBlock[] CollisionMaterials = new StructureCollisionMaterialsBlock[0];
        public GlobalCollisionBspBlock[] CollisionBSP = new GlobalCollisionBspBlock[0];
        public float VehicleFloor;
        public float VehicleCeiling;
        public UNUSEDStructureBspNodeBlock[] UNUSEDNodes = new UNUSEDStructureBspNodeBlock[0];
        public StructureBspLeafBlock[] Leaves = new StructureBspLeafBlock[0];
        public Moonfish.Model.Range WorldBoundsX;
        public Moonfish.Model.Range WorldBoundsY;
        public Moonfish.Model.Range WorldBoundsZ;
        public StructureBspSurfaceReferenceBlock[] SurfaceReferences = new StructureBspSurfaceReferenceBlock[0];
        public byte[] ClusterData;
        public StructureBspClusterPortalBlock[] ClusterPortals = new StructureBspClusterPortalBlock[0];
        public StructureBspFogPlaneBlock[] FogPlanes = new StructureBspFogPlaneBlock[0];
        private byte[] fieldpad0 = new byte[24];
        public StructureBspWeatherPaletteBlock[] WeatherPalette = new StructureBspWeatherPaletteBlock[0];
        public StructureBspWeatherPolyhedronBlock[] WeatherPolyhedra = new StructureBspWeatherPolyhedronBlock[0];
        public StructureBspDetailObjectDataBlock[] DetailObjects = new StructureBspDetailObjectDataBlock[0];
        public StructureBspClusterBlock[] Clusters = new StructureBspClusterBlock[0];
        public GlobalGeometryMaterialBlock[] Materials = new GlobalGeometryMaterialBlock[0];
        public StructureBspSkyOwnerClusterBlock[] SkyOwnerCluster = new StructureBspSkyOwnerClusterBlock[0];
        public StructureBspConveyorSurfaceBlock[] ConveyorSurfaces = new StructureBspConveyorSurfaceBlock[0];
        public StructureBspBreakableSurfaceBlock[] BreakableSurfaces = new StructureBspBreakableSurfaceBlock[0];
        public PathfindingDataBlock[] PathfindingData = new PathfindingDataBlock[0];
        public StructureBspPathfindingEdgesBlock[] PathfindingEdges = new StructureBspPathfindingEdgesBlock[0];
        public StructureBspBackgroundSoundPaletteBlock[] BackgroundSoundPalette = new StructureBspBackgroundSoundPaletteBlock[0];
        public StructureBspSoundEnvironmentPaletteBlock[] SoundEnvironmentPalette = new StructureBspSoundEnvironmentPaletteBlock[0];
        public byte[] SoundPASData;
        public StructureBspMarkerBlock[] Markers = new StructureBspMarkerBlock[0];
        public StructureBspRuntimeDecalBlock[] RuntimeDecals = new StructureBspRuntimeDecalBlock[0];
        public StructureBspEnvironmentObjectPaletteBlock[] EnvironmentObjectPalette = new StructureBspEnvironmentObjectPaletteBlock[0];
        public StructureBspEnvironmentObjectBlock[] EnvironmentObjects = new StructureBspEnvironmentObjectBlock[0];
        public StructureBspLightmapDataBlock[] Lightmaps = new StructureBspLightmapDataBlock[0];
        private byte[] fieldpad1 = new byte[4];
        public GlobalMapLeafBlock[] LeafMapLeaves = new GlobalMapLeafBlock[0];
        public GlobalLeafConnectionBlock[] LeafMapConnections = new GlobalLeafConnectionBlock[0];
        public GlobalErrorReportCategoriesBlock[] Errors = new GlobalErrorReportCategoriesBlock[0];
        public StructureBspPrecomputedLightingBlock[] PrecomputedLighting = new StructureBspPrecomputedLightingBlock[0];
        public StructureBspInstancedGeometryDefinitionBlock[] InstancedGeometriesDefinitions = new StructureBspInstancedGeometryDefinitionBlock[0];
        public StructureBspInstancedGeometryInstancesBlock[] InstancedGeometryInstances = new StructureBspInstancedGeometryInstancesBlock[0];
        public StructureBspSoundClusterBlock[] AmbienceSoundClusters = new StructureBspSoundClusterBlock[0];
        public StructureBspSoundClusterBlock[] ReverbSoundClusters = new StructureBspSoundClusterBlock[0];
        public TransparentPlanesBlock[] TransparentPlanes = new TransparentPlanesBlock[0];
        private byte[] fieldpad2 = new byte[96];
        public float VehicleSpericalLimitRadius;
        public OpenTK.Vector3 VehicleSpericalLimitCenter;
        public StructureBspDebugInfoBlock[] DebugInfo = new StructureBspDebugInfoBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("DECP")]
        public Moonfish.Tags.TagReference Decorators;
        public GlobalStructurePhysicsStructBlock StructurePhysics = new GlobalStructurePhysicsStructBlock();
        public GlobalWaterDefinitionsBlock[] WaterDefinitions = new GlobalWaterDefinitionsBlock[0];
        public StructurePortalDeviceMappingBlock[] portaldeviceMapping = new StructurePortalDeviceMappingBlock[0];
        public StructureBspAudibilityBlock[] Audibility = new StructureBspAudibilityBlock[0];
        public StructureBspFakeLightprobesBlock[] ObjectFakeLightprobes = new StructureBspFakeLightprobesBlock[0];
        public DecoratorPlacementDefinitionBlock[] Decorators0 = new DecoratorPlacementDefinitionBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 572;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(592));
            this.fieldpad = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(64));
            this.VehicleFloor = binaryReader.ReadSingle();
            this.VehicleCeiling = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(6));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.WorldBoundsX = binaryReader.ReadRange();
            this.WorldBoundsY = binaryReader.ReadRange();
            this.WorldBoundsZ = binaryReader.ReadRange();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            this.fieldpad0 = binaryReader.ReadBytes(24);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(136));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(176));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(116));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(100));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(72));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(60));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(104));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.fieldpad1 = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(676));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(48));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(200));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(88));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            this.fieldpad2 = binaryReader.ReadBytes(96);
            this.VehicleSpericalLimitRadius = binaryReader.ReadSingle();
            this.VehicleSpericalLimitCenter = binaryReader.ReadVector3();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(88));
            this.Decorators = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.StructurePhysics.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(172));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(52));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(92));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(48));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ImportInfo = base.ReadBlockArrayData<GlobalTagImportInfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.CollisionMaterials = base.ReadBlockArrayData<StructureCollisionMaterialsBlock>(binaryReader, pointerQueue.Dequeue());
            this.CollisionBSP = base.ReadBlockArrayData<GlobalCollisionBspBlock>(binaryReader, pointerQueue.Dequeue());
            this.UNUSEDNodes = base.ReadBlockArrayData<UNUSEDStructureBspNodeBlock>(binaryReader, pointerQueue.Dequeue());
            this.Leaves = base.ReadBlockArrayData<StructureBspLeafBlock>(binaryReader, pointerQueue.Dequeue());
            this.SurfaceReferences = base.ReadBlockArrayData<StructureBspSurfaceReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.ClusterData = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.ClusterPortals = base.ReadBlockArrayData<StructureBspClusterPortalBlock>(binaryReader, pointerQueue.Dequeue());
            this.FogPlanes = base.ReadBlockArrayData<StructureBspFogPlaneBlock>(binaryReader, pointerQueue.Dequeue());
            this.WeatherPalette = base.ReadBlockArrayData<StructureBspWeatherPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.WeatherPolyhedra = base.ReadBlockArrayData<StructureBspWeatherPolyhedronBlock>(binaryReader, pointerQueue.Dequeue());
            this.DetailObjects = base.ReadBlockArrayData<StructureBspDetailObjectDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.Clusters = base.ReadBlockArrayData<StructureBspClusterBlock>(binaryReader, pointerQueue.Dequeue());
            this.Materials = base.ReadBlockArrayData<GlobalGeometryMaterialBlock>(binaryReader, pointerQueue.Dequeue());
            this.SkyOwnerCluster = base.ReadBlockArrayData<StructureBspSkyOwnerClusterBlock>(binaryReader, pointerQueue.Dequeue());
            this.ConveyorSurfaces = base.ReadBlockArrayData<StructureBspConveyorSurfaceBlock>(binaryReader, pointerQueue.Dequeue());
            this.BreakableSurfaces = base.ReadBlockArrayData<StructureBspBreakableSurfaceBlock>(binaryReader, pointerQueue.Dequeue());
            this.PathfindingData = base.ReadBlockArrayData<PathfindingDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.PathfindingEdges = base.ReadBlockArrayData<StructureBspPathfindingEdgesBlock>(binaryReader, pointerQueue.Dequeue());
            this.BackgroundSoundPalette = base.ReadBlockArrayData<StructureBspBackgroundSoundPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundEnvironmentPalette = base.ReadBlockArrayData<StructureBspSoundEnvironmentPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundPASData = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.Markers = base.ReadBlockArrayData<StructureBspMarkerBlock>(binaryReader, pointerQueue.Dequeue());
            this.RuntimeDecals = base.ReadBlockArrayData<StructureBspRuntimeDecalBlock>(binaryReader, pointerQueue.Dequeue());
            this.EnvironmentObjectPalette = base.ReadBlockArrayData<StructureBspEnvironmentObjectPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.EnvironmentObjects = base.ReadBlockArrayData<StructureBspEnvironmentObjectBlock>(binaryReader, pointerQueue.Dequeue());
            this.Lightmaps = base.ReadBlockArrayData<StructureBspLightmapDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.LeafMapLeaves = base.ReadBlockArrayData<GlobalMapLeafBlock>(binaryReader, pointerQueue.Dequeue());
            this.LeafMapConnections = base.ReadBlockArrayData<GlobalLeafConnectionBlock>(binaryReader, pointerQueue.Dequeue());
            this.Errors = base.ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, pointerQueue.Dequeue());
            this.PrecomputedLighting = base.ReadBlockArrayData<StructureBspPrecomputedLightingBlock>(binaryReader, pointerQueue.Dequeue());
            this.InstancedGeometriesDefinitions = base.ReadBlockArrayData<StructureBspInstancedGeometryDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
            this.InstancedGeometryInstances = base.ReadBlockArrayData<StructureBspInstancedGeometryInstancesBlock>(binaryReader, pointerQueue.Dequeue());
            this.AmbienceSoundClusters = base.ReadBlockArrayData<StructureBspSoundClusterBlock>(binaryReader, pointerQueue.Dequeue());
            this.ReverbSoundClusters = base.ReadBlockArrayData<StructureBspSoundClusterBlock>(binaryReader, pointerQueue.Dequeue());
            this.TransparentPlanes = base.ReadBlockArrayData<TransparentPlanesBlock>(binaryReader, pointerQueue.Dequeue());
            this.DebugInfo = base.ReadBlockArrayData<StructureBspDebugInfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.StructurePhysics.ReadInstances(binaryReader, pointerQueue);
            this.WaterDefinitions = base.ReadBlockArrayData<GlobalWaterDefinitionsBlock>(binaryReader, pointerQueue.Dequeue());
            this.portaldeviceMapping = base.ReadBlockArrayData<StructurePortalDeviceMappingBlock>(binaryReader, pointerQueue.Dequeue());
            this.Audibility = base.ReadBlockArrayData<StructureBspAudibilityBlock>(binaryReader, pointerQueue.Dequeue());
            this.ObjectFakeLightprobes = base.ReadBlockArrayData<StructureBspFakeLightprobesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Decorators0 = base.ReadBlockArrayData<DecoratorPlacementDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.ImportInfo);
            queueableBinaryWriter.QueueWrite(this.CollisionMaterials);
            queueableBinaryWriter.QueueWrite(this.CollisionBSP);
            queueableBinaryWriter.QueueWrite(this.UNUSEDNodes);
            queueableBinaryWriter.QueueWrite(this.Leaves);
            queueableBinaryWriter.QueueWrite(this.SurfaceReferences);
            queueableBinaryWriter.QueueWrite(this.ClusterData);
            queueableBinaryWriter.QueueWrite(this.ClusterPortals);
            queueableBinaryWriter.QueueWrite(this.FogPlanes);
            queueableBinaryWriter.QueueWrite(this.WeatherPalette);
            queueableBinaryWriter.QueueWrite(this.WeatherPolyhedra);
            queueableBinaryWriter.QueueWrite(this.DetailObjects);
            queueableBinaryWriter.QueueWrite(this.Clusters);
            queueableBinaryWriter.QueueWrite(this.Materials);
            queueableBinaryWriter.QueueWrite(this.SkyOwnerCluster);
            queueableBinaryWriter.QueueWrite(this.ConveyorSurfaces);
            queueableBinaryWriter.QueueWrite(this.BreakableSurfaces);
            queueableBinaryWriter.QueueWrite(this.PathfindingData);
            queueableBinaryWriter.QueueWrite(this.PathfindingEdges);
            queueableBinaryWriter.QueueWrite(this.BackgroundSoundPalette);
            queueableBinaryWriter.QueueWrite(this.SoundEnvironmentPalette);
            queueableBinaryWriter.QueueWrite(this.SoundPASData);
            queueableBinaryWriter.QueueWrite(this.Markers);
            queueableBinaryWriter.QueueWrite(this.RuntimeDecals);
            queueableBinaryWriter.QueueWrite(this.EnvironmentObjectPalette);
            queueableBinaryWriter.QueueWrite(this.EnvironmentObjects);
            queueableBinaryWriter.QueueWrite(this.Lightmaps);
            queueableBinaryWriter.QueueWrite(this.LeafMapLeaves);
            queueableBinaryWriter.QueueWrite(this.LeafMapConnections);
            queueableBinaryWriter.QueueWrite(this.Errors);
            queueableBinaryWriter.QueueWrite(this.PrecomputedLighting);
            queueableBinaryWriter.QueueWrite(this.InstancedGeometriesDefinitions);
            queueableBinaryWriter.QueueWrite(this.InstancedGeometryInstances);
            queueableBinaryWriter.QueueWrite(this.AmbienceSoundClusters);
            queueableBinaryWriter.QueueWrite(this.ReverbSoundClusters);
            queueableBinaryWriter.QueueWrite(this.TransparentPlanes);
            queueableBinaryWriter.QueueWrite(this.DebugInfo);
            this.StructurePhysics.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.WaterDefinitions);
            queueableBinaryWriter.QueueWrite(this.portaldeviceMapping);
            queueableBinaryWriter.QueueWrite(this.Audibility);
            queueableBinaryWriter.QueueWrite(this.ObjectFakeLightprobes);
            queueableBinaryWriter.QueueWrite(this.Decorators0);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.ImportInfo);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.CollisionMaterials);
            queueableBinaryWriter.WritePointer(this.CollisionBSP);
            queueableBinaryWriter.Write(this.VehicleFloor);
            queueableBinaryWriter.Write(this.VehicleCeiling);
            queueableBinaryWriter.WritePointer(this.UNUSEDNodes);
            queueableBinaryWriter.WritePointer(this.Leaves);
            queueableBinaryWriter.Write(this.WorldBoundsX);
            queueableBinaryWriter.Write(this.WorldBoundsY);
            queueableBinaryWriter.Write(this.WorldBoundsZ);
            queueableBinaryWriter.WritePointer(this.SurfaceReferences);
            queueableBinaryWriter.WritePointer(this.ClusterData);
            queueableBinaryWriter.WritePointer(this.ClusterPortals);
            queueableBinaryWriter.WritePointer(this.FogPlanes);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.WritePointer(this.WeatherPalette);
            queueableBinaryWriter.WritePointer(this.WeatherPolyhedra);
            queueableBinaryWriter.WritePointer(this.DetailObjects);
            queueableBinaryWriter.WritePointer(this.Clusters);
            queueableBinaryWriter.WritePointer(this.Materials);
            queueableBinaryWriter.WritePointer(this.SkyOwnerCluster);
            queueableBinaryWriter.WritePointer(this.ConveyorSurfaces);
            queueableBinaryWriter.WritePointer(this.BreakableSurfaces);
            queueableBinaryWriter.WritePointer(this.PathfindingData);
            queueableBinaryWriter.WritePointer(this.PathfindingEdges);
            queueableBinaryWriter.WritePointer(this.BackgroundSoundPalette);
            queueableBinaryWriter.WritePointer(this.SoundEnvironmentPalette);
            queueableBinaryWriter.WritePointer(this.SoundPASData);
            queueableBinaryWriter.WritePointer(this.Markers);
            queueableBinaryWriter.WritePointer(this.RuntimeDecals);
            queueableBinaryWriter.WritePointer(this.EnvironmentObjectPalette);
            queueableBinaryWriter.WritePointer(this.EnvironmentObjects);
            queueableBinaryWriter.WritePointer(this.Lightmaps);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.WritePointer(this.LeafMapLeaves);
            queueableBinaryWriter.WritePointer(this.LeafMapConnections);
            queueableBinaryWriter.WritePointer(this.Errors);
            queueableBinaryWriter.WritePointer(this.PrecomputedLighting);
            queueableBinaryWriter.WritePointer(this.InstancedGeometriesDefinitions);
            queueableBinaryWriter.WritePointer(this.InstancedGeometryInstances);
            queueableBinaryWriter.WritePointer(this.AmbienceSoundClusters);
            queueableBinaryWriter.WritePointer(this.ReverbSoundClusters);
            queueableBinaryWriter.WritePointer(this.TransparentPlanes);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.Write(this.VehicleSpericalLimitRadius);
            queueableBinaryWriter.Write(this.VehicleSpericalLimitCenter);
            queueableBinaryWriter.WritePointer(this.DebugInfo);
            queueableBinaryWriter.Write(this.Decorators);
            this.StructurePhysics.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.WaterDefinitions);
            queueableBinaryWriter.WritePointer(this.portaldeviceMapping);
            queueableBinaryWriter.WritePointer(this.Audibility);
            queueableBinaryWriter.WritePointer(this.ObjectFakeLightprobes);
            queueableBinaryWriter.WritePointer(this.Decorators0);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Sbsp = ((TagClass)("sbsp"));
    }
}
