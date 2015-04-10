// ReSharper disable All
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
        public  StructureBspInstancedGeometryInstancesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspInstancedGeometryInstancesBlockBase(System.IO.BinaryReader binaryReader)
        {
            scale = binaryReader.ReadSingle();
            forward = binaryReader.ReadVector3();
            left = binaryReader.ReadVector3();
            up = binaryReader.ReadVector3();
            position = binaryReader.ReadVector3();
            instanceDefinition = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(12);
            invalidName_1 = binaryReader.ReadBytes(4);
            checksum = binaryReader.ReadInt32();
            name = binaryReader.ReadStringID();
            pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
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
                binaryWriter.Write(scale);
                binaryWriter.Write(forward);
                binaryWriter.Write(left);
                binaryWriter.Write(up);
                binaryWriter.Write(position);
                binaryWriter.Write(instanceDefinition);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 12);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(checksum);
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)pathfindingPolicy);
                binaryWriter.Write((Int16)lightmappingPolicy);
            }
        }
        [FlagsAttribute]
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
