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
        public  StructureBspBreakableSurfaceBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspBreakableSurfaceBlockBase(BinaryReader binaryReader)
        {
            this.instancedGeometryInstance = binaryReader.ReadShortBlockIndex1();
            this.breakableSurfaceIndex = binaryReader.ReadInt16();
            this.centroid = binaryReader.ReadVector3();
            this.radius = binaryReader.ReadSingle();
            this.collisionSurfaceIndex = binaryReader.ReadInt32();
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
    };
}
