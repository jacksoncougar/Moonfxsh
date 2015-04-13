using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapInstanceBucketSectionOffsetBlock : LightmapInstanceBucketSectionOffsetBlockBase
    {
        public  LightmapInstanceBucketSectionOffsetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2)]
    public class LightmapInstanceBucketSectionOffsetBlockBase
    {
        internal short sectionOffset;
        internal  LightmapInstanceBucketSectionOffsetBlockBase(BinaryReader binaryReader)
        {
            this.sectionOffset = binaryReader.ReadInt16();
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
    };
}
