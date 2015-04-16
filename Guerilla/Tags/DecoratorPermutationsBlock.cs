// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorPermutationsBlock : DecoratorPermutationsBlockBase
    {
        public  DecoratorPermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class DecoratorPermutationsBlockBase  : IGuerilla
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
        internal Moonfish.Tags.RGBColor tint2;
        internal float baseMapTintPercentage;
        internal float lightmapTintPercentage;
        internal float windScale;
        internal  DecoratorPermutationsBlockBase(BinaryReader binaryReader)
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
            tint2 = binaryReader.ReadRGBColor();
            baseMapTintPercentage = binaryReader.ReadSingle();
            lightmapTintPercentage = binaryReader.ReadSingle();
            windScale = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                binaryWriter.Write(tint2);
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
