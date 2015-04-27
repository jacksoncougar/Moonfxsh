// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspClusterInstancedGeometryIndexBlock : StructureBspClusterInstancedGeometryIndexBlockBase
    {
        public  StructureBspClusterInstancedGeometryIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspClusterInstancedGeometryIndexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureBspClusterInstancedGeometryIndexBlockBase : GuerillaBlock
    {
        internal short instancedGeometryIndex;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspClusterInstancedGeometryIndexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            instancedGeometryIndex = binaryReader.ReadInt16();
        }
        public  StructureBspClusterInstancedGeometryIndexBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            instancedGeometryIndex = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(instancedGeometryIndex);
                return nextAddress;
            }
        }
    };
}
