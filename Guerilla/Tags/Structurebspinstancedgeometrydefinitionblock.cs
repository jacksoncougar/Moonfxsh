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
    [LayoutAttribute(Size = 200)]
    public class StructureBspInstancedGeometryDefinitionBlockBase
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
            this.renderInfo = new StructureInstancedGeometryRenderInfoStructBlock(binaryReader);
            this.checksum = binaryReader.ReadInt32();
            this.boundingSphereCenter = binaryReader.ReadVector3();
            this.boundingSphereRadius = binaryReader.ReadSingle();
            this.collisionInfo = new GlobalCollisionBspStructBlock(binaryReader);
            this.bspPhysics = ReadCollisionBspPhysicsBlockArray(binaryReader);
            this.renderLeaves = ReadStructureBspLeafBlockArray(binaryReader);
            this.surfaceReferences = ReadStructureBspSurfaceReferenceBlockArray(binaryReader);
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
        internal  virtual CollisionBspPhysicsBlock[] ReadCollisionBspPhysicsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionBspPhysicsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionBspPhysicsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionBspPhysicsBlock(binaryReader);
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
    };
}
