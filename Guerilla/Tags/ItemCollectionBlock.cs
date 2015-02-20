using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("itmc")]
    public  partial class ItemCollectionBlock : ItemCollectionBlockBase
    {
        public  ItemCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ItemCollectionBlockBase
    {
        internal ItemPermutation[] itemPermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        internal  ItemCollectionBlockBase(BinaryReader binaryReader)
        {
            this.itemPermutations = ReadItemPermutationArray(binaryReader);
            this.spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
        internal  virtual ItemPermutation[] ReadItemPermutationArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ItemPermutation));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ItemPermutation[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ItemPermutation(binaryReader);
                }
            }
            return array;
        }
    };
}
