// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapInstanceBucketSectionOffsetBlock : LightmapInstanceBucketSectionOffsetBlockBase
    {
        public  LightmapInstanceBucketSectionOffsetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapInstanceBucketSectionOffsetBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class LightmapInstanceBucketSectionOffsetBlockBase : GuerillaBlock
    {
        internal short sectionOffset;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapInstanceBucketSectionOffsetBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sectionOffset = binaryReader.ReadInt16();
        }
        public  LightmapInstanceBucketSectionOffsetBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sectionOffset);
                return nextAddress;
            }
        }
    };
}
