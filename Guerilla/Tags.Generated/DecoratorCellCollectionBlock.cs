// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorCellCollectionBlock : DecoratorCellCollectionBlockBase
    {
        public  DecoratorCellCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class DecoratorCellCollectionBlockBase  : IGuerilla
    {
        internal ChildIndices[] childIndices;
        internal Moonfish.Tags.ShortBlockIndex1 cacheBlockIndex;
        internal short groupCount;
        internal int groupStartIndex;
        internal  DecoratorCellCollectionBlockBase(BinaryReader binaryReader)
        {
            childIndices = new []{ new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader), new ChildIndices(binaryReader),  };
            cacheBlockIndex = binaryReader.ReadShortBlockIndex1();
            groupCount = binaryReader.ReadInt16();
            groupStartIndex = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                childIndices[0].Write(binaryWriter);
                childIndices[1].Write(binaryWriter);
                childIndices[2].Write(binaryWriter);
                childIndices[3].Write(binaryWriter);
                childIndices[4].Write(binaryWriter);
                childIndices[5].Write(binaryWriter);
                childIndices[6].Write(binaryWriter);
                childIndices[7].Write(binaryWriter);
                binaryWriter.Write(cacheBlockIndex);
                binaryWriter.Write(groupCount);
                binaryWriter.Write(groupStartIndex);
                return nextAddress;
            }
        }
        [LayoutAttribute(Size = 2, Alignment = 1)]
        public class ChildIndices  : IGuerilla
        {
            internal short childIndex;
            internal  ChildIndices(BinaryReader binaryReader)
            {
                childIndex = binaryReader.ReadInt16();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(childIndex);
                    return nextAddress;
                }
            }
        };
    };
}
