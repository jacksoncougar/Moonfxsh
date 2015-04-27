// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspLightmapDataBlock : StructureBspLightmapDataBlockBase
    {
        public  StructureBspLightmapDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspLightmapDataBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class StructureBspLightmapDataBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmapGroup;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspLightmapDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmapGroup = binaryReader.ReadTagReference();
        }
        public  StructureBspLightmapDataBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            bitmapGroup = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmapGroup);
                return nextAddress;
            }
        }
    };
}
