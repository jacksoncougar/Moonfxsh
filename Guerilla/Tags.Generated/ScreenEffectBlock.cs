// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Egor = (TagClass)"egor";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("egor")]
    public partial class ScreenEffectBlock : ScreenEffectBlockBase
    {
        public ScreenEffectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class ScreenEffectBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal byte[] invalidName_0;
        internal RasterizerScreenEffectPassReferenceBlock[] passReferences;
        public override int SerializedSize { get { return 144; } }
        public override int Alignment { get { return 4; } }
        public ScreenEffectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(64);
            shader = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(64);
            blamPointers.Enqueue(ReadBlockArrayPointer<RasterizerScreenEffectPassReferenceBlock>(binaryReader));
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
            invalidName_[40].ReadPointers(binaryReader, blamPointers);
            invalidName_[41].ReadPointers(binaryReader, blamPointers);
            invalidName_[42].ReadPointers(binaryReader, blamPointers);
            invalidName_[43].ReadPointers(binaryReader, blamPointers);
            invalidName_[44].ReadPointers(binaryReader, blamPointers);
            invalidName_[45].ReadPointers(binaryReader, blamPointers);
            invalidName_[46].ReadPointers(binaryReader, blamPointers);
            invalidName_[47].ReadPointers(binaryReader, blamPointers);
            invalidName_[48].ReadPointers(binaryReader, blamPointers);
            invalidName_[49].ReadPointers(binaryReader, blamPointers);
            invalidName_[50].ReadPointers(binaryReader, blamPointers);
            invalidName_[51].ReadPointers(binaryReader, blamPointers);
            invalidName_[52].ReadPointers(binaryReader, blamPointers);
            invalidName_[53].ReadPointers(binaryReader, blamPointers);
            invalidName_[54].ReadPointers(binaryReader, blamPointers);
            invalidName_[55].ReadPointers(binaryReader, blamPointers);
            invalidName_[56].ReadPointers(binaryReader, blamPointers);
            invalidName_[57].ReadPointers(binaryReader, blamPointers);
            invalidName_[58].ReadPointers(binaryReader, blamPointers);
            invalidName_[59].ReadPointers(binaryReader, blamPointers);
            invalidName_[60].ReadPointers(binaryReader, blamPointers);
            invalidName_[61].ReadPointers(binaryReader, blamPointers);
            invalidName_[62].ReadPointers(binaryReader, blamPointers);
            invalidName_[63].ReadPointers(binaryReader, blamPointers);
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
            passReferences = ReadBlockArrayData<RasterizerScreenEffectPassReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 64);
                binaryWriter.Write(shader);
                binaryWriter.Write(invalidName_0, 0, 64);
                nextAddress = Guerilla.WriteBlockArray<RasterizerScreenEffectPassReferenceBlock>(binaryWriter, passReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}
