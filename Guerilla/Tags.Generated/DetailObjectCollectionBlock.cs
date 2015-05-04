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
        public static readonly TagClass Dobc = (TagClass) "dobc";
    };
} ;

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
        [TagReference("bitm")] internal Moonfish.Tags.TagReference spritePlate;
        internal DetailObjectTypeBlock[] types;
        internal byte[] invalidName_1;

        public override int SerializedSize
        {
            get { return 116; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DetailObjectCollectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            collectionType = (CollectionType) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround =
                binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(44);
            spritePlate = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<DetailObjectTypeBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(48);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            types = ReadBlockArrayData<DetailObjectTypeBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) collectionType);
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