// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrtSectionInfoBlock : PrtSectionInfoBlockBase
    {
        public  PrtSectionInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PrtSectionInfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class PrtSectionInfoBlockBase : GuerillaBlock
    {
        internal int sectionIndex;
        internal int pcaDataOffset;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PrtSectionInfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sectionIndex = binaryReader.ReadInt32();
            pcaDataOffset = binaryReader.ReadInt32();
        }
        public  PrtSectionInfoBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            sectionIndex = binaryReader.ReadInt32();
            pcaDataOffset = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
