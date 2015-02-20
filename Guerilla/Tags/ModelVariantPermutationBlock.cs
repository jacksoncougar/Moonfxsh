using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 32)]
    public  partial class ModelVariantPermutationBlock : ModelVariantPermutationBlockBase
    {
        public  ModelVariantPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class ModelVariantPermutationBlockBase
    {
        internal Moonfish.Tags.StringID permutationName;
        internal byte[] invalidName_;
        internal Flags flags;
        internal byte[] invalidName_0;
        internal float probability0Inf;
        internal ModelVariantStateBlock[] states;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  ModelVariantPermutationBlockBase(BinaryReader binaryReader)
        {
            this.permutationName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.flags = (Flags)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.probability0Inf = binaryReader.ReadSingle();
            this.states = ReadModelVariantStateBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(5);
            this.invalidName_2 = binaryReader.ReadBytes(7);
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
        internal  virtual ModelVariantStateBlock[] ReadModelVariantStateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : byte
        {
            CopyStatesToAllPermutations = 1,
        };
    };
}
