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
        public static readonly TagClass Dobc = (TagClass)"dobc";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dobc")]
    public partial class DetailObjectCollectionBlock : DetailObjectCollectionBlockBase
    {
        public DetailObjectCollectionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class DetailObjectCollectionBlockBase : GuerillaBlock
    {
        internal CollectionType collectionType;
        internal byte[] invalidName_;
        internal float globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround;
        internal byte[] invalidName_0;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference spritePlate;
        internal DetailObjectTypeBlock[] types;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 116; } }
        public override int Alignment { get { return 4; } }
        public DetailObjectCollectionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            collectionType = (CollectionType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(44);
            spritePlate = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<DetailObjectTypeBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(48);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
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
            types = ReadBlockArrayData<DetailObjectTypeBlock>(binaryReader, blamPointers.Dequeue());
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
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)collectionType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround);
                binaryWriter.Write(invalidName_0, 0, 44);
                binaryWriter.Write(spritePlate);
                nextAddress = Guerilla.WriteBlockArray<DetailObjectTypeBlock>(binaryWriter, types, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 48);
                return nextAddress;
            }
        }
        internal enum CollectionType : short
        {
            ScreenFacing = 0,
            ViewerFacing = 1,
        };
    };
}
