// ReSharper disable All
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
        public  ItemCollectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ItemCollectionBlockBase
    {
        internal ItemPermutation[] itemPermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        internal  ItemCollectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadItemPermutationArray(binaryReader);
            spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
        internal  virtual ItemPermutation[] ReadItemPermutationArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteItemPermutationArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteItemPermutationArray(binaryWriter);
                binaryWriter.Write(spawnTimeInSeconds0Default);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
    };
}
