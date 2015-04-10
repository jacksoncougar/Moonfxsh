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
        public  PathfindingDataBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  PathfindingDataBlockBase(BinaryReader binaryReader)
        {
            this.sectors = ReadSectorBlockArray(binaryReader);
            this.links = ReadSectorLinkBlockArray(binaryReader);
            this.refs = ReadRefBlockArray(binaryReader);
            this.bsp2dNodes = ReadSectorBsp2dNodesBlockArray(binaryReader);
            this.surfaceFlags = ReadSurfaceFlagsBlockArray(binaryReader);
            this.vertices = ReadSectorVertexBlockArray(binaryReader);
            this.objectRefs = ReadEnvironmentObjectRefsArray(binaryReader);
            this.pathfindingHints = ReadPathfindingHintsBlockArray(binaryReader);
            this.instancedGeometryRefs = ReadInstancedGeometryReferenceBlockArray(binaryReader);
            this.structureChecksum = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(32);
            this.userPlacedHints = ReadUserHintBlockArray(binaryReader);
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
        internal  virtual SectorBlock[] ReadSectorBlockArray(BinaryReader binaryReader)
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
        internal  virtual SectorLinkBlock[] ReadSectorLinkBlockArray(BinaryReader binaryReader)
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
        internal  virtual RefBlock[] ReadRefBlockArray(BinaryReader binaryReader)
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
        internal  virtual SectorBsp2dNodesBlock[] ReadSectorBsp2dNodesBlockArray(BinaryReader binaryReader)
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
        internal  virtual SurfaceFlagsBlock[] ReadSurfaceFlagsBlockArray(BinaryReader binaryReader)
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
        internal  virtual SectorVertexBlock[] ReadSectorVertexBlockArray(BinaryReader binaryReader)
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
        internal  virtual EnvironmentObjectRefs[] ReadEnvironmentObjectRefsArray(BinaryReader binaryReader)
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
        internal  virtual PathfindingHintsBlock[] ReadPathfindingHintsBlockArray(BinaryReader binaryReader)
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
        internal  virtual InstancedGeometryReferenceBlock[] ReadInstancedGeometryReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual UserHintBlock[] ReadUserHintBlockArray(BinaryReader binaryReader)
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
    };
}
