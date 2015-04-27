// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapInstanceBucketReferenceBlock : LightmapInstanceBucketReferenceBlockBase
    {
        public  LightmapInstanceBucketReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapInstanceBucketReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LightmapInstanceBucketReferenceBlockBase : GuerillaBlock
    {
        internal short flags;
        internal short bucketIndex;
        internal LightmapInstanceBucketSectionOffsetBlock[] sectionOffsets;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapInstanceBucketReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = binaryReader.ReadInt16();
            bucketIndex = binaryReader.ReadInt16();
            sectionOffsets = Guerilla.ReadBlockArray<LightmapInstanceBucketSectionOffsetBlock>(binaryReader);
        }
        public  LightmapInstanceBucketReferenceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            flags = binaryReader.ReadInt16();
            bucketIndex = binaryReader.ReadInt16();
            sectionOffsets = Guerilla.ReadBlockArray<LightmapInstanceBucketSectionOffsetBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flags);
                binaryWriter.Write(bucketIndex);
                nextAddress = Guerilla.WriteBlockArray<LightmapInstanceBucketSectionOffsetBlock>(binaryWriter, sectionOffsets, nextAddress);
                return nextAddress;
            }
        }
    };
}
