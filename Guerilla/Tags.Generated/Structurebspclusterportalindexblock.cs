// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspClusterPortalIndexBlock : StructureBspClusterPortalIndexBlockBase
    {
        public  StructureBspClusterPortalIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspClusterPortalIndexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureBspClusterPortalIndexBlockBase : GuerillaBlock
    {
        internal short portalIndex;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspClusterPortalIndexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            portalIndex = binaryReader.ReadInt16();
        }
        public  StructureBspClusterPortalIndexBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            portalIndex = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(portalIndex);
                return nextAddress;
            }
        }
    };
}
