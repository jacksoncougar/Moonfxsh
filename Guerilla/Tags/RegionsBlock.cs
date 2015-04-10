using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RegionsBlock : RegionsBlockBase
    {
        public  RegionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class RegionsBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal PermutationsBlock[] permutations;
        internal  RegionsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.permutations = ReadPermutationsBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual PermutationsBlock[] ReadPermutationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PermutationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PermutationsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PermutationsBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
