using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PrtRawPcaDataBlock : PrtRawPcaDataBlockBase
    {
        public  PrtRawPcaDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class PrtRawPcaDataBlockBase
    {
        internal float rawPcaData;
        internal  PrtRawPcaDataBlockBase(BinaryReader binaryReader)
        {
            this.rawPcaData = binaryReader.ReadSingle();
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
    };
}
