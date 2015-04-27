// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspInstancedGeometryDefinitionBlock : StructureBspInstancedGeometryDefinitionBlockBase
    {
        public  StructureBspInstancedGeometryDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspInstancedGeometryDefinitionBlock(): base()
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
        
        public override int SerializedSize{get { return 200; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspInstancedGeometryDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public  StructureBspInstancedGeometryDefinitionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
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
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                renderInfo.Write(binaryWriter);
                binaryWriter.Write(checksum);
                binaryWriter.Write(boundingSphereCenter);
                binaryWriter.Write(boundingSphereRadius);
                collisionInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<CollisionBspPhysicsBlock>(binaryWriter, bspPhysics, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspLeafBlock>(binaryWriter, renderLeaves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSurfaceReferenceBlock>(binaryWriter, surfaceReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}
