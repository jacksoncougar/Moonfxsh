// ReSharper disable All
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
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PrtRawPcaDataBlockBase  : IGuerilla
    {
        internal float rawPcaData;
        internal  PrtRawPcaDataBlockBase(BinaryReader binaryReader)
        {
            rawPcaData = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rawPcaData);
                return nextAddress;
            }
        }
    };
}
