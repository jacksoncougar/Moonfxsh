// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectChangeColors : ObjectChangeColorsBase
    {
        public  ObjectChangeColors(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ObjectChangeColorsBase
    {
        internal ObjectChangeColorInitialPermutation[] initialPermutations;
        internal ObjectChangeColorFunction[] functions;
        internal  ObjectChangeColorsBase(System.IO.BinaryReader binaryReader)
        {
            ReadObjectChangeColorInitialPermutationArray(binaryReader);
            ReadObjectChangeColorFunctionArray(binaryReader);
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
        internal  virtual ObjectChangeColorInitialPermutation[] ReadObjectChangeColorInitialPermutationArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectChangeColorInitialPermutation));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectChangeColorInitialPermutation[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectChangeColorInitialPermutation(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectChangeColorFunction[] ReadObjectChangeColorFunctionArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectChangeColorFunction));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectChangeColorFunction[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectChangeColorFunction(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectChangeColorInitialPermutationArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectChangeColorFunctionArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteObjectChangeColorInitialPermutationArray(binaryWriter);
                WriteObjectChangeColorFunctionArray(binaryWriter);
            }
        }
    };
}
