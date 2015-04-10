// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspBreakableSurfaceBlock : StructureBspBreakableSurfaceBlockBase
    {
        public  StructureBspBreakableSurfaceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class StructureBspBreakableSurfaceBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 instancedGeometryInstance;
        internal short breakableSurfaceIndex;
        internal OpenTK.Vector3 centroid;
        internal float radius;
        internal int collisionSurfaceIndex;
        internal  StructureBspBreakableSurfaceBlockBase(System.IO.BinaryReader binaryReader)
        {
            instancedGeometryInstance = binaryReader.ReadShortBlockIndex1();
            breakableSurfaceIndex = binaryReader.ReadInt16();
            centroid = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
            collisionSurfaceIndex = binaryReader.ReadInt32();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(instancedGeometryInstance);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(centroid);
                binaryWriter.Write(radius);
                binaryWriter.Write(collisionSurfaceIndex);
            }
        }
    };
}
