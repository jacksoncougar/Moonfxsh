using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorCacheBlockDataBlock : DecoratorCacheBlockDataBlockBase
    {
        public  DecoratorCacheBlockDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 136)]
    public class DecoratorCacheBlockDataBlockBase
    {
        internal DecoratorPlacementBlock[] placements;
        internal DecalVerticesBlock[] decalVertices;
        internal IndicesBlock[] decalIndices;
        internal Moonfish.Tags.VertexBuffer decalVertexBuffer;
        internal byte[] invalidName_;
        internal SpriteVerticesBlock[] spriteVertices;
        internal IndicesBlock[] spriteIndices;
        internal Moonfish.Tags.VertexBuffer spriteVertexBuffer;
        internal byte[] invalidName_0;
        internal  DecoratorCacheBlockDataBlockBase(BinaryReader binaryReader)
        {
            this.placements = ReadDecoratorPlacementBlockArray(binaryReader);
            this.decalVertices = ReadDecalVerticesBlockArray(binaryReader);
            this.decalIndices = ReadIndicesBlockArray(binaryReader);
            this.decalVertexBuffer = binaryReader.ReadVertexBuffer();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.spriteVertices = ReadSpriteVerticesBlockArray(binaryReader);
            this.spriteIndices = ReadIndicesBlockArray(binaryReader);
            this.spriteVertexBuffer = binaryReader.ReadVertexBuffer();
            this.invalidName_0 = binaryReader.ReadBytes(16);
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
        internal  virtual DecoratorPlacementBlock[] ReadDecoratorPlacementBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorPlacementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorPlacementBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorPlacementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecalVerticesBlock[] ReadDecalVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecalVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecalVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecalVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual IndicesBlock[] ReadIndicesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(IndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new IndicesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new IndicesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SpriteVerticesBlock[] ReadSpriteVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SpriteVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SpriteVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SpriteVerticesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
