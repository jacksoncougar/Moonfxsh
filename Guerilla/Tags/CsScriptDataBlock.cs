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
        public  CsScriptDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 128)]
    public class CsScriptDataBlockBase
    {
        internal CsPointSetBlock[] pointSets;
        internal byte[] invalidName_;
        internal  CsScriptDataBlockBase(BinaryReader binaryReader)
        {
            this.pointSets = ReadCsPointSetBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(120);
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
        internal  virtual CsPointSetBlock[] ReadCsPointSetBlockArray(BinaryReader binaryReader)
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
    };
}
