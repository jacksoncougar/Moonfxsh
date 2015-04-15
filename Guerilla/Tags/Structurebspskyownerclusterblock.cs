// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspSkyOwnerClusterBlock : StructureBspSkyOwnerClusterBlockBase
    {
        public  StructureBspSkyOwnerClusterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureBspSkyOwnerClusterBlockBase  : IGuerilla
    {
        internal short clusterOwner;
        internal  StructureBspSkyOwnerClusterBlockBase(BinaryReader binaryReader)
        {
            clusterOwner = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(clusterOwner);
                return nextAddress;
            }
        }
    };
}
