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
    public partial class DecoratorCacheBlockBlock : DecoratorCacheBlockBlockBase
    {
        public DecoratorCacheBlockBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class DecoratorCacheBlockBlockBase : GuerillaBlock
    {
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal DecoratorCacheBlockDataBlock[] cacheBlockData;

        public override int SerializedSize
        {
            get { return 44; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DecoratorCacheBlockBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorCacheBlockDataBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
            cacheBlockData = ReadBlockArrayData<DecoratorCacheBlockDataBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCacheBlockDataBlock>(binaryWriter, cacheBlockData,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}