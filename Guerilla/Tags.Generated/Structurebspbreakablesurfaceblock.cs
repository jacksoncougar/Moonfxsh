// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspBreakableSurfaceBlock : StructureBspBreakableSurfaceBlockBase
    {
        public  StructureBspBreakableSurfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspBreakableSurfaceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class StructureBspBreakableSurfaceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 instancedGeometryInstance;
        internal short breakableSurfaceIndex;
        internal OpenTK.Vector3 centroid;
        internal float radius;
        internal int collisionSurfaceIndex;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspBreakableSurfaceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            instancedGeometryInstance = binaryReader.ReadShortBlockIndex1();
            breakableSurfaceIndex = binaryReader.ReadInt16();
            centroid = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
            collisionSurfaceIndex = binaryReader.ReadInt32();
        }
        public  StructureBspBreakableSurfaceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(instancedGeometryInstance);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(centroid);
                binaryWriter.Write(radius);
                binaryWriter.Write(collisionSurfaceIndex);
                return nextAddress;
            }
        }
    };
}
