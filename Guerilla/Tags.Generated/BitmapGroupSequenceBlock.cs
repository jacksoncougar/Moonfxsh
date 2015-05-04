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
    public partial class BitmapGroupSequenceBlock : BitmapGroupSequenceBlockBase
    {
        public BitmapGroupSequenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class BitmapGroupSequenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal short firstBitmapIndex;
        internal short bitmapCount;
        internal byte[] invalidName_;
        internal BitmapGroupSpriteBlock[] sprites;
        public override int SerializedSize { get { return 60; } }
        public override int Alignment { get { return 4; } }
        public BitmapGroupSequenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            firstBitmapIndex = binaryReader.ReadInt16();
            bitmapCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(16);
            blamPointers.Enqueue(ReadBlockArrayPointer<BitmapGroupSpriteBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sprites = ReadBlockArrayData<BitmapGroupSpriteBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(firstBitmapIndex);
                binaryWriter.Write(bitmapCount);
                binaryWriter.Write(invalidName_, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<BitmapGroupSpriteBlock>(binaryWriter, sprites, nextAddress);
                return nextAddress;
            }
        }
    };
}
