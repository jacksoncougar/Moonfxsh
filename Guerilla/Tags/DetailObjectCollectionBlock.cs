// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass DobcClass = (TagClass)"dobc";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dobc")]
    public  partial class DetailObjectCollectionBlock : DetailObjectCollectionBlockBase
    {
        public  DetailObjectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class DetailObjectCollectionBlockBase  : IGuerilla
    {
        internal CollectionType collectionType;
        internal byte[] invalidName_;
        internal float globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround;
        internal byte[] invalidName_0;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference spritePlate;
        internal DetailObjectTypeBlock[] types;
        internal byte[] invalidName_1;
        internal  DetailObjectCollectionBlockBase(BinaryReader binaryReader)
        {
            collectionType = (CollectionType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(44);
            spritePlate = binaryReader.ReadTagReference();
            types = Guerilla.ReadBlockArray<DetailObjectTypeBlock>(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(48);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)collectionType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround);
                binaryWriter.Write(invalidName_0, 0, 44);
                binaryWriter.Write(spritePlate);
                nextAddress = Guerilla.WriteBlockArray<DetailObjectTypeBlock>(binaryWriter, types, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 48);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum CollectionType : short
        {
            ScreenFacing = 0,
            ViewerFacing = 1,
        };
    };
}
