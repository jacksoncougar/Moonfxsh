using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorCacheBlockBlock : DecoratorCacheBlockBlockBase
    {
        public  DecoratorCacheBlockBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class DecoratorCacheBlockBlockBase
    {
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal DecoratorCacheBlockDataBlock[] cacheBlockData;
        internal  DecoratorCacheBlockBlockBase(BinaryReader binaryReader)
        {
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.cacheBlockData = ReadDecoratorCacheBlockDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual DecoratorCacheBlockDataBlock[] ReadDecoratorCacheBlockDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorCacheBlockDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorCacheBlockDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorCacheBlockDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
