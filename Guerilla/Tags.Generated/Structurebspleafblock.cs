// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspLeafBlock : StructureBspLeafBlockBase
    {
        public  StructureBspLeafBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspLeafBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class StructureBspLeafBlockBase : GuerillaBlock
    {
        internal short cluster;
        internal short surfaceReferenceCount;
        internal int firstSurfaceReferenceIndex;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspLeafBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            cluster = binaryReader.ReadInt16();
            surfaceReferenceCount = binaryReader.ReadInt16();
            firstSurfaceReferenceIndex = binaryReader.ReadInt32();
        }
        public  StructureBspLeafBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            cluster = binaryReader.ReadInt16();
            surfaceReferenceCount = binaryReader.ReadInt16();
            firstSurfaceReferenceIndex = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(cluster);
                binaryWriter.Write(surfaceReferenceCount);
                binaryWriter.Write(firstSurfaceReferenceIndex);
                return nextAddress;
            }
        }
    };
}
