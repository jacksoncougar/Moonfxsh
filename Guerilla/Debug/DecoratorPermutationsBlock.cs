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
        public  DecoratorPermutationsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 38)]
    public class DecoratorPermutationsBlockBase
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
        internal  DecoratorPermutationsBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
