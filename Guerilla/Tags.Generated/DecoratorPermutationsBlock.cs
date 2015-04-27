// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorPermutationsBlock : DecoratorPermutationsBlockBase
    {
        public  DecoratorPermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DecoratorPermutationsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class DecoratorPermutationsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ByteBlockIndex1 shader;
        internal byte[] invalidName_;
        internal Flags flags;
        internal FadeDistance fadeDistance;
        internal byte index;
        internal byte distributionWeight;
        internal Moonfish.Model.Range scale;
        internal Moonfish.Tags.RGBColor tint1;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.RGBColor tint2;
        internal byte[] invalidName_1;
        internal float baseMapTintPercentage;
        internal float lightmapTintPercentage;
        internal float windScale;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DecoratorPermutationsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            shader = binaryReader.ReadByteBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(3);
            flags = (Flags)binaryReader.ReadByte();
            fadeDistance = (FadeDistance)binaryReader.ReadByte();
            index = binaryReader.ReadByte();
            distributionWeight = binaryReader.ReadByte();
            scale = binaryReader.ReadRange();
            tint1 = binaryReader.ReadRGBColor();
            invalidName_0 = binaryReader.ReadBytes(1);
            tint2 = binaryReader.ReadRGBColor();
            invalidName_1 = binaryReader.ReadBytes(1);
            baseMapTintPercentage = binaryReader.ReadSingle();
            lightmapTintPercentage = binaryReader.ReadSingle();
            windScale = binaryReader.ReadSingle();
        }
        public  DecoratorPermutationsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            shader = binaryReader.ReadByteBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(3);
            flags = (Flags)binaryReader.ReadByte();
            fadeDistance = (FadeDistance)binaryReader.ReadByte();
            index = binaryReader.ReadByte();
            distributionWeight = binaryReader.ReadByte();
            scale = binaryReader.ReadRange();
            tint1 = binaryReader.ReadRGBColor();
            invalidName_0 = binaryReader.ReadBytes(1);
            tint2 = binaryReader.ReadRGBColor();
            invalidName_1 = binaryReader.ReadBytes(1);
            baseMapTintPercentage = binaryReader.ReadSingle();
            lightmapTintPercentage = binaryReader.ReadSingle();
            windScale = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(shader);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write((Byte)fadeDistance);
                binaryWriter.Write(index);
                binaryWriter.Write(distributionWeight);
                binaryWriter.Write(scale);
                binaryWriter.Write(tint1);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(tint2);
                binaryWriter.Write(invalidName_1, 0, 1);
                binaryWriter.Write(baseMapTintPercentage);
                binaryWriter.Write(lightmapTintPercentage);
                binaryWriter.Write(windScale);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        {
            AlignToNormal = 1,
            OnlyOnGround = 2,
            Upright = 4,
        };
        internal enum FadeDistance : byte
        {
            Close = 0,
            Medium = 1,
            Far = 2,
        };
    };
}
