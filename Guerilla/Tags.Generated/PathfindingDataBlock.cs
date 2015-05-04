// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PathfindingDataBlock : PathfindingDataBlockBase
    {
        public PathfindingDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class PathfindingDataBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 116; } }
        public override int Alignment { get { return 4; } }
        public PathfindingDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SectorBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SectorLinkBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RefBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SectorBsp2dNodesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SurfaceFlagsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SectorVertexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<EnvironmentObjectRefs>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PathfindingHintsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<InstancedGeometryReferenceBlock>(binaryReader));
            structureChecksum = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(32);
            blamPointers.Enqueue(ReadBlockArrayPointer<UserHintBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sectors = ReadBlockArrayData<SectorBlock>(binaryReader, blamPointers.Dequeue());
            links = ReadBlockArrayData<SectorLinkBlock>(binaryReader, blamPointers.Dequeue());
            refs = ReadBlockArrayData<RefBlock>(binaryReader, blamPointers.Dequeue());
            bsp2dNodes = ReadBlockArrayData<SectorBsp2dNodesBlock>(binaryReader, blamPointers.Dequeue());
            surfaceFlags = ReadBlockArrayData<SurfaceFlagsBlock>(binaryReader, blamPointers.Dequeue());
            vertices = ReadBlockArrayData<SectorVertexBlock>(binaryReader, blamPointers.Dequeue());
            objectRefs = ReadBlockArrayData<EnvironmentObjectRefs>(binaryReader, blamPointers.Dequeue());
            pathfindingHints = ReadBlockArrayData<PathfindingHintsBlock>(binaryReader, blamPointers.Dequeue());
            instancedGeometryRefs = ReadBlockArrayData<InstancedGeometryReferenceBlock>(binaryReader, blamPointers.Dequeue());
            userPlacedHints = ReadBlockArrayData<UserHintBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SectorBlock>(binaryWriter, sectors, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SectorLinkBlock>(binaryWriter, links, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RefBlock>(binaryWriter, refs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SectorBsp2dNodesBlock>(binaryWriter, bsp2dNodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SurfaceFlagsBlock>(binaryWriter, surfaceFlags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SectorVertexBlock>(binaryWriter, vertices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EnvironmentObjectRefs>(binaryWriter, objectRefs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PathfindingHintsBlock>(binaryWriter, pathfindingHints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<InstancedGeometryReferenceBlock>(binaryWriter, instancedGeometryRefs, nextAddress);
                binaryWriter.Write(structureChecksum);
                binaryWriter.Write(invalidName_, 0, 32);
                nextAddress = Guerilla.WriteBlockArray<UserHintBlock>(binaryWriter, userPlacedHints, nextAddress);
                return nextAddress;
            }
        }
    };
}
