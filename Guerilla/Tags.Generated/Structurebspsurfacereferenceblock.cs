// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspSurfaceReferenceBlock : StructureBspSurfaceReferenceBlockBase
    {
        public  StructureBspSurfaceReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspSurfaceReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class StructureBspSurfaceReferenceBlockBase : GuerillaBlock
    {
        internal short stripIndex;
        internal short lightmapTriangleIndex;
        internal int bSPNodeIndex;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspSurfaceReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stripIndex = binaryReader.ReadInt16();
            lightmapTriangleIndex = binaryReader.ReadInt16();
            bSPNodeIndex = binaryReader.ReadInt32();
        }
        public  StructureBspSurfaceReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            stripIndex = binaryReader.ReadInt16();
            lightmapTriangleIndex = binaryReader.ReadInt16();
            bSPNodeIndex = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stripIndex);
                binaryWriter.Write(lightmapTriangleIndex);
                binaryWriter.Write(bSPNodeIndex);
                return nextAddress;
            }
        }
    };
}
