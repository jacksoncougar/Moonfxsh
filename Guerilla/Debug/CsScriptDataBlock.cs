// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CsScriptDataBlock : CsScriptDataBlockBase
    {
        public  CsScriptDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 128)]
    public class CsScriptDataBlockBase
    {
        internal CsPointSetBlock[] pointSets;
        internal byte[] invalidName_;
        internal  CsScriptDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadCsPointSetBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(120);
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
        internal  virtual CsPointSetBlock[] ReadCsPointSetBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CsPointSetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CsPointSetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CsPointSetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCsPointSetBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteCsPointSetBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 120);
            }
        }
    };
}
