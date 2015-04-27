// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BitmapGroupSequenceBlock : BitmapGroupSequenceBlockBase
    {
        public  BitmapGroupSequenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  BitmapGroupSequenceBlock(): base()
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
        
        public override int SerializedSize{get { return 60; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  BitmapGroupSequenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            firstBitmapIndex = binaryReader.ReadInt16();
            bitmapCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(16);
            sprites = Guerilla.ReadBlockArray<BitmapGroupSpriteBlock>(binaryReader);
        }
        public  BitmapGroupSequenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            firstBitmapIndex = binaryReader.ReadInt16();
            bitmapCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(16);
            sprites = Guerilla.ReadBlockArray<BitmapGroupSpriteBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
