// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PrtSectionInfoBlock : PrtSectionInfoBlockBase
    {
        public  PrtSectionInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class PrtSectionInfoBlockBase  : IGuerilla
    {
        internal int sectionIndex;
        internal int pcaDataOffset;
        internal  PrtSectionInfoBlockBase(BinaryReader binaryReader)
        {
            sectionIndex = binaryReader.ReadInt32();
            pcaDataOffset = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sectionIndex);
                binaryWriter.Write(pcaDataOffset);
                return nextAddress;
            }
        }
    };
}
