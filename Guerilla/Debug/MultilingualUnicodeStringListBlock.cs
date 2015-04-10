// ReSharper disable All
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
        public  MultilingualUnicodeStringListBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class MultilingualUnicodeStringListBlockBase
    {
        internal MultilingualUnicodeStringReferenceBlock[] stringReferences;
        internal byte[] stringDataUtf8;
        internal byte[] invalidName_;
        internal  MultilingualUnicodeStringListBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadMultilingualUnicodeStringReferenceBlockArray(binaryReader);
            stringDataUtf8 = ReadData(binaryReader);
            invalidName_ = binaryReader.ReadBytes(36);
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
        internal  virtual MultilingualUnicodeStringReferenceBlock[] ReadMultilingualUnicodeStringReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultilingualUnicodeStringReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultilingualUnicodeStringReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultilingualUnicodeStringReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMultilingualUnicodeStringReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteMultilingualUnicodeStringReferenceBlockArray(binaryWriter);
                WriteData(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 36);
            }
        }
    };
}
