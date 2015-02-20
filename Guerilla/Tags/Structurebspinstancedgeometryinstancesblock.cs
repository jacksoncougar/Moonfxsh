using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspInstancedGeometryInstancesBlock : StructureBspInstancedGeometryInstancesBlockBase
    {
        public  StructureBspInstancedGeometryInstancesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88)]
    public class StructureBspInstancedGeometryInstancesBlockBase
    {
        internal float scale;
        internal OpenTK.Vector3 forward;
        internal OpenTK.Vector3 left;
        internal OpenTK.Vector3 up;
        internal OpenTK.Vector3 position;
        internal Moonfish.Tags.ShortBlockIndex1 instanceDefinition;
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal int checksum;
        internal Moonfish.Tags.StringID name;
        internal PathfindingPolicy pathfindingPolicy;
        internal LightmappingPolicy lightmappingPolicy;
        internal  StructureBspInstancedGeometryInstancesBlockBase(BinaryReader binaryReader)
        {
            this.scale = binaryReader.ReadSingle();
            this.forward = binaryReader.ReadVector3();
            this.left = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.position = binaryReader.ReadVector3();
            this.instanceDefinition = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = binaryReader.ReadBytes(12);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.checksum = binaryReader.ReadInt32();
            this.name = binaryReader.ReadStringID();
            this.pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            this.lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
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
        internal enum Flags : short
        {
            NotInLightprobes = 1,
        };
        internal enum PathfindingPolicy : short
        {
            Cutout = 0,
            Static = 1,
            None = 2,
        };
        internal enum LightmappingPolicy : short
        {
            PerPixel = 0,
            PerVertex = 1,
        };
    };
}
