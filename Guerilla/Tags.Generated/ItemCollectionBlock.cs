// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

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
        public  ItemCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ItemCollectionBlockBase : GuerillaBlock
    {
        internal ItemPermutation[] itemPermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 12; }}
        
        internal  ItemCollectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            itemPermutations = Guerilla.ReadBlockArray<ItemPermutation>(binaryReader);
            spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
