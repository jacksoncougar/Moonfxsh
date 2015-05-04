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
    public partial class DecoratorCellCollectionBlock : DecoratorCellCollectionBlockBase
    {
        public DecoratorCellCollectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class DecoratorCellCollectionBlockBase : GuerillaBlock
    {
        internal ChildIndices[] childIndices;
        internal Moonfish.Tags.ShortBlockIndex1 cacheBlockIndex;
        internal short groupCount;
        internal int groupStartIndex;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DecoratorCellCollectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            childIndices = new[]
            {
                new ChildIndices(), new ChildIndices(), new ChildIndices(), new ChildIndices(), new ChildIndices(),
                new ChildIndices(), new ChildIndices(), new ChildIndices()
            };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[3].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[4].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[5].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[6].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(childIndices[7].ReadFields(binaryReader)));
            cacheBlockIndex = binaryReader.ReadShortBlockIndex1();
            groupCount = binaryReader.ReadInt16();
            groupStartIndex = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            childIndices[0].ReadPointers(binaryReader, blamPointers);
            childIndices[1].ReadPointers(binaryReader, blamPointers);
            childIndices[2].ReadPointers(binaryReader, blamPointers);
            childIndices[3].ReadPointers(binaryReader, blamPointers);
            childIndices[4].ReadPointers(binaryReader, blamPointers);
            childIndices[5].ReadPointers(binaryReader, blamPointers);
            childIndices[6].ReadPointers(binaryReader, blamPointers);
            childIndices[7].ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
        public class ChildIndices : GuerillaBlock
        {
            internal short childIndex;

            public override int SerializedSize
            {
                get { return 2; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public ChildIndices() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                childIndex = binaryReader.ReadInt16();
                return blamPointers;
            }

            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }

            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
                using (binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(childIndex);
                    return nextAddress;
                }
            }
        };
    };
}