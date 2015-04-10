// ReSharper disable All
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
        public  StructureBspClusterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspClusterBlockBase(System.IO.BinaryReader binaryReader)
        {
            sectionInfo = new GlobalGeometrySectionInfoStructBlock(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            ReadStructureBspClusterDataBlockNewArray(binaryReader);
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
            ReadPredictedResourceBlockArray(binaryReader);
            ReadStructureBspClusterPortalIndexBlockArray(binaryReader);
            checksumFromStructure = binaryReader.ReadInt32();
            ReadStructureBspClusterInstancedGeometryIndexBlockArray(binaryReader);
            ReadGlobalGeometrySectionStripIndexBlockArray(binaryReader);
            collisionMoppCode = ReadData(binaryReader);
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
        internal  virtual StructureBspClusterDataBlockNew[] ReadStructureBspClusterDataBlockNewArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspClusterPortalIndexBlock[] ReadStructureBspClusterPortalIndexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspClusterInstancedGeometryIndexBlock[] ReadStructureBspClusterInstancedGeometryIndexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalGeometrySectionStripIndexBlock[] ReadGlobalGeometrySectionStripIndexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterDataBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePredictedResourceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterPortalIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterInstancedGeometryIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometrySectionStripIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                sectionInfo.Write(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
                WriteStructureBspClusterDataBlockNewArray(binaryWriter);
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
                WritePredictedResourceBlockArray(binaryWriter);
                WriteStructureBspClusterPortalIndexBlockArray(binaryWriter);
                binaryWriter.Write(checksumFromStructure);
                WriteStructureBspClusterInstancedGeometryIndexBlockArray(binaryWriter);
                WriteGlobalGeometrySectionStripIndexBlockArray(binaryWriter);
                WriteData(binaryWriter);
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
