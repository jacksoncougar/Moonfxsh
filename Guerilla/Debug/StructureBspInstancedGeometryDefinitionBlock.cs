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
        public  StructureBspInstancedGeometryDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspInstancedGeometryDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            renderInfo = new StructureInstancedGeometryRenderInfoStructBlock(binaryReader);
            checksum = binaryReader.ReadInt32();
            boundingSphereCenter = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            collisionInfo = new GlobalCollisionBspStructBlock(binaryReader);
            ReadCollisionBspPhysicsBlockArray(binaryReader);
            ReadStructureBspLeafBlockArray(binaryReader);
            ReadStructureBspSurfaceReferenceBlockArray(binaryReader);
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
        internal  virtual CollisionBspPhysicsBlock[] ReadCollisionBspPhysicsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionBspPhysicsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspLeafBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspSurfaceReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                renderInfo.Write(binaryWriter);
                binaryWriter.Write(checksum);
                binaryWriter.Write(boundingSphereCenter);
                binaryWriter.Write(boundingSphereRadius);
                collisionInfo.Write(binaryWriter);
                WriteCollisionBspPhysicsBlockArray(binaryWriter);
                WriteStructureBspLeafBlockArray(binaryWriter);
                WriteStructureBspSurfaceReferenceBlockArray(binaryWriter);
            }
        }
    };
}
