// ReSharper disable All
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
        public  ScenarioStructureBspBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioStructureBspBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGlobalTagImportInfoBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            ReadStructureCollisionMaterialsBlockArray(binaryReader);
            ReadGlobalCollisionBspBlockArray(binaryReader);
            vehicleFloorWorldUnits = binaryReader.ReadSingle();
            vehicleCeilingWorldUnits = binaryReader.ReadSingle();
            ReadUNUSEDStructureBspNodeBlockArray(binaryReader);
            ReadStructureBspLeafBlockArray(binaryReader);
            worldBoundsX = binaryReader.ReadRange();
            worldBoundsY = binaryReader.ReadRange();
            worldBoundsZ = binaryReader.ReadRange();
            ReadStructureBspSurfaceReferenceBlockArray(binaryReader);
            clusterData = ReadData(binaryReader);
            ReadStructureBspClusterPortalBlockArray(binaryReader);
            ReadStructureBspFogPlaneBlockArray(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(24);
            ReadStructureBspWeatherPaletteBlockArray(binaryReader);
            ReadStructureBspWeatherPolyhedronBlockArray(binaryReader);
            ReadStructureBspDetailObjectDataBlockArray(binaryReader);
            ReadStructureBspClusterBlockArray(binaryReader);
            ReadGlobalGeometryMaterialBlockArray(binaryReader);
            ReadStructureBspSkyOwnerClusterBlockArray(binaryReader);
            ReadStructureBspConveyorSurfaceBlockArray(binaryReader);
            ReadStructureBspBreakableSurfaceBlockArray(binaryReader);
            ReadPathfindingDataBlockArray(binaryReader);
            ReadStructureBspPathfindingEdgesBlockArray(binaryReader);
            ReadStructureBspBackgroundSoundPaletteBlockArray(binaryReader);
            ReadStructureBspSoundEnvironmentPaletteBlockArray(binaryReader);
            soundPASData = ReadData(binaryReader);
            ReadStructureBspMarkerBlockArray(binaryReader);
            ReadStructureBspRuntimeDecalBlockArray(binaryReader);
            ReadStructureBspEnvironmentObjectPaletteBlockArray(binaryReader);
            ReadStructureBspEnvironmentObjectBlockArray(binaryReader);
            ReadStructureBspLightmapDataBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(4);
            ReadGlobalMapLeafBlockArray(binaryReader);
            ReadGlobalLeafConnectionBlockArray(binaryReader);
            ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            ReadStructureBspPrecomputedLightingBlockArray(binaryReader);
            ReadStructureBspInstancedGeometryDefinitionBlockArray(binaryReader);
            ReadStructureBspInstancedGeometryInstancesBlockArray(binaryReader);
            ReadStructureBspSoundClusterBlockArray(binaryReader);
            ReadStructureBspSoundClusterBlockArray(binaryReader);
            ReadTransparentPlanesBlockArray(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(96);
            vehicleSpericalLimitRadius = binaryReader.ReadSingle();
            vehicleSpericalLimitCenter = binaryReader.ReadVector3();
            ReadStructureBspDebugInfoBlockArray(binaryReader);
            decorators = binaryReader.ReadTagReference();
            structurePhysics = new GlobalStructurePhysicsStructBlock(binaryReader);
            ReadGlobalWaterDefinitionsBlockArray(binaryReader);
            ReadStructurePortalDeviceMappingBlockArray(binaryReader);
            ReadStructureBspAudibilityBlockArray(binaryReader);
            ReadStructureBspFakeLightprobesBlockArray(binaryReader);
            ReadDecoratorPlacementDefinitionBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalTagImportInfoBlock[] ReadGlobalTagImportInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureCollisionMaterialsBlock[] ReadStructureCollisionMaterialsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalCollisionBspBlock[] ReadGlobalCollisionBspBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UNUSEDStructureBspNodeBlock[] ReadUNUSEDStructureBspNodeBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspLeafBlock[] ReadStructureBspLeafBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspSurfaceReferenceBlock[] ReadStructureBspSurfaceReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspClusterPortalBlock[] ReadStructureBspClusterPortalBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspFogPlaneBlock[] ReadStructureBspFogPlaneBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspWeatherPaletteBlock[] ReadStructureBspWeatherPaletteBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspWeatherPolyhedronBlock[] ReadStructureBspWeatherPolyhedronBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspDetailObjectDataBlock[] ReadStructureBspDetailObjectDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspClusterBlock[] ReadStructureBspClusterBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalGeometryMaterialBlock[] ReadGlobalGeometryMaterialBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspSkyOwnerClusterBlock[] ReadStructureBspSkyOwnerClusterBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspConveyorSurfaceBlock[] ReadStructureBspConveyorSurfaceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspBreakableSurfaceBlock[] ReadStructureBspBreakableSurfaceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PathfindingDataBlock[] ReadPathfindingDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspPathfindingEdgesBlock[] ReadStructureBspPathfindingEdgesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspBackgroundSoundPaletteBlock[] ReadStructureBspBackgroundSoundPaletteBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspSoundEnvironmentPaletteBlock[] ReadStructureBspSoundEnvironmentPaletteBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspMarkerBlock[] ReadStructureBspMarkerBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspRuntimeDecalBlock[] ReadStructureBspRuntimeDecalBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspEnvironmentObjectPaletteBlock[] ReadStructureBspEnvironmentObjectPaletteBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspEnvironmentObjectBlock[] ReadStructureBspEnvironmentObjectBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspLightmapDataBlock[] ReadStructureBspLightmapDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalMapLeafBlock[] ReadGlobalMapLeafBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalLeafConnectionBlock[] ReadGlobalLeafConnectionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspPrecomputedLightingBlock[] ReadStructureBspPrecomputedLightingBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspInstancedGeometryDefinitionBlock[] ReadStructureBspInstancedGeometryDefinitionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspInstancedGeometryInstancesBlock[] ReadStructureBspInstancedGeometryInstancesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspSoundClusterBlock[] ReadStructureBspSoundClusterBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual TransparentPlanesBlock[] ReadTransparentPlanesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspDebugInfoBlock[] ReadStructureBspDebugInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalWaterDefinitionsBlock[] ReadGlobalWaterDefinitionsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructurePortalDeviceMappingBlock[] ReadStructurePortalDeviceMappingBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspAudibilityBlock[] ReadStructureBspAudibilityBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspFakeLightprobesBlock[] ReadStructureBspFakeLightprobesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual DecoratorPlacementDefinitionBlock[] ReadDecoratorPlacementDefinitionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalTagImportInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureCollisionMaterialsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalCollisionBspBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUNUSEDStructureBspNodeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspLeafBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspSurfaceReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterPortalBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspFogPlaneBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspWeatherPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspWeatherPolyhedronBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspDetailObjectDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryMaterialBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspSkyOwnerClusterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspConveyorSurfaceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspBreakableSurfaceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePathfindingDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspPathfindingEdgesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspBackgroundSoundPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspSoundEnvironmentPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspMarkerBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspRuntimeDecalBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspEnvironmentObjectPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspEnvironmentObjectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspLightmapDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalMapLeafBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalLeafConnectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalErrorReportCategoriesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspPrecomputedLightingBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspInstancedGeometryDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspInstancedGeometryInstancesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspSoundClusterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTransparentPlanesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspDebugInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalWaterDefinitionsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructurePortalDeviceMappingBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspAudibilityBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspFakeLightprobesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorPlacementDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGlobalTagImportInfoBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                WriteStructureCollisionMaterialsBlockArray(binaryWriter);
                WriteGlobalCollisionBspBlockArray(binaryWriter);
                binaryWriter.Write(vehicleFloorWorldUnits);
                binaryWriter.Write(vehicleCeilingWorldUnits);
                WriteUNUSEDStructureBspNodeBlockArray(binaryWriter);
                WriteStructureBspLeafBlockArray(binaryWriter);
                binaryWriter.Write(worldBoundsX);
                binaryWriter.Write(worldBoundsY);
                binaryWriter.Write(worldBoundsZ);
                WriteStructureBspSurfaceReferenceBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteStructureBspClusterPortalBlockArray(binaryWriter);
                WriteStructureBspFogPlaneBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 24);
                WriteStructureBspWeatherPaletteBlockArray(binaryWriter);
                WriteStructureBspWeatherPolyhedronBlockArray(binaryWriter);
                WriteStructureBspDetailObjectDataBlockArray(binaryWriter);
                WriteStructureBspClusterBlockArray(binaryWriter);
                WriteGlobalGeometryMaterialBlockArray(binaryWriter);
                WriteStructureBspSkyOwnerClusterBlockArray(binaryWriter);
                WriteStructureBspConveyorSurfaceBlockArray(binaryWriter);
                WriteStructureBspBreakableSurfaceBlockArray(binaryWriter);
                WritePathfindingDataBlockArray(binaryWriter);
                WriteStructureBspPathfindingEdgesBlockArray(binaryWriter);
                WriteStructureBspBackgroundSoundPaletteBlockArray(binaryWriter);
                WriteStructureBspSoundEnvironmentPaletteBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteStructureBspMarkerBlockArray(binaryWriter);
                WriteStructureBspRuntimeDecalBlockArray(binaryWriter);
                WriteStructureBspEnvironmentObjectPaletteBlockArray(binaryWriter);
                WriteStructureBspEnvironmentObjectBlockArray(binaryWriter);
                WriteStructureBspLightmapDataBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 4);
                WriteGlobalMapLeafBlockArray(binaryWriter);
                WriteGlobalLeafConnectionBlockArray(binaryWriter);
                WriteGlobalErrorReportCategoriesBlockArray(binaryWriter);
                WriteStructureBspPrecomputedLightingBlockArray(binaryWriter);
                WriteStructureBspInstancedGeometryDefinitionBlockArray(binaryWriter);
                WriteStructureBspInstancedGeometryInstancesBlockArray(binaryWriter);
                WriteStructureBspSoundClusterBlockArray(binaryWriter);
                WriteStructureBspSoundClusterBlockArray(binaryWriter);
                WriteTransparentPlanesBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_2, 0, 96);
                binaryWriter.Write(vehicleSpericalLimitRadius);
                binaryWriter.Write(vehicleSpericalLimitCenter);
                WriteStructureBspDebugInfoBlockArray(binaryWriter);
                binaryWriter.Write(decorators);
                structurePhysics.Write(binaryWriter);
                WriteGlobalWaterDefinitionsBlockArray(binaryWriter);
                WriteStructurePortalDeviceMappingBlockArray(binaryWriter);
                WriteStructureBspAudibilityBlockArray(binaryWriter);
                WriteStructureBspFakeLightprobesBlockArray(binaryWriter);
                WriteDecoratorPlacementDefinitionBlockArray(binaryWriter);
            }
        }
    };
}
