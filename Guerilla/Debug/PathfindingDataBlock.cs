// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PathfindingDataBlock : PathfindingDataBlockBase
    {
        public  PathfindingDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class PathfindingDataBlockBase
    {
        internal SectorBlock[] sectors;
        internal SectorLinkBlock[] links;
        internal RefBlock[] refs;
        internal SectorBsp2dNodesBlock[] bsp2dNodes;
        internal SurfaceFlagsBlock[] surfaceFlags;
        internal SectorVertexBlock[] vertices;
        internal EnvironmentObjectRefs[] objectRefs;
        internal PathfindingHintsBlock[] pathfindingHints;
        internal InstancedGeometryReferenceBlock[] instancedGeometryRefs;
        internal int structureChecksum;
        internal byte[] invalidName_;
        internal UserHintBlock[] userPlacedHints;
        internal  PathfindingDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadSectorBlockArray(binaryReader);
            ReadSectorLinkBlockArray(binaryReader);
            ReadRefBlockArray(binaryReader);
            ReadSectorBsp2dNodesBlockArray(binaryReader);
            ReadSurfaceFlagsBlockArray(binaryReader);
            ReadSectorVertexBlockArray(binaryReader);
            ReadEnvironmentObjectRefsArray(binaryReader);
            ReadPathfindingHintsBlockArray(binaryReader);
            ReadInstancedGeometryReferenceBlockArray(binaryReader);
            structureChecksum = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(32);
            ReadUserHintBlockArray(binaryReader);
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
        internal  virtual SectorBlock[] ReadSectorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SectorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SectorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SectorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SectorLinkBlock[] ReadSectorLinkBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SectorLinkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SectorLinkBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SectorLinkBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RefBlock[] ReadRefBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RefBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RefBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RefBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SectorBsp2dNodesBlock[] ReadSectorBsp2dNodesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SectorBsp2dNodesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SectorBsp2dNodesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SectorBsp2dNodesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SurfaceFlagsBlock[] ReadSurfaceFlagsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SurfaceFlagsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SurfaceFlagsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SurfaceFlagsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SectorVertexBlock[] ReadSectorVertexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SectorVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SectorVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SectorVertexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EnvironmentObjectRefs[] ReadEnvironmentObjectRefsArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EnvironmentObjectRefs));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EnvironmentObjectRefs[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EnvironmentObjectRefs(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PathfindingHintsBlock[] ReadPathfindingHintsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PathfindingHintsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PathfindingHintsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PathfindingHintsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual InstancedGeometryReferenceBlock[] ReadInstancedGeometryReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InstancedGeometryReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InstancedGeometryReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InstancedGeometryReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintBlock[] ReadUserHintBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSectorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSectorLinkBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRefBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSectorBsp2dNodesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSurfaceFlagsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSectorVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEnvironmentObjectRefsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePathfindingHintsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteInstancedGeometryReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteSectorBlockArray(binaryWriter);
                WriteSectorLinkBlockArray(binaryWriter);
                WriteRefBlockArray(binaryWriter);
                WriteSectorBsp2dNodesBlockArray(binaryWriter);
                WriteSurfaceFlagsBlockArray(binaryWriter);
                WriteSectorVertexBlockArray(binaryWriter);
                WriteEnvironmentObjectRefsArray(binaryWriter);
                WritePathfindingHintsBlockArray(binaryWriter);
                WriteInstancedGeometryReferenceBlockArray(binaryWriter);
                binaryWriter.Write(structureChecksum);
                binaryWriter.Write(invalidName_, 0, 32);
                WriteUserHintBlockArray(binaryWriter);
            }
        }
    };
}
