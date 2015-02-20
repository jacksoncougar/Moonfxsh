using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sbsp")]
    public  partial class ScenarioStructureBspBlock : ScenarioStructureBspBlockBase
    {
        public  ScenarioStructureBspBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 572)]
    public class ScenarioStructureBspBlockBase
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
        internal  ScenarioStructureBspBlockBase(BinaryReader binaryReader)
        {
            this.importInfo = ReadGlobalTagImportInfoBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.collisionMaterials = ReadStructureCollisionMaterialsBlockArray(binaryReader);
            this.collisionBSP = ReadGlobalCollisionBspBlockArray(binaryReader);
            this.vehicleFloorWorldUnits = binaryReader.ReadSingle();
            this.vehicleCeilingWorldUnits = binaryReader.ReadSingle();
            this.uNUSEDNodes = ReadUNUSEDStructureBspNodeBlockArray(binaryReader);
            this.leaves = ReadStructureBspLeafBlockArray(binaryReader);
            this.worldBoundsX = binaryReader.ReadRange();
            this.worldBoundsY = binaryReader.ReadRange();
            this.worldBoundsZ = binaryReader.ReadRange();
            this.surfaceReferences = ReadStructureBspSurfaceReferenceBlockArray(binaryReader);
            this.clusterData = ReadData(binaryReader);
            this.clusterPortals = ReadStructureBspClusterPortalBlockArray(binaryReader);
            this.fogPlanes = ReadStructureBspFogPlaneBlockArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(24);
            this.weatherPalette = ReadStructureBspWeatherPaletteBlockArray(binaryReader);
            this.weatherPolyhedra = ReadStructureBspWeatherPolyhedronBlockArray(binaryReader);
            this.detailObjects = ReadStructureBspDetailObjectDataBlockArray(binaryReader);
            this.clusters = ReadStructureBspClusterBlockArray(binaryReader);
            this.materials = ReadGlobalGeometryMaterialBlockArray(binaryReader);
            this.skyOwnerCluster = ReadStructureBspSkyOwnerClusterBlockArray(binaryReader);
            this.conveyorSurfaces = ReadStructureBspConveyorSurfaceBlockArray(binaryReader);
            this.breakableSurfaces = ReadStructureBspBreakableSurfaceBlockArray(binaryReader);
            this.pathfindingData = ReadPathfindingDataBlockArray(binaryReader);
            this.pathfindingEdges = ReadStructureBspPathfindingEdgesBlockArray(binaryReader);
            this.backgroundSoundPalette = ReadStructureBspBackgroundSoundPaletteBlockArray(binaryReader);
            this.soundEnvironmentPalette = ReadStructureBspSoundEnvironmentPaletteBlockArray(binaryReader);
            this.soundPASData = ReadData(binaryReader);
            this.markers = ReadStructureBspMarkerBlockArray(binaryReader);
            this.runtimeDecals = ReadStructureBspRuntimeDecalBlockArray(binaryReader);
            this.environmentObjectPalette = ReadStructureBspEnvironmentObjectPaletteBlockArray(binaryReader);
            this.environmentObjects = ReadStructureBspEnvironmentObjectBlockArray(binaryReader);
            this.lightmaps = ReadStructureBspLightmapDataBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.leafMapLeaves = ReadGlobalMapLeafBlockArray(binaryReader);
            this.leafMapConnections = ReadGlobalLeafConnectionBlockArray(binaryReader);
            this.errors = ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            this.precomputedLighting = ReadStructureBspPrecomputedLightingBlockArray(binaryReader);
            this.instancedGeometriesDefinitions = ReadStructureBspInstancedGeometryDefinitionBlockArray(binaryReader);
            this.instancedGeometryInstances = ReadStructureBspInstancedGeometryInstancesBlockArray(binaryReader);
            this.ambienceSoundClusters = ReadStructureBspSoundClusterBlockArray(binaryReader);
            this.reverbSoundClusters = ReadStructureBspSoundClusterBlockArray(binaryReader);
            this.transparentPlanes = ReadTransparentPlanesBlockArray(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(96);
            this.vehicleSpericalLimitRadius = binaryReader.ReadSingle();
            this.vehicleSpericalLimitCenter = binaryReader.ReadVector3();
            this.debugInfo = ReadStructureBspDebugInfoBlockArray(binaryReader);
            this.decorators = binaryReader.ReadTagReference();
            this.structurePhysics = new GlobalStructurePhysicsStructBlock(binaryReader);
            this.waterDefinitions = ReadGlobalWaterDefinitionsBlockArray(binaryReader);
            this.portalDeviceMapping = ReadStructurePortalDeviceMappingBlockArray(binaryReader);
            this.audibility = ReadStructureBspAudibilityBlockArray(binaryReader);
            this.objectFakeLightprobes = ReadStructureBspFakeLightprobesBlockArray(binaryReader);
            this.decorators0 = ReadDecoratorPlacementDefinitionBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual GlobalTagImportInfoBlock[] ReadGlobalTagImportInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalTagImportInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalTagImportInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalTagImportInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureCollisionMaterialsBlock[] ReadStructureCollisionMaterialsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureCollisionMaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureCollisionMaterialsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureCollisionMaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalCollisionBspBlock[] ReadGlobalCollisionBspBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalCollisionBspBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalCollisionBspBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalCollisionBspBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UNUSEDStructureBspNodeBlock[] ReadUNUSEDStructureBspNodeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UNUSEDStructureBspNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UNUSEDStructureBspNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UNUSEDStructureBspNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspLeafBlock[] ReadStructureBspLeafBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspLeafBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspLeafBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspLeafBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspSurfaceReferenceBlock[] ReadStructureBspSurfaceReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspSurfaceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspSurfaceReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspSurfaceReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspClusterPortalBlock[] ReadStructureBspClusterPortalBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterPortalBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterPortalBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterPortalBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspFogPlaneBlock[] ReadStructureBspFogPlaneBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFogPlaneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFogPlaneBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFogPlaneBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspWeatherPaletteBlock[] ReadStructureBspWeatherPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspWeatherPolyhedronBlock[] ReadStructureBspWeatherPolyhedronBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPolyhedronBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPolyhedronBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPolyhedronBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspDetailObjectDataBlock[] ReadStructureBspDetailObjectDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDetailObjectDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDetailObjectDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDetailObjectDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspClusterBlock[] ReadStructureBspClusterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometryMaterialBlock[] ReadGlobalGeometryMaterialBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspSkyOwnerClusterBlock[] ReadStructureBspSkyOwnerClusterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspSkyOwnerClusterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspSkyOwnerClusterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspSkyOwnerClusterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspConveyorSurfaceBlock[] ReadStructureBspConveyorSurfaceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspConveyorSurfaceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspConveyorSurfaceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspConveyorSurfaceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspBreakableSurfaceBlock[] ReadStructureBspBreakableSurfaceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspBreakableSurfaceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspBreakableSurfaceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspBreakableSurfaceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PathfindingDataBlock[] ReadPathfindingDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PathfindingDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PathfindingDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PathfindingDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspPathfindingEdgesBlock[] ReadStructureBspPathfindingEdgesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspPathfindingEdgesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspPathfindingEdgesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspPathfindingEdgesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspBackgroundSoundPaletteBlock[] ReadStructureBspBackgroundSoundPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspBackgroundSoundPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspBackgroundSoundPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspBackgroundSoundPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspSoundEnvironmentPaletteBlock[] ReadStructureBspSoundEnvironmentPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspSoundEnvironmentPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspSoundEnvironmentPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspSoundEnvironmentPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspMarkerBlock[] ReadStructureBspMarkerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspMarkerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspMarkerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspMarkerBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspRuntimeDecalBlock[] ReadStructureBspRuntimeDecalBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspRuntimeDecalBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspRuntimeDecalBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspRuntimeDecalBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspEnvironmentObjectPaletteBlock[] ReadStructureBspEnvironmentObjectPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspEnvironmentObjectPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspEnvironmentObjectPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspEnvironmentObjectPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspEnvironmentObjectBlock[] ReadStructureBspEnvironmentObjectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspEnvironmentObjectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspEnvironmentObjectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspEnvironmentObjectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspLightmapDataBlock[] ReadStructureBspLightmapDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspLightmapDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspLightmapDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspLightmapDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalMapLeafBlock[] ReadGlobalMapLeafBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalMapLeafBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalMapLeafBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalMapLeafBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalLeafConnectionBlock[] ReadGlobalLeafConnectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalLeafConnectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalLeafConnectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalLeafConnectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspPrecomputedLightingBlock[] ReadStructureBspPrecomputedLightingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspPrecomputedLightingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspPrecomputedLightingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspPrecomputedLightingBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspInstancedGeometryDefinitionBlock[] ReadStructureBspInstancedGeometryDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspInstancedGeometryDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspInstancedGeometryDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspInstancedGeometryDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspInstancedGeometryInstancesBlock[] ReadStructureBspInstancedGeometryInstancesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspInstancedGeometryInstancesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspInstancedGeometryInstancesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspInstancedGeometryInstancesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspSoundClusterBlock[] ReadStructureBspSoundClusterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspSoundClusterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspSoundClusterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspSoundClusterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TransparentPlanesBlock[] ReadTransparentPlanesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TransparentPlanesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TransparentPlanesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TransparentPlanesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspDebugInfoBlock[] ReadStructureBspDebugInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDebugInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDebugInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDebugInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalWaterDefinitionsBlock[] ReadGlobalWaterDefinitionsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalWaterDefinitionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalWaterDefinitionsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalWaterDefinitionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructurePortalDeviceMappingBlock[] ReadStructurePortalDeviceMappingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructurePortalDeviceMappingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructurePortalDeviceMappingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructurePortalDeviceMappingBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspAudibilityBlock[] ReadStructureBspAudibilityBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspAudibilityBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspAudibilityBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspAudibilityBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspFakeLightprobesBlock[] ReadStructureBspFakeLightprobesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFakeLightprobesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFakeLightprobesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFakeLightprobesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorPlacementDefinitionBlock[] ReadDecoratorPlacementDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorPlacementDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorPlacementDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorPlacementDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
