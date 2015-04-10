// ReSharper disable All
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
        public  BitmapGroupSequenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  BitmapGroupSequenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            firstBitmapIndex = binaryReader.ReadInt16();
            bitmapCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(16);
            ReadBitmapGroupSpriteBlockArray(binaryReader);
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
        internal  virtual BitmapGroupSpriteBlock[] ReadBitmapGroupSpriteBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBitmapGroupSpriteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(firstBitmapIndex);
                binaryWriter.Write(bitmapCount);
                binaryWriter.Write(invalidName_, 0, 16);
                WriteBitmapGroupSpriteBlockArray(binaryWriter);
            }
        }
    };
}
