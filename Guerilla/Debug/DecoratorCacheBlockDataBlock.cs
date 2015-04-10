// ReSharper disable All
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
        public  DecoratorCacheBlockDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorCacheBlockDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadDecoratorPlacementBlockArray(binaryReader);
            ReadDecalVerticesBlockArray(binaryReader);
            ReadIndicesBlockArray(binaryReader);
            decalVertexBuffer = binaryReader.ReadVertexBuffer();
            invalidName_ = binaryReader.ReadBytes(16);
            ReadSpriteVerticesBlockArray(binaryReader);
            ReadIndicesBlockArray(binaryReader);
            spriteVertexBuffer = binaryReader.ReadVertexBuffer();
            invalidName_0 = binaryReader.ReadBytes(16);
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
        internal  virtual DecoratorPlacementBlock[] ReadDecoratorPlacementBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual DecalVerticesBlock[] ReadDecalVerticesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual IndicesBlock[] ReadIndicesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SpriteVerticesBlock[] ReadSpriteVerticesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorPlacementBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecalVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteIndicesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSpriteVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteDecoratorPlacementBlockArray(binaryWriter);
                WriteDecalVerticesBlockArray(binaryWriter);
                WriteIndicesBlockArray(binaryWriter);
                binaryWriter.Write(decalVertexBuffer);
                binaryWriter.Write(invalidName_, 0, 16);
                WriteSpriteVerticesBlockArray(binaryWriter);
                WriteIndicesBlockArray(binaryWriter);
                binaryWriter.Write(spriteVertexBuffer);
                binaryWriter.Write(invalidName_0, 0, 16);
            }
        }
    };
}
