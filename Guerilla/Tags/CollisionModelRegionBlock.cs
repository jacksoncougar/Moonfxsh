using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelRegionBlock : CollisionModelRegionBlockBase
    {
        public  CollisionModelRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class CollisionModelRegionBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal CollisionModelPermutationBlock[] permutations;
        internal  CollisionModelRegionBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.permutations = ReadCollisionModelPermutationBlockArray(binaryReader);
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
        internal  virtual CollisionModelPermutationBlock[] ReadCollisionModelPermutationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionModelPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionModelPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionModelPermutationBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
