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
    public partial class ShapeGroupReferenceBlock : ShapeGroupReferenceBlockBase
    {
        public ShapeGroupReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShapeGroupReferenceBlockBase : GuerillaBlock
    {
        internal ShapeBlockReferenceBlock[] shapes;
        internal UiModelSceneReferenceBlock[] modelSceneBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public ShapeGroupReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShapeBlockReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UiModelSceneReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BitmapBlockReferenceBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            shapes = ReadBlockArrayData<ShapeBlockReferenceBlock>(binaryReader, blamPointers.Dequeue());
            modelSceneBlocks = ReadBlockArrayData<UiModelSceneReferenceBlock>(binaryReader, blamPointers.Dequeue());
            bitmapBlocks = ReadBlockArrayData<BitmapBlockReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShapeBlockReferenceBlock>(binaryWriter, shapes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UiModelSceneReferenceBlock>(binaryWriter, modelSceneBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BitmapBlockReferenceBlock>(binaryWriter, bitmapBlocks, nextAddress);
                return nextAddress;
            }
        }
    };
}
