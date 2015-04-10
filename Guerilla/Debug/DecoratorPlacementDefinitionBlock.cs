// ReSharper disable All
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
        public  DecoratorPlacementDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorPlacementDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            gridOrigin = binaryReader.ReadVector3();
            cellCountPerDimension = binaryReader.ReadInt32();
            ReadDecoratorCacheBlockBlockArray(binaryReader);
            ReadDecoratorGroupBlockArray(binaryReader);
            ReadDecoratorCellCollectionBlockArray(binaryReader);
            ReadDecoratorProjectedDecalBlockArray(binaryReader);
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
        internal  virtual DecoratorCacheBlockBlock[] ReadDecoratorCacheBlockBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual DecoratorGroupBlock[] ReadDecoratorGroupBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual DecoratorCellCollectionBlock[] ReadDecoratorCellCollectionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual DecoratorProjectedDecalBlock[] ReadDecoratorProjectedDecalBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorCacheBlockBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorGroupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorCellCollectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorProjectedDecalBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gridOrigin);
                binaryWriter.Write(cellCountPerDimension);
                WriteDecoratorCacheBlockBlockArray(binaryWriter);
                WriteDecoratorGroupBlockArray(binaryWriter);
                WriteDecoratorCellCollectionBlockArray(binaryWriter);
                WriteDecoratorProjectedDecalBlockArray(binaryWriter);
            }
        }
    };
}
