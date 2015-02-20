using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspClusterBlock : StructureBspClusterBlockBase
    {
        public  StructureBspClusterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 176)]
    public class StructureBspClusterBlockBase
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
        internal  StructureBspClusterBlockBase(BinaryReader binaryReader)
        {
            this.sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.clusterData = ReadStructureBspClusterDataBlockNewArray(binaryReader);
            this.boundsX = binaryReader.ReadRange();
            this.boundsY = binaryReader.ReadRange();
            this.boundsZ = binaryReader.ReadRange();
            this.scenarioSkyIndex = binaryReader.ReadByte();
            this.mediaIndex = binaryReader.ReadByte();
            this.scenarioVisibleSkyIndex = binaryReader.ReadByte();
            this.scenarioAtmosphericFogIndex = binaryReader.ReadByte();
            this.planarFogDesignator = binaryReader.ReadByte();
            this.visibleFogPlaneIndex = binaryReader.ReadByte();
            this.backgroundSound = binaryReader.ReadShortBlockIndex1();
            this.soundEnvironment = binaryReader.ReadShortBlockIndex1();
            this.weather = binaryReader.ReadShortBlockIndex1();
            this.transitionStructureBSP = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.predictedResources = ReadPredictedResourceBlockArray(binaryReader);
            this.portals = ReadStructureBspClusterPortalIndexBlockArray(binaryReader);
            this.checksumFromStructure = binaryReader.ReadInt32();
            this.instancedGeometryIndices = ReadStructureBspClusterInstancedGeometryIndexBlockArray(binaryReader);
            this.indexReorderTable = ReadGlobalGeometrySectionStripIndexBlockArray(binaryReader);
            this.collisionMoppCode = ReadData(binaryReader);
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
        internal  virtual StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterDataBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterDataBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterDataBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedResourceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspClusterPortalIndexBlock[] ReadStructureBspClusterPortalIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterPortalIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterPortalIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterPortalIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspClusterInstancedGeometryIndexBlock[] ReadStructureBspClusterInstancedGeometryIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterInstancedGeometryIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterInstancedGeometryIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterInstancedGeometryIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometrySectionStripIndexBlock[] ReadGlobalGeometrySectionStripIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometrySectionStripIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometrySectionStripIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometrySectionStripIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : short
        {
            OneWayPortal = 1,
            DoorPortal = 2,
            PostprocessedGeometry = 4,
            IsTheSky = 8,
        };
    };
}
