// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspInstancedGeometryDefinitionBlock : StructureBspInstancedGeometryDefinitionBlockBase
    {
        public  StructureBspInstancedGeometryDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 200, Alignment = 4)]
    public class StructureBspInstancedGeometryDefinitionBlockBase  : IGuerilla
    {
        internal StructureInstancedGeometryRenderInfoStructBlock renderInfo;
        internal int checksum;
        internal OpenTK.Vector3 boundingSphereCenter;
        internal float boundingSphereRadius;
        internal GlobalCollisionBspStructBlock collisionInfo;
        internal CollisionBspPhysicsBlock[] bspPhysics;
        internal StructureBspLeafBlock[] renderLeaves;
        internal StructureBspSurfaceReferenceBlock[] surfaceReferences;
        internal  StructureBspInstancedGeometryDefinitionBlockBase(BinaryReader binaryReader)
        {
            renderInfo = new StructureInstancedGeometryRenderInfoStructBlock(binaryReader);
            checksum = binaryReader.ReadInt32();
            boundingSphereCenter = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            collisionInfo = new GlobalCollisionBspStructBlock(binaryReader);
            bspPhysics = Guerilla.ReadBlockArray<CollisionBspPhysicsBlock>(binaryReader);
            renderLeaves = Guerilla.ReadBlockArray<StructureBspLeafBlock>(binaryReader);
            surfaceReferences = Guerilla.ReadBlockArray<StructureBspSurfaceReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                renderInfo.Write(binaryWriter);
                binaryWriter.Write(checksum);
                binaryWriter.Write(boundingSphereCenter);
                binaryWriter.Write(boundingSphereRadius);
                collisionInfo.Write(binaryWriter);
                Guerilla.WriteBlockArray<CollisionBspPhysicsBlock>(binaryWriter, bspPhysics, nextAddress);
                Guerilla.WriteBlockArray<StructureBspLeafBlock>(binaryWriter, renderLeaves, nextAddress);
                Guerilla.WriteBlockArray<StructureBspSurfaceReferenceBlock>(binaryWriter, surfaceReferences, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
