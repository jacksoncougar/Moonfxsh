using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dobc")]
    public  partial class DetailObjectCollectionBlock : DetailObjectCollectionBlockBase
    {
        public  DetailObjectCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class DetailObjectCollectionBlockBase
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
            this.collectionType = (CollectionType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(44);
            this.spritePlate = binaryReader.ReadTagReference();
            this.types = ReadDetailObjectTypeBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(48);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual DetailObjectTypeBlock[] ReadDetailObjectTypeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DetailObjectTypeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DetailObjectTypeBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DetailObjectTypeBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum CollectionType : short
        
        {
            ScreenFacing = 0,
            ViewerFacing = 1,
        };
    };
}
