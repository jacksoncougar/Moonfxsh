// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Itmc = (TagClass)"itmc";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("itmc")]
    public partial class ItemCollectionBlock : ItemCollectionBlockBase
    {
        public ItemCollectionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ItemCollectionBlockBase : GuerillaBlock
    {
        internal ItemPermutation[] itemPermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public ItemCollectionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ItemPermutation>(binaryReader));
            spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            itemPermutations = ReadBlockArrayData<ItemPermutation>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ItemPermutation>(binaryWriter, itemPermutations, nextAddress);
                binaryWriter.Write(spawnTimeInSeconds0Default);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
