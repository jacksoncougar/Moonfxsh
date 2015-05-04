// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorCacheBlockDataBlock : DecoratorCacheBlockDataBlockBase
    {
        public DecoratorCacheBlockDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 136, Alignment = 4)]
    public class DecoratorCacheBlockDataBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 136; } }
        public override int Alignment { get { return 4; } }
        public DecoratorCacheBlockDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorPlacementBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecalVerticesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<IndicesBlock>(binaryReader));
            decalVertexBuffer = binaryReader.ReadVertexBuffer();
            invalidName_ = binaryReader.ReadBytes(16);
            blamPointers.Enqueue(ReadBlockArrayPointer<SpriteVerticesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<IndicesBlock>(binaryReader));
            spriteVertexBuffer = binaryReader.ReadVertexBuffer();
            invalidName_0 = binaryReader.ReadBytes(16);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            placements = ReadBlockArrayData<DecoratorPlacementBlock>(binaryReader, blamPointers.Dequeue());
            decalVertices = ReadBlockArrayData<DecalVerticesBlock>(binaryReader, blamPointers.Dequeue());
            decalIndices = ReadBlockArrayData<IndicesBlock>(binaryReader, blamPointers.Dequeue());
            spriteVertices = ReadBlockArrayData<SpriteVerticesBlock>(binaryReader, blamPointers.Dequeue());
            spriteIndices = ReadBlockArrayData<IndicesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DecoratorPlacementBlock>(binaryWriter, placements, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecalVerticesBlock>(binaryWriter, decalVertices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<IndicesBlock>(binaryWriter, decalIndices, nextAddress);
                binaryWriter.Write(decalVertexBuffer);
                binaryWriter.Write(invalidName_, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<SpriteVerticesBlock>(binaryWriter, spriteVertices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<IndicesBlock>(binaryWriter, spriteIndices, nextAddress);
                binaryWriter.Write(spriteVertexBuffer);
                binaryWriter.Write(invalidName_0, 0, 16);
                return nextAddress;
            }
        }
    };
}
