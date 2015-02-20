using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 16)]
    public  partial class ModelRegionBlock : ModelRegionBlockBase
    {
        public  ModelRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ModelRegionBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal byte collisionRegionIndex;
        internal byte physicsRegionIndex;
        internal byte[] invalidName_;
        internal ModelPermutationBlock[] permutations;
        internal  ModelRegionBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.collisionRegionIndex = binaryReader.ReadByte();
            this.physicsRegionIndex = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.permutations = ReadModelPermutationBlockArray(binaryReader);
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
        internal  virtual ModelPermutationBlock[] ReadModelPermutationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelPermutationBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
