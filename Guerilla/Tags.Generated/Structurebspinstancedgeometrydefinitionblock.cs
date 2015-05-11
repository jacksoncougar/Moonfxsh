// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspInstancedGeometryDefinitionBlock : StructureBspInstancedGeometryDefinitionBlockBase
    {
        public StructureBspInstancedGeometryDefinitionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 200, Alignment = 4)]
    public class StructureBspInstancedGeometryDefinitionBlockBase : GuerillaBlock
    {
        internal StructureInstancedGeometryRenderInfoStructBlock renderInfo;
        internal int checksum;
        internal OpenTK.Vector3 boundingSphereCenter;
        internal float boundingSphereRadius;
        internal GlobalCollisionBspStructBlock collisionInfo;
        internal CollisionBspPhysicsBlock[] bspPhysics;
        internal StructureBspLeafBlock[] renderLeaves;
        internal StructureBspSurfaceReferenceBlock[] surfaceReferences;

        public override int SerializedSize
        {
            get { return 200; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspInstancedGeometryDefinitionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            renderInfo = new StructureInstancedGeometryRenderInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderInfo.ReadFields(binaryReader)));
            checksum = binaryReader.ReadInt32();
            boundingSphereCenter = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            collisionInfo = new GlobalCollisionBspStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(collisionInfo.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionBspPhysicsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspLeafBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSurfaceReferenceBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            renderInfo.ReadPointers(binaryReader, blamPointers);
            collisionInfo.ReadPointers(binaryReader, blamPointers);
            bspPhysics = ReadBlockArrayData<CollisionBspPhysicsBlock>(binaryReader, blamPointers.Dequeue());
            renderLeaves = ReadBlockArrayData<StructureBspLeafBlock>(binaryReader, blamPointers.Dequeue());
            surfaceReferences = ReadBlockArrayData<StructureBspSurfaceReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                renderInfo.Write(binaryWriter);
                binaryWriter.Write(checksum);
                binaryWriter.Write(boundingSphereCenter);
                binaryWriter.Write(boundingSphereRadius);
                collisionInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<CollisionBspPhysicsBlock>(binaryWriter, bspPhysics, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspLeafBlock>(binaryWriter, renderLeaves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSurfaceReferenceBlock>(binaryWriter,
                    surfaceReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}