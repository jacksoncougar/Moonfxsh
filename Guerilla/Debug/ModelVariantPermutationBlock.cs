// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelVariantPermutationBlock : ModelVariantPermutationBlockBase
    {
        public  ModelVariantPermutationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelVariantPermutationBlockBase(System.IO.BinaryReader binaryReader)
        {
            permutationName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(1);
            flags = (Flags)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(2);
            probability0Inf = binaryReader.ReadSingle();
            ReadModelVariantStateBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(5);
            invalidName_2 = binaryReader.ReadBytes(7);
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
        internal  virtual ModelVariantStateBlock[] ReadModelVariantStateBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelVariantStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(permutationName);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(probability0Inf);
                WriteModelVariantStateBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 5);
                binaryWriter.Write(invalidName_2, 0, 7);
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            CopyStatesToAllPermutations = 1,
        };
    };
}
