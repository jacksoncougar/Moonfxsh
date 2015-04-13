using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("unic")]
    public  partial class MultilingualUnicodeStringListBlock : MultilingualUnicodeStringListBlockBase
    {
        public  MultilingualUnicodeStringListBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class MultilingualUnicodeStringListBlockBase
    {
        internal MultilingualUnicodeStringReferenceBlock[] stringReferences;
        internal byte[] stringDataUtf8;
        internal byte[] invalidName_;
        internal  MultilingualUnicodeStringListBlockBase(BinaryReader binaryReader)
        {
            this.stringReferences = ReadMultilingualUnicodeStringReferenceBlockArray(binaryReader);
            this.stringDataUtf8 = ReadData(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(36);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual MultilingualUnicodeStringReferenceBlock[] ReadMultilingualUnicodeStringReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultilingualUnicodeStringReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultilingualUnicodeStringReferenceBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultilingualUnicodeStringReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
