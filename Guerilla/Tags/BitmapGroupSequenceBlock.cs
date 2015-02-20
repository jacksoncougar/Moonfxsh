using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BitmapGroupSequenceBlock : BitmapGroupSequenceBlockBase
    {
        public  BitmapGroupSequenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class BitmapGroupSequenceBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal short firstBitmapIndex;
        internal short bitmapCount;
        internal byte[] invalidName_;
        internal BitmapGroupSpriteBlock[] sprites;
        internal  BitmapGroupSequenceBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.firstBitmapIndex = binaryReader.ReadInt16();
            this.bitmapCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.sprites = ReadBitmapGroupSpriteBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual BitmapGroupSpriteBlock[] ReadBitmapGroupSpriteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapGroupSpriteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapGroupSpriteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapGroupSpriteBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
