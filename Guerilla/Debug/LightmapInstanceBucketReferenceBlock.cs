// ReSharper disable All
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
        public  LightmapInstanceBucketReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class LightmapInstanceBucketReferenceBlockBase
    {
        internal short flags;
        internal short bucketIndex;
        internal LightmapInstanceBucketSectionOffsetBlock[] sectionOffsets;
        internal  LightmapInstanceBucketReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = binaryReader.ReadInt16();
            bucketIndex = binaryReader.ReadInt16();
            ReadLightmapInstanceBucketSectionOffsetBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual LightmapInstanceBucketSectionOffsetBlock[] ReadLightmapInstanceBucketSectionOffsetBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightmapInstanceBucketSectionOffsetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightmapInstanceBucketSectionOffsetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightmapInstanceBucketSectionOffsetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightmapInstanceBucketSectionOffsetBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flags);
                binaryWriter.Write(bucketIndex);
                WriteLightmapInstanceBucketSectionOffsetBlockArray(binaryWriter);
            }
        }
    };
}
