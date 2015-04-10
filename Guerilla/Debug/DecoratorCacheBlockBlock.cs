// ReSharper disable All
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
        public  DecoratorCacheBlockBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class DecoratorCacheBlockBlockBase
    {
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal DecoratorCacheBlockDataBlock[] cacheBlockData;
        internal  DecoratorCacheBlockBlockBase(System.IO.BinaryReader binaryReader)
        {
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            ReadDecoratorCacheBlockDataBlockArray(binaryReader);
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
        internal  virtual DecoratorCacheBlockDataBlock[] ReadDecoratorCacheBlockDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorCacheBlockDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometryBlockInfo.Write(binaryWriter);
                WriteDecoratorCacheBlockDataBlockArray(binaryWriter);
            }
        }
    };
}
