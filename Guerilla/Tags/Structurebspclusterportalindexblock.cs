// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspClusterPortalIndexBlock : StructureBspClusterPortalIndexBlockBase
    {
        public  StructureBspClusterPortalIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureBspClusterPortalIndexBlockBase  : IGuerilla
    {
        internal short portalIndex;
        internal  StructureBspClusterPortalIndexBlockBase(BinaryReader binaryReader)
        {
            portalIndex = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(portalIndex);
                return nextAddress;
            }
        }
    };
}
