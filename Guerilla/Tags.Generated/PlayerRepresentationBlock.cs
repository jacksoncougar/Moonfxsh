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
    public partial class PlayerRepresentationBlock : PlayerRepresentationBlockBase
    {
        public PlayerRepresentationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 188, Alignment = 4)]
    public class PlayerRepresentationBlockBase : GuerillaBlock
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonHands;
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonBody;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference thirdPersonUnit;
        internal Moonfish.Tags.StringIdent thirdPersonVariant;
        public override int SerializedSize { get { return 188; } }
        public override int Alignment { get { return 4; } }
        public PlayerRepresentationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            firstPersonHands = binaryReader.ReadTagReference();
            firstPersonBody = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(40);
            invalidName_0 = binaryReader.ReadBytes(120);
            thirdPersonUnit = binaryReader.ReadTagReference();
            thirdPersonVariant = binaryReader.ReadStringID();
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
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_[24].ReadPointers(binaryReader, blamPointers);
            invalidName_[25].ReadPointers(binaryReader, blamPointers);
            invalidName_[26].ReadPointers(binaryReader, blamPointers);
            invalidName_[27].ReadPointers(binaryReader, blamPointers);
            invalidName_[28].ReadPointers(binaryReader, blamPointers);
            invalidName_[29].ReadPointers(binaryReader, blamPointers);
            invalidName_[30].ReadPointers(binaryReader, blamPointers);
            invalidName_[31].ReadPointers(binaryReader, blamPointers);
            invalidName_[32].ReadPointers(binaryReader, blamPointers);
            invalidName_[33].ReadPointers(binaryReader, blamPointers);
            invalidName_[34].ReadPointers(binaryReader, blamPointers);
            invalidName_[35].ReadPointers(binaryReader, blamPointers);
            invalidName_[36].ReadPointers(binaryReader, blamPointers);
            invalidName_[37].ReadPointers(binaryReader, blamPointers);
            invalidName_[38].ReadPointers(binaryReader, blamPointers);
            invalidName_[39].ReadPointers(binaryReader, blamPointers);
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
            invalidName_0[88].ReadPointers(binaryReader, blamPointers);
            invalidName_0[89].ReadPointers(binaryReader, blamPointers);
            invalidName_0[90].ReadPointers(binaryReader, blamPointers);
            invalidName_0[91].ReadPointers(binaryReader, blamPointers);
            invalidName_0[92].ReadPointers(binaryReader, blamPointers);
            invalidName_0[93].ReadPointers(binaryReader, blamPointers);
            invalidName_0[94].ReadPointers(binaryReader, blamPointers);
            invalidName_0[95].ReadPointers(binaryReader, blamPointers);
            invalidName_0[96].ReadPointers(binaryReader, blamPointers);
            invalidName_0[97].ReadPointers(binaryReader, blamPointers);
            invalidName_0[98].ReadPointers(binaryReader, blamPointers);
            invalidName_0[99].ReadPointers(binaryReader, blamPointers);
            invalidName_0[100].ReadPointers(binaryReader, blamPointers);
            invalidName_0[101].ReadPointers(binaryReader, blamPointers);
            invalidName_0[102].ReadPointers(binaryReader, blamPointers);
            invalidName_0[103].ReadPointers(binaryReader, blamPointers);
            invalidName_0[104].ReadPointers(binaryReader, blamPointers);
            invalidName_0[105].ReadPointers(binaryReader, blamPointers);
            invalidName_0[106].ReadPointers(binaryReader, blamPointers);
            invalidName_0[107].ReadPointers(binaryReader, blamPointers);
            invalidName_0[108].ReadPointers(binaryReader, blamPointers);
            invalidName_0[109].ReadPointers(binaryReader, blamPointers);
            invalidName_0[110].ReadPointers(binaryReader, blamPointers);
            invalidName_0[111].ReadPointers(binaryReader, blamPointers);
            invalidName_0[112].ReadPointers(binaryReader, blamPointers);
            invalidName_0[113].ReadPointers(binaryReader, blamPointers);
            invalidName_0[114].ReadPointers(binaryReader, blamPointers);
            invalidName_0[115].ReadPointers(binaryReader, blamPointers);
            invalidName_0[116].ReadPointers(binaryReader, blamPointers);
            invalidName_0[117].ReadPointers(binaryReader, blamPointers);
            invalidName_0[118].ReadPointers(binaryReader, blamPointers);
            invalidName_0[119].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(firstPersonHands);
                binaryWriter.Write(firstPersonBody);
                binaryWriter.Write(invalidName_, 0, 40);
                binaryWriter.Write(invalidName_0, 0, 120);
                binaryWriter.Write(thirdPersonUnit);
                binaryWriter.Write(thirdPersonVariant);
                return nextAddress;
            }
        }
    };
}
