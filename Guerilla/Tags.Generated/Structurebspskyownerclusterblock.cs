// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspSkyOwnerClusterBlock : StructureBspSkyOwnerClusterBlockBase
    {
        public  StructureBspSkyOwnerClusterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspSkyOwnerClusterBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureBspSkyOwnerClusterBlockBase : GuerillaBlock
    {
        internal short clusterOwner;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspSkyOwnerClusterBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            clusterOwner = binaryReader.ReadInt16();
        }
        public  StructureBspSkyOwnerClusterBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(clusterOwner);
                return nextAddress;
            }
        }
    };
}
