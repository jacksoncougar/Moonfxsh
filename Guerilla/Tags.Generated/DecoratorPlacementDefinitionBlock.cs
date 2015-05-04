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
    public partial class DecoratorPlacementDefinitionBlock : DecoratorPlacementDefinitionBlockBase
    {
        public DecoratorPlacementDefinitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class DecoratorPlacementDefinitionBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 gridOrigin;
        internal int cellCountPerDimension;
        internal DecoratorCacheBlockBlock[] cacheBlocks;
        internal DecoratorGroupBlock[] groups;
        internal DecoratorCellCollectionBlock[] cells;
        internal DecoratorProjectedDecalBlock[] decals;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 4; } }
        public DecoratorPlacementDefinitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            gridOrigin = binaryReader.ReadVector3();
            cellCountPerDimension = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorCacheBlockBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorGroupBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorCellCollectionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorProjectedDecalBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            cacheBlocks = ReadBlockArrayData<DecoratorCacheBlockBlock>(binaryReader, blamPointers.Dequeue());
            groups = ReadBlockArrayData<DecoratorGroupBlock>(binaryReader, blamPointers.Dequeue());
            cells = ReadBlockArrayData<DecoratorCellCollectionBlock>(binaryReader, blamPointers.Dequeue());
            decals = ReadBlockArrayData<DecoratorProjectedDecalBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gridOrigin);
                binaryWriter.Write(cellCountPerDimension);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCacheBlockBlock>(binaryWriter, cacheBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorGroupBlock>(binaryWriter, groups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCellCollectionBlock>(binaryWriter, cells, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorProjectedDecalBlock>(binaryWriter, decals, nextAddress);
                return nextAddress;
            }
        }
    };
}
