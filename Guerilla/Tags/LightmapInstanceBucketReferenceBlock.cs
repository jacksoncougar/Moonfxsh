using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapInstanceBucketReferenceBlock : LightmapInstanceBucketReferenceBlockBase
    {
        public  LightmapInstanceBucketReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class LightmapInstanceBucketReferenceBlockBase
    {
        internal short flags;
        internal short bucketIndex;
        internal LightmapInstanceBucketSectionOffsetBlock[] sectionOffsets;
        internal  LightmapInstanceBucketReferenceBlockBase(BinaryReader binaryReader)
        {
            this.flags = binaryReader.ReadInt16();
            this.bucketIndex = binaryReader.ReadInt16();
            this.sectionOffsets = ReadLightmapInstanceBucketSectionOffsetBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual LightmapInstanceBucketSectionOffsetBlock[] ReadLightmapInstanceBucketSectionOffsetBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapInstanceBucketSectionOffsetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapInstanceBucketSectionOffsetBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapInstanceBucketSectionOffsetBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
