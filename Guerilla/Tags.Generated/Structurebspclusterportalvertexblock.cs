// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspClusterPortalVertexBlock : StructureBspClusterPortalVertexBlockBase
    {
        public  StructureBspClusterPortalVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspClusterPortalVertexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class StructureBspClusterPortalVertexBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 point;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspClusterPortalVertexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            point = binaryReader.ReadVector3();
        }
        public  StructureBspClusterPortalVertexBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            point = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(point);
                return nextAddress;
            }
        }
    };
}
