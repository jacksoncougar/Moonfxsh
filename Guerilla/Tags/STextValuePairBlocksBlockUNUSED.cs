using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class STextValuePairBlocksBlockUNUSED : STextValuePairBlocksBlockUNUSEDBase
    {
        public  STextValuePairBlocksBlockUNUSED(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class STextValuePairBlocksBlockUNUSEDBase
    {
        internal Moonfish.Tags.String32 name;
        internal STextValuePairReferenceBlockUNUSED[] textValuePairs;
        internal  STextValuePairBlocksBlockUNUSEDBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.textValuePairs = ReadSTextValuePairReferenceBlockUNUSEDArray(binaryReader);
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
        internal  virtual STextValuePairReferenceBlockUNUSED[] ReadSTextValuePairReferenceBlockUNUSEDArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(STextValuePairReferenceBlockUNUSED));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new STextValuePairReferenceBlockUNUSED[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new STextValuePairReferenceBlockUNUSED(binaryReader);
                }
            }
            return array;
        }
    };
}
