using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorPlacementDefinitionBlock : DecoratorPlacementDefinitionBlockBase
    {
        public  DecoratorPlacementDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class DecoratorPlacementDefinitionBlockBase
    {
        internal OpenTK.Vector3 gridOrigin;
        internal int cellCountPerDimension;
        internal DecoratorCacheBlockBlock[] cacheBlocks;
        internal DecoratorGroupBlock[] groups;
        internal DecoratorCellCollectionBlock[] cells;
        internal DecoratorProjectedDecalBlock[] decals;
        internal  DecoratorPlacementDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.gridOrigin = binaryReader.ReadVector3();
            this.cellCountPerDimension = binaryReader.ReadInt32();
            this.cacheBlocks = ReadDecoratorCacheBlockBlockArray(binaryReader);
            this.groups = ReadDecoratorGroupBlockArray(binaryReader);
            this.cells = ReadDecoratorCellCollectionBlockArray(binaryReader);
            this.decals = ReadDecoratorProjectedDecalBlockArray(binaryReader);
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
        internal  virtual DecoratorCacheBlockBlock[] ReadDecoratorCacheBlockBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorCacheBlockBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorCacheBlockBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorCacheBlockBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorGroupBlock[] ReadDecoratorGroupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorCellCollectionBlock[] ReadDecoratorCellCollectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorCellCollectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorCellCollectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorCellCollectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DecoratorProjectedDecalBlock[] ReadDecoratorProjectedDecalBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorProjectedDecalBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorProjectedDecalBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorProjectedDecalBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
