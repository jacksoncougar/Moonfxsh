// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class TagImportFileBlock : TagImportFileBlockBase
    {
        public TagImportFileBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 528, Alignment = 4)]
    public class TagImportFileBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String256 path;
        internal Moonfish.Tags.String32 modificationDate;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal int checksumCrc32;
        internal int sizeBytes;
        internal byte[] zippedData;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 528; } }
        public override int Alignment { get { return 4; } }
        public TagImportFileBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            path = binaryReader.ReadString256();
            modificationDate = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            invalidName_0 = binaryReader.ReadBytes(88);
            checksumCrc32 = binaryReader.ReadInt32();
            sizeBytes = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            invalidName_1 = binaryReader.ReadBytes(128);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[24].ReadPointers(binaryReader, blamPointers);
            invalidName_0[25].ReadPointers(binaryReader, blamPointers);
            invalidName_0[26].ReadPointers(binaryReader, blamPointers);
            invalidName_0[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[28].ReadPointers(binaryReader, blamPointers);
            invalidName_0[29].ReadPointers(binaryReader, blamPointers);
            invalidName_0[30].ReadPointers(binaryReader, blamPointers);
            invalidName_0[31].ReadPointers(binaryReader, blamPointers);
            invalidName_0[32].ReadPointers(binaryReader, blamPointers);
            invalidName_0[33].ReadPointers(binaryReader, blamPointers);
            invalidName_0[34].ReadPointers(binaryReader, blamPointers);
            invalidName_0[35].ReadPointers(binaryReader, blamPointers);
            invalidName_0[36].ReadPointers(binaryReader, blamPointers);
            invalidName_0[37].ReadPointers(binaryReader, blamPointers);
            invalidName_0[38].ReadPointers(binaryReader, blamPointers);
            invalidName_0[39].ReadPointers(binaryReader, blamPointers);
            invalidName_0[40].ReadPointers(binaryReader, blamPointers);
            invalidName_0[41].ReadPointers(binaryReader, blamPointers);
            invalidName_0[42].ReadPointers(binaryReader, blamPointers);
            invalidName_0[43].ReadPointers(binaryReader, blamPointers);
            invalidName_0[44].ReadPointers(binaryReader, blamPointers);
            invalidName_0[45].ReadPointers(binaryReader, blamPointers);
            invalidName_0[46].ReadPointers(binaryReader, blamPointers);
            invalidName_0[47].ReadPointers(binaryReader, blamPointers);
            invalidName_0[48].ReadPointers(binaryReader, blamPointers);
            invalidName_0[49].ReadPointers(binaryReader, blamPointers);
            invalidName_0[50].ReadPointers(binaryReader, blamPointers);
            invalidName_0[51].ReadPointers(binaryReader, blamPointers);
            invalidName_0[52].ReadPointers(binaryReader, blamPointers);
            invalidName_0[53].ReadPointers(binaryReader, blamPointers);
            invalidName_0[54].ReadPointers(binaryReader, blamPointers);
            invalidName_0[55].ReadPointers(binaryReader, blamPointers);
            invalidName_0[56].ReadPointers(binaryReader, blamPointers);
            invalidName_0[57].ReadPointers(binaryReader, blamPointers);
            invalidName_0[58].ReadPointers(binaryReader, blamPointers);
            invalidName_0[59].ReadPointers(binaryReader, blamPointers);
            invalidName_0[60].ReadPointers(binaryReader, blamPointers);
            invalidName_0[61].ReadPointers(binaryReader, blamPointers);
            invalidName_0[62].ReadPointers(binaryReader, blamPointers);
            invalidName_0[63].ReadPointers(binaryReader, blamPointers);
            invalidName_0[64].ReadPointers(binaryReader, blamPointers);
            invalidName_0[65].ReadPointers(binaryReader, blamPointers);
            invalidName_0[66].ReadPointers(binaryReader, blamPointers);
            invalidName_0[67].ReadPointers(binaryReader, blamPointers);
            invalidName_0[68].ReadPointers(binaryReader, blamPointers);
            invalidName_0[69].ReadPointers(binaryReader, blamPointers);
            invalidName_0[70].ReadPointers(binaryReader, blamPointers);
            invalidName_0[71].ReadPointers(binaryReader, blamPointers);
            invalidName_0[72].ReadPointers(binaryReader, blamPointers);
            invalidName_0[73].ReadPointers(binaryReader, blamPointers);
            invalidName_0[74].ReadPointers(binaryReader, blamPointers);
            invalidName_0[75].ReadPointers(binaryReader, blamPointers);
            invalidName_0[76].ReadPointers(binaryReader, blamPointers);
            invalidName_0[77].ReadPointers(binaryReader, blamPointers);
            invalidName_0[78].ReadPointers(binaryReader, blamPointers);
            invalidName_0[79].ReadPointers(binaryReader, blamPointers);
            invalidName_0[80].ReadPointers(binaryReader, blamPointers);
            invalidName_0[81].ReadPointers(binaryReader, blamPointers);
            invalidName_0[82].ReadPointers(binaryReader, blamPointers);
            invalidName_0[83].ReadPointers(binaryReader, blamPointers);
            invalidName_0[84].ReadPointers(binaryReader, blamPointers);
            invalidName_0[85].ReadPointers(binaryReader, blamPointers);
            invalidName_0[86].ReadPointers(binaryReader, blamPointers);
            invalidName_0[87].ReadPointers(binaryReader, blamPointers);
            zippedData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            invalidName_1[28].ReadPointers(binaryReader, blamPointers);
            invalidName_1[29].ReadPointers(binaryReader, blamPointers);
            invalidName_1[30].ReadPointers(binaryReader, blamPointers);
            invalidName_1[31].ReadPointers(binaryReader, blamPointers);
            invalidName_1[32].ReadPointers(binaryReader, blamPointers);
            invalidName_1[33].ReadPointers(binaryReader, blamPointers);
            invalidName_1[34].ReadPointers(binaryReader, blamPointers);
            invalidName_1[35].ReadPointers(binaryReader, blamPointers);
            invalidName_1[36].ReadPointers(binaryReader, blamPointers);
            invalidName_1[37].ReadPointers(binaryReader, blamPointers);
            invalidName_1[38].ReadPointers(binaryReader, blamPointers);
            invalidName_1[39].ReadPointers(binaryReader, blamPointers);
            invalidName_1[40].ReadPointers(binaryReader, blamPointers);
            invalidName_1[41].ReadPointers(binaryReader, blamPointers);
            invalidName_1[42].ReadPointers(binaryReader, blamPointers);
            invalidName_1[43].ReadPointers(binaryReader, blamPointers);
            invalidName_1[44].ReadPointers(binaryReader, blamPointers);
            invalidName_1[45].ReadPointers(binaryReader, blamPointers);
            invalidName_1[46].ReadPointers(binaryReader, blamPointers);
            invalidName_1[47].ReadPointers(binaryReader, blamPointers);
            invalidName_1[48].ReadPointers(binaryReader, blamPointers);
            invalidName_1[49].ReadPointers(binaryReader, blamPointers);
            invalidName_1[50].ReadPointers(binaryReader, blamPointers);
            invalidName_1[51].ReadPointers(binaryReader, blamPointers);
            invalidName_1[52].ReadPointers(binaryReader, blamPointers);
            invalidName_1[53].ReadPointers(binaryReader, blamPointers);
            invalidName_1[54].ReadPointers(binaryReader, blamPointers);
            invalidName_1[55].ReadPointers(binaryReader, blamPointers);
            invalidName_1[56].ReadPointers(binaryReader, blamPointers);
            invalidName_1[57].ReadPointers(binaryReader, blamPointers);
            invalidName_1[58].ReadPointers(binaryReader, blamPointers);
            invalidName_1[59].ReadPointers(binaryReader, blamPointers);
            invalidName_1[60].ReadPointers(binaryReader, blamPointers);
            invalidName_1[61].ReadPointers(binaryReader, blamPointers);
            invalidName_1[62].ReadPointers(binaryReader, blamPointers);
            invalidName_1[63].ReadPointers(binaryReader, blamPointers);
            invalidName_1[64].ReadPointers(binaryReader, blamPointers);
            invalidName_1[65].ReadPointers(binaryReader, blamPointers);
            invalidName_1[66].ReadPointers(binaryReader, blamPointers);
            invalidName_1[67].ReadPointers(binaryReader, blamPointers);
            invalidName_1[68].ReadPointers(binaryReader, blamPointers);
            invalidName_1[69].ReadPointers(binaryReader, blamPointers);
            invalidName_1[70].ReadPointers(binaryReader, blamPointers);
            invalidName_1[71].ReadPointers(binaryReader, blamPointers);
            invalidName_1[72].ReadPointers(binaryReader, blamPointers);
            invalidName_1[73].ReadPointers(binaryReader, blamPointers);
            invalidName_1[74].ReadPointers(binaryReader, blamPointers);
            invalidName_1[75].ReadPointers(binaryReader, blamPointers);
            invalidName_1[76].ReadPointers(binaryReader, blamPointers);
            invalidName_1[77].ReadPointers(binaryReader, blamPointers);
            invalidName_1[78].ReadPointers(binaryReader, blamPointers);
            invalidName_1[79].ReadPointers(binaryReader, blamPointers);
            invalidName_1[80].ReadPointers(binaryReader, blamPointers);
            invalidName_1[81].ReadPointers(binaryReader, blamPointers);
            invalidName_1[82].ReadPointers(binaryReader, blamPointers);
            invalidName_1[83].ReadPointers(binaryReader, blamPointers);
            invalidName_1[84].ReadPointers(binaryReader, blamPointers);
            invalidName_1[85].ReadPointers(binaryReader, blamPointers);
            invalidName_1[86].ReadPointers(binaryReader, blamPointers);
            invalidName_1[87].ReadPointers(binaryReader, blamPointers);
            invalidName_1[88].ReadPointers(binaryReader, blamPointers);
            invalidName_1[89].ReadPointers(binaryReader, blamPointers);
            invalidName_1[90].ReadPointers(binaryReader, blamPointers);
            invalidName_1[91].ReadPointers(binaryReader, blamPointers);
            invalidName_1[92].ReadPointers(binaryReader, blamPointers);
            invalidName_1[93].ReadPointers(binaryReader, blamPointers);
            invalidName_1[94].ReadPointers(binaryReader, blamPointers);
            invalidName_1[95].ReadPointers(binaryReader, blamPointers);
            invalidName_1[96].ReadPointers(binaryReader, blamPointers);
            invalidName_1[97].ReadPointers(binaryReader, blamPointers);
            invalidName_1[98].ReadPointers(binaryReader, blamPointers);
            invalidName_1[99].ReadPointers(binaryReader, blamPointers);
            invalidName_1[100].ReadPointers(binaryReader, blamPointers);
            invalidName_1[101].ReadPointers(binaryReader, blamPointers);
            invalidName_1[102].ReadPointers(binaryReader, blamPointers);
            invalidName_1[103].ReadPointers(binaryReader, blamPointers);
            invalidName_1[104].ReadPointers(binaryReader, blamPointers);
            invalidName_1[105].ReadPointers(binaryReader, blamPointers);
            invalidName_1[106].ReadPointers(binaryReader, blamPointers);
            invalidName_1[107].ReadPointers(binaryReader, blamPointers);
            invalidName_1[108].ReadPointers(binaryReader, blamPointers);
            invalidName_1[109].ReadPointers(binaryReader, blamPointers);
            invalidName_1[110].ReadPointers(binaryReader, blamPointers);
            invalidName_1[111].ReadPointers(binaryReader, blamPointers);
            invalidName_1[112].ReadPointers(binaryReader, blamPointers);
            invalidName_1[113].ReadPointers(binaryReader, blamPointers);
            invalidName_1[114].ReadPointers(binaryReader, blamPointers);
            invalidName_1[115].ReadPointers(binaryReader, blamPointers);
            invalidName_1[116].ReadPointers(binaryReader, blamPointers);
            invalidName_1[117].ReadPointers(binaryReader, blamPointers);
            invalidName_1[118].ReadPointers(binaryReader, blamPointers);
            invalidName_1[119].ReadPointers(binaryReader, blamPointers);
            invalidName_1[120].ReadPointers(binaryReader, blamPointers);
            invalidName_1[121].ReadPointers(binaryReader, blamPointers);
            invalidName_1[122].ReadPointers(binaryReader, blamPointers);
            invalidName_1[123].ReadPointers(binaryReader, blamPointers);
            invalidName_1[124].ReadPointers(binaryReader, blamPointers);
            invalidName_1[125].ReadPointers(binaryReader, blamPointers);
            invalidName_1[126].ReadPointers(binaryReader, blamPointers);
            invalidName_1[127].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(path);
                binaryWriter.Write(modificationDate);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(invalidName_0, 0, 88);
                binaryWriter.Write(checksumCrc32);
                binaryWriter.Write(sizeBytes);
                nextAddress = Guerilla.WriteData(binaryWriter, zippedData, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 128);
                return nextAddress;
            }
        }
    };
}
