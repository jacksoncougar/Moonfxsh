// ReSharper disable All
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
        public  DetailObjectCollectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DetailObjectCollectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            collectionType = (CollectionType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(44);
            spritePlate = binaryReader.ReadTagReference();
            ReadDetailObjectTypeBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(48);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual DetailObjectTypeBlock[] ReadDetailObjectTypeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DetailObjectTypeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DetailObjectTypeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DetailObjectTypeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDetailObjectTypeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)collectionType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(globalZOffsetAppliedToAllDetailObjectsInThisCollectionSoTheyDontFloatAboveTheGround);
                binaryWriter.Write(invalidName_0, 0, 44);
                binaryWriter.Write(spritePlate);
                WriteDetailObjectTypeBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 48);
            }
        }
        internal enum CollectionType : short
        
        {
            ScreenFacing = 0,
            ViewerFacing = 1,
        };
    };
}
